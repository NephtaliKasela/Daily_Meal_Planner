using BusinessLayer;
using Daily_Meal_Planner.Models;
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

        public IActionResult Index(string mealtimeChoice, string categoryChoice)
        {
            List<UserProduct> products = _userRepository.GetAllUserProducts();
            List<UserCategory> categories = _userRepository.GetCategoryProducts(products);
            List<UserMealtime> mealtimes = _userRepository.GetMealtimes(categories);

            var vm = new UserMealtimeViewModel();
            vm.Mealtimes = mealtimes;

            // Get all mealtime names
            foreach (UserMealtime m in mealtimes)
            {
                vm.MealtimeNames.Add(m.MealtimeName);

                if(m.MealtimeName == mealtimeChoice)
                {
                    foreach(UserCategory uc in m.Categories)
                    {
                        //if(uc.Name == categoryChoice)
                        //{
                        //    // get progress bar by category 
                        //    foreach (UserProduct up in uc.Products)
                        //    {
                        //        vm.ProgressBar += (int)(up.Protein + up.Fats + up.Carbs + up.Calories);
                        //    }

                        //}

                        // get progress bar by mealtime
                        foreach (UserProduct up in uc.Products)
                        {
                            vm.ProgressBar += (int)(up.Protein + up.Fats + up.Carbs + up.Calories);
                        }
                    }
                }
            }

            // Get all category names
            foreach (UserCategory c in categories)
            { 
                if(!vm.CategoryNames.Contains(c.Name))
                {
                    vm.CategoryNames.Add(c.Name);
                }
            }
            
            vm.MealtimeChoice = mealtimeChoice;
            vm.CategoryChoice = categoryChoice;

            return View(vm);
        }

        public IActionResult EditUserProduct(ProductAndMealtimeViewModel productAndMealtimeViewModel)
        {
            return View(productAndMealtimeViewModel);
        }

        public IActionResult EditAndSaveUserProduct(ProductAndMealtimeViewModel productAndMealtimeViewModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userRepository.EditAndSaveUserProduct(productAndMealtimeViewModel.MealtimeChoice, productAndMealtimeViewModel.ProductName, productAndMealtimeViewModel.Gramms, productAndMealtimeViewModel.Protein, productAndMealtimeViewModel.Fats, productAndMealtimeViewModel.Carbs, productAndMealtimeViewModel.Calories, productAndMealtimeViewModel.CatName); 

            return View();
        }
    }
}
