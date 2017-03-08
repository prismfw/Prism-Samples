using System;
using System.Threading.Tasks;
using Prism;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView]
    [PreferredPanes(Panes.Detail)]
    public class RootViewSampleView : BaseSampleView<RootViewSampleModel>
    {
        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();
            
            var grid = new Grid()
            {
                ColumnDefinitions = { new ColumnDefinition(new GridLength(1, GridUnitType.Star)), new ColumnDefinition(new GridLength(1, GridUnitType.Star)) },
                RowDefinitions = { new RowDefinition(new GridLength(1, GridUnitType.Star)), new RowDefinition(new GridLength(1, GridUnitType.Star)) }
            };

            for (int i = 0; i < Model.Options.Length; i++)
            {
                var option = Model.Options[i];
                var border = new Border()
                {
                    Background = new SolidColorBrush(Colors.Transparent),
                    BorderBrush = new SolidColorBrush(Colors.Gray),
                    BorderThickness = new Thickness(2),
                    Margin = new Thickness(20),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = new Label()
                    {
                        Text = option,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    }
                };
                Grid.SetColumn(border, i % 2);
                Grid.SetRow(border, i / 2);

                border.PointerReleased += (o, e) =>
                {
                    if (option == Strings.SplitView && Device.Current.FormFactor != FormFactor.Phone)
                    {
                        Window.Current.Content = new SplitView();
                    }
                    else if (option == Strings.SplitViewWithTabs && Device.Current.FormFactor != FormFactor.Phone)
                    {
                        var tabView = new TabView();
                        InitializeTabView(tabView);
                        tabView.TabItems[0].Content = new SplitView();
                        tabView.TabItemSelected += OnSplitTabSelected;
                    }
                    else if (option == Strings.TabView)
                    {
                        var tabView = new TabView();
                        InitializeTabView(tabView);
                        tabView.TabItemSelected += OnTabSelected;
                    }
                    else
                    {
                        Window.Current.Content = new ViewStack();
                    }

                    Navigate(CategoryController.Uri);
                };

                grid.Children.Add(border);
            }

            var panel = Content as Panel;
            if (panel != null)
            {
                panel.Children.Add(grid);
            };
        }

        private void InitializeTabView(TabView tabView)
        {
            tabView.TabItems.AddRange(new[]
            {
                new TabItem() { Title = string.Format(Strings.Tab, 1) },
                new TabItem() { Title = string.Format(Strings.Tab, 2) },
                new TabItem() { Title = string.Format(Strings.Tab, 3) },
                new TabItem() { Title = string.Format(Strings.Tab, 4) },
                new TabItem() { Title = string.Format(Strings.Tab, 5) },
            });

            Window.Current.Content = tabView;
        }

        private void OnSplitTabSelected(TabView tabView, TabItemSelectedEventArgs e)
        {
            if (e.CurrentTabItem.Content == null && tabView.TabItems.IndexOf(e.CurrentTabItem) > 0)
            {
                var color = new Color(new Random().Next());
                color.A = 255;
                e.CurrentTabItem.Content = new SplitView()
                {
                    MasterContent = new ContentView()
                    {
                        Background = new SolidColorBrush(color),
                        Content = e.CurrentTabItem.Title
                    }
                };
            }
        }

        private void OnTabSelected(TabView tabView, TabItemSelectedEventArgs e)
        {
            if (e.CurrentTabItem.Content == null && tabView.TabItems.IndexOf(e.CurrentTabItem) > 0)
            {
                var color = new Color(new Random().Next());
                color.A = 255;
                e.CurrentTabItem.Content = new ContentView()
                {
                    Background = new SolidColorBrush(color),
                    Content = e.CurrentTabItem.Title,
                };
            }
        }
    }
}
