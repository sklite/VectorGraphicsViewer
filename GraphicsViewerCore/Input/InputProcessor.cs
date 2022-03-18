using System;
using System.Collections.Generic;
using System.IO;
using GraphicsViewer.Core.Input.InputReaders;
using GraphicsViewer.Core.Input.InputReaders.Json;
using GraphicsViewer.Core.Models;

namespace GraphicsViewer.Core.Input
{
    public class InputProcessor : IInputProcessor
    {
        private readonly Dictionary<string, IInputFileReader> _readers;
        public InputProcessor()
        {
            _readers = new Dictionary<string, IInputFileReader>
            {
                { ".json", new JsonFileReader() },
                //{ ".xml", new XmlFileReader() }
            };
        }

        public List<IFigure> ProcessInputFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException($"File {filePath} doesn't exist");

            var fileExtension = Path.GetExtension(filePath);

            if (!_readers.ContainsKey(fileExtension))
                throw new NotImplementedException($"Reading \"{fileExtension}\" files is not supported");

            return _readers[fileExtension].ReadFileContents(filePath);
        }
    }
}