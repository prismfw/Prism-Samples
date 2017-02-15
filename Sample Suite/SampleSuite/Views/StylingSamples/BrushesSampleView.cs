using System;
using System.Threading.Tasks;
using Prism;
using Prism.IO;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class BrushesSampleView : BaseSampleView<StylingSampleModel>
    {
        public const string Perspective = "Brushes";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                RowDefinitions =
                {
                    new RowDefinition(new GridLength(1, GridUnitType.Star)),
                    new RowDefinition(new GridLength(1, GridUnitType.Star)),
                    new RowDefinition(new GridLength(1, GridUnitType.Star))
                }
            };

            var label = GetLabel(grid);
            label.Text = nameof(SolidColorBrush);
            label.Foreground = new SolidColorBrush(Colors.Red);

            label = GetLabel(grid);
            label.Text = nameof(LinearGradientBrush);
            label.Foreground = new LinearGradientBrush(new Point(0, 0), new Point(1, 0), Colors.Red, Colors.Blue, Colors.Green);

            label = GetLabel(grid);
            label.Text = nameof(ImageBrush);
            label.Foreground = new ImageBrush(new Uri(Directory.AssetDirectory + "textBrush.png", UriKind.RelativeOrAbsolute), Stretch.UniformToFill);

            var panel = Content as Panel;
            if (panel != null)
            {
                panel.Children.Add(grid);
            };
        }

        private Label GetLabel(Grid grid)
        {
            var retval = new Label()
            {
                FontSize = 30,
                FontStyle = FontStyle.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            Grid.SetRow(retval, grid.Children.Count);
            grid.Children.Add(retval);
            return retval;
        }
    }
}
