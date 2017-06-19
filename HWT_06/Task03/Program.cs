/// <summary>
/// Напишите заготовку для векторного графического редактора. 
/// Полная версия редактора должна позволять создавать и выводить на экран такие фигуры как: Линия, Окружность, Прямоугольник, Круг, Кольцо. 
/// Заготовка, для упрощения, должна представлять собой консольное приложение с функционалом:
///    1. Создать фигуру выбранного типа по произвольным координатам.
///    2. Вывести фигуры на экран(для каждой фигуры вывести на консоль её тип и значения параметров).
/// </summary>
namespace Task03
{
    using System;
    using System.Text;

    class Program
    {
        static int X, Y, i = 0;
        static double R1, R2, Width, Height, Angle;

        /// <summary>
        /// Добавление подстрок в строку str.
        /// </summary>
        /// <param name="numStr"> Добавляемая строка по номеру в списке меню. </param>
        /// <param name="str"> Ссылка на строку параметров надписи. </param>
        /// <returns> Измененная строка. </returns>
        static string NewString(string numStr, string str)
        {
            i++;
            return str == "None" ? ("\n" + i + ") " + numStr) : (str + "\n" + i + ") " + numStr);
        }

        /// <summary>
        /// Заполнение параметров фигуры.
        /// </summary>
        /// <param name="num"> Номер фигуры.</param>
        static void Parameters(string num)
        {
            Console.Clear();
            Console.WriteLine("Введите координаты фигуры:");

            while (true)
            {
                Console.Write("X = ");
                if (int.TryParse(Console.ReadLine(), out X))
                {
                    break;
                }

                Console.WriteLine("Введите корректное значение!");
            }

            while (true)
            {
                Console.Write("Y = ");
                if (int.TryParse(Console.ReadLine(), out Y))
                {
                    break;
                }

                Console.WriteLine("Введите корректное значение!");
            }

            switch (num)
            {
                case "1":
                case "2":
                case "3":
                    {
                        Console.WriteLine("Введите радиус окружности:");
                        while (true)
                        {
                            Console.Write("R = ");
                            if (double.TryParse(Console.ReadLine(), out R1))
                            {
                                break;
                            }

                            Console.WriteLine("Введите корректное значение!");
                        }

                        if (num == "3")
                        {
                            Console.WriteLine("Введите радиус второй окружности:");
                            while (true)
                            {
                                Console.Write("R = ");
                                if (double.TryParse(Console.ReadLine(), out R2))
                                {
                                    break;
                                }

                                Console.WriteLine("Введите корректное значение!");
                            }
                        }

                        break;
                    }

                case "4":
                case "5":
                    {
                        Console.WriteLine("Введите длину:");
                        while (true)
                        {
                            Console.Write("Width = ");

                            if (double.TryParse(Console.ReadLine(), out Width))
                            {
                                break;
                            }

                            Console.WriteLine("Введите корректное значение!");
                        }

                        if (num == "5")
                        {
                            Console.WriteLine("Введите высоту:");

                            while (true)
                            {
                                Console.Write("Height = ");
                                if (double.TryParse(Console.ReadLine(), out Height))
                                {
                                    break;
                                }

                                Console.WriteLine("Введите корректное значение!");
                            }
                        }

                        Console.WriteLine("Введите угол наклона (от 0 до 360 градусов):");

                        while (true)
                        {
                            Console.Write("Angle = ");
                            if (double.TryParse(Console.ReadLine(), out Angle))
                            {
                                break;
                            }

                            Console.WriteLine("Введите корректное значение!");
                        }

                        break;
                    }

                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str = string.Empty;
            string num;
            string circle = "Окружность";
            string round = "Круг";
            string ring = "Кольцо";
            string line = "Линия";
            string rectangle = "Прямоугольник";

            while (true)
            {
                if (str == string.Empty)
                {
                    str = "None";
                }

                if (str.StartsWith("\n"))
                {
                    str = str.Remove(0, 1);
                }

                Console.Clear();
                Console.WriteLine("Созданные фигуры:\n{0}", str);
                Console.WriteLine("Введите для создания: \n\t1: {0} \n\t2: {1} \n\t3: {2} \n\t4: {3} \n\t5: {4} \n\t6: Удалить созданные фигуры \n\t0: Выход", circle, round, ring, line, rectangle);

                num = Console.ReadLine();
                Console.Clear();
                switch (num)
                {
                    case "0":
                        {
                            return;
                        }

                    case "1":
                        {
                            Parameters(num);
                            Circle c = new Circle(X, Y, R1);
                            str = NewString(c.ToString(), str);
                            break;
                        }

                    case "2":
                        {
                            Parameters(num);
                            Round ro = new Round(X, Y, R1);
                            str = NewString(ro.ToString(), str);
                            break;
                        }

                    case "3":
                        {
                            Parameters(num);
                            Ring ri = new Ring(X, Y, R1, R2);
                            str = NewString(ri.ToString(), str);
                            break;
                        }

                    case "4":
                        {
                            Parameters(num);
                            Line l = new Line(X, Y, Width, Angle);
                            str = NewString(l.ToString(), str);
                            break;
                        }

                    case "5":
                        {
                            Parameters(num);
                            Rectangle rec = new Rectangle(X, Y, Width, Height, Angle);
                            str = NewString(rec.ToString(), str);
                            break;
                        }

                    case "6":
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