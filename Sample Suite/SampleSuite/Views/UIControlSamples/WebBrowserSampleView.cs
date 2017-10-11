using System;
using System.Threading.Tasks;
using Prism;
using Prism.Data;
using Prism.Input;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using Prism.Utilities;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class WebBrowserSampleView : BaseSampleView<UIControlsSampleModel>
    {
        public const string Perspective = "WebBrowser";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var textBox = new TextBox()
            {
                ActionKeyType = ActionKeyType.Go,
                BorderWidth = 1,
                InputType = InputType.Url,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            textBox.SetResourceReference(Control.BorderBrushProperty, SystemResources.BaseLowBrushKey);
            textBox.ActionKeyPressed += (o, e) => GoTo(textBox.Text);

            var goButton = new Button()
            {
                Title = Strings.Go,
                Width = 72,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            goButton.Clicked += (o, e) => GoTo(textBox.Text);
            Grid.SetColumn(goButton, 1);

            var browser = new WebBrowser();
            Grid.SetColumnSpan(browser, 2);
            Grid.SetRow(browser, 1);

            SetContent(new Grid()
            {
                Children = { textBox, goButton, browser },
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                ColumnDefinitions =
                {
                    new ColumnDefinition(new GridLength(1, GridUnitType.Star)),
                    new ColumnDefinition()
                },
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(new GridLength(1, GridUnitType.Star))
                }
            });

            var backButton = new MenuButton()
            {
                Title = Strings.Back,
                Action = (button) => browser.GoBack()
            };
            BindingOperations.SetBinding(backButton, MenuButton.IsEnabledProperty, new Binding(WebBrowser.CanGoBackProperty) { Source = browser });

            var forwardButton = new MenuButton()
            {
                Title = Strings.Forward,
                Action = (button) => browser.GoForward()
            };
            BindingOperations.SetBinding(forwardButton, MenuButton.IsEnabledProperty, new Binding(WebBrowser.CanGoForwardProperty) { Source = browser });

            var refreshButton = new MenuButton()
            {
                Title = Strings.Refresh,
                Action = (button) => browser.Refresh()
            };

            Menu = new ActionMenu()
            {
                MaxDisplayItems = Device.Current.FormFactor == FormFactor.Phone ? 0 : 3,
                Items = { backButton, forwardButton, refreshButton }
            };
        }

        private void GoTo(string uri)
        {
            if (!string.IsNullOrWhiteSpace(uri))
            {
                try
                {
                    VisualTreeHelper.GetChild<WebBrowser>(this)?.Navigate(new Uri(uri, UriKind.Absolute));
                }
                catch (FormatException e)
                {
                    Logger.Error(e.Message);
                }
            }
        }
    }
}
