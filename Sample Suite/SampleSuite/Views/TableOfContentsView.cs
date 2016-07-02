using System;
using System.Linq;
using System.Threading.Tasks;
using Prism;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;

namespace SampleSuite
{
    [View]
    public class TableOfContentsView : ContentView<Category[]>
    {
        public override Task ConfigureUIAsync()
        {
            var border = new Border()
            {
                BorderBrush = new SolidColorBrush(Colors.Gray),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Child = new Label()
                {
                    Margin = new Thickness(12, 8),
                    Text = Resources.Strings.TableOfContentsGreeting + Environment.NewLine + Environment.NewLine + Resources.Strings.TableOfContentsInstructions,
                    TextAlignment = TextAlignment.Center
                },
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            DockPanel.SetDock(border, Dock.Top);

            var list = new ListBox()
            {
                Items = Model
            };
            
            list.ItemClicked += (o, e) =>
            {
                Navigate(typeof(CategoryController), new NavigationOptions() { Parameters = { { "category", e.Item as Category } } });
            };

            Title = Resources.Strings.TableOfContentsTitle;
            Content = new DockPanel()
            {
                Children = { border, list },
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            return base.ConfigureUIAsync();
        }
    }
}
