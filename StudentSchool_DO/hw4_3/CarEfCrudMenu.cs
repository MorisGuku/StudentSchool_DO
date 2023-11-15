using DbModel;
using Microsoft.Data.SqlClient;
using System.Net;
namespace hw_2;


public class CarEfCrudMenu
{
    public static void GetCarEfMenu()
    {
        while(true)
        {   
            ConsoleColorHelper.WriteMenu("Welcome to Cars EF table menu! Choose you're desteny: ");
            ConsoleColorHelper.WriteMenu("\t1 - Read data from Cars table");
            ConsoleColorHelper.WriteMenu("\t2 - Write data in Cars table");
            ConsoleColorHelper.WriteMenu("\t3 - Delete from Cars table");
            ConsoleColorHelper.WriteMenu("\t4 - Change data in Cars table");
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
                        var carRepository = new CarRepository();
                        var carsData = carRepository.GetCarsEF();
                        foreach (var car in carsData)
                            {
                                Console.WriteLine($"ID: {car.Id} Brand: {car.BrandCar} model: {car.ModelCar}  coast: {car.CoastCar}");
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
                        var carRepository = new CarRepository();
                        Console.WriteLine("Input Brand:");
                        var carBrand = Console.ReadLine();
                        Console.WriteLine("Input Model:");
                        var carModel =  Console.ReadLine();
                        Console.WriteLine("Input Coast:");
                        var carCoast =  InputConsole.IntInputCheck();
                        carRepository.CreateCar(new DbCar { BrandCar = carBrand, ModelCar = carModel, CoastCar = carCoast});
                        
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
                            ConsoleColorHelper.WriteService("Data from table Car:");
                            var carRepository = new CarRepository();
                            var carsData = carRepository.GetCarsEF();
                            foreach (var car in carsData)
                                {
                                    Console.WriteLine($"ID: {car.Id} BrandCar: {car.BrandCar} ModelCar: {car.ModelCar}  Car coast: {car.CoastCar}");
                                }
                            
                            ConsoleColorHelper.WriteMenu("Enter Car's ID for delete:");
                            var deleteCarId = InputConsole.GuidInputCheck();
                            carRepository.DeleteCar(deleteCarId);
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
                            ConsoleColorHelper.WriteService("Data from table Car:");
                            var carRepository = new CarRepository();
                            var carsData = carRepository.GetCarsEF();
                            foreach (var car in carsData)
                                {
                                    Console.WriteLine($"ID: {car.Id} BrandCar: {car.BrandCar} ModelCar: {car.ModelCar}  Car coast: {car.CoastCar}");
                                }
                            ConsoleColorHelper.WriteMenu("Enter Car's ID for edit:");
                            var editCarId = InputConsole.GuidInputCheck();
                            ConsoleColorHelper.WriteMenu("Select attribute for edit: ");
                            ConsoleColorHelper.WriteMenu("\t1 - Brand");
                            ConsoleColorHelper.WriteMenu("\t2 - Model");
                            ConsoleColorHelper.WriteMenu("\t3 - Coast");
                            ConsoleColorHelper.WriteMenu("\t4 - Add to SalesOffice");
                            ConsoleColorHelper.WriteMenu("Your choice?");
                            string editBrandCar = null;
                            string editModelCar = null;
                            int? editCoastCar = null;
                            Guid? editKeySalesOffice = null;
                            int attributeNumber = InputConsole.IntInputCheck();
                            switch(attributeNumber)
                            {
                                case 1:
                                {   
                                    ConsoleColorHelper.WriteMenu("Input new brand: ");
                                    editBrandCar = Console.ReadLine();
                                    break;
                                }
                                
                                case 2:
                                {   
                                    ConsoleColorHelper.WriteMenu("Input new model: ");
                                    editModelCar = Console.ReadLine();
                                    break;
                                }

                                case 3:
                                {   
                                    ConsoleColorHelper.WriteMenu("Input new coast: ");
                                    editCoastCar = InputConsole.IntInputCheck();
                                    break;
                                }

                                case 4:
                                {   
                                    ConsoleColorHelper.WriteService("Data from table SalesOffice:");
                                    var officeRepository = new OfficeRepository();
                                    var officesData = officeRepository.GetSalesOfficeEF();
                                    foreach (var office in officesData)
                                    {
                                        Console.WriteLine($"ID: {office.Id} Office Name: {office.NameSalesOffice} office address: {office.AddressSalesOffice}  Cars: {office.Cars}");
                                    }

                                    ConsoleColorHelper.WriteMenu("Enter Sales Offic's ID for addition to Car:");
                                    editKeySalesOffice = InputConsole.GuidInputCheck();

                                    break;
                                }

                            }
                            
                            carRepository.EditCar(editCarId, editBrandCar, editModelCar, editCoastCar, editKeySalesOffice);
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

