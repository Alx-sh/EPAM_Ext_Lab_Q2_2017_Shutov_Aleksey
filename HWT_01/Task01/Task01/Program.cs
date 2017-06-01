using System;
using System.Text;

namespace Task01
{
    ///<summary>
    /// Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.
    /// Пользователь вводит координаты точки (x; y) и выбирает букву графика(a-к). В консоли должно высветиться сообщение: «Точка[(x; y)] принадлежит фигуре[г]».
    ///</summary>
    
    class Program//todo pn Исправил
	{
        static void Main(string[] args)
        {
	        Console.InputEncoding = Encoding.Unicode;//todo pn без явного задания кодировки будет использована кодировка по умолчанию. Машина, на которой я проверяю настроена на английскую культуру, поэтому кириллические символы отображаются в ней как знаки вопроса. Следует учитывать такое специфичное поведение консоли в следующих заданиях :)/
	        Console.OutputEncoding = Encoding.Unicode;

			double x, y;
            string letter;

            while (true)
            {
                bool isDouble = false;
                bool? belong = false;

                Console.Clear();
                Console.WriteLine("Введите координаты точки (x,y):");
                while (true)
                {
                    Console.Write("x = ");
                    isDouble = double.TryParse(Console.ReadLine(), out x);
                    if (isDouble == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не верный формат входной строки! Введите действительное или целое число.");
                    }
                }
                while (true)
                {
                    Console.Write("y = ");
                    isDouble = double.TryParse(Console.ReadLine(), out y);
                    if (isDouble == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не верный формат входной строки! Введите действительное или целое число.");
                    }
                }

                Console.WriteLine("Выберите букву графика (а - к) или 0 для выхода:");
                letter = Console.ReadLine();
                switch (letter)
                {
                    case "0":
                        {
                            return;
                        }
                    case "а":
                        {
                            if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(1, 2))
                            {
                                belong = true;
                            }
                            break;
                        }
                    case "б":
                        {
                            if ((Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(1, 2)) && (Math.Pow(x, 2) + Math.Pow(y, 2) >= Math.Pow(0.5, 2)))
                            {
                                belong = true;
                            }
                            break;
                        }
                    case "в":
                        {
                            if (Math.Abs(x) <= 1 && Math.Abs(y) <= 1)
                            {
                                belong = true;
                            }
                            break;
                        }
                    case "г":
                        {
                            if (Math.Abs(x) + Math.Abs(y) <= 1)
                            {
                                belong = true;
                            }
                            break;
                        }
                    case "д":
                        {
                            if (Math.Abs(x) * 2 + Math.Abs(y) <= 1)
                            {
                                belong = true;
                            }
                            break;
                        }
                    case "е":
                        {
                            if (x <= 0 && x >= -2 && (Math.Abs(x) * 0.5 + Math.Abs(y) <= 1))
                            {
                                belong = true;
                            }
                            else
                            {
                                if (x > 0 && x <= 1 && (Math.Pow(x, 2) + Math.Pow(y, 2) <= 1))
                                {
                                    belong = true;
                                }
                            }
                            break;
                        }
                    case "ж":
                        {
                            if (y >= -1 && y <= 2 && (Math.Abs(x) * 2 + y <= 2))
                            {
                                belong = true;
                            }
                            break;
                        }
                    case "з":
                        {
                            if (y >= -2 && y <= 0 && Math.Abs(x) <= 1)
                            {
                                belong = true;
                            }
                            else
                            {
                                if (y > 0 && y <= 1 && Math.Abs(x) >= y)
                                {
                                    belong = true;
                                }
                            }                    
                            break;
                        }
                    case "и":
                        {
                            if ((y * 3 - x >= -1) && ((y <= 0 && x >= 0) || (y / 2  - x <= 1.5) && (-1 * x >= y)))
                            {
                                belong = true;
                            }
                            break;
                        }
                    case "к":
                        {
                            if (y >= 1)
                            {
                                belong = true;
                            }
                            else
                            {
                                if (y >= 0 && (Math.Abs(x) <= y))
                                {
                                    belong = true;
                                }
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("График не найден! Повторите ввод.");
                            belong = null;
                            break;
                        }
                }

                Console.WriteLine(belong == true ? "Точка ({0};{1}) принадлежит фигуре [{2}]." : (belong == false ? "Точка ({0};{1}) не принадлежит фигуре [{2}]." : string.Empty), x, y, letter); // Исправил
                Console.ReadKey();
            }
        }
    }
}