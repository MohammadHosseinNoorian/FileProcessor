using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FileProcessor;

public class Processor
{
    private string[] _file;

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
    public void Output()
    {
        if (_file != null)
        {
            for(int i = 1;i < _file.Length; i++)//skips first line(header)
            {
                string[] line = _file[i].Split(",");
            }
        }
        Console.ReadLine();
    }
    
}
