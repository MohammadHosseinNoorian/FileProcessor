using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessor;

public class Order
{
    private static List<Order> orders = new List<Order>();
    public int Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; init; }
    public string Product { get; init; }
    public int UnitPrice { get; set; }
    public int TotalPrice { get; set; }
    public bool IsValid { get; set; }
    public string IsValid_Reasons { get; set; }
    public Order(int id, string name, int q, string product, int uprice, bool isvalid, string reasons)
    {
        Id = id;
        Name = name;
        Quantity = q;
        Product = product;
        UnitPrice = uprice;
        TotalPrice = uprice * q;
        IsValid = isvalid;
        IsValid_Reasons = reasons;
        orders.Add(this);
    }
    public override string ToString()
    {
        return IsValid ? $"{Name}  wants {Quantity} {Product} that costs {TotalPrice} " : $"InValid because : {IsValid_Reasons}";
    }
}

public enum Product_priceEnum
{
    TV = 1000,
    PS5 = 500,
    Book = 20,
    Phone = 300,
    Car = 5000
}
