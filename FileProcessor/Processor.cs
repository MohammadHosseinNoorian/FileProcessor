using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Schema;

namespace FileProcessor;

public delegate LineValidator ValidationHandler(string[] line, out int uprice, out int tprice);
public class Processor
{
    private List<Order> orders = new List<Order>();
    private string[] _file;
    public event ValidationHandler? TimeToValidate;

    public Processor(string file)
    {
        try
        {
            _file = File.ReadAllLines(file);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public Processor() { }
    public void Process()
    {
        if (_file != null)
        {
            for(int i = 1;i < _file.Length; i++)//skips first line(header)
            {
                string[] line = _file[i].Split(",");
                if (line.Length != 4) continue;//skips the lines that are not complete
                int uprice = 0;int tprice = 0;
                LineValidator validationResult = TimeToValidate?.Invoke(line, out uprice, out tprice);
                int id = int.TryParse(line[0], out var I) ? I : 0;
                string name = line[1];
                int quantity = int.TryParse(line[3], out var p) ? p : 0;
                string product = line[2];
                orders.Add(new Order(id, name, quantity, product, uprice, tprice, validationResult.IsValid, validationResult.Reason));
            }
        }
    }
    public void Display()
    {
        foreach (Order o in orders)
        {
            Console.WriteLine(o.ToString());
            
        }
        Console.ReadLine();
    }
    
}
