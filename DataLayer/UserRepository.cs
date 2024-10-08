﻿using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            return _context.UserProducts.Where(p => p.State == true).ToList();
        }

        public List<UserProduct> GetUserProductsByName(string username)
        {
            return _context.UserProducts.Where(p => p.UserName == username && p.State == true).ToList();
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

        public List<UserMealtime> GetMealtimes(List<UserCategory> categories)
        {
            List<UserMealtime> mealtimes = new List<UserMealtime>();
            int count = 1;

            // classify products by category
            foreach (UserCategory c in categories)
            {
                bool flag = false;
                // check if mealtime name already exist in the list
                foreach (UserMealtime m in mealtimes)
                {
                    if (c.Mealtime == m.MealtimeName)
                    {
                        m.Categories.Add(c);
                        flag = true;
                        break;
                    }
                }
                // otherwise create an other mealtime 
                if (flag == false)
                {
                    UserMealtime mealT = new UserMealtime();
                    mealT.Id = count;
                    mealT.MealtimeName = c.Mealtime;

                    mealT.Categories = new List<UserCategory>();
                    mealT.Categories.Add(c);

                    count++;
                    mealtimes.Add(mealT);
                }
            }
            return mealtimes;
        }

        public void SaveUserProduct(List<UserProduct> products, string UserNameOrEmail, string mealtimeChoice, string productName, double Gramms, double Protein, double Fats, double Carbs, double Calories, string CategoryName)
        {
            UserProduct prod = new UserProduct();

            prod.UserName = UserNameOrEmail;
            prod.UserEmail = UserNameOrEmail;
            prod.UserId = 0;
            prod.Mealtime = mealtimeChoice;
            prod.ProductName = productName;
            prod.Gramms = Convert.ToDouble(Gramms);
            prod.Protein = Convert.ToDouble(Protein);
            prod.Fats = Convert.ToDouble(Fats);
            prod.Carbs = Convert.ToDouble(Carbs);
            prod.Calories = Convert.ToDouble(Calories);
            prod.CategoryName = CategoryName;
            prod.State = true;

            // Add the product
            // Check if the product is already in the user products list
            int flag = 0;
            foreach(UserProduct up in _context.UserProducts)
            {
                flag = 1;
                if((up.Mealtime != mealtimeChoice && up.CategoryName != CategoryName) || (up.Mealtime == mealtimeChoice && up.CategoryName != CategoryName))
                {
                    _context.UserProducts.Add(prod);
                    flag = 2;
                    break;
                }
            }
            if (flag == 0)
            {
                _context.UserProducts.Add(prod);
            }
            _context.SaveChanges();
        }

        public void EditAndSaveUserProduct(string UserNameOrEmail, string mealtimeChoice, string productName, double Gramms, double Protein, double Fats, double Carbs, double Calories, string CategoryName)
        {
            List<UserProduct> user_products = new List<UserProduct>();
            user_products = _context.UserProducts.Where(p => p.UserName == UserNameOrEmail).ToList();
            UserProduct prod = new UserProduct();
            foreach(UserProduct up in user_products)
            {
                if(up.Mealtime == mealtimeChoice && up.CategoryName == CategoryName && up.ProductName == productName)
                {
                    up.Gramms = Gramms;
                    up.Protein = Protein;
                    up.Fats= Fats;
                    up.Carbs= Carbs;
                    up.Calories= Calories;

                    break;
                }
            }
            _context.SaveChanges();
        }
    }
}
