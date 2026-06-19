// SPDX-License-Identifier: MIT
// Minimal Grasshopper plugin template.

using Grasshopper.Kernel;

namespace MIT_Template;

/// <summary>
/// Small base class that every component in this plugin can derive from.
/// </summary>
/// <remarks>
/// <para>
/// Why have a base class at all? Two reasons that scale well:
/// </para>
/// <list type="number">
/// <item>It fixes the Grasshopper <c>category</c> (the ribbon tab) in one place,
/// so all your components group together and you never repeat the string.</item>
/// <item>It is the natural home for shared helpers (here: <see cref="WrongInput"/>).</item>
/// </list>
/// <para>
/// Keep this class thin. Only promote something into the base class once two or
/// more components actually need it - premature shared state is hard to remove.
/// </para>
/// </remarks>
public abstract class TemplateComponent : GH_Component
{
    /// <summary>The ribbon tab all components in this plugin live under.</summary>
    private const string PluginCategory = "MIT Template";

    /// <param name="name">Full name shown in the component's title.</param>
    /// <param name="nickname">Short name shown on the canvas capsule.</param>
    /// <param name="description">One-line description for the tooltip / search.</param>
    /// <param name="subCategory">Drop-down group inside the ribbon tab.</param>
    protected TemplateComponent(string name, string nickname, string description, string subCategory)
        : base(name, nickname, description, PluginCategory, subCategory)
    {
    }

    /// <summary>
    /// Adds a runtime error explaining which input could not be read. Call this
    /// and <c>return</c> from <c>SolveInstance</c> when a required input is missing.
    /// </summary>
    /// <param name="index">Zero-based index of the input parameter.</param>
    /// <param name="message">Optional friendly message; a default is used if empty.</param>
    protected void WrongInput(int index, string message = "")
    {
        message = string.IsNullOrEmpty(message) ? $"Input {index} failed to collect data." : message;
        AddRuntimeMessage(GH_RuntimeMessageLevel.Error, message);
    }
}
