using UniSelector.Models;

namespace UniSelector.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        public  void Update(Product obj);
    }
}
