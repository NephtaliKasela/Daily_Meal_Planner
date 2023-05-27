using Daily_Meal_Planner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

using BusinessLayer;
using DataLayer;
using ServiceLayer;

namespace Daily_Meal_Planner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IProductsRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductsRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index(string catName)
        {
            // Get all products from the database
            List<Product> products = new List<Product>();
            products = _productRepository.GetAllProducts();

            // Assign the view model
            var vm = new AllProductsViewModel();
            vm.Categories = _productRepository.GetCategoryProducts(products);

            // Get all names of category products
            Prod_Operation operation = new Prod_Operation();
            vm.CategoryList = operation.GetCategoryName(vm.Categories);

            // Get the category name choosen by the user
            vm.CatName = catName;

            return View(vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}