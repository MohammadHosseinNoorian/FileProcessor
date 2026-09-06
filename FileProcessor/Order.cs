using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessor;

public class Order
{
    public int Id { get; set; }
    public User Customer { get; set; }
    public DateTime Date { get; set; }
    public List<Product> Products { get; set; } 
    public Order(int id, User cust, DateTime date, List<Product> products)
    {
        Id = id;
        Customer = cust;
        Date = date;
        Products = products;
    }

}
