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
    public class FlyoutSampleView : BaseSampleView<BaseSampleModel>
    {
        public const string Perspective = "Flyout";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                ColumnDefinitions =
                {
                    new ColumnDefinition(new GridLength(1, GridUnitType.Star))
                },
                RowDefinitions =
                {
                    new RowDefinition(new GridLength(1, GridUnitType.Star)),
                    new RowDefinition(new GridLength(1, GridUnitType.Star))
                }
            };

            var flyoutButton = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Title = Strings.Flyout,
                Flyout = new Flyout()
                {
                    Placement = FlyoutPlacement.Bottom,
                    Content = new Label()
                    {
                        Margin = new Thickness(12),
                        MaxWidth = 200,
                        Text = Strings.FlyoutContent,
                        TextAlignment = TextAlignment.Center
                    }
                }
            };


            var menuFlyoutButton = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Title = Strings.MenuFlyout,
                Flyout = new MenuFlyout()
                {
                    Placement = FlyoutPlacement.Top,
                    Items =
                    {
                        new MenuButton() { Title = Strings.Option + 1 },
                        new MenuButton() { Title = Strings.Option + 2 },
                        new MenuSeparator(),
                        new MenuButton() { Title = Strings.Option + 3 }
                    }
                }
            };
            Grid.SetRow(menuFlyoutButton, 1);

            grid.Children.Add(flyoutButton);
            grid.Children.Add(menuFlyoutButton);

            SetContent(grid);
        }
    }
}
