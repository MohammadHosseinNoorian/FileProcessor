using FileProcessor;

Console.WriteLine("** Welcome to file processor console app **");
Console.WriteLine("*******************************************");
Console.WriteLine("Add input file");
Processor p = new Processor(Console.ReadLine());
LineValidator validator = new LineValidator();
p.TimeToValidate += validator.Validate;
p.Process();
while (true)
    DisplayMenu(p);

static void DisplayMenu(Processor p)
{
    Console.WriteLine("1. get output");
    Console.WriteLine("2. get output as CSV file");
    Console.WriteLine("3. Exit");
    Console.WriteLine("Choose what you want to do(1-3)");
    int selectedn = int.Parse(Console.ReadLine());
    Console.WriteLine($"selectedn= {selectedn}");
    switch (selectedn)
    {
        case 1:
            p.Display();
            break;
        case 2:
            p.Display();
            break;
        case 3: 
            Environment.Exit(0);
            break;
    }
}
