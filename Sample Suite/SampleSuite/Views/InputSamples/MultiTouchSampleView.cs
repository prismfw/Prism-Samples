using System;
using System.Linq;
using System.Threading.Tasks;
using Prism;
using Prism.Input;
using Prism.IO;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using Prism.UI.Shapes;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class MultiTouchSampleView : BaseSampleView<BaseSampleModel>
    {
        public const string Perspective = "MultiTouch";

        private readonly Color[] colors = new[]
        {
            Colors.Turquoise,
            Colors.Magenta,
            Colors.Gold,
            Colors.LightCoral,
            Colors.YellowGreen,
        };

        private Canvas canvas;
        private int currentColor;

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            canvas = new Canvas()
            {
                Background = (Brush)TryFindResource(SystemResources.ViewBackgroundBrushKey),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            canvas.PointerPressed += (o, e) =>
            {
                var shape = canvas.Children.FirstOrDefault(c => (long)c.Tag == e.PointerId) as Ellipse;
                if (shape == null)
                {
                    shape = new Ellipse()
                    {
                        Width = 160,
                        Height = 160,
                        IsHitTestVisible = false,
                        Tag = e.PointerId
                    };
                    canvas.Children.Add(shape);
                }

                shape.Fill = new SolidColorBrush(colors[currentColor++ % colors.Length]);
                Canvas.SetTop(shape, e.Position.Y - shape.Height / 2);
                Canvas.SetLeft(shape, e.Position.X - shape.Width / 2);
            };

            canvas.PointerReleased += (o, e) =>
            {
                canvas.Children.RemoveAll(c => (long)c.Tag == e.PointerId);
            };

            canvas.PointerCanceled += (o, e) =>
            {
                canvas.Children.RemoveAll(c => (long)c.Tag == e.PointerId);
            };

            canvas.PointerMoved += (o, e) =>
            {
                var shape = canvas.Children.FirstOrDefault(c => (long)c.Tag == e.PointerId);
                if (shape != null)
                {
                    Canvas.SetTop(shape, e.Position.Y - shape.Height / 2);
                    Canvas.SetLeft(shape, e.Position.X - shape.Width / 2);
                    InvalidateArrange();
                }
            };

            SetContent(canvas);
        }
    }
}
