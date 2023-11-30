using DbModel;
using Microsoft.Data.SqlClient;
using System.Net;
namespace hw_2;


public class SalesOfficeSqlCrudMenu
{
    public static void GetSalesOfficeSqlMenu()
    {
        while(true)
        {   
            ConsoleColorHelper.WriteMenu("Welcome to SalesOffice SQL table menu! Choose you're desteny: ");
            ConsoleColorHelper.WriteMenu("\t1 - Read data from SalesOffice table");
            ConsoleColorHelper.WriteMenu("\t2 - Write data in SalesOffice table");
            ConsoleColorHelper.WriteMenu("\t3 - Delete from SalesOffice table");
            ConsoleColorHelper.WriteMenu("\t4 - Change data in SalesOffice table");
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
                        ConsoleColorHelper.WriteService("Data from table Sales Office:");
                        SqlOfficeRepository.GetSalesOfficeSql();

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
                        Console.WriteLine("Input office name:");
                        var officeName = Console.ReadLine();
                        Console.WriteLine("Input address:");
                        var officeAddress =  Console.ReadLine();
                        SqlOfficeRepository.CreateSalesOfficeSql(officeName, officeAddress);
                        ConsoleColorHelper.WriteService("Create is done!");
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
                            ConsoleColorHelper.WriteService("Data from table SalesOffice:");
                            SqlOfficeRepository.GetSalesOfficeSql();
                            ConsoleColorHelper.WriteMenu("Enter Sales Offic's ID fo delete:");
                            var deleteSalesOfficeId = InputConsole.GuidInputCheck();
                            SqlOfficeRepository.DeleteSalesOfficeSql(deleteSalesOfficeId);
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
                            ConsoleColorHelper.WriteService("Data from table SalesOffice:");
                            var officeRepository = new OfficeRepository();
                            var officesData = officeRepository.GetSalesOfficeEF();
                            foreach (var office in officesData)
                            {
                                Console.WriteLine($"ID: {office.Id} Office Name: {office.NameSalesOffice} office address: {office.AddressSalesOffice}  Cars: {office.Cars}");
                            }

                            ConsoleColorHelper.WriteMenu("Enter Sales Offic's ID for edit:");
                            var editSalesOfficeId = InputConsole.GuidInputCheck();
                            ConsoleColorHelper.WriteMenu("input new Name Sales Office");
                            string editNameSalesOffice = Console.ReadLine();
                            ConsoleColorHelper.WriteMenu("input new Address");
                            string editAddressSalesOffice = Console.ReadLine();
                            ConsoleColorHelper.WriteMenu("input new Add to Cars");
                            SqlOfficeRepository.EditSalesOfficeSql(editSalesOfficeId, editNameSalesOffice, editAddressSalesOffice);
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

