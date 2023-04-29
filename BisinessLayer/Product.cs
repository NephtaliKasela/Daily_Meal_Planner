namespace BisinessLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Gramms { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Calories { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}