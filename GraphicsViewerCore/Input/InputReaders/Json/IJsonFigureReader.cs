using GraphicsViewer.Core.Models;
using Newtonsoft.Json.Linq;

namespace GraphicsViewer.Core.Input.InputReaders.Json
{
    public interface IJsonFigureReader
    {
        IFigure ReadFigure(JObject jObject);
    }
}