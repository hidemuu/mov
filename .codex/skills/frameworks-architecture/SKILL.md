---
name: frameworks-architecture
description: Reorganize mov/frameworks as shared DLL foundations for many applications. Use when Codex is asked to restructure frameworks projects, move common code, clarify DLL boundaries, adjust project references, separate reusable foundation code from suites examples, or plan architecture cleanup in mov/frameworks.
---

# Frameworks Architecture

## Overview

Use this skill to keep `mov/frameworks` organized as the common DLL foundation while keeping `mov/suites` as examples and app implementations that consume those DLLs.

## Workflow

1. Read project context first.
   - Read root `AGENTS.md`.
   - Check `git status --short` before editing.
   - Treat unrelated dirty files as user work; do not revert them.

2. Map the current dependency shape.
   - Identify affected `.csproj` files and project references.
   - Read nearby namespaces, public types, and tests before moving code.
   - Check whether `suites` projects consume the target DLLs.

3. Choose the intended DLL boundary.
   - Keep reusable foundation code in `frameworks`.
   - Keep app hosts, operational examples, concrete UI choices, deployment details, and sample workflows in `suites`.
   - Promote code from `suites` into `frameworks` only when the reusable contract is clear.
   - Avoid adding dependencies from `frameworks` back into `suites`.

4. Preserve the existing layer vocabulary.
   - `models`: domain/data models.
   - `repository`: persistence and data access.
   - `service`: reusable application/domain services.
   - `controller`: orchestration and API-facing control logic.
   - `app`: runnable hosts and entry points.
   - `cores`: cross-domain primitives grouped by controller/core/io/model/service/ui.

5. Implement structural changes carefully.
   - Move files with namespace and project-reference updates together.
   - Keep public APIs stable where possible.
   - Rename projects or namespaces only when the benefit is clear and all consumers are updated.
   - Update solution membership when projects are added, removed, or renamed.
   - Keep most library projects portable as `netstandard2.0` unless a higher target is required.

6. Verify the reusable foundation and examples.
   - Build or test the nearest affected project first.
   - Run related NUnit test projects for shared logic changes.
   - Build `frameworks/mov.sln` after framework-level restructuring.
   - Build `suites/mov_suite.sln` when suite consumers or public DLL contracts are affected.

7. Update documentation and report.
   - Update `AGENTS.md`, `README.md`, or `mkdocs/docs` when architecture guidance changes.
   - State the new boundary, changed projects, verification results, and any breaking changes.

## Mov Defaults

- `frameworks` is the common foundation for multiple apps.
- `suites` is the operational example/application layer that uses `frameworks` DLLs.
- Existing domain names include `analizer`, `bom`, `calendar`, `designer`, `drawer`, `driver`, `game`, `imaging`, and `mobility`.
- Shared libraries usually target `netstandard2.0`; app/test hosts usually target `.NET 7` or `.NET 8`.
- Tests use NUnit.

## Reference

Read `references/frameworks-checklist.md` before broad moves, project renames, DLL boundary changes, or any change that affects both `frameworks` and `suites`.
