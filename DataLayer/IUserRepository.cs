using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataLayer
{
    public interface IUserRepository
    {
        public List<User> GetUser();
        public List<UserProduct> GetAllUserProducts();
        public List<UserProduct> GetUserProductsByName(string username);
        public List<UserCategory> GetCategoryProducts(List<UserProduct> Products);
        public List<UserMealtime> GetMealtimes(List<UserCategory> categories);
        public void SaveUserProduct(List<UserProduct> products, string UserNameOrEmail, string mealtimeChoice, string Name, double Gramms, double Protein, double Fats, double Carbs, double Calories, string CategoryName);
        public void EditAndSaveUserProduct(string UserNameOrEmail, string mealtimeChoice, string productName, double Gramms, double Protein, double Fats, double Carbs, double Calories, string CategoryName);

    }
}