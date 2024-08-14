using System.Reflection.Metadata;

namespace MethodApp
{
    internal class Program
    {
        static string ShowColor()
        {
            Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
            var color = Console.ReadLine();
            switch (color)
            {
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is red!");
                    break;

                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is green!");
                    break;
                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is cyan!");
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Your color is yellow!");
                    break;
                    
            }
            return color;
        }
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

            var (name, age) = ("PC", 0);

            Console.WriteLine("Мое имя: {0}", name);
            Console.WriteLine("Мой возраст: {0}", age);

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите возрас с цифрами:");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ваше имя: {0}", name);
            Console.WriteLine("Ваш возраст: {0}", age);

            ShowColor();

            var favcolors = new string[3];
            for (int i = 0;i < favcolors.Length;i++)
            {
                favcolors[i] = ShowColor();
            }
            Console.WriteLine("Ваши любимые цвета");
            foreach (var color in favcolors)
            {
                Console.WriteLine(color);
            }

            Console.ReadKey();
        }
    }
}
