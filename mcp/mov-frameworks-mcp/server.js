#!/usr/bin/env node
import fs from "node:fs";
import path from "node:path";
import process from "node:process";
import { fileURLToPath } from "node:url";

const serverRoot = path.dirname(fileURLToPath(import.meta.url));
const repoRoot = findRepoRoot();

const resources = [
  {
    uri: "mov://frameworks/architecture",
    name: "Mov Frameworks Architecture",
    description: "Architecture intent, layer boundaries, dependency direction, and design workflow for mov/frameworks.",
    mimeType: "text/markdown",
    file: path.join(repoRoot, "mkdocs", "docs", "framework", "frameworks_architecture.md")
  },
  {
    uri: "mov://frameworks/project-inventory",
    name: "Mov Frameworks Project Inventory",
    description: "Project inventory for mov/frameworks, including core, domain, aggregate, app, and test projects.",
    mimeType: "text/markdown",
    file: path.join(repoRoot, "mkdocs", "docs", "framework", "frameworks_project_inventory.md")
  },
  {
    uri: "mov://frameworks/agents",
    name: "Mov Agent Guidance",
    description: "Repository-level guidance that defines frameworks as shared DLL foundations and suites as usage examples.",
    mimeType: "text/markdown",
    file: path.join(repoRoot, "AGENTS.md")
  },
  {
    uri: "mov://frameworks/mcp-qa-logic",
    name: "Mov Frameworks MCP QA Logic",
    description: "Explains the local QA bridge logic and confirms that it uses deterministic document search rather than an AI agent.",
    mimeType: "text/markdown",
    file: path.join(repoRoot, "mkdocs", "docs", "framework", "mcp_qa_logic.md")
  }
];

const tools = [
  {
    name: "get_mov_frameworks_design_context",
    description: "Return concise mov/frameworks context for planning another application that consumes the shared DLL foundation.",
    inputSchema: {
      type: "object",
      properties: {
        app_goal: {
          type: "string",
          description: "Optional application goal or domain to tailor the design guidance."
        }
      },
      additionalProperties: false
    }
  }
];

let inputBuffer = Buffer.alloc(0);

process.stdin.on("data", (chunk) => {
  inputBuffer = Buffer.concat([inputBuffer, chunk]);
  readMessages();
});

function findRepoRoot() {
  const candidates = [
    process.env.MOV_REPO_ROOT,
    path.resolve(serverRoot, "..", "mov"),
    path.resolve(serverRoot, "..", ".."),
    process.cwd()
  ].filter(Boolean);

  for (const candidate of candidates) {
    if (
      fs.existsSync(path.join(candidate, "AGENTS.md")) &&
      fs.existsSync(path.join(candidate, "frameworks"))
    ) {
      return candidate;
    }
  }

  return path.resolve(serverRoot, "..", "..");
}

function readMessages() {
  while (true) {
    const headerEnd = inputBuffer.indexOf("\r\n\r\n");
    if (headerEnd === -1) return;

    const header = inputBuffer.subarray(0, headerEnd).toString("utf8");
    const lengthMatch = /Content-Length:\s*(\d+)/i.exec(header);
    if (!lengthMatch) {
      inputBuffer = inputBuffer.subarray(headerEnd + 4);
      continue;
    }

    const length = Number(lengthMatch[1]);
    const messageStart = headerEnd + 4;
    const messageEnd = messageStart + length;
    if (inputBuffer.length < messageEnd) return;

    const raw = inputBuffer.subarray(messageStart, messageEnd).toString("utf8");
    inputBuffer = inputBuffer.subarray(messageEnd);
    handleMessage(JSON.parse(raw));
  }
}

function handleMessage(message) {
  if (!message.method) return;

  try {
    switch (message.method) {
      case "initialize":
        return sendResult(message.id, {
          protocolVersion: "2024-11-05",
          capabilities: {
            resources: {},
            tools: {}
          },
          serverInfo: {
            name: "mov-frameworks-mcp",
            version: "0.1.0"
          }
        });
      case "notifications/initialized":
        return;
      case "resources/list":
        return sendResult(message.id, {
          resources: resources.map(({ file, ...resource }) => resource)
        });
      case "resources/read":
        return readResource(message);
      case "tools/list":
        return sendResult(message.id, { tools });
      case "tools/call":
        return callTool(message);
      default:
        return sendError(message.id, -32601, `Unsupported method: ${message.method}`);
    }
  } catch (error) {
    return sendError(message.id, -32603, error instanceof Error ? error.message : String(error));
  }
}

function readResource(message) {
  const uri = message.params?.uri;
  const resource = resources.find((item) => item.uri === uri);
  if (!resource) {
    return sendError(message.id, -32002, `Unknown resource: ${uri}`);
  }

  return sendResult(message.id, {
    contents: [
      {
        uri: resource.uri,
        mimeType: resource.mimeType,
        text: fs.readFileSync(resource.file, "utf8")
      }
    ]
  });
}

function callTool(message) {
  if (message.params?.name !== "get_mov_frameworks_design_context") {
    return sendError(message.id, -32602, `Unknown tool: ${message.params?.name}`);
  }

  const appGoal = message.params?.arguments?.app_goal || "unspecified application";
  const architecture = readText("mkdocs/docs/framework/frameworks_architecture.md");
  const inventory = readText("mkdocs/docs/framework/frameworks_project_inventory.md");

  return sendResult(message.id, {
    content: [
      {
        type: "text",
        text: [
          `# Design context for ${appGoal}`,
          "",
          "Use `frameworks` as the shared DLL foundation and `suites` as operational examples.",
          "Prefer the narrowest domain/core DLLs before taking the aggregate `Framework` package.",
          "Keep app UI, host setup, deployment, and sample workflows outside `frameworks`.",
          "",
          "## Architecture",
          architecture,
          "",
          "## Project Inventory",
          inventory
        ].join("\n")
      }
    ]
  });
}

function readText(relativePath) {
  return fs.readFileSync(path.join(repoRoot, relativePath), "utf8");
}

function sendResult(id, result) {
  send({ jsonrpc: "2.0", id, result });
}

function sendError(id, code, message) {
  send({ jsonrpc: "2.0", id, error: { code, message } });
}

function send(payload) {
  const body = JSON.stringify(payload);
  process.stdout.write(`Content-Length: ${Buffer.byteLength(body, "utf8")}\r\n\r\n${body}`);
}
