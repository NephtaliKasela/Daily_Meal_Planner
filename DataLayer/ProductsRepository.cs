using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductsRepository: IProductsRepository
    {
        MyDBContext _context;
        public ProductsRepository(MyDBContext context)
        {
            _context= context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Where(p => p.State == true).ToList();
        }

        public List<Category> GetCategoryProducts(List<Product> Products)
        {
            List<Category> categories = new List<Category>();
            int count = 1;

            // classify products by category
            foreach (Product p in Products)
            {
                bool flag = false;
                // check if category name already exist in the list
                foreach (var c in categories)
                {
                    if (p.CategoryName == c.Name)
                    {
                        c.Products.Add(p);
                        flag = true;
                        break;
                    }
                }
                // otherwise create an other category 
                if (flag == false)
                {
                    Category cat = new Category();
                    cat.Id = count;
                    cat.Name = p.CategoryName;

                    cat.Products = new List<Product>();
                    cat.Products.Add(p);

                    count++;
                    categories.Add(cat);
                }
            }
            return categories;
        }

        public void ReadData(string path)
        {
        }
    }
}
