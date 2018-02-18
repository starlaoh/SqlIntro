using System.Collections.Generic;

namespace SqlIntro
{
    public interface IProductRepository 
    {
        void DeleteProduct(int id);
        void InsertProduct(Product prod);
        void UpdateProduct(Product prod);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsWithReview();
        IEnumerable<Product> GetProductsAndReviews();
    }

}