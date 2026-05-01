# mov-frameworks-mcp

Local MCP server that exposes `mov/frameworks` architecture context for other application design sessions.

## Resources

- `mov://frameworks/architecture`
- `mov://frameworks/project-inventory`
- `mov://frameworks/agents`

## Tool

- `get_mov_frameworks_design_context`

## Run

```powershell
$env:MOV_REPO_ROOT="C:\Users\nando\workspace\repos\github\mov"
node C:\Users\nando\workspace\repos\github\mov\mcp\mov-frameworks-mcp\server.js
```

When this folder is copied to sibling repo `mov-mcp`, the server also auto-detects `../mov` as the Mov repository root.

## MCP client example

Use the copied sibling server from `C:\Users\nando\workspace\repos\github\mov-mcp`:

```json
{
  "mcpServers": {
    "mov-frameworks": {
      "command": "C:\\Users\\nando\\.cache\\codex-runtimes\\codex-primary-runtime\\dependencies\\node\\bin\\node.exe",
      "args": [
        "C:\\Users\\nando\\workspace\\repos\\github\\mov-mcp\\server.js"
      ],
      "env": {
        "MOV_REPO_ROOT": "C:\\Users\\nando\\workspace\\repos\\github\\mov"
      }
    }
  }
}
```

Once connected, design agents can read `mov://frameworks/architecture` and `mov://frameworks/project-inventory`, or call `get_mov_frameworks_design_context`.
