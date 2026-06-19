// SPDX-License-Identifier: MIT
// Minimal Grasshopper plugin template.

using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace MIT_Template;

/// <summary>
/// Tells Grasshopper about this plugin (name, icon, author) and gives it a
/// stable unique <see cref="Id"/>. Every Grasshopper plugin needs exactly one
/// <see cref="GH_AssemblyInfo"/>.
/// </summary>
/// <remarks>
/// IMPORTANT: generate your own GUID for <see cref="Id"/> before shipping
/// (Visual Studio: Tools &gt; Create GUID, or <c>uuidgen</c>). Two plugins that
/// share an Id cannot be loaded at the same time.
/// </remarks>
public sealed class TemplateAssemblyInfo : GH_AssemblyInfo
{
    public override string Name => "MIT Template";

    public override Bitmap? Icon => null; // 24x24 bitmap, or null for the default.

    public override string Description => "Minimal MIT-licensed Grasshopper plugin template.";

    // Replace with your own GUID before publishing.
    public override Guid Id => new("b1e3d6c2-0a4f-4d2b-9f7a-1c2e3a4b5c6d");

    public override string AuthorName => "Your Name";

    public override string AuthorContact => "you@example.com";
}
