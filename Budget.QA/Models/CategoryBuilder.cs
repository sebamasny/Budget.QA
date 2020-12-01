using static Budget.Helpers.Utils;

namespace Budget.Models
{
    public class CategoryBuilder
    {
        private readonly Category _category;

        private CategoryBuilder(Category category)
        {
            _category = category;
        }

        public static CategoryBuilder CreateDefault(string subcategory = "subcategory")
        {
            var category = new Category
            {
                Name = subcategory + RandomString(5)
            };
            return new CategoryBuilder(category);
        }

        public Category Build()
        {
            return _category;
        }
    }
}