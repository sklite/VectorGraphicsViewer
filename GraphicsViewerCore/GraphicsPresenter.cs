using System;
using System.Threading.Tasks;
using GraphicsViewer.Core.Events;
using GraphicsViewer.Core.Input;
using GraphicsViewer.Core.Rendering;

namespace GraphicsViewer.Core
{
    public class GraphicsPresenter : IGraphicsPresenter
    {
        private readonly IInputProcessor _inputProcessor;
        private readonly IGraphicsRenderer _graphicsRenderer;
        private IVectorGraphicView _view;

        public GraphicsPresenter(IInputProcessor inputProcessor, IGraphicsRenderer graphicsRenderer)
        {
            _inputProcessor = inputProcessor;
            _graphicsRenderer = graphicsRenderer;
            _graphicsRenderer.ZoomChanged += ZoomChanged;
        }

        public void SetView(IVectorGraphicView view)
        {
            if (_view != null)
            {
                _view.FileImported -= FileImported;
                _view.GraphicsInitialized -= GraphicsInitialized;
                _view.PanelClicked -= PanelClicked;
            }

            _view = view;

            _view.FileImported += FileImported;
            _view.GraphicsInitialized += GraphicsInitialized;
            _view.PanelClicked += PanelClicked;
        }

        private void ZoomChanged(object? sender, ZoomEventArgs e)
        {
            _view?.UpdateZoom(e.Zoom);
        }

        private void PanelClicked(object? sender, EventArgs e)
        {
            //TODO: Make additional behaviour for selecting objects here 
            throw new NotImplementedException();
        }

        private void GraphicsInitialized(object? sender, GraphicsInitializedEventArgs e)
        {
            _graphicsRenderer.Init(e.Graphics);
        }

        private async void FileImported(object? sender, ImportFileEventArgs e)
        {
            _view.SetBusy(true);
            
            await Task.Run(() =>
            {
                var figures = _inputProcessor.ProcessInputFile(e.FullPath);
                _graphicsRenderer.Draw(figures);
            });
            
            _view.SetBusy(false);
        }
    }
}