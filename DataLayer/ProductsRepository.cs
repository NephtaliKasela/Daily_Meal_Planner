using BisinessLayer;
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

        public List<Product> GetAllFormations()
        {
            return _context.Products.ToList();
        }
        public void ReadData(string path)
        {

        }

        //public List<Formation> GetFormations(int number)
        //{
        //    return _context.Formations.Include("Avis").OrderBy(qu => Guid.NewGuid()).Take(number).ToList();
        //}

        //public Formation GetFormationById(int iIdFormation)
        //{
        //    return _context.Formations.Include("Avis").FirstOrDefault(f => f.Id == iIdFormation);
        //}
    }
}
