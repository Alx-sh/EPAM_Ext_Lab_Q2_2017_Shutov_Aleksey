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
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str = string.Empty;
            string num;
            string bold = "Bold";
            string italic = "Italic";
            string underline = "Undeline";
            int index;

            while (true)
            {
                if (str.Length == 0)
                {
                    str = "None";
                }

                if (str[0] == ',')
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
                            index = str.IndexOf(bold);
                            if (index == -1)
                            {
                                if (str == "None")
                                {
                                    str = bold;
                                }
                                else
                                {
                                    str += ", " + bold;
                                }
                            }
                            else
                            {
                                if (index == 0)
                                {
                                    str = str.Remove(index, bold.Length);
                                }
                                else
                                {
                                    str = str.Remove(index - 2, bold.Length + 2);
                                }
                            }

                            break;
                        }

                    case "2":
                        {
                            index = str.IndexOf(italic);
                            if (index == -1)
                            {
                                if (str == "None")
                                {
                                    str = italic;
                                }
                                else
                                {
                                    str += ", " + italic;
                                }
                            }
                            else
                            {
                                if (index == 0)
                                {
                                    str = str.Remove(index, italic.Length);
                                }
                                else
                                {
                                    str = str.Remove(index - 2, italic.Length + 2);
                                }
                            }

                            break;
                        }

                    case "3":
                        {
                            index = str.IndexOf(underline);
                            if (index == -1)
                            {
                                if (str == "None")
                                {
                                    str = underline;
                                }
                                else
                                {
                                    str += ", " + underline;
                                }
                            }
                            else
                            {
                                if (index == 0)
                                {
                                    str = str.Remove(index, underline.Length);
                                }
                                else
                                {
                                    str = str.Remove(index - 2, underline.Length + 2);
                                }
                            }

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