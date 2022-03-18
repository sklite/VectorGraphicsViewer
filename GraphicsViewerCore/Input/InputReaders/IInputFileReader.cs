using System.Collections.Generic;
using GraphicsViewer.Core.Models;

namespace GraphicsViewer.Core.Input.InputReaders
{
    public interface IInputFileReader
    {
        List<IFigure> ReadFileContents(string filePath);
    }
}