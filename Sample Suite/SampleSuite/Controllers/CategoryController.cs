using System.Threading.Tasks;
using Prism;

namespace SampleSuite
{
    [NavigationController(Uri)]
    public class CategoryController : Controller<object>
    {
        public const string Uri = "Main";

        public override Task<string> LoadAsync(NavigationContext context)
        {
            if (context.NavigatedUri == Uri)
            {
                Model = Categories;
            }
            else
            {
                var category = context.Parameters.GetValueOrDefault<Category>("category");
                if (category == null)
                {
                    Model = Resources.Strings.UnknownCategoryError;
                    return Task.FromResult(ErrorView.Perspective);
                }

                if (category.Subcategories.Count == 0)
                {
                    var currentCat = category;

                    string uri = currentCat.Id;
                    while (currentCat.ParentCategory != null)
                    {
                        uri = string.Join("/", currentCat.ParentCategory.Id, uri);
                        currentCat = currentCat.ParentCategory;
                    }

                    Application.Current.BeginInvokeOnMainThread(() => Application.Current.EndIgnoringUserInput());
                    Application.Navigate(uri);
                    return Task.FromResult<string>(null);
                }

                Model = category;
            }
            
            return Task.FromResult(string.Empty);
        }

        private static Category[] Categories = new Category[]
        {
            new Category("DataBinding",
                new Category(SingleBindingSampleView.Perspective),
                new Category(MultiBindingSampleView.Perspective)
            ),
            new Category("FileIO",
                new Category("ReadWrite")
            ),
            new Category("Input",
                new Category(PointerEventsSampleView.Perspective)),
            new Category("RootViews"),
            new Category("Styling",
                new Category(BrushesSampleView.Perspective),
                new Category(TransformSampleView.Perspective)
            ),
            new Category("UIControls",
                new Category(FlyoutSampleView.Perspective),
                new Category(ImageSampleView.Perspective),
                new Category(InkCanvasSampleView.Perspective),
                new Category("ListBox",
                    new Category(ListBoxAddRemoveSampleView.Perspective),
                    new Category(ListBoxSectioningSampleView.Perspective)
                ),
                new Category(ShapesSampleView.Perspective),
                new Category(WebBrowserSampleView.Perspective)
            )
        };
    }
}
