using System;
using System.Drawing;

namespace GraphicsViewer.Core.Models.Figures
{
    public class Triangle : IFigure
    {
        public FigureType Type => FigureType.Triangle;

        public RectangleF Bounds
        {
            get
            {
                var minX = Math.Min(A.X, Math.Min(B.X, C.X));
                var minY = Math.Min(A.Y, Math.Min(B.Y, C.Y));

                var maxX = Math.Max(A.X, Math.Max(B.X, C.X));
                var maxY = Math.Max(A.Y, Math.Max(B.Y, C.Y));

                return RectangleF.FromLTRB(minX, maxY, maxX, minY);
            }
        }

        public PointF A { get; set; }
        public PointF B { get; set; }
        public PointF C { get; set; }
        public bool Filled { get; set; }
        public Color Color { get; set; }
    }
}