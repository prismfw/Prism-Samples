using System;
using System.Threading.Tasks;
using Prism;

namespace SampleSuite
{
    [NavigationController("Input/{sample}")]
    public class InputSampleController : Controller<InputSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            string sample = context.Parameters.GetValueOrDefault<string>("sample");
            Model = new InputSampleModel()
            {
                Title = Resources.Strings.ResourceManager.GetString(sample),
                Description = Resources.Strings.ResourceManager.GetString(sample + "SampleDescription"),
            };

            return Task.FromResult(sample);
        }
    }
}
