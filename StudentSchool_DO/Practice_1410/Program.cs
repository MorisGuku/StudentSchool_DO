namespace Practice_1410
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FooBar(3));
            Console.WriteLine(FooBar(5));
            Console.WriteLine(FooBar(15));
            Console.WriteLine(FooBar(12));
        }
        static string FooBar(int num)
        {
            if (num % 3 == 0)
            {
                return "foo";
            }
            else if (num % 5 == 0)
            {
                return "bar";

            }
            else if (num % 3 == 0 && num % 3 == 0)
            {
                return "foobar";

            }
            else
            {
                return "";
            }
        }
    }
}