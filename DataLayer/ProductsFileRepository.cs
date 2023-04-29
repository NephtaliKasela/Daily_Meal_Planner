using BisinessLayer;
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
        MyDBContext _context;

        public ProductsFileRepository(MyDBContext context)
        {
            _context= context;
            ReadData("xmlviewer.xml");
        }
        public ProductsFileRepository()
        {
            ReadData("xmlviewer.xml");
        }

        public void ReadData(string path)
        {
            //Créer un document XML
            XmlDocument xmlDocument = new XmlDocument();

            //Lire le fichier XML
            xmlDocument.Load(path);

            string jsonText = JsonConvert.SerializeXmlNode(xmlDocument);
            var dic = JsonConvert.DeserializeObject<IDictionary>(jsonText);

            foreach(IList d in dic.Values)
            {
                string strJsonFile = File.ReadAllText(d.ToString());
                var list = JsonConvert.DeserializeObject<IList>(jsonText);
            }
        }

        public List<Product> GetAllFormations()
        {
            return _context.Products.ToList();
        }
    }
}
