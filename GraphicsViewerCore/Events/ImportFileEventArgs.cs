using System;

namespace GraphicsViewer.Core.Events
{
    public class ImportFileEventArgs : EventArgs
    {
        public ImportFileEventArgs(string fullPath)
        {
            FullPath = fullPath;
        }

        public string FullPath { get; }
    }
}