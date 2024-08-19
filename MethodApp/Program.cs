using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace MethodApp
{
    internal class Program
    {
        static string ShowColor(string UserName, int UserAge)
        {
            Console.WriteLine("{0},{1} лет \n Напишите свой любимый цвет на английском с маленькой буквы", UserName, UserAge);
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
        static int[] GetArrayFromConsole(ref int num)
        {
            var result = new int[num];

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }

            return result;
        }
        static int[] SortArray(in int[] Result, out int[] sorteddesc, out int[] sortedasc)
        {
            sorteddesc = SortArrayDesc(Result);
            sortedasc = SortArrayAsc(Result);
            return Result;
        }
        static int[] SortArrayAsc(int[] result)
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
                Console.Write("|" + counted + "|");
            }
            return result;
        }
        static int[] SortArrayDesc(int[] result)
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
                Console.Write("|" + counted + "|");
            }
            return result;
        }
        static void ShowArray(int[] array, bool sorted = false)
        {
            var local = array;
            if (sorted)
            {
                local = SortArray(array, out var sortedDesc, out var sortedAsc);
            }
        }
        static void OperationIn(int[] array, in int data)
        {
            array[0] = data;
        }
        static void Echo(string saidworld, int deep)
        {
            var modif = saidworld;
            if (modif.Length > 2)
            {
                modif = modif.Remove(0, 2);
            }
            Console.BackgroundColor = (ConsoleColor)deep;
            Console.WriteLine("..." + modif);
            if (deep > 1)
            {
                Echo(modif, deep - 1);
            }
        }
        static void EchoStatic(string phrase, int deep)
        {
            Console.WriteLine(phrase);

            if (deep > 1)
            {
                EchoStatic(phrase, deep - 1);
            }
        }
        static decimal Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        private static int PowerUp(int N, byte pow)
        {
            int result = (int)Math.Pow(N, pow);
            return result;
        }
        private static int PowerUpBySwitch(int N, byte pow)

        {
            switch (pow)
            {
                case 0:
                    return 1;
                case 1:
                    return N;
                case > 1:
                    return N * PowerUpBySwitch(N, (byte)(pow - 1));
                default:
                    throw new ArgumentException("Invalid power value. Must be a byte between 0 and 255.");
            }
        }
        public static (string, string, byte, bool, int, string[], byte, string[]) CreateNameData()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastname = Console.ReadLine();
            Console.Write("Enter age: ");
            byte age = byte.Parse(Console.ReadLine());
            Console.Write("Enter if you have pets (true/false): ");
            bool pethaver = bool.Parse(Console.ReadLine());
            Console.Write("Enter number of pets: ");
            int petamount = int.Parse(Console.ReadLine());
            Console.Write("Enter pet names (comma-separated): ");
            string[] petnames = Console.ReadLine().Split(',');
            Console.Write("Enter number of favorite colors: ");
            byte favcolorsamt = byte.Parse(Console.ReadLine());
            Console.Write("Enter favorite colors (comma-separated): ");
            string[] favcolorsnames = Console.ReadLine().Split(',');
            return (name, lastname, age, pethaver, petamount, petnames, favcolorsamt, favcolorsnames);
        }
        public static (string, string, byte, bool, int, string[], byte, string[]) CheckAndCorrectData((string, string, byte, bool, int, string[], byte, string[]) nameData)
        {
            (string name, string lastname, byte age, bool pethaver, int petamount, string[] petnames, byte favcolorsamt, string[] favcolorsnames) = nameData;
            while (age < 1)
            {
                Console.WriteLine("Age must be at least 1. Please try again.");
                Console.Write("Enter age: ");
                if (!byte.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("Invalid age format. Please enter a number.");
                }
            }
            while (petamount < 0)
            {
                Console.WriteLine("Number of pets cannot be negative. Please try again.");
                Console.Write("Enter number of pets: ");
                if (!int.TryParse(Console.ReadLine(), out petamount))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            while (favcolorsamt < 0)
            {
                Console.WriteLine("Number of favorite colors cannot be negative. Please try again.");
                Console.Write("Enter number of favorite colors: ");
                if (!byte.TryParse(Console.ReadLine(), out favcolorsamt))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            return (name, lastname, age, pethaver, petamount, petnames, favcolorsamt, favcolorsnames);
        }
        public static void DisplayNameData((string, string, byte, bool, int, string[], byte, string[]) nameData)
        {
            (string name, string lastname, byte age, bool pethaver, int petamount, string[] petnames, byte favcolorsamt, string[] favcolorsnames) = nameData;
            Console.WriteLine($"Name: {name} {lastname}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Pet Owner: {pethaver}");
            Console.WriteLine($"Number of Pets: {petamount}");
            Console.WriteLine("Pet Names:");
            if (petnames.Length > 0)
            {
                foreach (string petname in petnames)
                {
                    Console.WriteLine($"- {petname}");
                }
            }
            else
            {
                Console.WriteLine("- None");
            }
            Console.WriteLine($"Number of Favorite Colors: {favcolorsamt}");
            Console.WriteLine("Favorite Colors:");
            if (favcolorsnames.Length > 0)
            {
                foreach (string color in favcolorsnames)
                {
                    Console.WriteLine($"- {color}");
                }
            }
            else
            {
                Console.WriteLine("- None");
            }
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

                (string name, int age) ColorUser;
                Console.Write("Введите имя:");
                ColorUser.name = Console.ReadLine();
                Console.Write("Введите возраст:");
                ColorUser.age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ваше имя: {0}", ColorUser.name);
                Console.WriteLine("Ваш возраст: {0}", ColorUser.age);
                ShowColor(ColorUser.name, ColorUser.age);
                var favcolors = new string[3];
                for (int i = 0; i < favcolors.Length; i++)
                {
                    favcolors[i] = ShowColor(ColorUser.name, ColorUser.age);
                }
                Console.WriteLine("Ваши любимые цвета");
                foreach (var color in favcolors)
                {
                    Console.WriteLine(color);
                }

                int size = 6;
                var array = GetArrayFromConsole(ref size);
                ShowArray(array, false);

                var SmalArray = new int[] { 1, 2, 3, 4, 5, 6 };
                var data = 8;
                OperationIn(SmalArray, data);

                Console.WriteLine("Напишите что-то");
                var str = Console.ReadLine();
                Console.WriteLine("Укажите глубину эха");
                var deep = int.Parse(Console.ReadLine());
                EchoStatic(str, deep);
                Echo(str, deep);

                Console.WriteLine(PowerUp(3, 2));
                Console.WriteLine(PowerUpBySwitch(3, 3));
            
                (string name, string lastname, byte age,
                bool pethaver, int petamount, string[] petnames, 
                byte favcolorsamt, string[] favcolorsnames) personData = CreateNameData();
                personData = CheckAndCorrectData(personData);
                DisplayNameData(personData);

                Console.ReadKey();
            }
        }
    }

