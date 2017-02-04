using System;
using System.Threading.Tasks;
using Prism;

namespace SampleSuite
{
    [NavigationController("DataBinding/{sample}")]
    public class DataBindingSampleController : Controller<DataBindingSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            string sample = context.Parameters.GetValueOrDefault<string>("sample");
            Model = new DataBindingSampleModel()
            {
                Title = Resources.Strings.ResourceManager.GetString(sample),
                Description = Resources.Strings.ResourceManager.GetString(sample + "SampleDescription"),
            };

            return Task.FromResult(sample);
        }
    }
}
