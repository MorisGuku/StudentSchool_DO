using DbModel;
using Microsoft.Data.SqlClient;
using System.Net;
namespace hw_2;

public class EfCrudMenu
{
    public static void GetSqlMenu()
    {
        while(true)
        {   
            ConsoleColorHelper.WriteMenu("Welcome to menu SQL DataBase EF CRUD works! Choose you're table: ");
            ConsoleColorHelper.WriteMenu("\t1 - Users");
            ConsoleColorHelper.WriteMenu("\t2 - SalesOffice");
            ConsoleColorHelper.WriteMenu("\t3 - Car");
            ConsoleColorHelper.WriteMenu("\t5 - Exit to main menu");
            ConsoleColorHelper.WriteMenu("\t6 - Еxit the program");
            ConsoleColorHelper.WriteMenu("Your choice?");
            var inputMenu = InputConsole.IntInputCheck();
            
            while(true)
            {
                switch(inputMenu)
                {
                    case 1:
                    {
                        UsersEfCrudMenu.GetUserEfMenu();
                        return;
                        
                    }

                    case 2:
                    {
                        SalesOfficeEfCrudMenu.GetSalesOfficeEfMenu();
                        return;
                    }

                    case 3:
                    {   
                        CarEfCrudMenu.GetCarEfMenu();
                        return;
                    }

                    case 4:
                    {
                        return;
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

