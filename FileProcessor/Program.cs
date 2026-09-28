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
    Console.WriteLine("1. change file");
    Console.WriteLine("2. Display output");
    Console.WriteLine("3. get output as CSV file");
    Console.WriteLine("4. Exit");
    Console.WriteLine("Please choose an option (1-4):");
    int selectedn = int.Parse(Console.ReadLine());
    switch (selectedn)
    {
        case 1:
            Console.WriteLine("Add input file");
            p = new Processor(Console.ReadLine());
            LineValidator validator = new LineValidator();
            p.TimeToValidate += validator.Validate;
            p.Process();
            break;
        case 2:
            p.Display();
            break;
        case 3:
            p.WriteCSVFile();
            break;
        case 4: 
            Environment.Exit(0);
            break;
    }
}
