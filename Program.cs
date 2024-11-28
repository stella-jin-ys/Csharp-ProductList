using System.Linq;

public class ProductList
{
    // properties
    public string Category { get; set; }
    public string ProductName { get; set; }
    public int Price { get; set; }

    // constructor
    public ProductList(string category, string name, int price)
    {
        Category = category;
        ProductName = name;
        Price = price;
    }
    // method

    public void Print()
    {
        Console.WriteLine($"{Category.PadRight(30)}{ProductName.PadRight(30)}{Price.ToString().PadRight(30)}");

    }

}

class Program
{
    static void Main()
    {
        List<ProductList> productList = new List<ProductList>();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("To enter a new product- follow the steps | To quite - enter:'Q'");
            Console.ResetColor();

            Console.Write("Enter a category: ");
            string categoryInput = Console.ReadLine();
            if (categoryInput.ToUpper().Trim() == "Q")
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Category".PadRight(30) + "Product".PadRight(30) + "Price".PadRight(30));
                Console.ResetColor();

                // Sort products by price in ascending order
                productList.Sort((x, y) => x.Price.CompareTo(y.Price)); // Lambda for comparison
                foreach (var product in productList)
                {
                    product.Print();

                }
                int totalPrice = productList.Sum(product => product.Price)
; Console.WriteLine("\n" + "".PadRight(30) + "Total amount: ".PadRight(30) + totalPrice);
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("To enter a new product - enter: 'P' | To search for a product - enter: 'S' | To quit - enter: 'Q'");
                Console.ResetColor();
                break;
            }

            Console.Write("Enter a Product Name: ");
            string productNameInput = Console.ReadLine();

            Console.Write("Enter a Price: ");
            int.TryParse(Console.ReadLine(), out int priceInput);

            productList.Add(new ProductList(categoryInput, productNameInput, priceInput));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product was successfully added!");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}

