using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsViewer.Core.Models;
using GraphicsViewer.Core.Models.Figures;
using GraphicsViewer.Core.Rendering;
using Xunit;

namespace Tests
{
    public class ScaleCalculatorTests
    {
        [Fact]
        public void CalcScale_ScalesCircle()
        {
            //Arrange
            var figures = new List<IFigure>()
            {
                new Circle
                {
                    Center = new PointF(500, 0),
                    Color = Color.Black,
                    Filled = true,
                    Radius = 100
                },
                new Line
                {
                    A = new PointF(0, 0),
                    B = new PointF(-100, -100),
                    Color = Color.Red
                }
            };

            var bmp = new Bitmap(600, 600);
            Graphics gr = Graphics.FromImage(bmp);

            //Act
            var scale = ScaleCalculator.CalcScale(figures, gr);

            //Assert
            Assert.Equal(scale.scaleX, 0.5);
            Assert.Equal(scale.scaleY, 1);
        }

        [Fact]
        public void CalcScale_ScalesLine()
        {
            //Arrange
            var figures = new List<IFigure>()
            {
                new Circle
                {
                    Center = new PointF(100, 0),
                    Color = Color.Black,
                    Filled = true,
                    Radius = 100
                },
                new Line
                {
                    A = new PointF(0, -500),
                    B = new PointF(0, -600),
                    Color = Color.Red
                }
            };

            var bmp = new Bitmap(600, 600);
            Graphics gr = Graphics.FromImage(bmp);

            //Act
            var scale = ScaleCalculator.CalcScale(figures, gr);

            //Assert
            Assert.Equal(scale.scaleX, 1);
            Assert.Equal(scale.scaleY, 0.5);
        }

        [Fact]
        public void CalcScale_ScalesTriangle()
        {
            //Arrange
            var figures = new List<IFigure>()
            {
                new Circle
                {
                    Center = new PointF(100, 0),
                    Color = Color.Black,
                    Filled = true,
                    Radius = 100
                },
                new Line
                {
                    A = new PointF(0, -5),
                    B = new PointF(0, -10),
                    Color = Color.Red
                },
                new Triangle()
                {
                    A = new PointF(0,0),
                    B = new PointF(100,100),
                    C = new PointF(1200, 0)
                }
            };

            var bmp = new Bitmap(600, 600);
            Graphics gr = Graphics.FromImage(bmp);

            //Act
            var scale = ScaleCalculator.CalcScale(figures, gr);

            //Assert
            Assert.Equal(scale.scaleX, 0.25);
            Assert.Equal(scale.scaleY, 1);
        }
    }
}
