using System;
using System.Threading.Tasks;
using Prism;
using Prism.UI.Controls;

namespace SampleSuite
{
    [NavigationController("UIControls/InkCanvas")]
    public class InkCanvasSampleController : Controller<UIControlsSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new UIControlsSampleModel()
            {
                Description = Resources.Strings.InkCanvasSampleDescription,
                Title = typeof(InkCanvas).Name
            };

            return Task.FromResult(InkCanvasSampleView.Perspective);
        }
    }
}
