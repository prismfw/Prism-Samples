using System;
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
    public class SingleBindingSampleView : BaseSampleView<DataBindingSampleModel>
    {
        public const string Perspective = "SingleBinding";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var modeButton = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 12),
                Title = string.Format(Strings.Mode, BindingMode.OneWayToTarget)
            };

            var sourceTextBox = new TextBox()
            {
                BorderWidth = 1,
                BorderBrush = new SolidColorBrush(Colors.Gray),
                Margin = new Thickness(0, 2, 0, 12)
            };

            var targetTextBox = new TextBox()
            {
                BorderWidth = 1,
                BorderBrush = new SolidColorBrush(Colors.Gray),
                Margin = new Thickness(0, 2)
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
                        modeButton,
                        new Label() { Text = Strings.SourceObject },
                        sourceTextBox,
                        new Label() { Text = Strings.TargetObject },
                        targetTextBox
                    }
                });
            };

            var binding = new Binding()
            {
                Mode = BindingMode.OneWayToTarget,
                Source = sourceTextBox
            };
            targetTextBox.SetBinding(TextBox.TextProperty, binding);

            modeButton.Clicked += (o, e) =>
            {
                binding.Mode = (BindingMode)(((int)binding.Mode) % 3) + 1;
                modeButton.Title = string.Format(Strings.Mode, binding.Mode);
            };
        }
    }
}
