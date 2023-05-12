using BusinessLayer;

namespace Daily_Meal_Planner.Models
{
    public class UserMealtimeViewModel
    {
        public List<UserMealtime> Mealtimes { get; set; }
        public List<string> MealtimeNames { get; set; }
        public List<string> CategoryNames { get; set; }

        public string MealtimeChoice { get; set; }
        public string CategoryChoice { get; set; }
        public int ProgressBar { get; set; }

        public UserMealtimeViewModel() 
        {
            Mealtimes = new List<UserMealtime>();
            MealtimeNames= new List<string>();
            CategoryNames = new List<string>(); 
            MealtimeChoice= string.Empty;
            CategoryChoice= string.Empty;
            ProgressBar= 0;
        }
    }
}
