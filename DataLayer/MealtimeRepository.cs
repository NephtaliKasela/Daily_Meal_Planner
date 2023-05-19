using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MealtimeRepository: IMealtimeRepository
    {
        MyDBContext _context;
        public MealtimeRepository(MyDBContext context)
        {
            _context = context;
        }

        public List<UserMealtime> GetUserMealtimes()
        {
            return _context.UserMealtime.ToList();
        }
    }
}
