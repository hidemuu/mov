$ErrorActionPreference = "Stop"

if (-not $env:MOV_REPO_ROOT) {
    $env:MOV_REPO_ROOT = Resolve-Path (Join-Path $PSScriptRoot "..\..")
}

if (-not $env:MOV_MCP_QA_PORT) {
    $env:MOV_MCP_QA_PORT = "8787"
}

$env:MOV_MCP_QA_QUIET = "1"

$node = $env:NODE_EXE
if (-not $node) {
    $nodeCommand = Get-Command node -ErrorAction SilentlyContinue
    if ($nodeCommand) {
        $node = $nodeCommand.Source
    }
}

if (-not $node) {
    throw "Node.js was not found. Install Node.js, add it to PATH, or set NODE_EXE to the node executable path."
} else {
    $node = Resolve-Path $node
}

$server = Join-Path $PSScriptRoot "qa-server.js"

& $node $server
