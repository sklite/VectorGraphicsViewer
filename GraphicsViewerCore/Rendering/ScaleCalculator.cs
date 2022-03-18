using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsViewer.Core.Models;

namespace GraphicsViewer.Core.Rendering
{
    public static class ScaleCalculator
    {
        /// <summary>
        /// Calculates appropriate scaling value for x and y axes if figure doesn't fit to Graphics drawing area
        /// </summary>
        /// <returns>Returns 1 if all figures are smaller than graphics drawing area, otherwise returns scaling ratio from 0 to 1</returns>
        public static (float scaleX, float scaleY) CalcScale(List<IFigure> figures, Graphics graphics)
        {
            var scaleX = 1.0f;
            var scaleY = 1.0f;

            var screenWidth = graphics.VisibleClipBounds.Width;
            var screenHeight = graphics.VisibleClipBounds.Height;

            var limitX = screenWidth / 2.0f;
            var limitY = screenHeight / 2.0f;

            var boundaries = figures.Select(figure => figure.Bounds).ToList();

            var maxX = boundaries.Max(boundary => boundary.Right);
            var maxY = boundaries.Max(boundary => boundary.Top);
            var minX = boundaries.Min(boundary => boundary.Left);
            var minY = boundaries.Min(boundary => boundary.Bottom);

            var maxOverlapX = Math.Max(Math.Abs(minX), maxX);
            var maxOverlapY = Math.Max(Math.Abs(minY), maxY);


            if (maxOverlapX > limitX)
                scaleX = limitX / maxOverlapX;

            if (maxOverlapY > limitY)
                scaleY = limitY / maxOverlapY;

            return (scaleX, scaleY);
        }
    }
}