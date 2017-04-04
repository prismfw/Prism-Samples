using System;
using System.Threading.Tasks;
using Prism;
using Prism.UI.Controls;

namespace SampleSuite
{
    [NavigationController("UIControls/Shapes")]
    public class ShapesSampleController : Controller<UIControlsSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new UIControlsSampleModel()
            {
                Description = Resources.Strings.ShapesSampleDescription,
                Title = Resources.Strings.Shapes
            };

            return Task.FromResult(ShapesSampleView.Perspective);
        }
    }
}
