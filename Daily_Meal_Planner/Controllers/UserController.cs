using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Daily_Meal_Planner.Controllers
{
    public class UserController : Controller
    {
        public IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<UserCategory> categories = new List<UserCategory>();
            categories = _userRepository.GetCategoryProducts(_userRepository.GetAllUserProducts());

            return View();
        }
    }
}
