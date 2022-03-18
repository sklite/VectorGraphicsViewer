using System.Drawing;

namespace GraphicsViewer.Core.Models.Figures
{
    public class Circle : IFigure
    {
        public FigureType Type => FigureType.Circle;
        public RectangleF Bounds => RectangleF.FromLTRB(Center.X - Radius, Center.Y + Radius, Center.X + Radius, Center.Y - Radius);
        public PointF Center { get; set; }
        public float Radius { get; set; }
        public bool Filled { get; set; }
        public Color Color { get; set; }
    }
}