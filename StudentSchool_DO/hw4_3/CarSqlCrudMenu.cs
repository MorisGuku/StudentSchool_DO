using DbModel;
using Microsoft.Data.SqlClient;
using System.Net;
namespace hw_2;


public class CarSqlCrudMenu
{
    public static void GetCarSqlMenu()
    {
        while(true)
        {   
            ConsoleColorHelper.WriteMenu("Welcome to Cars SQL table menu! Choose you're desteny: ");
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
                        SqlCarRepository.GetCarsSql();

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
                        
                        ConsoleColorHelper.WriteService("Created done!");
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
                            SqlCarRepository.GetCarsSql();
                            ConsoleColorHelper.WriteMenu("Enter Car's ID for delete:");
                            var deleteCarId = InputConsole.GuidInputCheck();
                            SqlCarRepository.DeleteCarSql(deleteCarId);
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
                            SqlCarRepository.GetCarsSql();
                            ConsoleColorHelper.WriteMenu("Enter Car's ID for edit:");
                            var editCarId = InputConsole.GuidInputCheck();
                            ConsoleColorHelper.WriteMenu("Input new Brand");
                            string editBrandCar = Console.ReadLine();
                            ConsoleColorHelper.WriteMenu("Input new Model");
                            string editModelCar = Console.ReadLine();
                            ConsoleColorHelper.WriteMenu("Input new Coast");
                            int editCoastCar = InputConsole.IntInputCheck();
                            
                            SqlCarRepository.EditCarSql(editCarId, editBrandCar, editModelCar, editCoastCar);
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

