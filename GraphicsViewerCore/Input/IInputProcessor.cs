using System.Collections.Generic;
using GraphicsViewer.Core.Models;

namespace GraphicsViewer.Core.Input
{
    public interface IInputProcessor
    {
        List<IFigure> ProcessInputFile(string filePath);
    }
}