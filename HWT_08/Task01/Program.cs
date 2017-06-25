/// <summary>
/// Написать программу, выполняющую сортировку массива строк по возрастанию длины. 
/// Если строки состоят из равного числа символов, их следует отсортировать по алфавиту. 
/// Реализовать метод сравнения строк отдельным методом, передаваемым в сортировку через делегат.
/// </summary>
namespace Task01
{
    using System;
    using System.Text;

    class Program
    {
        delegate void ArrSort(string[] str);

        private static void Sort(string[] str)
        {
            Array.Sort(str, new StringLengthSort());

            Console.WriteLine("\nМассив строк после сортировки:");

            foreach (var i in str)
            {
                Console.WriteLine(i);
            }
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string[] str = { "First string", "Second string", "abcdef", "qwerty", "asdfgh", "asdfga" };

            Console.WriteLine("Исходный массив строк:");
            foreach (var i in str)
            {
                Console.WriteLine(i);
            }

            ArrSort s = Sort;
            s?.Invoke(str);

            Console.ReadKey();
        }
    }
}