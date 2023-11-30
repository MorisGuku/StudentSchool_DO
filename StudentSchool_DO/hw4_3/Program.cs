﻿using hw_2;
using System.Net;
using Provider;
using DbModel;
internal class Program
{
    private static async Task Main(string[] args)
    {
        while (true)
        {
            ConsoleColorHelper.WriteMenu("Select one of the options: ");
            ConsoleColorHelper.WriteMenu("\t1 - Read data from file");
            ConsoleColorHelper.WriteMenu("\t2 - Write file by URL");
            ConsoleColorHelper.WriteMenu("\t3 - Show Fibonacci number");
            ConsoleColorHelper.WriteMenu("\t4 - Work with SQL database");
            ConsoleColorHelper.WriteMenu("\t5 - Work with EF database");
            ConsoleColorHelper.WriteMenu("\t6 - Exit");
            ConsoleColorHelper.WriteMenu("Your choice?");
            var inputMenu = InputConsole.IntInputCheck();
            while (true)
            {
                switch (inputMenu)
                {
                    case 1:
                        try
                        {
                            var filePath = Environment.CurrentDirectory + @"/VeryImportantText.txt";
                            ConsoleColorHelper.WriteService(filePath);
                            ConsoleColorHelper.WriteService("Enter the number of lines you want to output: ");
                            var numberOfLines = InputConsole.IntInputCheck();

                            string[] lines = FileReader.ReadLines(filePath, numberOfLines);
                            foreach (string line in lines)
                            {
                                Console.WriteLine(line);
                            }

                        }

                        catch (FileNotFoundException)
                        {
                            ConsoleColorHelper.WriteErrors("An exception occurred: FileNotFoundException");// Handle exception FileNotFoundException
                        }

                        catch (Exception ex)
                        {
                            ConsoleColorHelper.WriteErrors($"An exception occurred: {ex.Message}");
                        }

                        ConsoleColorHelper.WriteMenu("Do you want to perform the operation again(1) or exit to the main menu(2)?");
                        if (InputConsole.IntInputCheck() == 1)
                        {
                            inputMenu = 1;
                            continue;
                        }

                        else
                        {
                            break;
                        }

                    case 2:
                        ConsoleColorHelper.WriteService("Enter the URL of the page you want to save: ");
                        try
                        {
                            using (WebClient client = new WebClient())
                            {
                                var Url = Console.ReadLine();
                                string reply = client.DownloadString(Url);
                                using (StreamWriter writer = new StreamWriter("URL.txt", false))
                                {
                                    await writer.WriteLineAsync(reply);
                                    ConsoleColorHelper.WriteService("The file was successfully saved.");
                                }

                            }

                        }

                        catch (FileNotFoundException)
                        {
                            ConsoleColorHelper.WriteErrors("An exception occurred: FileNotFoundException");// Handle exception FileNotFoundException
                        }

                        catch (Exception ex)
                        {
                            ConsoleColorHelper.WriteErrors($"An exception occurred: {ex.Message}");
                        }

                        ConsoleColorHelper.WriteMenu("Do you want to perform the operation again(1) or exit to the main menu(2)?");
                        if (InputConsole.IntInputCheck() == 1)
                        {
                            inputMenu = 2;
                            continue;
                        }

                        else
                        {
                            break;
                        }

                    case 3:
                        ConsoleColorHelper.WriteService("Enter the sequence number of the Fibonacci number");
                        int NumberFibonachi = InputConsole.IntInputCheck();

                        Console.WriteLine($"{NumberFibonachi}th Fibonacci number: {Fibonachi.GetFibonachi(NumberFibonachi)}");
                        ConsoleColorHelper.WriteMenu("Do you want to perform the operation again(1) or exit to previous menu(2)?");
                        if (InputConsole.IntInputCheck() == 1)
                        {
                            inputMenu = 3;
                            continue;
                        }

                        else
                        {
                            break;
                        }

                    case 4:
                        SqlCrudMenu.GetSqlMenu();
                        break;
                    
                    case 5:
                        EfCrudMenu.GetEfMenu();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;
                }

                break;
            }

        }


    }

}
