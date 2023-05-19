using BusinessLayer;
using Daily_Meal_Planner.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Daily_Meal_Planner.Controllers
{
    public class MealtimeController : Controller
    {
        public IUserRepository _userRepository;
        public IMealtimeRepository _mealtimeRepository;

        public MealtimeController(IUserRepository userRepository, IMealtimeRepository mealtimeRepository)
        {
            this._userRepository = userRepository;
            this._mealtimeRepository = mealtimeRepository;
        }

        public IActionResult Index(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index", "Home");
            }

            foreach(UserMealtime um in _mealtimeRepository.GetUserMealtimes())
            {
                productViewModel.Mealtimes.Add(um.MealtimeName);
            }

            return View(productViewModel);
        }

        public IActionResult SaveUserProduct(ProductAndMealtimeViewModel productAndMealtimeViewModel)
        {
            //List<UserProduct> userProducts = new List<UserProduct>();
            var userProducts = _userRepository.GetAllUserProducts();
            _userRepository.SaveUserProduct(userProducts, productAndMealtimeViewModel.MealtimeChoice, productAndMealtimeViewModel.ProductName, productAndMealtimeViewModel.Gramms, productAndMealtimeViewModel.Protein, productAndMealtimeViewModel.Fats, productAndMealtimeViewModel.Carbs, productAndMealtimeViewModel.Calories, productAndMealtimeViewModel.CatName);
            
            return RedirectToAction("index", "Home");
        }
    }
}
