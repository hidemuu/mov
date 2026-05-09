#!/usr/bin/env node
import fs from "node:fs";
import http from "node:http";
import path from "node:path";
import process from "node:process";
import { fileURLToPath } from "node:url";

const serverRoot = path.dirname(fileURLToPath(import.meta.url));
const repoRoot = findRepoRoot();
const port = Number(process.env.PORT || process.env.MOV_MCP_QA_PORT || 8787);

process.stdout.on("error", () => {});
process.stderr.on("error", () => {});

const docs = [
  {
    title: "Mov Frameworks Architecture",
    uri: "mov://frameworks/architecture",
    file: path.join(repoRoot, "mkdocs", "docs", "framework", "frameworks_architecture.md")
  },
  {
    title: "Mov Frameworks Project Inventory",
    uri: "mov://frameworks/project-inventory",
    file: path.join(repoRoot, "mkdocs", "docs", "framework", "frameworks_project_inventory.md")
  },
  {
    title: "Mov Agent Guidance",
    uri: "mov://frameworks/agents",
    file: path.join(repoRoot, "AGENTS.md")
  }
];

const server = http.createServer((request, response) => {
  const url = new URL(request.url || "/", `http://${request.headers.host || "localhost"}`);

  if (url.pathname === "/" || url.pathname === "/qa") {
    const question = url.searchParams.get("q") || "";
    if (!question) {
      return html(response, renderHome());
    }

    return json(response, answer(question));
  }

  if (url.pathname === "/resources") {
    return json(response, {
      resources: docs.map(({ title, uri, file }) => ({ title, uri, file }))
    });
  }

  if (url.pathname === "/health") {
    return json(response, { ok: true, repoRoot, port });
  }

  response.writeHead(404, { "content-type": "application/json; charset=utf-8" });
  response.end(JSON.stringify({ error: "not found" }));
});

server.listen(port, "127.0.0.1", () => {
  if (!process.env.MOV_MCP_QA_QUIET) {
    console.log(`mov-frameworks QA server listening on http://127.0.0.1:${port}`);
  }
});

function findRepoRoot() {
  const candidates = [
    process.env.MOV_REPO_ROOT,
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

function answer(question) {
  const terms = tokenize(question);
  const matches = [];

  for (const doc of docs) {
    const text = fs.readFileSync(doc.file, "utf8");
    const sections = splitSections(text);
    for (const section of sections) {
      const score = scoreSection(section.text, terms);
      if (score > 0) {
        matches.push({
          title: doc.title,
          uri: doc.uri,
          heading: section.heading,
          score,
          text: compact(section.text)
        });
      }
    }
  }

  matches.sort((a, b) => b.score - a.score);
  const top = matches.slice(0, 5);

  return {
    question,
    answer: top.length
      ? summarize(question, top)
      : "関連する記述が見つかりませんでした。`/resources` で参照できるMCP resourceを確認してください。",
    sources: top.map(({ title, uri, heading, score }) => ({ title, uri, heading, score }))
  };
}

function splitSections(text) {
  const lines = text.split(/\r?\n/);
  const sections = [];
  let heading = "Overview";
  let body = [];

  for (const line of lines) {
    if (/^#{1,3}\s+/.test(line) && body.length) {
      sections.push({ heading, text: body.join("\n") });
      heading = line.replace(/^#{1,3}\s+/, "").trim();
      body = [line];
    } else {
      if (/^#{1,3}\s+/.test(line)) {
        heading = line.replace(/^#{1,3}\s+/, "").trim();
      }
      body.push(line);
    }
  }

  if (body.length) {
    sections.push({ heading, text: body.join("\n") });
  }

  return sections;
}

function tokenize(text) {
  return Array.from(
    new Set(
      text
        .toLowerCase()
        .split(/[^a-z0-9_.:/\\-]+/i)
        .map((term) => term.trim())
        .filter((term) => term.length >= 2)
    )
  );
}

function scoreSection(text, terms) {
  const haystack = text.toLowerCase();
  return terms.reduce((score, term) => {
    const escaped = term.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
    const count = (haystack.match(new RegExp(escaped, "g")) || []).length;
    return score + count;
  }, 0);
}

function summarize(question, matches) {
  const snippets = matches
    .map((match) => `- ${match.heading}: ${match.text}`)
    .join("\n");

  return [
    `質問: ${question}`,
    "",
    "参照文書から関連度の高い箇所を抽出しました。",
    snippets
  ].join("\n");
}

function compact(text) {
  return text
    .replace(/```[\s\S]*?```/g, "[code block omitted]")
    .replace(/\s+/g, " ")
    .trim()
    .slice(0, 800);
}

function renderHome() {
  return `<!doctype html>
<html lang="ja">
<head>
  <meta charset="utf-8">
  <title>Mov Frameworks MCP QA</title>
  <style>
    body { font-family: system-ui, sans-serif; max-width: 900px; margin: 40px auto; padding: 0 20px; line-height: 1.6; }
    input { width: 75%; padding: 10px; font-size: 16px; }
    button { padding: 10px 14px; font-size: 16px; }
    code { background: #f2f2f2; padding: 2px 4px; }
  </style>
</head>
<body>
  <h1>Mov Frameworks MCP QA</h1>
  <form action="/qa" method="get">
    <input name="q" placeholder="例: frameworksとsuitesの責務分担は？">
    <button type="submit">Ask</button>
  </form>
  <p>JSON API: <code>/qa?q=frameworksとsuitesの責務分担は？</code></p>
  <p>Resources: <code>/resources</code></p>
</body>
</html>`;
}

function json(response, payload) {
  response.writeHead(200, { "content-type": "application/json; charset=utf-8" });
  response.end(JSON.stringify(payload, null, 2));
}

function html(response, body) {
  response.writeHead(200, { "content-type": "text/html; charset=utf-8" });
  response.end(body);
}
