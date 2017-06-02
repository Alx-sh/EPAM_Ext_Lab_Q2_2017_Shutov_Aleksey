/// <summary>
/// Написать программу, которая удваивает в первой введенной строки все символы, принадлежащие второй введенной строке.
/// Пример:
/// Введите первую строку: написать программу, которая
/// Введите вторую строку: описание
/// Результирующая строка: ннааппииссаать ппроограамму, коотоораая
/// </summary>
namespace Task02
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
 
            string strFirst;
            string strSecond;
            StringBuilder result = new StringBuilder();

            Console.Write("Введите первую строку: ");
            strFirst = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            strSecond = Console.ReadLine();

            foreach (char ch in strFirst)
            {
                result.Append(ch);
                if (strSecond.Contains(ch.ToString()))
                {
                    result.Append(ch);
                }  
            }

            Console.WriteLine("Результирующая строка: {0}", result);
            Console.ReadKey();
        }
    }
}