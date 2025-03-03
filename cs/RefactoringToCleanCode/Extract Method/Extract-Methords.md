
# **Refactoring: Extract Method**  
---
## **What is Extract Method?**  
Extract Method is a refactoring technique that improves code readability and maintainability by moving a block of code into a separate method. This helps reduce duplication, enhance modularity, and improve testability.  

## **When to Use Extract Method?**  
- A method is too long or does too many things.  
- A block of code is repeated in multiple places.  
- The method has multiple levels of abstraction, making it hard to read.  
- A piece of logic has a distinct responsibility and could be reused.  

## **Steps to Extract a Method**  
1. **Identify** the block of code that should be extracted.  
2. **Create a new method** with a meaningful name that describes what it does.  
3. **Move the selected code** into the new method.  
4. **Replace the original code** with a call to the new method.  
5. **Ensure correctness** by testing the refactored code.  

## **Example in C#**  

### **Before Refactoring**  
```csharp
using System;
using System.Collections.Generic;

class Invoice
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

class Order
{
    public string CustomerName { get; set; }
    public List<Item> Items { get; set; }
}

class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
```

### **After Extracting Method**  
```csharp
using System;
using System.Collections.Generic;

class Invoice
{
    public void PrintInvoice(Order order)
    {
        Console.WriteLine("Customer: " + order.CustomerName);
        double total = CalculateTotal(order);
        Console.WriteLine("Total: $" + total);
    }

    private double CalculateTotal(Order order)
    {
        double total = 0;
        foreach (var item in order.Items)
        {
            total += item.Price * item.Quantity;
        }
        return total;
    }
}

class Order
{
    public string CustomerName { get; set; }
    public List<Item> Items { get; set; }
}

class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
```

## **Benefits of Extract Method**  
✅ **Improved Readability** – The method is easier to read and understand.  
✅ **Better Reusability** – The extracted method can be reused in other parts of the code.  
✅ **Easier Testing** – The new method can be tested separately.  
✅ **Simplifies Debugging** – Isolating logic helps in debugging and future modifications.  

---
