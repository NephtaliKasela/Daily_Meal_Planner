using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class UserCategory
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<UserProduct> Products { get; set; }
        public string Mealtime { get; set; }
    }
}