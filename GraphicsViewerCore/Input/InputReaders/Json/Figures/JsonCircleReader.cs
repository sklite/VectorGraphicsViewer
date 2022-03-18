using GraphicsViewer.Core.Extensions;
using GraphicsViewer.Core.Models;
using GraphicsViewer.Core.Models.Figures;
using Newtonsoft.Json.Linq;

namespace GraphicsViewer.Core.Input.InputReaders.Json.Figures
{
    public class JsonCircleReader : IJsonFigureReader
    {
        public IFigure ReadFigure(JObject jObject)
        {
            var result = new Circle
            {
                Center = TokenParser.ParsePoint(jObject.Get("center")),
                Radius = TokenParser.ParseFloat(jObject.Get("radius")),
                Filled = TokenParser.ParseBoolean(jObject.Get("filled")),
                Color = TokenParser.ParseColor(jObject.Get("color"))
            };

            return result;
        }
    }
}