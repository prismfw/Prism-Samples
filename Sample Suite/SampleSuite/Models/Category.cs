using System.Collections.ObjectModel;

namespace SampleSuite
{
    public class Category
    {
        public string Id { get; private set; }

        public string Description { get; private set; }

        public Category ParentCategory { get; private set; }

        public ReadOnlyCollection<Category> Subcategories { get; private set; }

        public Category(string id, params Category[] subcategories)
        {
            Id = id;
            Description = Resources.Strings.ResourceManager.GetString(id) ?? Id;
            Subcategories = new ReadOnlyCollection<Category>(subcategories);

            foreach (var category in subcategories)
            {
                category.ParentCategory = this;
            }
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
