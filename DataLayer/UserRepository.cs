using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace DataLayer
{
    public class UserRepository : IUserRepository
    {
        MyDBContext _context;
        public UserRepository(MyDBContext context)
        {
            _context = context;
        }

        public List<User> GetUser()
        {
            return _context.Users.ToList();
        }

        public List<UserProduct> GetAllUserProducts()
        {
            return _context.UserProducts.ToList();
        }

        public List<UserProduct> GetUserProductsByName(string username)
        {
            return _context.UserProducts.Where(p => p.UserName == username).ToList();
        }

        public List<UserCategory> GetCategoryProducts(List<UserProduct> Products)
        {
            List<UserCategory> categories = new List<UserCategory>();
            int count = 1;

            // classify products by category
            foreach (UserProduct p in Products)
            {
                bool flag = false;
                // check if category name already exist in the list
                foreach (UserCategory uc in categories)
                {
                    if (p.CategoryName == uc.Name && p.Mealtime == uc.Mealtime)
                    {
                        uc.Products.Add(p);
                        flag = true;
                        break;
                    }
                }
                // otherwise create an other category 
                if (flag == false)
                {
                    UserCategory cat = new UserCategory();
                    cat.Id = count;
                    cat.Name = p.CategoryName;
                    cat.Mealtime = p.Mealtime;

                    cat.Products = new List<UserProduct>();
                    cat.Products.Add(p);

                    count++;
                    categories.Add(cat);
                }
            }
            return categories;
        }


        public void SaveUserProduct(List<UserProduct> products, string mealtimeChoice, string productName, double Gramms, double Protein, double Fats, double Carbs, double Calories, string CategoryName)
        {
            UserProduct prod = new UserProduct();

            prod.UserName = "Unknown";
            prod.UserId = 0;
            prod.Mealtime = mealtimeChoice;
            prod.ProductName = productName;
            prod.Gramms = Convert.ToDouble(Gramms);
            prod.Protein = Convert.ToDouble(Protein);
            prod.Fats = Convert.ToDouble(Fats);
            prod.Carbs = Convert.ToDouble(Carbs);
            prod.Calories = Convert.ToDouble(Calories);
            prod.CategoryName = CategoryName;

            _context.UserProducts.Add(prod);
            _context.SaveChanges();
        }


        
        //public List<UserMealtime> GetMealtimes(List<UserCategory> categories)
        //{
        //    List<UserMealtime> mealtimes = new List<UserMealtime>();
        //    int count = 1;

        //    // classify products by category
        //    foreach (UserMealtime c in categories)
        //    {
        //        bool flag = false;
        //        // check if category name already exist in the list
        //        foreach (UserCategory m in mealtimes)
        //        {
        //            if (c.Mealtime == m.Name)
        //            {
        //                uc.Products.Add(p);
        //                flag = true;
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}
