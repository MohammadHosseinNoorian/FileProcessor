using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessor;

public class Product
{
    public int Quantity { get; }
    public int Price { get; } 
    public ProductTypeEnum ProductType { get; }
    public Product(int q, ProductTypeEnum type)
    {
        Quantity = q;
        ProductType = type;
        Price = q * (int)type;
    }

}
public enum ProductTypeEnum
{
    TV = 1000,
    PS5 = 500,
    Book = 20,
    Phone = 300,
    Car = 5000
}
