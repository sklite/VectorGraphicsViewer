using System;
using System.Drawing;

namespace GraphicsViewer.Core.Events
{
    public class GraphicsInitializedEventArgs : EventArgs
    {
        public GraphicsInitializedEventArgs(Graphics graphics)
        {
            Graphics = graphics;
        }

        public Graphics Graphics { get; }
    }
}