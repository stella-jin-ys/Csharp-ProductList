

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
        Console.WriteLine($"{Category},{ProductName},{Price}");
    }
    public static void Main()
    {
        List<ProductList> productList = new List<ProductList>();

        while (true)
        {
            Console.WriteLine("To enter a new product- follow the steps | To quite - enter:'Q'");

            Console.Write("Enter a category: ");
            string categoryInput = Console.ReadLine();
            if (categoryInput.ToUpper().Trim() == "Q")
            {
                break;
            }
            Console.Write("Enter a Product Name: ");
            string productNameInput = Console.ReadLine();
            if (productNameInput.ToUpper().Trim() == "Q")
            {
                break;
            }
            Console.Write("Enter a Price: ");
            int.TryParse(Console.ReadLine(), out int priceInput);
            if (productNameInput.ToUpper().Trim() == "Q")
            {
                break;
            }
            productList.Add(new ProductList(categoryInput, productNameInput, priceInput));
            Console.WriteLine("The product was successfully added");
            break;

        }

    }
}