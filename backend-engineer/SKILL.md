---
name: backend-engineer
description:
  Write ASP .NET code.
---

# Projects
- {ProjectName}.{Context}.API (Presentation layer)
- {ProjectName}.{Context}.Modules (Domain, Application, Infrastructure)
- {ProjectName}.{Context}.Migrations (Database migrations)
- {ProjectName}.Integration (Files to communicate between microservices/bounded contexts)

# Key concepts
- Generate code based on the reference solution GeminiReference.Blog structure.
- Always look into each project's README.md file to understand the project's structure and how to use it.
- Always use [this library](https://github.com/NeuraltechSA/Neuraltech.SharedKernel) as SharedKernel. Currently, it won't be imported as a library, but instead, as a remote project reference (path can be found in solution file).
- Never put infraestructure code in Domain or Application layer, with the exception of wolverine event handler interface, which is used in application layer. Always put it in Infrastructure layer. The direction of imports must be: Domain -> Application -> Infrastructure.
- Don't generate documentation for the code. Only generate code.
- Don't generate tests.