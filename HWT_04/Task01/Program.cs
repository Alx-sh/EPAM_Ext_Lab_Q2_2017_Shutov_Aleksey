/// <summary>
/// Написать программу, которая определяет среднюю длину слова во введенной текстовой строке. 
/// Учесть, что символы пунктуации на длину слов влиять не должны. 
/// Регулярные выражения не использовать. 
/// И не пытайтесь прописать все ручками. 
/// Используйте стандартные методы класса String.
/// </summary>
namespace Task01
{
    using System;
    using System.Text;

    class Program
    {
        /// <summary>
        /// Очищаем строку от лишних знаков пунктуации и пробелов.
        /// </summary>
        /// <param name="str"> Входная строка. </param>
        static void ClearString (ref string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char ch in str)
            {
                sb.Append(char.IsPunctuation(ch) ? ' ' : ch);
            }

            str = sb.ToString();

            while (str.StartsWith(" "))
            {
                str = str.TrimStart(' ');
            }

            while (str.EndsWith(" "))
            {
                str = str.TrimEnd(' ');
            }

            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str;
            int sum = 0;
            int countWord = 1;
            int average;
           
            Console.WriteLine("Введите текстовую строку:");
            str = Console.ReadLine();

            ClearString(ref str);
            Console.WriteLine(str);
            foreach (char ch in str)
            {
                sum += (char.IsLetterOrDigit(ch) && !char.IsPunctuation(ch)) ? 1 : 0;
                countWord += (char.IsSeparator(ch) ? 1 : 0);
            }

            Console.WriteLine("Сумма всех букв в строке = {0}\nКоличество слов = {1}", sum, countWord);//Исправил

            average = sum / countWord;

            Console.WriteLine("Средняя длина слова в веденной строке - {0} символов", average);
            Console.ReadKey();
        }
    }
}