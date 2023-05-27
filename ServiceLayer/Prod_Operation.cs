using BusinessLayer;


namespace ServiceLayer
{
    public class Prod_Operation
    {
        public List<string> GetCategoryName(List<Category> categories)
        {
            List<string> Names = new List<string>();
            // Get all names of category products
            foreach (var c in categories)
            {
                Names.Add(c.Name);
            }
            return Names;
        }
    }
}