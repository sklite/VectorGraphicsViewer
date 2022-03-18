using System;
using System.Drawing;
using GraphicsViewer.Core.Models;
using GraphicsViewer.Core.Models.Figures;

namespace GraphicsViewer.Core.Rendering.FigureRenderers
{
    public class CircleRenderer : IFigureRenderer
    {
        public void Render(Graphics graphics, IFigure figure)
        {
            if (figure is not Circle circle)
                throw new ArgumentException($"{nameof(CircleRenderer)} cannot render {figure.Type}");

            if (circle.Filled)
            {
                var brush = new SolidBrush(circle.Color);
                graphics.FillEllipse(brush, circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius,
                    circle.Radius * 2, circle.Radius * 2);
            }
            else
            {
                var pen = new Pen(circle.Color);
                graphics.DrawEllipse(pen, circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius,
                    circle.Radius * 2, circle.Radius * 2);
            }
        }
    }
}