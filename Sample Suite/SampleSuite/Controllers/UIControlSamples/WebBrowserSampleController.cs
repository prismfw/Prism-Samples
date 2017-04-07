using System;
using System.Threading.Tasks;
using Prism;
using Prism.UI.Controls;

namespace SampleSuite
{
    [NavigationController("UIControls/WebBrowser")]
    public class WebBrowserSampleController : Controller<UIControlsSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new UIControlsSampleModel()
            {
                Description = Resources.Strings.WebBrowserSampleDescription,
                Title = typeof(WebBrowser).Name
            };

            return Task.FromResult(WebBrowserSampleView.Perspective);
        }
    }
}
