/// <summary>
/// Создать класс Ring (кольцо), описываемое координатами центра, внешним и внутренним радиусами, а также свойствами, позволяющими узнать площадь кольца и суммарную длину внешней и внутренней границ кольца. 
/// Обеспечить нахождение класса в заведомо корректном состоянии.
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

            Ring ring1 = new Ring()
            {
                X = 1,
                Y = 2,
                r1 = new Round(3),
                r2 = new Round(4)
            };
            Console.WriteLine("Ring1:\nCoordinates of the center: ({0}, {1})\nLength:\t{2}\nArea:\t{3}\n", ring1.X, ring1.Y, ring1.GetLength(), ring1.GetArea());

            Ring ring2 = new Ring(0, 2, 1, 2);
            Console.WriteLine("Ring2:\nCoordinates of the center: ({0}, {1})\nLength:\t{2}\nArea:\t{3}", ring2.X, ring2.Y, ring2.GetLength(), ring2.GetArea());
            Console.ReadKey();
        }
    }
}
