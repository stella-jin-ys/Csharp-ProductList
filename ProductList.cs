public class ProductList
{
    // properties
    public string Category { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    // constructor
    public ProductList(string category, string name, double price)
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