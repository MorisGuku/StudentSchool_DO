using DbModel;
using Microsoft.Data.SqlClient;
using System.Net;
namespace hw_2;


public class UsersSqlCrudMenu
{
    public static void GetUserSqlMenu()
    {
        while(true)
        {   
            ConsoleColorHelper.WriteMenu("Welcome to menu SQL DataBase CRUD works! Choose you're desteny: ");
            ConsoleColorHelper.WriteMenu("\t1 - Read data from DB");
            ConsoleColorHelper.WriteMenu("\t2 - Write data in DB");
            ConsoleColorHelper.WriteMenu("\t3 - Delete from DB");
            ConsoleColorHelper.WriteMenu("\t4 - Change data in DB");
            ConsoleColorHelper.WriteMenu("\t5 - Exit to main menu");
            ConsoleColorHelper.WriteMenu("\t6 - Еxit the program");
            ConsoleColorHelper.WriteMenu("Your choice?");
            var inputMenu = InputConsole.IntInputCheck();
            
            while(true)
            {
                switch(inputMenu)
                {
                    case 1: //read
                    {
                        ConsoleColorHelper.WriteService("Data from table Users:");
                        SqlUserRepository.GetUsersSql();
                        
                        ConsoleColorHelper.WriteMenu("Do you want to perform the operation again(1) or exit to  previous menu(2)?");
                        if (InputConsole.IntInputCheck() == 1)
                        {
                            inputMenu = 1;
                            continue;
                        }

                        else
                        {
                            break;
                        }
                        
                    }

                    case 2: //create
                    {
                        ConsoleColorHelper.WriteService("Enter correct data in the following fields");
                        Console.WriteLine("Input FirstName:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Input LastName:");
                        string lastName =  Console.ReadLine();
                        SqlUserRepository.CreateUserSql(firstName,lastName);
                        Console.WriteLine("Created done!");
                        ConsoleColorHelper.WriteMenu("Do you want to perform the operation again(1) or exit to  previous menu(2)?");
                        if (InputConsole.IntInputCheck() == 1)
                        {
                            inputMenu = 2;
                            continue;
                        }

                        else
                        {
                            break;
                        }

                    }

                    case 3: //delete
                    {
                        try
                        {
                            ConsoleColorHelper.WriteService("Data from table Users:");
                            SqlUserRepository.GetUsersSql();
                            ConsoleColorHelper.WriteMenu("Enter User's ID for delete:");
                            var deleteUserId = InputConsole.GuidInputCheck();
                            SqlUserRepository.DeleteUserSql(deleteUserId);
                            ConsoleColorHelper.WriteService("Delete is done!");
                            ConsoleColorHelper.WriteMenu("Do you want to perform the operation again(1) or exit to  previous menu(2)?"); 
                            if (InputConsole.IntInputCheck() == 1)
                            {
                                inputMenu = 3;
                                continue;
                            }

                            else
                            {
                                break;
                            }
                            
                        }

                        catch (Exception ex)
                        {
                            ConsoleColorHelper.WriteErrors("Delete is not done!!!!");
                            ConsoleColorHelper.WriteErrors($"An exception occurred: {ex.Message}");
                            break;
                        }

                    }
                    
                    case 4: //update
                    {
                        try
                        {
                            ConsoleColorHelper.WriteService("Data from table Users:");
                            SqlUserRepository.GetUsersSql();
                            ConsoleColorHelper.WriteMenu("Enter User's ID for edit:");
                            var editUserId = InputConsole.GuidInputCheck();
                            ConsoleColorHelper.WriteMenu("\tInput new FirstName");
                            string editFirstName = Console.ReadLine();
                            ConsoleColorHelper.WriteMenu("\tInput new LastName");
                            string editLastName  = Console.ReadLine();
                            
                            SqlUserRepository.EditUserSql(editUserId, editFirstName, editLastName);
                            ConsoleColorHelper.WriteService("Edit is done!");
                            ConsoleColorHelper.WriteMenu("Do you want to perform the operation again(1) or exit to  previous menu(2)?"); 
                            if (InputConsole.IntInputCheck() == 1)
                            {
                                inputMenu = 4;
                                continue;
                            }

                            else
                            {
                                break;
                            }
                            
                        }

                        catch (Exception ex)
                        {
                            ConsoleColorHelper.WriteErrors("Edit is not done!!!!");
                            ConsoleColorHelper.WriteErrors($"An exception occurred: {ex.Message}");
                            break;
                        }

                    }
                    
                    case 5:
                    {
                        return;
                    }

                    case 6:
                    {
                        Environment.Exit(0);
                        break;
                    }
                    
                }

            break; 
            }

        }

    }

}

