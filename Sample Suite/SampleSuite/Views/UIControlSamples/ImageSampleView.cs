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
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class ImageSampleView : BaseSampleView<ImageSampleModel>
    {
        public const string Perspective = "Image";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var panel = new WrapPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                Orientation = Orientation.Horizontal,
                MaxLength = 2,
            };

            AddImage(panel, Stretch.None);
            AddImage(panel, Stretch.Fill);
            AddImage(panel, Stretch.Uniform);
            AddImage(panel, Stretch.UniformToFill);

            SetContent(new ScrollViewer()
            {
                Content = panel,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            });
        }

        private void AddImage(Panel panel, Stretch stretch)
        {
            var border = new Border()
            {
                Child = new Image(Model.ImageUri)
                {
                    Width = 280,
                    Height = 280,
                    Stretch = stretch
                }
            };
            border.SetResourceReference(Border.BorderBrushProperty, SystemResources.AltHighBrushKey);

            panel.Children.Add(new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(20),
                Orientation = Orientation.Vertical,
                Children =
                {
                    new Label()
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(3),
                        Text = stretch.ToString(),
                        TextAlignment = TextAlignment.Center,
                    },
                    border
                }
            });
        }
    }
}
