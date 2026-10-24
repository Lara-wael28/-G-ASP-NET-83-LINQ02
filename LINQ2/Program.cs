namespace LINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> ProductList = new List<Product>
            {
                new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18, UnitsInStock = 39 },
                new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19, UnitsInStock = 17 },
                new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10, UnitsInStock = 13 },
                new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22, UnitsInStock = 0 },
                new Product { ProductID = 5, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31, UnitsInStock = 20 },
                new Product { ProductID = 6, ProductName = "Tofu", Category = "Produce", UnitPrice = 23, UnitsInStock = 15 },
                new Product { ProductID = 7, ProductName = "Pavlova", Category = "Confections", UnitPrice = 17, UnitsInStock = 0 },
                new Product { ProductID = 8, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97, UnitsInStock = 5 },
                new Product { ProductID = 9, ProductName = "Alice Mutton", Category = "Meat/Poultry", UnitPrice = 39, UnitsInStock = 12 },
                new Product { ProductID = 10, ProductName = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18, UnitsInStock = 25 }
            };
            //q3 part1 
            var result001 = ProductList
                              .OrderBy(p => p.UnitPrice);
            foreach (var p in result001)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            }

            //q8 part1
            var result002 = ProductList
                        .OrderBy(p => p.Category)
                        .ThenByDescending(p => p.UnitPrice);

            foreach (var p in result002)
            {
                Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");
            }

            //q9 part1
            var result003 = ProductList
                        .Where(p => p.Category == "Beverages")
                        .OrderByDescending(p => p.UnitsInStock);

            foreach (var p in result003)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");
            }

            //q12 part1
            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var result004 = Arr
                    .OrderBy(s => s.Length)
                    .ThenBy(s => s, StringComparer.OrdinalIgnoreCase);
            foreach (var word in result004)
            {
                Console.WriteLine(word);
            }

            //q13 part1
            var result006 = Arr
                        .Where(s => s.Length > 1 && s[1] == 'i')
                        .Reverse()
                        .ToList();
            foreach (var item in result006)
            {
                Console.WriteLine(item);
            }

            //q1 part2
            var result = ProductList.OrderByDescending(p => p.UnitPrice)
                                    .Take(3);
            foreach (var product in result)
            {
                Console.WriteLine(product);
            }

            //q2 part2
            int pageSize = 5;
            int pageNumber = 2;

            var result02 = ProductList
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize);

            foreach (var p in result02)
            {
                Console.WriteLine(p.ProductName);
            }

            //q3 part2
             var result03 = ProductList
                            .OrderBy(p => p.UnitPrice)
                            .TakeWhile(p => p.UnitPrice < 25);

            foreach (var p in result03)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            }

            //q4 part2
            var result04 = ProductList
                            .Where(p => p.Category == "Seafood")
                            .All(p => p.UnitsInStock > 0);

            Console.WriteLine(result04);

            //q5 part2
            int[] ids = { 3, 9, 13, 18 };
            var result05 = ids.Contains(9);
            Console.WriteLine(result05);

            //q6 part2
            var result06 = ProductList
                             .GroupBy(p => p.Category);

            foreach (var group in result06)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }

            //q7 part2
            var result07 = ProductList
                    .GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        ProductNames = g.Select(p => p.ProductName)
                    });
            foreach (var group in result07)
            {
                Console.WriteLine(group.Category);

                foreach (var name in group.ProductNames)
                {
                    Console.WriteLine(name);
                }
            }

            //q8 part2
            var result08 = ProductList
                    .GroupBy(p => p.Category)
                    .Where(g => g.Count() > 3)
                    .Select(g => g.Key);
            foreach (var category in result08)
            {
                Console.WriteLine(category);
            }

            //q9 part2
            var result09 =  from c in Customer
                            group c by c.Country into g
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count(),
                                TotalOrderValue = g
                                    .SelectMany(c => c.Orders)
                                    .Sum(o => o.TotalOrderValue)
                            };

            foreach (var item in result09)
            {
                Console.WriteLine(
                    $"{item.Country} - {item.Count} - {item.TotalOrderValue}");
            }

            //q10 part2
            var result10 = ProductList
                         .Sum(p => p.UnitsInStock);
            Console.WriteLine(result10);

            //q11 part2
            var cheapest = ProductList
                    .Min(p => p.UnitPrice);

            var expensive = ProductList
                    .Max(p => p.UnitPrice);
            Console.WriteLine($"Cheapest: {cheapest}");
            Console.WriteLine($"Most Expensive: {expensive}");

            //q12 part2
            var result12 = ProductList
                    .Select(p => p.Category)
                    .Distinct();
            foreach (var category in result)
            {
                Console.WriteLine(category);
            }

            //q13 part2
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };
            var result13 = setA.Except(setB);
            foreach (var id in result13)
            {
                Console.WriteLine(id);
            }

            //q14 part2
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };
            var result14 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

            //q15 part2

            //q16 part2
            var result16 = ProductList
                           .First(p => p.UnitPrice > 50);
            Console.WriteLine($"{result16.ProductName} - {result16.UnitPrice}");

            //q17 part2
            var result17 = ProductList
                           .FirstOrDefault(p => p.UnitPrice > 500);
            if (result17 != null)
            {
                Console.WriteLine($"{result17.ProductName} - {result17 .UnitPrice}");
            }
            else
            {
                Console.WriteLine("No product found");
            }

            //q18 part2

            //q19 part2
            var result19 = Enumerable.Range(1, 30)
                       .Where(n => n % 2 == 0);
            foreach (var number in result19)
            {
                Console.WriteLine(number);
            }

            //q20
            var result20 = ProductList
                    .Take(3)
                    .Select(p => p.ProductName)
                    .Concat( Customer.Take(3).Select(c => c.CompanyName));
            foreach (var name in result20)
            {
                Console.WriteLine(name);
            }

            //21
            var result21 = ProductList
                    .Select(p => p.ProductName)
                    .Zip(
                        Customer.Select(c => c.CompanyName),
                        (productName, companyName) =>
                            $"{productName} sold to {companyName}"
                    );

            foreach (var item in result21)
            {
                Console.WriteLine(item);
            }

        }
    }
}
