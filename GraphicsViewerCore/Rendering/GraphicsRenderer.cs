using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsViewer.Core.Events;
using GraphicsViewer.Core.Models;
using GraphicsViewer.Core.Rendering.FigureRenderers;

namespace GraphicsViewer.Core.Rendering
{
    public class GraphicsRenderer : IGraphicsRenderer
    {
        private Graphics _graphics;
        private readonly Dictionary<FigureType, IFigureRenderer> _figuresRenderers;

        public GraphicsRenderer()
        {
            _figuresRenderers = new Dictionary<FigureType, IFigureRenderer>
            {
                { FigureType.Line , new LineRenderer()},
                { FigureType.Triangle , new TriangleRenderer()},
                { FigureType.Circle , new CircleRenderer()}
            };
        }

        private void ResizeGraphics(float scale)
        {
            _graphics.ScaleTransform(scale, scale);
        }

        private float CalculateScale(List<IFigure> figures)
        {
            var scales = ScaleCalculator.CalcScale(figures, _graphics);
            return Math.Min(scales.scaleX, scales.scaleY);
        }

        public void Init(Graphics graphics)
        {
            _graphics = graphics;
            //Point axis Y up
            _graphics.ScaleTransform(1.0f, -1.0f);
            //Center the coordinate system
            _graphics.TranslateTransform(_graphics.VisibleClipBounds.Width / 2.0f, -_graphics.VisibleClipBounds.Height / 2.0f);
        }

        public void Draw(List<IFigure> figures)
        {
            _graphics.Clear(Color.White);

            var scale = CalculateScale(figures);
            ResizeGraphics(scale);
            var percentage = 100.0 * scale;
            ZoomChanged?.Invoke(this, new ZoomEventArgs((int)percentage));

            foreach (var figure in figures)
            {
                if (_figuresRenderers.ContainsKey(figure.Type))
                    _figuresRenderers[figure.Type].Render(_graphics, figure);
            }

            ResizeGraphics(1.0f / scale);
        }

        public event EventHandler<ZoomEventArgs>? ZoomChanged;
    }
}