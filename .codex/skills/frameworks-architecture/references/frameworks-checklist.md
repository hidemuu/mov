# Frameworks Architecture Checklist

Use this checklist when reorganizing `mov/frameworks`.

## Scope

- Affected projects and namespaces are listed.
- The desired DLL boundary is explicit.
- Current `suites` consumers are identified.
- Project references are mapped before moving files.
- The change avoids app-specific behavior in `frameworks`.

## Layering

- Common primitives stay in `frameworks/cores/core` or a more specific core package.
- Reusable model packages do not depend on app hosts.
- Repository projects contain persistence/data access concerns.
- Service projects contain reusable application/domain behavior.
- Controller projects orchestrate use cases and API-facing control flow.
- Runnable hosts remain under `frameworks/app` or `suites/app`, not in core libraries.

## Compatibility

- Public types and namespaces are preserved unless a rename is intentional.
- Breaking changes are called out in the final response.
- `netstandard2.0` libraries remain portable unless a higher target is deliberately required.
- Project references are updated in both `frameworks/mov.sln` and affected `.csproj` files.
- `suites` examples continue to build against the reorganized DLLs.

## Verification

- Run the narrowest affected `dotnet build` first.
- Run related NUnit test projects when shared behavior changes.
- Build `frameworks/mov.sln` after structural changes.
- Build `suites/mov_suite.sln` when project references or public contracts used by suites change.
- Report any build/test command that could not be run.

## Documentation

- Update `AGENTS.md` when the intended structure or recurring workflow changes.
- Update `README.md` or `mkdocs/docs` when public architecture or setup changes.
- Avoid copying mojibake from existing docs into new text.
