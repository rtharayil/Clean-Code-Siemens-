using System;
using System.Collections.Generic;

public class  Invoice
{
    public void PrintInvoice(Order order)
    {
        Console.WriteLine("Customer: " + order.CustomerName);

        // Extractable logic: Calculate total price
        double total = 0;
        foreach (var item in order.Items)
        {
            total += item.Price * item.Quantity;
        }

        Console.WriteLine("Total: $" + total);
    }
}

public class Order
{
    public required string CustomerName { get; set; }
    public required List<Item> Items { get; set; }
}

public class Item
{
    public required string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
