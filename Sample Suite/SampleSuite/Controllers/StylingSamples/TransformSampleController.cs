using System;
using System.Threading.Tasks;
using Prism;

namespace SampleSuite
{
    [NavigationController("Styling/{sample}")]
    public class TransformSampleController : Controller<TransformSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new TransformSampleModel()
            {
                Title = Resources.Strings.ResourceManager.GetString(context.Parameters.GetValueOrDefault<string>("sample")),
                Description = Resources.Strings.TransformSampleDescription
            };

            return Task.FromResult(string.Empty);
        }
    }
}
