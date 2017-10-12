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
    public class LabelSampleView : BaseSampleView<LabelSampleModel>
    {
        public const string Perspective = "Label";

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

            AddImage(panel, TextAlignment.Left);
            AddImage(panel, TextAlignment.Right);
            AddImage(panel, TextAlignment.Center);
            AddImage(panel, TextAlignment.Justified);

            SetContent(new ScrollViewer()
            {
                Content = panel,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            });
        }

        private void AddImage(Panel panel, TextAlignment alignment)
        {
            var border = new Border()
            {
                Height = 280,
                Width = 280,
                Padding = new Thickness(2),
                Child = new Label()
                {
                    Text = Model.LabelText,
                    TextAlignment = alignment,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Center
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
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Margin = new Thickness(3),
                        Text = alignment.ToString(),
                        TextAlignment = TextAlignment.Center,
                    },
                    border
                }
            });
        }
    }
}
