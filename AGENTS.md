# AGENTS.md

Guidance for coding agents working in this repository.

## Project Overview

This repository contains the Mov .NET workspace. It is split into two main solution areas:

- `frameworks/`: shared DLL foundations for many current and future applications. Treat this as the reusable platform layer.
- `suites/`: operational examples and application suites that consume the DLLs from `frameworks`.

There are two Visual Studio solution files:

- `frameworks/mov.sln`
- `suites/mov_suite.sln`

Most library projects target `netstandard2.0`. App and test projects mostly target `.NET 7`, with several newer Blazor WebAssembly apps targeting `.NET 8`.

## Repository Layout

- `frameworks/app/`: runnable framework-level apps such as API and console app.
- `frameworks/cores/`: reusable core/controller/io/model/service/ui libraries.
- `frameworks/src/`: domain modules such as `analizer`, `bom`, `calendar`, `designer`, `drawer`, `driver`, `game`, `imaging`, and `mobility`.
- `suites/app/`: suite-level runnable apps such as API, Blazor, React, WPF, and console hosts.
- `suites/src/`: suite-specific clients and integrations for each domain.
- `suites/*App/`: standalone app projects.
- `scripts/`: reference scripts and experiments; do not treat these as the primary application unless the task explicitly points there.
- `mkdocs/`: Material for MkDocs documentation.

## Architecture Intent

`frameworks` is the common foundation. Changes here should favor stable DLL boundaries, reusable domain abstractions, and low coupling to any single app. Avoid moving app-specific UI, deployment, local configuration, or operational examples into `frameworks` unless the behavior is truly shared across multiple apps.

`suites` demonstrates how applications use the shared foundation. It may contain app hosts, concrete integrations, UI choices, sample workflows, and client implementations that depend on `frameworks`. When a behavior starts in `suites`, promote it to `frameworks` only after the reusable contract is clear.

When reorganizing `frameworks`, use the repo skill at `.codex/skills/frameworks-architecture`.

## Build And Test

Prefer running commands from the repository root unless a project-specific command requires another working directory.

Useful commands:

```powershell
dotnet restore frameworks\mov.sln
dotnet build frameworks\mov.sln
dotnet test frameworks\mov.sln

dotnet restore suites\mov_suite.sln
dotnet build suites\mov_suite.sln
dotnet test suites\mov_suite.sln
```

For focused work, build or test the closest affected project first:

```powershell
dotnet build path\to\Project.csproj
dotnet test path\to\TestProject.csproj
```

React app commands are under `suites/app/ReactApp/ClientApp`:

```powershell
npm install
npm run start
npm run build
npm run test
npm run lint
npm run storybook
```

Electron app commands are under `suites/app/ElectronApp`:

```powershell
npm install
npm run start
```

MkDocs commands are under `mkdocs`:

```powershell
mkdocs serve
mkdocs build
```

## Testing Conventions

- .NET tests use NUnit.
- Test projects are usually named with `.test`, `.Test`, or `Test` in the project/directory name.
- When changing a shared library in `frameworks/cores`, run the nearest test project and consider whether dependent domain/app projects also need a build.
- When changing a suite client in `suites/src`, run that client's test project when one exists, then build the relevant app or solution.

## Coding Conventions

Follow existing C# style in the edited area. The README documents these naming conventions:

- Namespaces, classes, interfaces, structs, enums, enum values, events, methods, and properties: PascalCase.
- Constants: all uppercase.
- Public fields: camelCase.
- Private fields: leading underscore plus camelCase.
- Parameters and local variables: camelCase.

The codebase is layered. Keep domain logic in the appropriate layer instead of pushing it into app hosts:

- `models`: domain/data models.
- `repository`: persistence and data access.
- `service`: application/domain services.
- `controller`: orchestration/API-facing control logic.
- `app`: host applications and UI/API entry points.

## Frontend Notes

- `suites/app/ReactApp/ClientApp` is a React 18 app using Fluent UI, MUI, Bootstrap, Storybook, Jest, ESLint, and Prettier.
- Prefer existing component and styling patterns in the app being edited.
- For Blazor apps, keep Razor/C# changes scoped to the specific app unless shared behavior clearly belongs in `frameworks` or `suites/src`.

## Documentation

- Update `README.md`, `suites/README.md`, or `mkdocs/docs` when behavior, setup, or public architecture changes.
- The root `README.md` currently contains mojibake in places; avoid copying corrupted text into new documentation. Prefer verified facts from project files.
- `mkdocs/docs/framework/frameworks_architecture.md` documents `frameworks` as the shared DLL foundation.
- `mkdocs/docs/framework/frameworks_project_inventory.md` lists framework projects for MCP-assisted app design.
- A local MCP server for this context lives in `mcp/mov-frameworks-mcp` and is mirrored to sibling folder `../mov-mcp`.

## Generated And External Files

Do not edit generated output unless the task explicitly requires it.

Avoid changing:

- `bin/`
- `obj/`
- `.next/`
- `dist/`
- generated assembly info/global using files
- package lock or generated asset files unless dependency changes require it

## Agent Workflow

- Inspect the closest project files before editing; this repo has several similar app and domain structures.
- For `frameworks` structure work, use `$frameworks-architecture` and preserve the distinction between common DLL foundations and `suites` usage examples.
- Keep changes scoped to the requested feature or fix.
- Preserve existing user changes and unrelated worktree changes.
- Prefer `rg` for search when available. If it is unavailable or blocked, use PowerShell `Get-ChildItem` and `Select-String`.
- Add or update focused tests for behavior changes where a nearby NUnit test project exists.
- Before finalizing, run the narrowest meaningful build/test command that covers the touched code. If a full solution build is too broad or blocked, report the narrower verification that was run.
