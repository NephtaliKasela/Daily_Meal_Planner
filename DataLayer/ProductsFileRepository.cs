using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataLayer
{
    public class ProductsFileRepository : IProductsRepository
    {
        public List<Product> GetAllProducts()
        {
            List<Product> Products = new List<Product>();

            Products.Add(new Product { Id = 1, Name = "Бренди 40% алкоголя", Gramms = 100, Protein = 0.00, Fats = 0.00, Carbs = 0.50, Calories = 225, CategoryName = "Алкоголь" });
            Products.Add(new Product { Id = 2, Name = "Вермут 13% алкоголя", Gramms = 100, Protein = 0.00, Fats = 0.00, Carbs = 15.90, Calories = 158, CategoryName = "Алкоголь" });
            Products.Add(new Product { Id = 3, Name = "Вино белое 10% алкоголя", Gramms = 100, Protein = 0.00, Fats = 0.00, Carbs = 4.50, Calories = 78, CategoryName = "Алкоголь" });
            Products.Add(new Product { Id = 4, Name = "Беляши", Gramms = 100, Protein = 11.00, Fats = 10.00, Carbs = 23.20, Calories = 223, CategoryName = "Готовые блюда" });
            Products.Add(new Product { Id = 5, Name = "Блинчики с творогом и сметаной", Gramms = 100, Protein = 25.80, Fats = 33.10, Carbs = 55.20, Calories = 640, CategoryName = "Готовые блюда" });
            Products.Add(new Product { Id = 6, Name = "Белые грибы", Gramms = 100, Protein = 3.70, Fats = 1.70, Carbs = 1.10, Calories = 23, CategoryName = "Грибы" });
            Products.Add(new Product { Id = 7, Name = "Белые грибы сушеные", Gramms = 100, Protein = 20.10, Fats = 4.80, Carbs = 7.60, Calories = 152, CategoryName = "Грибы" });

            return Products;
        }

        public List<Category> GetCategoryProducts(List<Product> Products)
        {
            List<Category> categories= new List<Category>();
            int count = 1;

            // classify products by category
            foreach (Product p in Products)
            {
                bool flag = false;
                // check if category name already exist in the list
                foreach (var c in categories)
                {
                    if(p.CategoryName == c.Name)
                    {
                        c.Products.Add(p);
                        flag = true;
                        break;
                    }
                }
                // otherwise create an other category 
                if(flag == false)
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
            //Créer un document XML
            XmlDocument xmlDocument = new XmlDocument();

            //Lire le fichier XML
            xmlDocument.Load(path);
            //string s = xmlDocument.ToString();

            string jsonText = JsonConvert.SerializeXmlNode(xmlDocument);
            string chemin = @"C:\\Nephterland\\COURSES\\PROGRAMMING\\UNIVERSITY\\VsProjets\\C_Sharp\\Web\\Daily_Meal_Planner\\Daily_Meal_Planner\\bin\\Debug\\net6.0\\Test\\test.txt";
            string chemin2 = @"C:\\Nephterland\\COURSES\\PROGRAMMING\\UNIVERSITY\\VsProjets\\C_Sharp\\Web\\Daily_Meal_Planner\\Daily_Meal_Planner\\bin\\Debug\\net6.0\\Test\\test2.txt";
            string chemin3 = @"C:\\Nephterland\\COURSES\\PROGRAMMING\\UNIVERSITY\\VsProjets\\C_Sharp\\Web\\Daily_Meal_Planner\\Daily_Meal_Planner\\bin\\Debug\\net6.0\\Test\\test3.txt";
            
            chemin = chemin.Replace(@"\\", "/");
            chemin2 = chemin2.Replace(@"\\", "/");
            chemin3 = chemin3.Replace(@"\\", "/");
            File.WriteAllText(chemin, jsonText);

            string[] ss = jsonText.Split("Category");
            File.WriteAllText(chemin2, "");
            foreach (string ss2 in ss)
            {
                File.AppendAllText(chemin2, ss2 + "\n\n");
            }

            var dic = JsonConvert.DeserializeObject<IDictionary>(jsonText);

            foreach (IList d in dic.Values)
            {
                string strJsonFile = d.ToString();
                //var list = JsonConvert.DeserializeObject<IList>(jsonText);
                File.AppendAllText(chemin3, strJsonFile + "\n\n");
            }

            //StreamReader reader = new StreamReader(jsonText);
            //while (!reader.EndOfStream)
            //{
            //    string line = reader.ReadLine();
            //    File.AppendAllText("Test/test.txt", line + "\n\n");
            //}

        }

        
    }
}
