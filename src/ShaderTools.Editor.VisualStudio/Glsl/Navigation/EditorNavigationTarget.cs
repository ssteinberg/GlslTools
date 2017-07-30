﻿using System.Collections.Generic;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using ShaderTools.Editor.VisualStudio.Core.Glyphs;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation
{
    internal class EditorNavigationTarget
    {
        public EditorNavigationTarget(string name, SnapshotSpan span, SnapshotSpan seek, Glyph icon, ImageSource glyph)
        {
            Name = name;
            Span = span;
            Seek = seek;
            Icon = icon;
            Glyph = glyph;
        }

        public string Name { get; }
        public SnapshotSpan Span { get; }
        public SnapshotSpan Seek { get; }
        public Glyph Icon { get; }
        public ImageSource Glyph { get; }
        public bool IsGray { get; set; }
    }

    internal sealed class EditorTypeNavigationTarget : EditorNavigationTarget
    {
        public List<EditorNavigationTarget> Children { get; }

        public EditorTypeNavigationTarget(string name, SnapshotSpan span, SnapshotSpan seek, Glyph icon, ImageSource glyph, List<EditorNavigationTarget> children)
            : base(name, span, seek, icon, glyph)
        {
            Children = children;
        }
    }
}