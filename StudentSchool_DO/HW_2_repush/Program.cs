using HW_2_repush;
using System.Net;

while (true)
{
    ConsoleClr.Menu("Select one of the options: ");
    ConsoleClr.Menu("\t1 - Read data from file");
    ConsoleClr.Menu("\t2 - Write file by URL");
    ConsoleClr.Menu("\t3 - Show Fibonacci number");
    ConsoleClr.Menu("\t4 - Exit");
    ConsoleClr.Menu("Your choice?");

    switch (IntInputCheck())
    {
        case 1:
            try
            {
                var filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + @"\VeryImportantText.txt";
                ConsoleClr.Service("Enter the number of lines you want to output: ");
                var numberOfLines = IntInputCheck();

                string[] lines = FileReader.ReadLines(filePath, numberOfLines);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (FileNotFoundException)
            {
                ConsoleClr.Errors("An exception occurred: FileNotFoundException");// Handle exception FileNotFoundException
            }
            catch (Exception ex)
            {
                ConsoleClr.Errors($"An exception occurred: {ex.Message}");
            }
            ConsoleClr.Menu("Do you want to perform the operation again(1) or exit to the main menu(2)?");
            if (IntInputCheck() == 1)
            {
                goto case 1;
            }
            else
            {
                continue;
            }
        case 2:
            ConsoleClr.Service("Enter the URL of the page you want to save: ");
            try
            {
                using (WebClient client = new WebClient())
                {
                    var Url = Console.ReadLine();
                    string reply = client.DownloadString(Url);
                    using (StreamWriter writer = new StreamWriter("URL.txt", false))
                    {
                        await writer.WriteLineAsync(reply);
                        ConsoleClr.Service("The file was successfully saved.");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                ConsoleClr.Errors("An exception occurred: FileNotFoundException");// Handle exception FileNotFoundException
            }
            catch (Exception ex)
            {
                ConsoleClr.Errors($"An exception occurred: {ex.Message}");
            }
            ConsoleClr.Menu("Do you want to perform the operation again(1) or exit to the main menu(2)?");
            if (IntInputCheck() == 1)
            {
                goto case 2;
            }
            else
            {
                continue;
            }
        case 3:
            ConsoleClr.Service("Enter the sequence number of the Fibonacci number");
            int NumberFibonachi = IntInputCheck();

            Console.WriteLine($"{NumberFibonachi}th Fibonacci number: {Fibonachi.GetFibonachi(NumberFibonachi)}");
            ConsoleClr.Menu("Do you want to perform the operation again(1) or exit to the main menu(2)?");
            if (IntInputCheck() == 1)
            {
                goto case 3;
            }
            else
            {
                continue;
            }
        case 4:
            Environment.Exit(0);
            break;


    }
}
static int IntInputCheck()
{
    int num;
    while (!int.TryParse(Console.ReadLine(), out num))
    {
        ConsoleClr.Errors("Invalid input. Please enter a number:");
    }
    return num;
}