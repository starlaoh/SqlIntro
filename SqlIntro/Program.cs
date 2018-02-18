using System;
using System.Configuration;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
            var repo = new DapperProjectRepository(connectionString);

            Product product = null;

            foreach (var prod in repo.GetProducts())
            {
                if (product == null ) { product = prod; }

                Console.WriteLine("Product Name:" + prod.Name);
            }

            foreach (var rate in repo.GetProductsWithReview())
            {
                if (product == null) { product = rate; }

                Console.WriteLine("Product Name:" + rate.Name + "Rating:" + rate.Rating);
            }

            foreach (var prod in repo.GetProductsAndReviews())
            {
                if (product == null) { product = prod; }

                Console.WriteLine("Product Name:" + prod.Name);
            }
            
            Console.ReadLine();
        }
    }
}
