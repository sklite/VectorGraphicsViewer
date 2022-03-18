using System;

namespace GraphicsViewer.Core.Events
{
    public class ZoomEventArgs : EventArgs
    {
        public ZoomEventArgs(int zoom)
        {
            Zoom = zoom;
        }

        public int Zoom { get; }
    }
}