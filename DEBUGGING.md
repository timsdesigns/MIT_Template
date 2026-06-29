# Debugging the Grasshopper plugin (macOS & Windows)

This repo debugs the plugin from **VS Code** on both macOS and Windows using the
files in `.vscode/`. A `.gha` is a class library with **no entry point**, so you
cannot "run" it directly. Instead VS Code:

1. builds the project (`dotnet build`),
2. launches **Rhino** as the program,
3. tells Rhino where to find the freshly built `.gha` via `RHINO_PACKAGE_DIRS`,
4. runs the `_Grasshopper` command, and
5. attaches the .NET (`coreclr`) debugger so your breakpoints bind.

## Prerequisites

| | macOS | Windows |
| --- | --- | --- |
| Rhino | **Rhino 8** at `/Applications/Rhino 8.app` | **Rhino 8** at `C:\Program Files\Rhino 8\System\Rhino.exe` |
| SDK | **.NET 8 SDK** | **.NET 8 SDK** |
| VS Code | **C# extension** (`ms-dotnettools.csharp`) provides the `coreclr` debugger | same |

If your Rhino is installed elsewhere, edit the `program` path in
`.vscode/launch.json` (`osx.program` / `windows.program`).

## How to run

1. Open this folder in VS Code.
2. Go to **Run and Debug** (`Ctrl+Shift+D` / `Cmd+Shift+D`).
3. Pick a configuration from the dropdown:
   - **Rhino 8 - Grasshopper (template)** - just opens Grasshopper.
   - **Rhino 8 - Grasshopper + Workbench (template, pick file)** - also opens a
     chosen `.ghx` from `DebugWorkbench`.
4. Press **F5**. For the second config, answer the workbench picker, then set a
   breakpoint in a component's `SolveInstance` and trigger it on the canvas.

> Hot reload is enabled (`hotReloadOnSave`): saving a `.cs` file while debugging
> applies supported edits to the running Rhino session without a restart.

## `${input:workbench}` - which `.ghx` to auto-open

The workbench choice is a **picker** defined once under `inputs` in
`.vscode/launch.json`. `value` is a file name inside `DebugWorkbench`. To add a
new workbench, drop the `.ghx` in that folder and add its file name to the
`workbench` input's `options`.

## Where to change configuration

| What | File | Key |
| --- | --- | --- |
| Workbench list / default | `.vscode/launch.json` | `inputs` -> `workbench` |
| Rhino path (per OS) | `.vscode/launch.json` | `osx.program` / `windows.program` |
| Which folder Rhino scans for the plugin | `.vscode/launch.json` | `env.RHINO_PACKAGE_DIRS` |
| Build command/args | `.vscode/tasks.json` | `tasks[0].args` |

## Stale plugin (same GUID) gotcha

Grasshopper loads **one** `.gha` per `GH_AssemblyInfo.Id`. If it also finds an
**older** `.gha` with that GUID on another scanned folder (e.g. a
developer/library folder configured in
`%APPDATA%/Grasshopper/grasshopper_kernel.xml` -> `Assemblies:Folders`, or
`~/Library/Application Support/McNeel/Rhinoceros/...` on macOS), it loads one and
silently skips the other - your debug build may be ignored. Disable the stale
copy (rename it, e.g. `*.gha` -> `*.gha.disabled`) so only the build-output copy
from `RHINO_PACKAGE_DIRS` is used.
