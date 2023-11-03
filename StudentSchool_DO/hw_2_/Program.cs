using hw_2;
using System.Net;

while (true)
{
    ConsoleClr.WriteMenu("Select one of the options: ");
    ConsoleClr.WriteMenu("\t1 - Read data from file");
    ConsoleClr.WriteMenu("\t2 - Write file by URL");
    ConsoleClr.WriteMenu("\t3 - Show Fibonacci number");
    ConsoleClr.WriteMenu("\t4 - Exit");
    ConsoleClr.WriteMenu("Your choice?");
    var inputMenu = IntInputCheck();
    while (true)
    {
        switch (inputMenu)
        {
            case 1:
                try
                {
                    var filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + @"\VeryImportantText.txt";
                    ConsoleClr.WriteService("Enter the number of lines you want to output: ");
                    var numberOfLines = IntInputCheck();

                    string[] lines = FileReader.ReadLines(filePath, numberOfLines);
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }

                }

                catch (FileNotFoundException)
                {
                    ConsoleClr.WriteErrors("An exception occurred: FileNotFoundException");// Handle exception FileNotFoundException
                }

                catch (Exception ex)
                {
                    ConsoleClr.WriteErrors($"An exception occurred: {ex.Message}");
                }

                ConsoleClr.WriteMenu("Do you want to perform the operation again(1) or exit to the main menu(2)?");
                if (IntInputCheck() == 1)
                {
                    inputMenu = 1;
                    continue;
                }

                else
                {
                    break;
                }

            case 2:
                ConsoleClr.WriteService("Enter the URL of the page you want to save: ");
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        var Url = Console.ReadLine();
                        string reply = client.DownloadString(Url);
                        using (StreamWriter writer = new StreamWriter("URL.txt", false))
                        {
                            await writer.WriteLineAsync(reply);
                            ConsoleClr.WriteService("The file was successfully saved.");
                        }

                    }

                }

                catch (FileNotFoundException)
                {
                    ConsoleClr.WriteErrors("An exception occurred: FileNotFoundException");// Handle exception FileNotFoundException
                }

                catch (Exception ex)
                {
                    ConsoleClr.WriteErrors($"An exception occurred: {ex.Message}");
                }

                ConsoleClr.WriteMenu("Do you want to perform the operation again(1) or exit to the main menu(2)?");
                if (IntInputCheck() == 1)
                {
                    inputMenu = 2;
                    continue;
                }

                else
                {
                    break;
                }

            case 3:
                ConsoleClr.WriteService("Enter the sequence number of the Fibonacci number");
                int NumberFibonachi = IntInputCheck();

                Console.WriteLine($"{NumberFibonachi}th Fibonacci number: {Fibonachi.GetFibonachi(NumberFibonachi)}");
                ConsoleClr.WriteMenu("Do you want to perform the operation again(1) or exit to the main menu(2)?");
                if (IntInputCheck() == 1)
                {
                    inputMenu = 3;
                    continue;
                }

                else
                {
                    break;
                }

            case 4:
                Environment.Exit(0);
                break;
        }

        break;
    }

}


static int IntInputCheck()
{
    int num;
    while (!int.TryParse(Console.ReadLine(), out num))
    {
        ConsoleClr.WriteErrors("Invalid input. Please enter a number:");
    }

    return num;
}