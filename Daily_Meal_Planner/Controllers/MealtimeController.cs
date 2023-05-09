using BusinessLayer;
using Daily_Meal_Planner.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Daily_Meal_Planner.Controllers
{
    public class MealtimeController : Controller
    {
        public IUserRepository _userRepository;

        public MealtimeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("index", "Home");
            }

            return View(productViewModel);
        }

        public IActionResult SaveUserProduct(ProductAndMealtimeViewModel productAndMealtimeViewModel)
        {
            //List<UserProduct> userProducts = new List<UserProduct>();
            var userProducts = _userRepository.GetAllUserProducts();
            _userRepository.SaveUserProduct(userProducts, productAndMealtimeViewModel.mealtimeChoice, productAndMealtimeViewModel.ProductName, productAndMealtimeViewModel.Gramms, productAndMealtimeViewModel.Protein, productAndMealtimeViewModel.Fats, productAndMealtimeViewModel.Carbs, productAndMealtimeViewModel.Calories, productAndMealtimeViewModel.CategoryName);
            return View();
        }
    }
}
