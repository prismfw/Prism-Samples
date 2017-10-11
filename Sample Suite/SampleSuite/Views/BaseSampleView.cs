using System.Threading.Tasks;
using Prism;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;

namespace SampleSuite
{
    public class BaseSampleView<T> : ContentView<T>
        where T : BaseSampleModel
    {
        public override Task ConfigureUIAsync()
        {
            Title = Model.Title;

            var infoButton = new Border()
            {
                Width = 40,
                Height = 40,
                BorderBrush = (Brush)Application.Current.TryFindResource(SystemResources.AccentBrushKey),
                BorderThickness = new Thickness(2),
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, 10, 0),
                Child = new Label()
                {
                    FontSize = 24,
                    Foreground = (Brush)Application.Current.TryFindResource(SystemResources.AccentBrushKey),
                    IsHitTestVisible = false,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Text = "i"
                },
            };

            var infoScroller = new ScrollViewer()
            {
                Content = new Label() { Text = Model.Description, Margin = new Thickness((double)FindResource(SystemResources.VerticalScrollBarWidthKey) + 2) },
                MaxHeight = 150,
                Visibility = Visibility.Collapsed
            };

            var infoPanel = new Border()
            {
                BorderThickness = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Child = new StackPanel()
                {
                    Children = { infoButton, infoScroller },
                    Background = new SolidColorBrush(new Color(64, 128, 128, 128)),
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                }
            };
            infoPanel.SetResourceReference(Border.BackgroundProperty, SystemResources.BaseHighBrushKey);

            Content = new Grid()
            {
                Children = { infoPanel },
                ColumnDefinitions = { new ColumnDefinition(new GridLength(1, GridUnitType.Star)) },
                RowDefinitions = { new RowDefinition(new GridLength(1, GridUnitType.Auto)), new RowDefinition(new GridLength(1, GridUnitType.Star)) },
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            infoButton.PointerPressed += (o, e) =>
            {
                infoScroller.Visibility = infoScroller.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            };

            return base.ConfigureUIAsync();
        }

        public void SetContent(Element content)
        {
            content.Margin += new Thickness(0, 40, 0, 0);
            Grid.SetRowSpan(content, 2);

            var panel = Content as Panel;
            if (panel != null)
            {
                if (panel.Children.Count > 1)
                {
                    panel.Children[0] = content;
                }
                else
                {
                    panel.Children.Insert(0, content);
                }
            }
        }
    }
}
