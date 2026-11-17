using LINQ.DataSources;
using linq02.Models;
using System.Security.Cryptography.X509Certificates;
namespace linq02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = Source.ProductList;
            List<Customer> customers = Source.CustomerList;

            /*Q1*/
            List<Product> Top3 = products.OrderByDescending(p => p.UnitPrice).Take(3).ToList();

            foreach (Product p in Top3)
            { Console.WriteLine(p.ProductName + " " + p.UnitPrice); }
            spacing();
            /*Q2*/
            List<Product> page2 = products.Skip(5).Take(5).ToList();

            /*Q3*/
            List<Product> lessThan25 = products.Where(p => p.UnitPrice < 25).OrderBy(p => p.UnitPrice).ToList();

            /*Q4*/

            bool isAllSeaFoodInStock = !products.Where(p => p.Category == "SeaFood").Any(x => x.UnitsInStock == 0);

            Console.WriteLine(isAllSeaFoodInStock);
            spacing();
            /*Q5*/
            int[] ids = { 3, 9, 13, 18 };

            bool IsThere9 = ids.Any(x => x == 9);

            Console.WriteLine(IsThere9);

            /*Q6*/
            spacing();
            List<IGrouping<string, Product>> GroupProduct = products.GroupBy(products => products.Category).ToList();

            foreach (var G in GroupProduct)
            {
                Console.WriteLine($"{G.Key} = {G.Count()}");

            }

            Console.WriteLine("Total Products:" + products.Count());
            spacing();
            /*Q7*/
            foreach (var G in GroupProduct)
            {
                Console.WriteLine("product Category:" + G.Key + "\nitems:");
                foreach (var item in G)
                {
                    Console.WriteLine(item.ProductName);
                }
                Console.WriteLine("-------------------");


            }
            spacing();


            /*Q8*/
            List<IGrouping<string, Product>> GroupProductFilter = products.GroupBy(x => x.Category).Where(r => r.Count() > 3).ToList();

            foreach (var G in GroupProductFilter)
            {
                Console.WriteLine($"{G.Key} = {G.Count()}");

            }
            spacing();

            /*Q9*/

            /*Q10*/
            int CountProductInStock = products.Sum(x => x.UnitsInStock);

            Console.WriteLine(CountProductInStock);
            spacing();

            /*Q11*/
            Product CheapestProduct = products.MinBy(x => x.UnitPrice);
            Product MostExpensiveProduct = products.MaxBy(x => x.UnitPrice);
            Console.WriteLine("Cheapest Product:" + CheapestProduct.ProductName);
            Console.WriteLine("Most expensive Product:" + MostExpensiveProduct.ProductName);
            spacing();
            /*Q12*/
            List<string> ProductCategoreis = products.Select(x => x.Category).Distinct().ToList();

            Console.WriteLine("categories:");
            foreach (var C in ProductCategoreis)
            {
                Console.WriteLine(C);
            }

            spacing();

            /*Q13*/
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            List<int> UniqueInSetA = setA.Except(setB).ToList();

            foreach (var A in UniqueInSetA)
            { Console.WriteLine(A); }

            spacing();

            /*Q14*/

            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            List<string> UniqueCountry = list1
                                        .Select(x => String.Format(x).ToLower())
                                        .Except(
                                            list2.Select(x => String.Format(x).ToLower()))
                                        .ToList();
            foreach(var c in UniqueCountry)
            { Console.WriteLine(c); }

            spacing();
            /*Q15*/
            Dictionary<int,Product> productDictionary=products.ToDictionary(x => x.ProductID);
            Console.WriteLine(productDictionary[18]);

            spacing();

            /*Q16*/
            Product? firstMoreThan50 = products.FirstOrDefault(x => x.UnitPrice > 50);
            Console.WriteLine(firstMoreThan50);
            spacing();
            /*Q17*/
            Product? firstMoreThan500 = products.FirstOrDefault(x => x.UnitPrice > 500);
            Console.WriteLine(firstMoreThan50);
            spacing();
            /*Q18*/
            List<string> result = Enumerable.Range(1, 10)
                                            .Select(x => $"7 x {x} = {7 * x}")
                                            .ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            spacing();
            /*Q19*/
            var evenNumbers = Enumerable.Range(1, 30)
                                        .Where(x => x % 2 == 0);

            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }
            spacing();
            /*Q20*/

            List<string> productsAndCompanies = products
                                            .Take(3)
                                            .Select(p => p.ProductName)
                                            .Concat(customers.Take(3).Select(c => c.CustomerName))
                                            .ToList();

            foreach (string item in productsAndCompanies)
            {
                Console.WriteLine(item);
            }
            spacing();

            /*Q21*/
            List<string> Report= products.Zip(customers,(product, customer) 
                =>$"{product.ProductName} sold to {customer.CustomerName}").ToList();

            foreach (var item in Report)
            {
                Console.WriteLine(item);
            }

        }

        public static void spacing()
        { Console.WriteLine("===================================="); }


    }
}
