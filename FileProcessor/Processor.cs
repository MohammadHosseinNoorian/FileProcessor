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
    private string _dir;
    public event ValidationHandler? TimeToValidate;

    public Processor(string file)
    {
        try
        {
            _file = File.ReadAllLines(file);
            _dir = Path.GetDirectoryName(file);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Please change file.");
        }
    }
    public Processor() { }
    public void Process()
    {
        if (_file != null)
        {
            for (int i = 1; i < _file.Length; i++)//skips first line(header)
            {
                string[] line = _file[i].Split(",");
                int uprice = 0; int tprice = 0;
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
        if (_file != null)
        {
            foreach (Order o in orders)
            {
                Console.WriteLine(o.ToString());
            }
            int failedorders = (from o in orders where o.IsValid == false select o).Count();
            int succeedorders = (from o in orders where o.IsValid == true select o).Count();
            Order maxorder = orders.MaxBy(o => o.TotalPrice);
            Console.WriteLine($"We have {succeedorders + failedorders} orders: fileds:{failedorders}, succeed:{succeedorders}");
            Console.WriteLine($"Max_Price order:{{id: {maxorder?.Id}, Name: {maxorder?.Name}, totalprice: {maxorder?.TotalPrice}}}");
        }
        else
            Console.WriteLine("Please change file.");
        Console.WriteLine("Press Enter to go back to the menu");
        Console.ReadLine();
    }
    public void WriteCSVFile()
    {
        if (_file != null)
        {
            string succeedfilepath = _dir + @"\succeedorders.csv";
            string failedfilepath = _dir + @"\failedorders.csv";
            StringBuilder failedfiletext = new StringBuilder();
            StringBuilder succeedfiletext = new StringBuilder();
            failedfiletext.AppendLine("id,name,product,quantity,reasons");
            succeedfiletext.AppendLine("id,name,product,quantity,totalprice");
            Console.WriteLine("writing files ....");
            foreach (Order o in orders)
            {
                if (o.IsValid == false)
                    failedfiletext.AppendLine($"{o.Id},{o.Name},{o.Product},{o.Quantity},{o.IsValid_Reasons}");
                else
                    succeedfiletext.AppendLine($"{o.Id},{o.Name},{o.Product},{o.Quantity},{o.TotalPrice}");
            }
            File.WriteAllText(failedfilepath, failedfiletext.ToString());
            File.WriteAllText(succeedfilepath, succeedfiletext.ToString());
            Console.WriteLine("Finished. The files succeedorders.csv and failedorders.csv have been created next to your input file.");
        }
        else
            Console.WriteLine("Please change file.");
        Console.WriteLine("Press Enter to go back to the menu");
        Console.ReadLine();

    }
}
