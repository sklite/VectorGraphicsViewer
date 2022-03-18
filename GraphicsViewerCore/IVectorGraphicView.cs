using System;
using GraphicsViewer.Core.Events;

namespace GraphicsViewer.Core
{
    public interface IVectorGraphicView
    {
        void SetBusy(bool isBusy);
        void UpdateZoom(int zoomPercentage);

        event EventHandler<ImportFileEventArgs> FileImported;
        event EventHandler<GraphicsInitializedEventArgs> GraphicsInitialized;
        event EventHandler<EventArgs> PanelClicked;
    }
}