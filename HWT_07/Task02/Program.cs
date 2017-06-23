/// <summary>
/// Задан английский текст. 
/// Выделить отдельные слова и для каждого посчитать частоту встречаемости. 
/// Слова, отличающиеся регистром, считать одинаковыми. 
/// В качестве разделителей считать пробел и точку.
/// </summary>
namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        /// <summary>
        /// Очищаем строку от лишних знаков пунктуации и пробелов.
        /// </summary>
        /// <param name="str"> Входная строка. </param>
        static void ClearString(ref string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char ch in str)
            {
                sb.Append(char.IsPunctuation(ch) ? ' ' : ch);
            }

            str = sb.ToString().ToLower();

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

        /// <summary>
        /// Формируем сортированный словарь из слов и их частот встречаемости.
        /// </summary>
        /// <param name="str">Входная строка.</param>
        /// <returns>Сортированный словарь.</returns>
        static public SortedDictionary<string, double> GetDict(string str)
        {
            SortedDictionary<string, double> dict = new SortedDictionary<string, double>();
            string[] result = str.Split(' ');

            for (int i = 0; i < result.Length; i++)
            {
                double count = 1;

                if (dict.ContainsKey(result[i]))
                {
                    continue;
                }

                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[i].Equals(result[j]))
                    {
                        count++;
                    }
                }

                dict.Add(result[i], Math.Round(count / result.Length, 3));
            }

            return dict;
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            SortedDictionary<string, double> SDict = new SortedDictionary<string, double>();
            string str;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите текстовую строку, или пустую строку для выхода:");
                str = Console.ReadLine();

                if (string.IsNullOrEmpty(str))
                {
                    return;
                }

                ClearString(ref str);
                SDict = GetDict(str);

                Console.WriteLine("Слово\t\tЧастота встречаемости:");
                foreach (var x in SDict)
                {
                    Console.WriteLine(" {0}\t-\t{1}", x.Key, x.Value);
                }

                Console.ReadKey();
            }
        }
    }
}
