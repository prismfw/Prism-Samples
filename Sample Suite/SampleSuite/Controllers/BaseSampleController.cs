using System;
using System.Threading.Tasks;
using Prism;

namespace SampleSuite
{
    // A generic controller for views that don't require any specific model data.
    [NavigationController("{category}/{sample}")]
    public class BaseSampleController : Controller<BaseSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            string sample = context.Parameters.GetValue<string>("sample");
            Model = new BaseSampleModel()
            {
                Description = Resources.Strings.ResourceManager.GetString(sample + "SampleDescription"),
                Title = Resources.Strings.ResourceManager.GetString(sample) ?? sample
            };

            return Task.FromResult(sample);
        }
    }
}
