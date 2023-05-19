using BusinessLayer;

namespace DataLayer
{
    public interface IMealtimeRepository
    {
        public List<UserMealtime> GetUserMealtimes();
    }
}