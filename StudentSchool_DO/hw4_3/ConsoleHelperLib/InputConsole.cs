using System.ComponentModel;

namespace hw_2;

public class InputConsole
{
    public static int IntInputCheck()
    {
        int num;
        while (!int.TryParse(Console.ReadLine(), out num))
        {
            ConsoleColorHelper.WriteErrors("Invalid input. Please enter a number:");
        }

        return num;
    }
    
    public static Guid GuidInputCheck()
    {
        Guid guid;
        while (!Guid.TryParse(Console.ReadLine(), out guid))
        {
            ConsoleColorHelper.WriteErrors("Invalid input. Please enter a GUID:");
        }

        return guid;
    }

}

