using System.Collections.Generic;

namespace SqlIntro
{
    public interface IProductRepository
    {
        void DeleteProduct(int id);
        IEnumerable<Product> GetProducts();
        void InsertProduct(Product prod);
        void UpdateProduct(Product prod);
    }
}