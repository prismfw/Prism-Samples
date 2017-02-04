using System;
using System.Threading.Tasks;
using Prism;

namespace SampleSuite
{
    [NavigationController("RootViews")]
    public class RootViewSampleController : Controller<RootViewSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new RootViewSampleModel()
            {
                Title = Resources.Strings.RootViews,
                Description = Resources.Strings.RootViewSampleDescription,
                Options = new[]
                {
                    Resources.Strings.SplitView,
                    Resources.Strings.TabView,
                    Resources.Strings.TabbedSplitView,
                    Resources.Strings.SingleView
                }
            };

            return Task.FromResult(string.Empty);
        }
    }
}
