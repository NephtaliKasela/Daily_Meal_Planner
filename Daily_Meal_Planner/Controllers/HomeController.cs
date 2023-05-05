using BusinessLayer;
using Daily_Meal_Planner.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Daily_Meal_Planner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string catName)
        {
            ProductsFileRepository prod = new ProductsFileRepository();
            List<Product> products = new List<Product>();
            products = prod.GetAllProducts();

            var vm = new AllProductsViewModel();
            vm.Categories = prod.GetCategoryProducts(products);

            // get all names of category products
            vm.CategoryList = new List<string>();
            foreach(var categoryName in vm.Categories)
            {
                vm.CategoryList.Add(categoryName.Name);
            }

            vm.CatName = catName;

            return View(vm);
        }

        public IActionResult Mealtime()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}