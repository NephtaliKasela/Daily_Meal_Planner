using BusinessLayer;
using Daily_Meal_Planner.Models;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Operation;

namespace Daily_Meal_Planner.Controllers
{
    public class UserController : Controller
    {
        public IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]
        public IActionResult Index(string mealtimeChoice, string categoryChoice, string username)
        {
            // Set a parameter to emplty string if it is null
            if(mealtimeChoice == null) mealtimeChoice= string.Empty;
            if(categoryChoice == null) categoryChoice= string.Empty;
            if(username == null) username= string.Empty;

            // Get user products data from the database by the username
            List<UserProduct> products = _userRepository.GetUserProductsByName(username);
            List<UserCategory> categories = _userRepository.GetCategoryProducts(products);
            List<UserMealtime> mealtimes = _userRepository.GetMealtimes(categories);

            // Assign the view model
            var vm = new UserMealtimeViewModel();
            vm.Mealtimes = mealtimes;

            if (mealtimeChoice == string.Empty && vm.Mealtimes.Count > 0)
            {
                vm.MealtimeChoice = vm.Mealtimes[0].MealtimeName;
            }
            else
            {
                vm.MealtimeChoice = mealtimeChoice;
                vm.CategoryChoice = categoryChoice;
            }

            // Get all mealtime names
            UserProd_Operation operation = new UserProd_Operation();
            vm.MealtimeNames = operation.GetMealtimeName(mealtimes);

            // Get progress bar percentage for the mealtime choosen and the category
            (int progM, int progC) = operation.GetProgressBar(mealtimes, mealtimeChoice, vm.MealtimeChoice, categoryChoice);
            vm.ProgressBarMT = progM;
            vm.ProgressBarC = progC;

            // Get all category names
            vm.CategoryNames = operation.GetCategoryName(categories);
            //foreach (UserCategory c in categories)
            //{ 
            //    if(!vm.CategoryNames.Contains(c.Name))
            //    {
            //        vm.CategoryNames.Add(c.Name);
            //    }
            //}
            
            return View(vm);
        }

        public IActionResult Login()
        { 
            return View(); 
        }

        // Modify the user product and save
        [HttpPost]
        public IActionResult EditUserProduct(ProductAndMealtimeViewModel productAndMealtimeViewModel)
        {
            return View(productAndMealtimeViewModel);
        }

        public IActionResult EditAndSaveUserProduct(ProductAndMealtimeViewModel productAndMealtimeViewModel)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("EditAndSaveUserProduct", productAndMealtimeViewModel);
            }

            // Save the user product that was modified
            _userRepository.EditAndSaveUserProduct(productAndMealtimeViewModel.MealtimeChoice, productAndMealtimeViewModel.ProductName, productAndMealtimeViewModel.Gramms, productAndMealtimeViewModel.Protein, productAndMealtimeViewModel.Fats, productAndMealtimeViewModel.Carbs, productAndMealtimeViewModel.Calories, productAndMealtimeViewModel.CatName); 

            return RedirectToAction("index");
        }
    }
}
