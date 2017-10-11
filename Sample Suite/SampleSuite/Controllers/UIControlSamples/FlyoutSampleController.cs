using System;
using System.Threading.Tasks;
using Prism;
using Prism.UI.Controls;

namespace SampleSuite
{
    [NavigationController("UIControls/Flyout")]
    public class FlyoutSampleController : Controller<UIControlsSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new UIControlsSampleModel()
            {
                Description = Resources.Strings.FlyoutSampleDescription,
                Title = Resources.Strings.Flyout
            };

            return Task.FromResult(FlyoutSampleView.Perspective);
        }
    }
}
