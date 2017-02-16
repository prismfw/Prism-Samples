using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using Prism.UI.Shapes;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView]
    [PreferredPanes(Panes.Detail)]
    public class ShapesSampleView : BaseSampleView<ShapesSampleModel>
    {
        private bool isDashEnabled;

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var stackPanel = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Orientation = Orientation.Vertical
            };

            AddShape(stackPanel, new Line()
            {
                X1 = 6,
                Y1 = 6,
                X2 = 274,
                Y2 = 274
            });

            AddShape(stackPanel, new Ellipse()
            {
                Width = 280,
                Height = 200
            });

            AddShape(stackPanel, new Quadrangle()
            {
                Width = 280,
                Height = 200
            });

            AddShape(stackPanel, new Polygon()
            {
                Points =
                {
                    new Point(124, 4),
                    new Point(244, 124),
                    new Point(244, 244),
                    new Point(4, 244),
                    new Point(4, 124)
                }
            });

            AddShape(stackPanel, new Polyline()
            {
                Points =
                {
                    new Point(4, 244),
                    new Point(64, 4),
                    new Point(124, 204),
                    new Point(184, 4),
                    new Point(244, 244)
                }
            });

            AddShape(stackPanel, new Path()
            {
                Figures =
                {
                    new PathFigure()
                    {
                        IsClosed = true,
                        StartPoint = new Point(60, 240),
                        Segments =
                        {
                            new BezierSegment(new Point(0, 180), new Point(100, 120), new Point(60, 60)),
                            new ArcSegment(new Point(180, 60), new Size(30, 25)),
                            new BezierSegment(new Point(140, 120), new Point(240, 180), new Point(180, 240))
                        }
                    }
                }
            });

            var panel = Content as Panel;
            if (panel != null)
            {
                panel.Children.Add(new ScrollViewer() { Content = stackPanel });
            }

            Menu = new ActionMenu()
            {
                Items =
                {
                    new MenuButton()
                    {
                        Title = Strings.ToggleDash,
                        Action = (b) =>
                        {
                            isDashEnabled = !isDashEnabled;
                            foreach (var shape in stackPanel.Children.OfType<Shape>())
                            {
                                shape.SetStrokeDashPattern(isDashEnabled ? new double[] { 20, 20 } : null, 0);
                            }
                        }
                    }
                }
            };
        }

        private void AddShape(Panel panel, Shape shape)
        {
            panel.Children.Add(new Label()
            {
                Margin = new Thickness(4, 4, 0, 0),
                Text = shape.GetType().Name + ":"
            });

            shape.Fill = new SolidColorBrush(Colors.Yellow);
            shape.Stroke = new SolidColorBrush(Colors.Red);
            shape.StrokeThickness = 6;
            shape.HorizontalAlignment = HorizontalAlignment.Center;
            shape.VerticalAlignment = VerticalAlignment.Center;
            shape.Margin = new Thickness(0, 0, 0, 20);
            panel.Children.Add(shape);
        }
    }
}
