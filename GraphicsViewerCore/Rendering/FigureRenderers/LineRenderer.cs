using System;
using System.Drawing;
using GraphicsViewer.Core.Models;
using GraphicsViewer.Core.Models.Figures;

namespace GraphicsViewer.Core.Rendering.FigureRenderers
{
    public class LineRenderer : IFigureRenderer
    {
        public void Render(Graphics graphics, IFigure figure)
        {
            if (figure is not Line lineFigure)
                throw new ArgumentException($"{nameof(LineRenderer)} cannot render {figure.Type}");

            var pen = new Pen(lineFigure.Color);

            graphics.DrawLine(pen, lineFigure.A, lineFigure.B);
        }
    }
}