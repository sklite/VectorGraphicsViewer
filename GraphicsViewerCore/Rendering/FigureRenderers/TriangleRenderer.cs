using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using GraphicsViewer.Core.Models;
using GraphicsViewer.Core.Models.Figures;

namespace GraphicsViewer.Core.Rendering.FigureRenderers
{
    public class TriangleRenderer : IFigureRenderer
    {
        public void Render(Graphics graphics, IFigure figure)
        {
            if (figure is not Triangle triangle)
                throw new ArgumentException($"{nameof(TriangleRenderer)} cannot render {figure.Type}");

            var pen = new Pen(triangle.Color);
            var path = new GraphicsPath();

            path.AddLines(new []{triangle.A,triangle.B, triangle.C});
            path.CloseFigure();
            graphics.DrawPath(pen, path);

            if (triangle.Filled)
            {
                var brush = new SolidBrush(triangle.Color);
                graphics.FillPath(brush, path);
            }
        }
    }
}