using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace ExtractMethords
{
    [TestFixture]
    public class InvoiceTests
    {
        [Test]
        public void PrintInvoice_ShouldPrintCorrectTotal()
        {
            // Arrange
            var order = new Order
            {
                CustomerName = "John Doe",
                Items = new List<Item>
            {
                new Item { Name = "Item1", Price = 10.0, Quantity = 2 },
                new Item { Name = "Item2", Price = 5.0, Quantity = 3 }
            }
            };
            var invoice = new Invoice();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                invoice.PrintInvoice(order);

                // Assert
                var expectedOutput = "Customer: John Doe\nTotal: $35\n";
                Assert.That(sw.ToString().Replace("\r", ""), Is.EqualTo(expectedOutput)); // Normalize line endings
            }
        }
    }
}