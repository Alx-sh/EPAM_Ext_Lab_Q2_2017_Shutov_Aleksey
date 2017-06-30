/// <summary>
/// Напишите расширяющий метод, который определяет, является ли строка положительным целым числом. 
/// Методы Parse и TryParse не использовать.
/// </summary>
namespace Task02
{
    using System;
    using System.Text;

    public static class DataHelper
    {
        public static bool IsPositiveInteger(this string str, Predicate<char> condition)
        {
            foreach (var item in str)
            {
                if (!condition(item))
                {
                    return false;
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите строку или пустую строку для выхода:");
                string str = Console.ReadLine();

                if (string.IsNullOrEmpty(str))
                {
                    break;
                }

                Console.WriteLine("Строка{0}является целым положительным числом.", str.IsPositiveInteger(char.IsNumber) ? " " : " не ");
                Console.WriteLine("Нажмите любую клавишу для продолжения.");
                Console.ReadKey();
            }
        }
    }
}
