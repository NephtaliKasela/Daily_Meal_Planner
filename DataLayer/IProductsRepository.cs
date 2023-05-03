using BusinessLayer;

namespace DataLayer
{
    public interface IProductsRepository
    {
        public List<Product> GetAllProducts();
        public void ReadData(string path);
    }
}