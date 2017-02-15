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
            
            var infoPanel = new StackPanel()
            {
                Children = { infoButton, infoScroller },
                Background = new SolidColorBrush(new Color(64, 128, 128, 128)),
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            DockPanel.SetDock(infoPanel, Dock.Top);
            
            Content = new DockPanel()
            {
                Children = { infoPanel },
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            infoButton.PointerPressed += (o, e) =>
            {
                infoScroller.Visibility = infoScroller.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                infoPanel.InvalidateMeasure();
            };

            return base.ConfigureUIAsync();
        }
    }
}
