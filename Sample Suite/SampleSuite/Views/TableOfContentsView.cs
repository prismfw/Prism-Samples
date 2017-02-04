using System;
using System.Threading.Tasks;
using Prism;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView]
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
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(12, 8),
                    Text = Strings.TableOfContentsGreeting + Environment.NewLine + Environment.NewLine + Strings.TableOfContentsInstructions,
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

            Title = Strings.TableOfContentsTitle;
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
