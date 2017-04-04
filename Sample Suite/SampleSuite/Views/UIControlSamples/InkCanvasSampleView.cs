using System.Threading.Tasks;
using Prism;
using Prism.Data;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using Prism.UI.Media.Inking;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class InkCanvasSampleView : BaseSampleView<UIControlsSampleModel>
    {
        public const string Perspective = "InkCanvas";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();
            
            var penLabel = new Label()
            {
                Lines = 1,
                Margin = new Thickness(4, 8, 0, 0),
                Text = Strings.PenSizeAndShape + ":"
            };
            Grid.SetColumnSpan(penLabel, 2);

            var sizeSlider = new Slider()
            {
                Margin = new Thickness(8, 8, 8, 28),
                MaxValue = 20,
                MinValue = 1,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetRow(sizeSlider, 1);

            var penList = new SelectList()
            {
                Items = new object[] { PenTipShape.Circle, PenTipShape.Square },
                Margin = new Thickness(20, 8, 20, 28),
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(penList, 1);
            Grid.SetRow(penList, 1);

            var panel = new Grid()
            {
                Children = { penLabel, penList, sizeSlider },
                HorizontalAlignment = HorizontalAlignment.Stretch,
                ColumnDefinitions =
                {
                    new ColumnDefinition(new GridLength(1, GridUnitType.Star)),
                    new ColumnDefinition(new GridLength(1, GridUnitType.Auto))
                },
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition()
                }
            };
            DockPanel.SetDock(panel, Dock.Bottom);

            var canvas = new InkCanvas();
            BindingOperations.SetBinding(canvas.DefaultDrawingAttributes, InkDrawingAttributes.SizeProperty, new Binding(Slider.ValueProperty)
            {
                Source = sizeSlider
            });

            BindingOperations.SetBinding(canvas.DefaultDrawingAttributes, InkDrawingAttributes.PenTipProperty, new Binding(SelectList.SelectedItemProperty)
            {
                Source = penList
            });

            SetContent(new DockPanel()
            {
                Children = { panel, canvas },
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            });

            Menu = new ActionMenu()
            {
                Items =
                {
                    new MenuButton()
                    {
                        Title = Strings.Clear,
                        Action = (button) => canvas.Strokes.Clear()
                    }
                }
            };
        }
    }
}
