using System.Linq;

public class Program
{
    List<ProductList> productList = new List<ProductList>();
    public void AddProduct()
    {
        Console.Write("Enter a category: ");
        string categoryInput = Console.ReadLine().ToLower().Trim();
        if (categoryInput.ToUpper().Trim() == "Q")
        {
            ShowProductList();
            return;
        }

        Console.Write("Enter a Product Name: ");
        string productNameInput = Console.ReadLine().ToLower().Trim();

        Console.Write("Enter a Price: ");
        int.TryParse(Console.ReadLine(), out int priceInput);

        productList.Add(new ProductList(categoryInput, productNameInput, priceInput));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product was successfully added!");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ResetColor();
    }
    public void SearchProduct()
    {
        Console.Write("Enter a product name to search: ");
        string name = Console.ReadLine().ToLower().Trim();
        var searchedProduct = productList.FirstOrDefault(p => p.ProductName == name);
        if (searchedProduct != null)
        {
            ShowProductList(searchedProduct.ProductName);
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
    public void ShowProductList(string searchedProduct = null)
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Category".PadRight(30) + "Product".PadRight(30) + "Price".PadRight(30));
        Console.ResetColor();

        // Sort products by price in ascending order
        productList.Sort((x, y) => x.Price.CompareTo(y.Price)); // Lambda for comparison
        foreach (var product in productList)
        {
            if (!string.IsNullOrEmpty(searchedProduct) && product.ProductName.Equals(searchedProduct))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                product.Print();
                Console.ResetColor();
            }
            else
            {
                product.Print();
            }

        }
        int totalPrice = productList.Sum(product => product.Price)

; Console.WriteLine("\n" + "".PadRight(30) + "Total amount: ".PadRight(30) + totalPrice);
        Console.WriteLine("----------------------------------------------------------------------");

        while (true)
        {

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("To enter a new product - enter: 'P' | To search for a product - enter: 'S' | To quit - enter: 'Q'");
            Console.ResetColor();

            string userInput = Console.ReadLine().ToUpper().Trim();

            switch (userInput)
            {
                case "S":
                    SearchProduct();
                    return;
                case "P":
                    AddProduct();
                    return;
                case "Q":
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Please enter a valid options");
                    break;
            }
        }

    }
    public static void Main()
    {
        Program program = new Program();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("To enter a new product- follow the steps | To quite - enter:'Q'");
            Console.ResetColor();

            program.AddProduct();
        }
    }
}

