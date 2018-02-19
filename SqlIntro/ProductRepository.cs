using System;
using System.Collections.Generic;
using System.Data;

namespace SqlIntro
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = _conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Name FROM product"; //TODO:  Write a SELECT statement that gets all products
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Name = dr["Name"].ToString() };
                }
            }
        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            using (var conn = _conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM product WHERE ProductId = @Id";
                cmd.AddParamWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            //This is annoying and unnecessarily tedious for large objects.
            //More on this in the future...  Nothing to do here..
            using (var conn = _conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE product SET name = @name WHERE ProductId = @Id";
                cmd.AddParamWithValue("@name", prod.Name);
                cmd.AddParamWithValue("@id", prod.Id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            using (var conn = _conn)
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO product (name) values(@name)";
                cmd.AddParamWithValue("@name", prod.Name);
                cmd.ExecuteNonQuery();

                Console.ReadKey();
            }
        }

        public IEnumerable<Product> GetProductsWithReview()
        {
            using (var conn = _conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Name, Rating FROM product INNER JOIN productreview ON product.ProductID = productreview.ProductID";

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Name = dr["Rating"].ToString() };
                }
            }
        }

        public IEnumerable<Product> GetProductsAndReviews()
        {
            using (var conn = _conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Name, Rating FROM product LEFT JOIN productreview ON product.ProductID = productreview.ProductID";

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Name = dr["Rating"].ToString() };
                }
            }
        }
    }
}