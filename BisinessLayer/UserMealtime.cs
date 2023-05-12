namespace BusinessLayer
{
    public class UserMealtime
    {
        public int Id { get; set; }
        public string MealtimeName { get; set; }
        public List<UserCategory> Categories { get; set; }
    }
}