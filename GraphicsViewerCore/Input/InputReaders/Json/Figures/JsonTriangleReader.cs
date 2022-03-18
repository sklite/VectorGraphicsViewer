using GraphicsViewer.Core.Extensions;
using GraphicsViewer.Core.Models;
using GraphicsViewer.Core.Models.Figures;
using Newtonsoft.Json.Linq;

namespace GraphicsViewer.Core.Input.InputReaders.Json.Figures
{
    public class JsonTriangleReader : IJsonFigureReader
    {
        public IFigure ReadFigure(JObject jObject)
        {
            var result = new Triangle
            {
                A = TokenParser.ParsePoint(jObject.Get("a")),
                B = TokenParser.ParsePoint(jObject.Get("b")),
                C = TokenParser.ParsePoint(jObject.Get("c")),
                Filled = TokenParser.ParseBoolean(jObject.Get("filled")),
                Color = TokenParser.ParseColor(jObject.Get("color"))
            };

            return result;
        }
    }
}