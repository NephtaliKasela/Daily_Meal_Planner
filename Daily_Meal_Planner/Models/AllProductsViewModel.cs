using BusinessLayer;

namespace Daily_Meal_Planner.Models
{
    public class AllProductsViewModel
    {
        public List<Category> Categories { get; set; }
        public List<string> CategoryList { get;set; }
        public string CatName { get;set; }
    }
}
