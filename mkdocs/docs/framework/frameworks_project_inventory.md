# Mov Frameworks Project Inventory

This inventory documents the projects under `mov/frameworks` for MCP-assisted application design.

## Solutions

- `frameworks/mov.sln`: framework foundation solution.

## App Hosts

| Project | Target | Role |
| --- | --- | --- |
| `app/api/Api.csproj` | `net7.0` | ASP.NET Core API host for framework modules. |
| `app/mov/ConsoleApp.csproj` | `net7.0` | Console host for framework usage. |

## Core Foundation Projects

| Project | Target |
| --- | --- |
| `cores/core/Core.csproj` | `netstandard2.0` |
| `cores/controller/authorizers/Authorizers.csproj` | `netstandard2.0` |
| `cores/controller/configurators/Configurators.csproj` | `netstandard2.0` |
| `cores/controller/schedulers/Schedulers.csproj` | `netstandard2.0` |
| `cores/controller/spreadsheets/SpreadSheets.csproj` | `netstandard2.0` |
| `cores/controller/translators/Translators.csproj` | `netstandard2.0` |
| `cores/io/accessors/Accessors.csproj` | `netstandard2.0` |
| `cores/io/errors/Errors.csproj` | `netstandard2.0` |
| `cores/io/loggers/Loggers.csproj` | `netstandard2.0` |
| `cores/io/repositories/Repositories.csproj` | `netstandard2.0` |
| `cores/io/resources/Resources.csproj` | `netstandard2.0` |
| `cores/model/characters/Characters.csproj` | `netstandard2.0` |
| `cores/model/documents/Documents.csproj` | `netstandard2.0` |
| `cores/model/locations/Locations.csproj` | `netstandard2.0` |
| `cores/model/maths/Maths.csproj` | `netstandard2.0` |
| `cores/model/products/Products.csproj` | `netstandard2.0` |
| `cores/model/robots/Robots.csproj` | `netstandard2.0` |
| `cores/model/shields/Shields.csproj` | `netstandard2.0` |
| `cores/model/styles/Styles.csproj` | `netstandard2.0` |
| `cores/model/valuables/Valuables.csproj` | `netstandard2.0` |
| `cores/service/learnings/Learnings.csproj` | `netstandard2.0` |
| `cores/service/sequencers/Sequencers.csproj` | `netstandard2.0` |
| `cores/service/statistics/Statistics.csproj` | `netstandard2.0` |
| `cores/service/stores/Stores.csproj` | `netstandard2.0` |
| `cores/service/transactions/Transactions.csproj` | `netstandard2.0` |
| `cores/ui/charts/Charts.csproj` | `netstandard2.0` |
| `cores/ui/commands/Commands.csproj` | `netstandard2.0` |
| `cores/ui/graphicers/Graphicers.csproj` | `netstandard2.0` |
| `cores/ui/layouts/Layouts.csproj` | `netstandard2.0` |

## Domain Projects

| Domain | Models | Repository | Service | Controller | Test |
| --- | --- | --- | --- | --- | --- |
| `analizer` | `Analizer.Models` | `Analizer.Repository` | `Analizer.Service` | `Analizer.Controller` | `Analizer.Test` |
| `bom` | `Bom.Models` | `Bom.Repository` | `Bom.Service` | `Bom.Controller` | |
| `calendar` | `Calendar.Models` | `Calendar.Repository` | `Calendar.Service` | `Calendar.Controller` | |
| `designer` | `Designer.Models` | `Designer.Repository` | `Designer.Service` | `Designer.Controller` | `Designer.Test` |
| `drawer` | `Drawer.Models` | `Drawer.Repository` | `Drawer.Service` | `Drawer.Controller` | |
| `driver` | `Driver.Models` | `Driver.Repository` | `Driver.Service` | `Driver.Controller` | |
| `game` | `Game.Models` | `Game.Repository` | `Game.Service` | `Game.Controller` | `Game.Test` |
| `imaging` | `Imaging.Models` | `Imaging.Repository` | `Imaging.Service` | `Imaging.Controller` | |
| `mobility` | `Mobility.Models` | `Mobility.Repository` | `Mobility.Service` | `Mobility.Controller` | |

## Aggregate Projects

| Project | Target | Role |
| --- | --- | --- |
| `src/framework/Framework.csproj` | `netstandard2.0` | Aggregates selected core controllers and domain controllers into a broad framework surface. |
| `src/usecase/UseCase.csproj` | `netstandard2.0` | Use-case package that references selected domain repositories/services. |
| `lib/Lib.csproj` | `netstandard2.0` | Convenience DLL referencing `Commands` and aggregate `Framework`. |

## Test Projects

Test projects use NUnit and generally target `net7.0`.

- `cores/controller/authorizers.test/Authorizers.Test.csproj`
- `cores/controller/configurators.test/Configurators.Test.csproj`
- `cores/controller/translators.test/Translators.Test.csproj`
- `cores/io/accessors.test/Accessors.Test.csproj`
- `cores/io/errors.test/Errors.Test.csproj`
- `cores/io/loggers.test/Loggers.Test.csproj`
- `cores/io/repositories.test/Repositories.Test.csproj`
- `cores/service/sequencers.test/Sequencers.Test.csproj`
- `cores/service/stores.test/Stores.Test.csproj`
- `cores/ui/Commands.Test/Commands.Test.csproj`
- `cores/ui/layouts.test/Layouts.Test.csproj`
- `src/analizer/Analizer.Test/Analizer.Test.csproj`
- `src/designer/designer.test/Designer.Test.csproj`
- `src/game/game.test/Game.Test.csproj`

