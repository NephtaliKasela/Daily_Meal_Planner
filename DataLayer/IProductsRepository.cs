using BusinessLayer;

namespace DataLayer
{
    public interface IProductsRepository
    {
        public List<Product> GetAllProducts();
        public List<Category> GetCategoryProducts(List<Product> Products);
        public List<Product> ReadData();
    }
}