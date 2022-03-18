using System.Drawing;
using GraphicsViewer.Core.Models;

namespace GraphicsViewer.Core.Rendering.FigureRenderers
{
    public interface IFigureRenderer
    {
        void Render(Graphics graphics, IFigure figure);
    }
}