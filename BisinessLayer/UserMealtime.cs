namespace BusinessLayer
{
    public class UserMealtime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserCategory> Categories { get; set; }
    }
}