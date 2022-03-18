using System.Drawing;

namespace GraphicsViewer.Core.Models
{
    public interface IFigure
    {
        FigureType Type { get; }
        RectangleF Bounds { get; }
        Color Color { get; }
    }
}