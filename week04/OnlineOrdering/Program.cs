using System;

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1 (USA)
        Address a1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Customer c1 = new Customer("Cam", a1);

        Order o1 = new Order(c1);
        o1.AddProduct(new Product("Protein Bar", "P100", 2.50, 4));
        o1.AddProduct(new Product("Water Bottle", "W200", 12.99, 1));

        // ORDER 2 (International)
        Address a2 = new Address("Calle 10 #5-20", "Cali", "Valle del Cauca", "Colombia");
        Customer c2 = new Customer("Maria", a2);

        Order o2 = new Order(c2);
        o2.AddProduct(new Product("Coffee Beans", "C300", 8.75, 2));
        o2.AddProduct(new Product("Mug", "M400", 6.50, 3));
        o2.AddProduct(new Product("Spoon Set", "S500", 4.00, 1));

        // DISPLAY RESULTS
        DisplayOrder(o1);
        Console.WriteLine("----------------------------------------");
        DisplayOrder(o2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order.GetTotalCost():0.00}");
    }
}
