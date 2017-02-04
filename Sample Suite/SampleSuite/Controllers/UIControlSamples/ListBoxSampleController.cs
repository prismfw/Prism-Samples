using System;
using System.Threading.Tasks;
using Prism;
using Prism.UI.Controls;

namespace SampleSuite
{
    [NavigationController("UIControls/ListBox/{sample}")]
    public class ListBoxSampleController : Controller<ListBoxSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            string sample = context.Parameters.GetValueOrDefault<string>("sample");

            Model = new ListBoxSampleModel() { Title = Resources.Strings.ResourceManager.GetString(sample) };
            switch(sample)
            {
                case ListBoxAddRemoveSampleView.Perspective:
                    Model.Description = Resources.Strings.ListBoxAddRemoveSampleDescription;
                    Model.Items = new[]
                    {
                        Resources.Strings.Item + " 1",
                        Resources.Strings.Item + " 2"
                    };
                    break;
                case ListBoxSectioningSampleView.Perspective:
                    Model.Description = Resources.Strings.ListBoxSectioningSampleDescription;
                    Model.Items = new ObservableSection<string>[10];
                    for (int i = 0; i < Model.Items.Length;)
                    {
                        // ObservableSection is a convenience class.  Any class that implements the IList interface will work.
                        var section = new ObservableSection<string>();
                        Model.Items[i] = section;

                        section.HeaderTitle = Resources.Strings.Section + " " + (++i).ToString();
                        for (int j = 0; j < 10;)
                        {
                            section.Items.Add(Resources.Strings.Item + " " + (++j).ToString());
                        }
                    };
                    break;
            }

            return Task.FromResult(sample);
        }
    }
}
