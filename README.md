# MIT Template (Grasshopper, .NET 8)

A deliberately small, MIT-licensed starting point for a Grasshopper plugin that
builds and debugs the same way on **Windows and macOS** (Rhino 8+, .NET 8).

It contains **no functional components** - only the minimum scaffolding plus one
clearly-marked example you copy and replace.

## What's inside

| File | Role |
|------|------|
| `MIT_Template.csproj` | SDK-style project; outputs a `.gha`; `Grasshopper` is a compile-only reference. |
| `TemplateAssemblyInfo.cs` | Registers the plugin (name, icon, **unique GUID**). One per plugin. |
| `TemplateComponent.cs` | Thin base class: fixes the ribbon category + shared `WrongInput` helper. |
| `ExampleComponent.cs` | Inert skeleton showing the GUID + input/output + `SolveInstance` shape. |
| `.vscode/` | Cross-platform Rhino launch/build config (see **Debugging**). |

## Getting started

1. **Rename** the project, `AssemblyName`/`RootNamespace`, and the `Name` in
   `TemplateAssemblyInfo.cs`.
2. **Generate new GUIDs**: one for `TemplateAssemblyInfo.Id`, one for every
   component's `ComponentGuid`. Never reuse the template's GUIDs.
3. Copy `ExampleComponent.cs` per new component; rename the class and fill in IO.
4. `dotnet build` - the `.gha` lands in `bin/Debug/net8.0`.

## Design notes (the questions you should ask)

**Do I need a base class?** A thin one pays off fast: it pins the ribbon
`category` in a single place and hosts shared helpers. Keep it thin - promote
code into it only when 2+ components need it.

**Inheritance vs. composition?** Components must inherit `GH_Component`
(framework requirement). For your *own* logic prefer composition (plain classes
the component calls) so it stays unit-testable without Rhino.

**Component documentation?** Three layers:
- `name` / `nickname` / `description` in the constructor -> tooltips & search.
- Per-parameter descriptions in `Register*Params` -> the param tooltips.
- XML `///` docs on the class -> for the next developer (not shown in Rhino).

## Debugging on Windows and macOS

The `.vscode` folder launches **Rhino** (a `.gha` has no entry point and cannot
be "run") and attaches the .NET debugger so breakpoints bind.

1. Open this folder in VS Code with the C# extension installed.
2. Press **F5** -> "Rhino 8 - Grasshopper (template)".
3. Rhino starts, Grasshopper opens, and breakpoints in your components bind.

`RHINO_PACKAGE_DIRS` in `launch.json` points Rhino at `bin/Debug/net8.0` so it
loads exactly the `.gha` you just built. Adjust the Rhino paths in `launch.json`
if yours differ.

## License

MIT - see `LICENSE`.
