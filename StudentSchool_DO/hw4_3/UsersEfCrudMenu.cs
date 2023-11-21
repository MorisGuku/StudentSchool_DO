using DbModel;
using Microsoft.Data.SqlClient;
using System.Net;
namespace hw_2;


public class UsersEfCrudMenu
{
    public static void GetUserEfMenu()
    {
        while(true)
        {   
            ConsoleColorHelper.WriteMenu("Welcome to menu SQL DataBase EF CRUD works! Choose you're desteny: ");
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
                        var userRepository = new UserRepository();
                        var usersData = userRepository.GetUsersEF();
                        foreach (var user in usersData)
                        {
                            Console.WriteLine($"ID: {user.UserId} Firstname: {user.FirstName} Lastname: {user.LastName}  CreatedTimeStamp: {user.CreatedTime}");
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
                        var userRepository = new UserRepository();
                        Console.WriteLine("Input FirstName:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Input LastName:");
                        var lastName =  Console.ReadLine();
                        userRepository.CreateUser(new DbUser { FirstName = firstName, LastName = lastName });
                        var users = userRepository.GetUsersEF();
                        var id = users.OrderByDescending(u => u.CreatedTime).Select(u => u.UserId).FirstOrDefault();
                        var userData = userRepository.GetUserEF(id);

                        Console.WriteLine($"ID: {userData.UserId} Firstname: {userData.FirstName} Lastname: {userData.LastName}  CreatedTimeStamp: {userData.CreatedTime}");
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
                            var userRepository = new UserRepository();
                            var usersData = userRepository.GetUsersEF();
                            foreach (var user in usersData)
                                {
                                    Console.WriteLine($"ID: {user.UserId} Firstname: {user.FirstName} Lastname: {user.LastName}  CreatedTimeStamp: {user.CreatedTime}");
                                }

                            ConsoleColorHelper.WriteMenu("Enter User's ID for delete:");
                            var deleteUserId = InputConsole.GuidInputCheck();
                            userRepository.DeleteUser(deleteUserId);
                            
                            var usersDataAfterDelete = userRepository.GetUsersEF();
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
                            var userRepository = new UserRepository();
                            var usersData = userRepository.GetUsersEF();
                            foreach (var user in usersData)
                            {
                                Console.WriteLine($"ID: {user.UserId} Firstname: {user.FirstName} Lastname: {user.LastName}  CreatedTimeStamp: {user.CreatedTime}");
                            }

                            ConsoleColorHelper.WriteMenu("Enter User's ID for edit:");
                            var editUserId = InputConsole.GuidInputCheck();
                            ConsoleColorHelper.WriteMenu("Select attribute for edit: ");
                            ConsoleColorHelper.WriteMenu("\t1 - FirstName");
                            ConsoleColorHelper.WriteMenu("\t2 - LastName");
                            ConsoleColorHelper.WriteMenu("\t3 - Add to Car");
                            ConsoleColorHelper.WriteMenu("Your choice?");
                            
                            string editFirstName = null;
                            string editLastName = null;
                            Guid? editKeyCar = null;
                            int attributeNumber = InputConsole.IntInputCheck();
                            switch(attributeNumber)
                            {
                                case 1:
                                {   
                                    ConsoleColorHelper.WriteMenu("Input new FirstName: ");
                                    editFirstName = Console.ReadLine();
                                    break;
                                }
                                
                                case 2:
                                {   
                                    ConsoleColorHelper.WriteMenu("Input new LastName: ");
                                    editLastName = Console.ReadLine();
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

                            userRepository.EditUser(editUserId, editFirstName, editLastName, editKeyCar);
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

