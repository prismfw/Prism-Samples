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
    public class HoldingGestureSampleView : BaseSampleView<BaseSampleModel>
    {
        public const string Perspective = "HoldingGesture";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var label = new Label()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 3),
                Text = " "
            };

            var holdingRecognizer = new HoldingGestureRecognizer();

            var quad = new Quadrangle()
            {
                Fill = new SolidColorBrush(Colors.Orange),
                GestureRecognizers = { holdingRecognizer },
                StrokeThickness = 0,
                Height = 200,
                Width = 200
            };

            holdingRecognizer.Holding += (o, e) =>
            {
                switch (e.State)
                {
                    case HoldingState.Started:
                        label.Text = Strings.HoldingStarted;
                        quad.Fill = new SolidColorBrush(Colors.Yellow);
                        break;
                    case HoldingState.Completed:
                        label.Text = Strings.HoldingCompleted;
                        quad.Fill = new SolidColorBrush(Colors.Green);
                        break;
                    case HoldingState.Canceled:
                        label.Text = Strings.HoldingCanceled;
                        quad.Fill = new SolidColorBrush(Colors.Red);
                        break;
                }
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
