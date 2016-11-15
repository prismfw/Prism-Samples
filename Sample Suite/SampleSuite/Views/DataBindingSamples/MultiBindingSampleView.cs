using System;
using System.Globalization;
using System.Threading.Tasks;
using Prism;
using Prism.Data;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [View(Perspective)]
    public class MultiBindingSampleView : BaseSampleView<DataBindingSampleModel>
    {
        public const string Perspective = "MultiBinding";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var colorDisplay = new Border()
            {
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                BorderThickness = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 12, 0, 2),
                Height = 48,
                Width = 48,
            };

            var colorLabel = new Label()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 12)
            };

            var redSlider = new Slider()
            {
                Margin = new Thickness(4, 2, 4, 12),
                MaxValue = 255,
                StepFrequency = 1,
                IsSnapToStepEnabled = true
            };

            var greenSlider = new Slider()
            {
                Margin = new Thickness(4, 2, 4, 12),
                MaxValue = 255,
                StepFrequency = 1,
                IsSnapToStepEnabled = true
            };

            var blueSlider = new Slider()
            {
                Margin = new Thickness(4, 2, 4, 12),
                MaxValue = 255,
                StepFrequency = 1,
                IsSnapToStepEnabled = true
            };

            var panel = Content as Panel;
            if (panel != null)
            {
                panel.Children.Add(new StackPanel()
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(2),
                    Orientation = Orientation.Vertical,
                    Children =
                    {
                        colorDisplay,
                        colorLabel,
                        new Label() { Text = Strings.Red },
                        redSlider,
                        new Label() { Text = Strings.Green },
                        greenSlider,
                        new Label() { Text = Strings.Blue },
                        blueSlider
                    }
                });
            };

            colorDisplay.SetBinding(Border.BackgroundProperty, new MultiBinding()
            {
                Converter = new RGBConverter(),
                Bindings =
                {
                    new Binding(Slider.ValueProperty) { Source = redSlider },
                    new Binding(Slider.ValueProperty) { Source = greenSlider },
                    new Binding(Slider.ValueProperty) { Source = blueSlider },
                    new Binding(Label.TextProperty)
                    {
                        Source = colorLabel,
                        Mode = BindingMode.OneWayToSource
                    }
                }
            });
        }

        private class RGBConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                // called for slider values converted to color
                return new SolidColorBrush(new Color((byte)(double)values[0], (byte)(double)values[1], (byte)(double)values[2]));
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                // called for color converted to label text
                var brush = value as SolidColorBrush;
                return new object[1] { brush == null ? null : brush.Color.ToString() };
            }
        }
    }
}
