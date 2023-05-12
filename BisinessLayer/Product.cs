using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Gramms { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Calories { get; set; }
        public string CategoryName { get; set; }
        public bool State { get; set; }
    }
}