using BusinessLayer;
using Daily_Meal_Planner.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

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
            //ProductsFileRepository r = new ProductsFileRepository();
            //r.ReadData();



            List<Product> products = new List<Product>();
            products = _productRepository.GetAllProducts();

            var vm = new AllProductsViewModel();
            vm.Categories = _productRepository.GetCategoryProducts(products);

            // get all names of category products
            foreach(var categoryName in vm.Categories)
            {
                vm.CategoryList.Add(categoryName.Name);
            }

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