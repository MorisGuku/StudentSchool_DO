using DbModel;
using Microsoft.Data.SqlClient;
using System.Net;
namespace hw_2;


public class SalesOfficeEfCrudMenu
{
    public static void GetSalesOfficeEfMenu()
    {
        while(true)
        {   
            ConsoleColorHelper.WriteMenu("Welcome to SalesOffice EF table menu! Choose you're desteny: ");
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
                        var officeRepository = new OfficeRepository();
                        var officeData = officeRepository.GetSalesOfficeEF();
                        foreach (var office in officeData)
                            {
                                Console.WriteLine($"ID: {office.Id} Office name: {office.NameSalesOffice} office address: {office.AddressSalesOffice}  Cars: {office.Cars}");
                            }

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
                        var officeRepository = new OfficeRepository();
                        Console.WriteLine("Input office name:");
                        var officeName = Console.ReadLine();
                        Console.WriteLine("Input address:");
                        var officeAddress =  Console.ReadLine();
                        officeRepository.CreateSalesOffice(new DbSalesOffice { NameSalesOffice = officeName, AddressSalesOffice = officeAddress });                    
                        
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
                            var officeRepository = new OfficeRepository();
                            var officesData = officeRepository.GetSalesOfficeEF();
                            foreach (var office in officesData)
                            {
                                Console.WriteLine($"ID: {office.Id} Office Name: {office.NameSalesOffice} office address: {office.AddressSalesOffice}  Cars: {office.Cars}");
                            }

                            ConsoleColorHelper.WriteMenu("Enter Sales Offic's ID fo delete:");
                            var deleteSalesOfficeId = InputConsole.GuidInputCheck();
                            officeRepository.DeleteSalesOffice(deleteSalesOfficeId);
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
                            ConsoleColorHelper.WriteMenu("Select attribute for edit: ");
                            ConsoleColorHelper.WriteMenu("\t1 - Name Sales Office");
                            ConsoleColorHelper.WriteMenu("\t2 - Address");
                            ConsoleColorHelper.WriteMenu("\t4 - Add to Cars");
                            ConsoleColorHelper.WriteMenu("Your choice?");
                            string editNameSalesOffice = null;
                            string editAddressSalesOffice = null;
                            Guid? editKeyCar = null;
                            int attributeNumber = InputConsole.IntInputCheck();
                            
                            switch(attributeNumber)
                            {
                                case 1:
                                {   
                                    ConsoleColorHelper.WriteMenu("Input new name sales office: ");
                                    editNameSalesOffice = Console.ReadLine();
                                    break;
                                }
                                
                                case 2:
                                {   
                                    ConsoleColorHelper.WriteMenu("Input new address: ");
                                    editAddressSalesOffice = Console.ReadLine();
                                    break;
                                }

                                case 3:
                                {
                                    ConsoleColorHelper.WriteService("Data from table Car:");
                                    var carRepository = new CarRepository();
                                    var carData = carRepository.GetCarsEF();
                                    foreach (var car in carData)
                                    {
                                        Console.WriteLine($"ID: {car.Id} Brand Name: {car.BrandCar} Model car: {car.ModelCar}  Coast car: {car.CoastCar}");
                                    }

                                    ConsoleColorHelper.WriteMenu("Enter Sales Offic's ID for addition to Car:");
                                    editKeyCar = InputConsole.GuidInputCheck();
                                    break;
                                }

                            }

                                officeRepository.EditSalesOffice(editSalesOfficeId, editNameSalesOffice, editAddressSalesOffice, editKeyCar);
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

