using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessor;

public class LineValidator
{
    public bool IsValid { get; set;  }
    public string Reason { get; set; }
    public LineValidator Validate(string[] line, out int unitprice, out int totalprice)
    {
        Reason = "";
        if (!int.TryParse(line[0], out int id) || id < 1000 || line[1].Length == 0 || int.TryParse(line[1], out int _))//ids start from 1000
            Reason += "Invalid User- ";
        if (!int.TryParse(line[3], out int quantity) || quantity < 1)
            Reason += "Invalid Quantity- ";
        if (Enum.TryParse<Product_priceEnum>(line[2], out Product_priceEnum value))
        {
            unitprice = (int)value;
            totalprice = (int)value * quantity;
        }
        else
        {
            Reason += "Invalid product- ";
            unitprice = 0;
            totalprice = 0;
        }
        IsValid = Reason.Length == 0;
        return this;
    }
}
