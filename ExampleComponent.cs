// SPDX-License-Identifier: MIT
// Minimal Grasshopper plugin template.

using System;
using Grasshopper.Kernel;

namespace MIT_Template;

/// <summary>
/// EXAMPLE skeleton component. It intentionally does no real work - it only
/// shows the four things every Grasshopper component must provide:
/// a unique <see cref="ComponentGuid"/>, input params, output params, and a
/// <see cref="SolveInstance"/> body. Copy this file to start a real component,
/// then: rename the class, generate a NEW <see cref="ComponentGuid"/>, and fill
/// in the IO + logic.
/// </summary>
public sealed class ExampleComponent : TemplateComponent
{
    public ExampleComponent()
        : base("Example", "Ex", "Template skeleton - replace with your own logic.", "Examples")
    {
    }

    /// <summary>
    /// Unique, STABLE id for this component. Grasshopper uses it to match saved
    /// definitions to this component, so never change it after release - and use
    /// a fresh GUID for every new component you create.
    /// </summary>
    public override Guid ComponentGuid => new("3f2a1b0c-4d5e-6f70-8190-a1b2c3d4e5f6");

    /// <summary>Where the component appears in the ribbon drop-down.</summary>
    public override GH_Exposure Exposure => GH_Exposure.primary;

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        // Example input. Replace with your own parameters.
        pManager.AddTextParameter("Input", "I", "Any text; echoed to the output.", GH_ParamAccess.item, "hello");
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        // Example output. Replace with your own parameters.
        pManager.AddTextParameter("Output", "O", "The input, echoed back.", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess da)
    {
        string value = string.Empty;
        if (!da.GetData(0, ref value))
        {
            WrongInput(0);
            return;
        }

        // Replace this pass-through with real work.
        da.SetData(0, value);
    }
}
