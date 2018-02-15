using System;
using System.Configuration;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
            var repo = new ProductRepository(connectionString);

            Product product = null;
            //IProductRepository repo = new ProductRepository(Connection); 

            foreach (var prod in repo.GetProducts())
            {
                if (product == null && prod.Name == "Cody's Lame Product") { product = prod; }

                Console.WriteLine("Product Name:" + prod.Name);
            }

            if (product != null)
            {
                product.Name = "Cody's Lame Product";
                repo.UpdateProduct(product);
            }

           
            Console.ReadLine();
        }

       
    }
}
