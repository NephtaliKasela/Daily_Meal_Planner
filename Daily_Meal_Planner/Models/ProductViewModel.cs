namespace Daily_Meal_Planner.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public double Gramms { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Calories { get; set; }
        public string CatName { get; set; }
        public List<string> Mealtimes { get; set; }

        public ProductViewModel()
        {
            Mealtimes = new List<string>();
        }
    }
}
