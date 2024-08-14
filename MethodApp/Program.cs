using System.Reflection.Metadata;

namespace MethodApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string name, string[] dishes) User;
            Console.WriteLine("Введите имя");
            User.name = Console.ReadLine();
            User.dishes = new string[5];
            Console.WriteLine("Введите пять любимых блюд");
            for (int i = 0; i < User.dishes.Length; i++)
            {
                User.dishes[i] = Console.ReadLine();
            }
            
            Console.ReadKey();
        }
    }
}
