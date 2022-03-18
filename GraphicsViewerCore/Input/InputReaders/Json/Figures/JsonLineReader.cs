using GraphicsViewer.Core.Extensions;
using GraphicsViewer.Core.Models;
using GraphicsViewer.Core.Models.Figures;
using Newtonsoft.Json.Linq;

namespace GraphicsViewer.Core.Input.InputReaders.Json.Figures
{
    public class JsonLineReader : IJsonFigureReader
    {
        public IFigure ReadFigure(JObject jObject)
        {
            var result = new Line
            {
                A = TokenParser.ParsePoint(jObject.Get("a")),
                B = TokenParser.ParsePoint(jObject.Get("b")),
                Color = TokenParser.ParseColor(jObject.Get("color"))
            };

            return result;
        }
    }
}