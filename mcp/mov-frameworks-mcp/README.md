# mov-frameworks-mcp

Local MCP server that exposes `mov/frameworks` architecture context for other application design sessions.

## Resources

- `mov://frameworks/architecture`
- `mov://frameworks/project-inventory`
- `mov://frameworks/agents`

## Tool

- `get_mov_frameworks_design_context`

## Run MCP Server

```powershell
cd <mov-repo>
$env:MOV_REPO_ROOT=(Get-Location).Path
node .\mcp\mov-frameworks-mcp\server.js
```

When this folder is copied elsewhere, set `MOV_REPO_ROOT` to the Mov repository root.

## Local QA Bridge

For browser or curl-based QA against the same MCP resource documents:

```powershell
cd <mov-repo>
.\mcp\mov-frameworks-mcp\start-qa.ps1
```

Open `http://127.0.0.1:8787/` or call:

```powershell
Invoke-RestMethod "http://127.0.0.1:8787/qa?q=frameworks-and-suites"
```

Set `MOV_MCP_QA_PORT` before running `start-qa.ps1` to use another port.
If `node` is not on PATH, set `NODE_EXE` to the Node.js executable path before running the script.

## MCP Client Example

Use the server from this repository:

```json
{
  "mcpServers": {
    "mov-frameworks": {
      "command": "node",
      "args": [
        "<mov-repo>\\mcp\\mov-frameworks-mcp\\server.js"
      ],
      "env": {
        "MOV_REPO_ROOT": "<mov-repo>"
      }
    }
  }
}
```

Once connected, design agents can read `mov://frameworks/architecture` and `mov://frameworks/project-inventory`, or call `get_mov_frameworks_design_context`.
