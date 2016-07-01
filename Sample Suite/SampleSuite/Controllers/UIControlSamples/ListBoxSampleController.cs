using System;
using System.Threading.Tasks;
using Prism;

namespace SampleSuite
{
    [Navigation("UIControls/ListBox/{sample}")]
    public class ListBoxSampleController : Controller<ListBoxSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new ListBoxSampleModel()
            {
                Title = Resources.Strings.ResourceManager.GetString(context.Parameters.GetValueOrDefault<string>("sample")),
                Description = Resources.Strings.ListBoxAddRemoveSampleDescription,
                Items = new[]
                {
                    Resources.Strings.Item + " 1",
                    Resources.Strings.Item + " 2"
                }
            };

            return Task.FromResult(string.Empty);
        }
    }
}
