using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessor;

public class Order
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; init; }
    public string Product { get; init; }
    public int UnitPrice { get; set; }
    public int TotalPrice { get; set; }
    public bool IsValid { get; set; } = true;
    public string IsValid_Reasons { get; set; }
    public Order(int id, string name, int q, string product, int uprice, int tprice, bool isvalid, string reason)
    {
        Id = id;
        Name = name;
        Quantity = q;
        Product = product;
        UnitPrice = uprice;
        TotalPrice = tprice;
        IsValid = isvalid;
        IsValid_Reasons = reason;
    }
    public override string ToString()
    {
        return IsValid ? $"{Name}  wants {Quantity} {Product} that costs {TotalPrice} " : $"!InValid because : {IsValid_Reasons}:{{ ID: {Id}, Name: {Name}, Product: {Product}, Quantity: {Quantity}}}";
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
