using System;
using System.Threading.Tasks;
using Prism;
using Prism.Input;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using Prism.UI.Shapes;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class TapGesturesSampleView : BaseSampleView<BaseSampleModel>
    {
        public const string Perspective = "TapGestures";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var label = new Label()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 3),
                Text = " "
            };

            var tapRecognizer = new TapGestureRecognizer()
            {
                IsDoubleTapEnabled = true,
                IsRightTapEnabled = true
            };

            tapRecognizer.Tapped += (o, e) => label.Text = Strings.Tapped;
            tapRecognizer.DoubleTapped += (o, e) => label.Text = Strings.DoubleTapped;
            tapRecognizer.RightTapped += (o, e) => label.Text = Strings.RightTapped;

            var quad = new Quadrangle()
            {
                Fill = new SolidColorBrush(Colors.Orange),
                GestureRecognizers = { tapRecognizer },
                StrokeThickness = 0,
                Height = 200,
                Width = 200
            };

            var panel = new StackPanel()
            {
                Children = { label, quad },
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            SetContent(panel);
        }
    }
}
