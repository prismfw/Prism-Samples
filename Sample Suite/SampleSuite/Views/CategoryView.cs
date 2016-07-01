using System.Linq;
using System.Threading.Tasks;
using Prism;
using Prism.UI;
using Prism.UI.Controls;

namespace SampleSuite
{
    [View]
    [PreferredPanes(Panes.Master)]
    public class CategoryView : ContentView<Category>
    {
        public override Task ConfigureUIAsync()
        {
            var list = new ListBox()
            {
                Items = Model.Subcategories
            };

            list.ItemClicked += (o, e) =>
            {
                Navigate(typeof(CategoryController), new NavigationOptions() { Parameters = { { "category", e.Item as Category } } });
            };

            Title = Model.Description;
            StackId = Model.Id;
            Content = list;

            return base.ConfigureUIAsync();
        }
    }
}
