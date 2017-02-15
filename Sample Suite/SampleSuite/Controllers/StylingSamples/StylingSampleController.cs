using System;
using System.Threading.Tasks;
using Prism;

namespace SampleSuite
{
    [NavigationController("Styling/{sample}")]
    public class StylingSampleController : Controller<StylingSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            string sample = context.Parameters.GetValueOrDefault<string>("sample");
            Model = new StylingSampleModel()
            {
                Title = Resources.Strings.ResourceManager.GetString(sample),
                Description = Resources.Strings.ResourceManager.GetString(sample + "SampleDescription"),
            };

            return Task.FromResult(sample);
        }
    }
}
