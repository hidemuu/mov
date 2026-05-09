# Mov Frameworks MCP QA Logic

## Purpose

The local QA bridge in `mcp/mov-frameworks-mcp/qa-server.js` provides quick browser or HTTP access to the same framework documents exposed by the MCP server.

It is intended for lightweight validation and manual inspection. It is not an AI answering system.

## AI Agent Usage

The QA bridge does not call an AI agent, OpenAI API, local LLM, Codex session, or MCP client reasoning loop.

All answers are produced inside `qa-server.js` by deterministic document search:

1. Receive a question from `GET /qa?q=...`.
2. Tokenize the question into simple search terms.
3. Load local Markdown documents from the repository.
4. Split each Markdown document into heading-based sections.
5. Count how often each search term appears in each section.
6. Sort sections by score.
7. Return the top matching snippets with source metadata.

The response is therefore a ranked extraction of relevant documentation sections, not generated reasoning.

## Source Documents

The QA bridge currently searches these files:

- `mkdocs/docs/framework/frameworks_architecture.md`
- `mkdocs/docs/framework/frameworks_project_inventory.md`
- `mkdocs/docs/framework/mcp_qa_logic.md`
- `AGENTS.md`

These correspond to MCP resources exposed by `server.js`.

## Endpoints

| Endpoint | Role |
| --- | --- |
| `GET /` | Browser form for manual QA. |
| `GET /qa?q=...` | Returns ranked matching snippets as JSON. |
| `GET /resources` | Lists the local documents used by the QA bridge. |
| `GET /health` | Returns process health and resolved repository root. |

## Relationship To MCP

`server.js` is the actual stdio MCP server. It exposes:

- resources such as `mov://frameworks/architecture`;
- the `get_mov_frameworks_design_context` tool.

`qa-server.js` is an HTTP helper for local QA only. It reads the same repository documents, but it does not implement the MCP protocol and does not invoke an AI model.

When another application design agent connects through MCP, the intended split is:

1. MCP provides framework architecture documents and design context.
2. The MCP client-side AI agent reads those resources.
3. The AI agent performs interpretation, synthesis, and design planning.

## Scoring Details

The QA bridge uses a simple lexical score:

- question text is lowercased and split into terms;
- duplicate terms are removed;
- terms shorter than two characters are ignored;
- each section score is the sum of term occurrence counts;
- sections with score greater than zero are candidates;
- the top five sections are returned.

This means answers depend on literal term overlap. Synonyms, paraphrases, and semantic meaning are not inferred unless the same words appear in the documents.

## Implications

- Use the QA bridge to confirm whether documentation is discoverable.
- Use an MCP-connected AI agent for actual architecture interpretation and application design.
- If QA results are poor, improve the source Markdown documents or add terms that expected users will search for.
