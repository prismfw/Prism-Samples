using System.Threading.Tasks;
using Prism;
using Prism.UI;
using Prism.UI.Controls;
using SampleSuite.Resources;

namespace SampleSuite
{
    [View(Perspective)]
    [PreferredPanes(Panes.Master | Panes.Detail)]
    public class ErrorView : ContentView<string>
    {
        public const string Perspective = "error";

        public override Task ConfigureUIAsync()
        {
            Title = Strings.Error;
            Content = new Label()
            {
                Text = Model?.ToString(),
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(12, 8),
            };

            return base.ConfigureUIAsync();
        }
    }
}
