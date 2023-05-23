using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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

        public List<Product> ReadData()
        {
            //Créer un document XML
            //XmlDocument xmlDocument = new XmlDocument();

            //Lire le fichier XML
            //xmlDocument.Load(path);
            //string s = xmlDocument.ToString();

            //string jsonText = JsonConvert.SerializeXmlNode(xmlDocument);

            List<Product> products = new List<Product>();

            string chemin = @"C:\Nephterland\COURSES\PROGRAMMING\UNIVERSITY\VsProjets\C_Sharp\Web\Folder\Daily_Meal_Planner\DataLayer\bin\Debug\net6.0\DM_Products\products.json";

            chemin = chemin.Replace(@"\", "/");
            string[] arr = chemin.Split("/");
            string jsonFile = arr[arr.Length - 2] + "/" + arr[arr.Length -1];
         

            var stream = File.OpenText(chemin);
            string jsonArray = stream.ReadToEnd();

            var result = JsonConvert.DeserializeObject<IList>(jsonArray);

            foreach (IList r in result)
            {
                string categoryName = string.Empty;
                
                string str = r.ToString();
                var jsonStr = JsonConvert.DeserializeObject<IDictionary>(str);

                foreach(DictionaryEntry r1 in jsonStr)
                {
                    if (r1.Key.ToString() == "@name")
                    {
                        categoryName = r1.Value.ToString();
                    }
                    else if (r1.Key.ToString() == "Product")
                    {
                        string str2 = r1.Value.ToString();
                        var jsonStr2 = JsonConvert.DeserializeObject<IList>(str2);

                        foreach (var r2 in jsonStr2)
                        {
                            Product product = new Product();

                            string str3 = r2.ToString();
                            var jsonStr3 = JsonConvert.DeserializeObject<IDictionary>(str3);
                            
                            product.CategoryName = categoryName;

                            foreach(DictionaryEntry prod in jsonStr3)
                            {
                                if (prod.Key.ToString() == "Name")
                                {
                                    product.Name = prod.Value.ToString();
                                }
                                else if (prod.Key.ToString() == "Gramms")
                                {
                                    product.Gramms = double.Parse(prod.Value.ToString());
                                }
                                else if (prod.Key.ToString() == "Protein")
                                {
                                    product.Protein = double.Parse(prod.Value.ToString());
                                }
                                else if (prod.Key.ToString() == "Fats")
                                {
                                    product.Fats = double.Parse(prod.Value.ToString());
                                }
                                else if (prod.Key.ToString() == "Carbs")
                                {
                                    product.Carbs = double.Parse(prod.Value.ToString());
                                }
                                else if (prod.Key.ToString() == "Calories")
                                {
                                    product.Calories = double.Parse(prod.Value.ToString());
                                }
                            }
                            products.Add(product);
                        }
                    }
                }  
            }
            return products;
        }

        
    }
}
