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
    public class SelectListSampleView : BaseSampleView<SelectListSampleModel>
    {
        public const string Perspective = "SelectList";

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

            grid.Children.Add(GetPanel(false));
            grid.Children.Add(GetPanel(true));

            SetContent(grid);
        }

        private Panel GetPanel(bool withAdapter)
        {
            var panel = new StackPanel()
            {
                Children =
                {
                    new Label()
                    {
                        Text = withAdapter ? Strings.WithAdapter : Strings.WithoutAdapter,
                        Margin = new Thickness(6),
                        HorizontalAlignment = HorizontalAlignment.Center
                    },
                    new SelectList()
                    {
                        Adapter = withAdapter ? new SelectListColorAdapter() : null,
                        Items = Model.Items,
                        HorizontalAlignment = HorizontalAlignment.Center
                    }
                },
                Margin = new Thickness(0, 12),
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = withAdapter ? VerticalAlignment.Top : VerticalAlignment.Center,
            };
            Grid.SetRow(panel, withAdapter ? 1 : 0);

            return panel;
        }

        private class SelectListColorAdapter : SelectListAdapter
        {
            public override object GetDisplayItem(object value)
            {
                var item = value as SelectListSampleModelItem;
                return new StackPanel()
                {
                    Children =
                    {
                        new Canvas()
                        {
                            Background = new SolidColorBrush((Color)item.Value),
                            Margin = new Thickness(0, 0, 6, 0),
                            Height = 60,
                            Width = 60
                        },
                        new Label()
                        {
                            Text = item.Name,
                            VerticalAlignment = VerticalAlignment.Center
                        }
                    },
                    Margin = new Thickness(0, 0, ((Thickness)Application.Current.FindResource(SystemResources.SelectListDisplayItemPaddingKey)).Right, 0),
                };
            }

            public override object GetListItem(object value)
            {
                var item = value as SelectListSampleModelItem;
                var color = (Color)item.Value;
                
                var canvas = new Canvas()
                {
                    Background = new SolidColorBrush(color),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 60,
                    MinWidth = 200,
                };

                var margin = (Thickness)Application.Current.FindResource(SystemResources.SelectListListItemPaddingKey);
                margin.Right *= 1.5;
                canvas.SetValue(Element.MarginProperty, margin, new Thickness(3), PlatformMask.iOS);
                return canvas;
            }
        }
    }
}
