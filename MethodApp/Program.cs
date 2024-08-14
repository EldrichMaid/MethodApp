using System.Reflection.Metadata;

namespace MethodApp
{
    internal class Program
    {
        static string ShowColor(string UserName, int UserAge)
        {
            Console.WriteLine("{0},{1} лет \n Напишите свой любимый цвет на английском с маленькой буквы",UserName,UserAge);
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
        static int[] GetArrayFromConsole(int num = 5)
        {
            var result = new int[num];

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }
                                  
            return result;
        }
        static int[] SortArray(int[] result)
        {         
            int Local;

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[i] > result[j])
                    {
                        Local = result[i];
                        result[i] = result[j];
                        result[j] = Local;
                    }
                }
            }

            foreach (var counted in result)
            {
                Console.Write(counted + "/");
            }

            return result;
        }
        static void ShowArray(int[] array, bool sorted = false) 
        {
            var local = array;
            if (sorted)
            {
                local= SortArray(array);
            }
            foreach (var counted in local)
            {
                Console.Write(counted + "/");
            }
        }

        static void OperationIn(int[] array, in int data)
        {
            array[0]= data;
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
            Console.Write("Введите возраст с цифрами:");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ваше имя: {0}", name);
            Console.WriteLine("Ваш возраст: {0}", age);

            (string name,int  age) ColorUser;
            Console.Write("Введите имя:");
            ColorUser.name = Console.ReadLine();
            Console.Write("Введите возраст:");
            ColorUser.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ваше имя: {0}",ColorUser.name);
            Console.WriteLine("Ваш возраст: {0}",ColorUser.age);

            ShowColor(ColorUser.name, ColorUser.age);

            var favcolors = new string[3];
            for (int i = 0;i < favcolors.Length;i++)
            {
                favcolors[i] = ShowColor(ColorUser.name, ColorUser.age);
            }
            Console.WriteLine("Ваши любимые цвета");
            foreach (var color in favcolors)
            {
                Console.WriteLine(color);
            }

            var array = GetArrayFromConsole(10);
            SortArray(array);

            var SmalArray = new int[] { 1, 2, 3, 4, 5, 6 };
            var data = 8;
            OperationIn(SmalArray, data);
                                   
            Console.ReadKey();
        }
    }
}
