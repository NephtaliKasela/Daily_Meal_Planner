using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserProduct
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public double Gramms { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Calories { get; set; }
        public string CategoryName { get; set; }
        public string Mealtime { get; set; }
        public bool State { get; set; }
    }
}
