/// <summary>
/// Для выделения текстовой надписи можно использовать выделение жирным, курсивом и подчёркиванием. 
/// Предложите способ хранения информации о выделении надписи и напишите программу, которая позволяет назначать и удалять текстовой надписи выделение.
/// </summary>
namespace Task06
{
    using System;
    using System.Text;

    class Program
    {
        /// <summary>
        /// Добавление и удаление подстрок в строку str.
        /// </summary>
        /// <param name="numStr"> Добавляемая строка по номеру в списке меню. </param>
        /// <param name="str"> Ссылка на строка параметров надписи. </param>
        /// <returns> Измененная строка. </returns>
        static string NewString(string numStr, ref string str)
        {
            int index = str.IndexOf(numStr);

            if (index == -1)
            {
                str = str == "None" ? numStr : str + ", " + numStr;
            }
            else
            {
                str = index == 0 ? str.Remove(index, numStr.Length) : str.Remove(index - 2, numStr.Length + 2);
            }

            return str;
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str = string.Empty;
            string num;
            string bold = "Bold";
            string italic = "Italic";
            string underline = "Undeline";

            while (true)
            {
                if (str == string.Empty)
                {
                    str = "None";
                }

                if (str.StartsWith(","))
                {
                    str = str.Remove(0, 2);
                }

                Console.Clear();
                Console.WriteLine("Параметры надписи: {0}", str);
                Console.WriteLine("Введите: \n\t1: {0} \n\t2: {1} \n\t3: {2} \n\t4: Очистить строку \n\t0: Выход", bold, italic, underline);

                num = Console.ReadLine();
                switch (num)
                {
                    case "0":
                        {
                            return;
                        }

                    case "1":
                        {
                            str = NewString(bold, ref str);
                            break;
                        }

                    case "2":
                        {
                            str = NewString(italic, ref str);
                            break;
                        }

                    case "3":
                        {
                            str = NewString(underline, ref str);
                            break;
                        }

                    case "4":
                        {
                            str = "None";
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Неверный пункт меню! Нжамите любую клавишу для продолжения.");
                            Console.ReadLine();
                            break;
                        }
                }
            }
        }
    }
}