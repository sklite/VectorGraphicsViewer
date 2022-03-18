using System.Collections.Generic;
using System.IO;
using GraphicsViewer.Core.Extensions;
using GraphicsViewer.Core.Input.InputReaders.Json.Figures;
using GraphicsViewer.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GraphicsViewer.Core.Input.InputReaders.Json
{
    public class JsonFileReader : IInputFileReader
    {
        private readonly Dictionary<string, IJsonFigureReader> _figureReaders;

        public JsonFileReader()
        {
            _figureReaders = new Dictionary<string, IJsonFigureReader>
            {
                {"line", new JsonLineReader()},
                {"circle", new JsonCircleReader()},
                {"triangle", new JsonTriangleReader()},
            };
        }

        public List<IFigure> ReadFileContents(string filePath)
        {
            var result = new List<IFigure>();

            using var textReader = new StreamReader(filePath);
            using var reader = new JsonTextReader(textReader);

            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.StartObject) continue;

                var jObject = JObject.Load(reader);
                var figureType = jObject.Get("type");

                var newFigure = _figureReaders[figureType].ReadFigure(jObject);
                result.Add(newFigure);
            }

            return result;
        }
    }
}