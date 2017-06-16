/// <summary>
/// Создайте иерархию классов и пропишите ключевые методы для компьютерной игры (без реализации функционала). 
/// Суть игры:
///   1. Игрок может передвигаться по прямоугольному полю размером Width на Height.
///   2. На поле располагаются бонусы (яблоко, вишня и т.д.), которые игрок может подобрать для поднятия каких-либо характеристик.
///   3. За игроком охотятся монстры (волки, медведи и т.д.), которые могут передвигаться по карте по какому-либо алгоритму.
///   4. На поле располагаются препятствия разных типов(камни, деревья и т.д.), которые игрок и монстры должны обходить.
/// Цель игры – собрать все бонусы и не быть «съеденным» монстрами.
/// </summary>
namespace Task04
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int width = 15;
            int height = 15;

            Field field = new Field(width, height);
            Player player1 = new Player(1, "Игрок1", Player.Professions.Guardian, 0, 0);

            // Для примера заполнил поле пустыми ячейками.
            while (true)
            {
                field.GameMove();

                if(player1.Status == "Убит")
                {
                    Console.WriteLine("Поражение! Игрок убит.");
                    break;
                }

                if (field.NoBonuses())
                {
                    Console.WriteLine("Победа! На поле не осталось бонусов.");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}