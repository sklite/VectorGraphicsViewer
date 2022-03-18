using System;
using System.Drawing;

namespace GraphicsViewer.Core.Models.Figures
{
    public class Line : IFigure
    {
        public FigureType Type => FigureType.Line;

        public RectangleF Bounds
        {
            get
            {
                var minX = Math.Min(A.X, B.X);
                var minY = Math.Min(A.Y, B.Y);

                var maxX = Math.Max(A.X, B.X);
                var maxY = Math.Max(A.Y, B.Y);

                return RectangleF.FromLTRB(minX, maxY, maxX, minY);
            }
        }

        public Color Color { get; set; }
        public PointF A { get; set; }
        public PointF B { get; set; }
    }
}