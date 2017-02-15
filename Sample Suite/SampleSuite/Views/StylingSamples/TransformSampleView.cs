using System;
using System.Threading.Tasks;
using Prism;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class TransformSampleView : BaseSampleView<StylingSampleModel>
    {
        public const string Perspective = "Transform";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var grid = new Grid()
            {
                ColumnDefinitions = { new ColumnDefinition(new GridLength(1, GridUnitType.Star)), new ColumnDefinition(new GridLength(1, GridUnitType.Star)) },
                RowDefinitions = { new RowDefinition(new GridLength(1, GridUnitType.Star)), new RowDefinition(new GridLength(1, GridUnitType.Star)) }
            };

            var normalPanel = GetTransformExample(null, Strings.Normal);
            Grid.SetColumnSpan(normalPanel, 2);
            Grid.SetRowSpan(normalPanel, 2);
            grid.Children.Add(normalPanel);

            var translatePanel = GetTransformExample(new TranslateTransform(-25, 25), Strings.Translation);
            grid.Children.Add(translatePanel);
            
            var rotatePanel = GetTransformExample(new RotateTransform(135), Strings.Rotation);
            Grid.SetColumn(rotatePanel, 1);
            grid.Children.Add(rotatePanel);

            var scalePanel = GetTransformExample(new ScaleTransform(2, 2), Strings.Scale);
            Grid.SetRow(scalePanel, 1);
            grid.Children.Add(scalePanel);
            
            var skewPanel = GetTransformExample(new SkewTransform(20, 20), Strings.Skew);
            Grid.SetColumn(skewPanel, 1);
            Grid.SetRow(skewPanel, 1);
            grid.Children.Add(skewPanel);

            var panel = Content as Panel;
            if (panel != null)
            {
                panel.Children.Add(grid);
            };
        }

        private Element GetTransformExample(Transform transform, string title)
        {
            return  new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Orientation = Orientation.Vertical,
                Children =
                {
                    new Label()
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Text = title
                    },
                    new Border()
                    {
                        Background = new SolidColorBrush(new Color(64, 128, 128, 128)),
                        Margin = new Thickness(12),
                        Height = 96,
                        Width = 96,
                        Child = new Label()
                        {
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            RenderTransform = transform,
                            FontSize = 48,
                            Text = "A"
                        }
                    }
                }
            };
        }
    }
}
