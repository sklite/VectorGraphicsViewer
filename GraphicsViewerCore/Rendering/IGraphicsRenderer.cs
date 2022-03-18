using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsViewer.Core.Events;
using GraphicsViewer.Core.Models;

namespace GraphicsViewer.Core.Rendering
{
    public interface IGraphicsRenderer
    {
        void Init(Graphics graphics);
        void Draw(List<IFigure> figures);
        event EventHandler<ZoomEventArgs> ZoomChanged;
    }
}