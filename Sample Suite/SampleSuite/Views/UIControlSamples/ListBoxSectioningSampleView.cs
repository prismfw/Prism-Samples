using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class ListBoxSectioningSampleView : BaseSampleView<ListBoxSampleModel>
    {
        public const string Perspective = "Sectioning";

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var listBox = new ListBox()
            {
                IsSectioningEnabled = true,
                Items = Model.Items,
                SelectionMode = SelectionMode.Multiple
            };

            SetContent(listBox);
        }
    }
}
