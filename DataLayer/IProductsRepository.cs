using BisinessLayer;

namespace DataLayer
{
    public interface IProductsRepository
    {
        public List<Product> GetAllFormations();
        public void ReadData(string path);
    }
}