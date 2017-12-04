using System;
using System.Threading.Tasks;
using Prism;
using Prism.Systems;
using Prism.Systems.Sensors;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class AccelerometerSampleView : BaseSampleView<BaseSampleModel>
    {
        public const string Perspective = "Accelerometer";

        private Label xLabel, yLabel, zLabel, timestampLabel;

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var panel = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                Orientation = Orientation.Vertical,
                Margin = new Thickness(4, 2),
            };

            xLabel = new Label() { Text = GetText(Strings.AxisX, null) };
            yLabel = new Label() { Text = GetText(Strings.AxisY, null) };
            zLabel = new Label() { Text = GetText(Strings.AxisZ, null) };
            timestampLabel = new Label() { Text = GetText(Strings.Timestamp, null) };

            var slider = new Slider()
            {
                Margin = new Thickness(10, 0),
                MaxValue = 1000,
                MinValue = 1,
                Value = 1
            };

            if (Accelerometer.Current == null)
            {
                panel.Children.Add(new Label()
                {
                    Foreground = new SolidColorBrush(Colors.Red),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(0, 5),
                    Text = Strings.AccelerometerUnavailable,
                    TextAlignment = TextAlignment.Center
                });

                panel.Resources[SystemResources.LabelForegroundBrushKey] = Resources[SystemResources.BaseMediumBrushKey];

                slider.IsEnabled = false;
                xLabel.Text = GetText(Strings.AxisX, Strings.NA);
                yLabel.Text = GetText(Strings.AxisY, Strings.NA);
                zLabel.Text = GetText(Strings.AxisZ, Strings.NA);
                timestampLabel.Text = GetText(Strings.Timestamp, Strings.NA);
            }
            else
            {
                slider.ValueChanged += (o, e) => Accelerometer.Current.UpdateInterval = e.NewValue;

                Accelerometer.Current.ReadingChanged -= OnReadingChanged;
                Accelerometer.Current.ReadingChanged += OnReadingChanged;
                Accelerometer.Current.UpdateInterval = 1;
            }

            panel.Children.Add(xLabel);
            panel.Children.Add(yLabel);
            panel.Children.Add(zLabel);
            panel.Children.Add(timestampLabel);

            panel.Children.Add(new Label()
            {
                Margin = new Thickness(0, 12, 0, 4),
                Text = Strings.UpdateInterval
            });

            panel.Children.Add(slider);

            SetContent(panel);
        }

        protected override void OnUnloaded(EventArgs e)
        {
            base.OnUnloaded(e);

            if (Accelerometer.Current != null)
            {
                Accelerometer.Current.UpdateInterval = double.NaN;
            }
        }

        private string GetText(string name, object value)
        {
            return $"{name}: {value}";
        }

        private void OnReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs e)
        {
            Application.Current.BeginInvokeOnMainThread(() =>
            {
                xLabel.Text = GetText(Strings.AxisX, e.Reading.AccelerationX);
                yLabel.Text = GetText(Strings.AxisY, e.Reading.AccelerationY);
                zLabel.Text = GetText(Strings.AxisZ, e.Reading.AccelerationZ);
                timestampLabel.Text = GetText(Strings.Timestamp, e.Reading.Timestamp);
            });
        }
    }
}
