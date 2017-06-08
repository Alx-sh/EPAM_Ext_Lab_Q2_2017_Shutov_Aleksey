﻿/// <summary>
/// Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст). 
/// Написать программу, демонстрирующую использование этого класса.
/// </summary>
namespace Task03
{
    using System;
    using System.Text;

    class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        private int age;

        public User()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Patronymic = string.Empty;
            BirthDate = DateTime.Now;
            age = Age;
        }

        public User(string f, string n, string o, DateTime bd)
        {
            Surname = f;
            Name = n;
            Patronymic = o;
            BirthDate = bd;
            age = Age;
        }

        public int Age
        {
            get
            {
                age = (DateTime.Today.Year - BirthDate.Year);
                if (BirthDate > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            User us1;
            User us2;

            us1 = new User();
            Console.WriteLine("ФИО:\t\t {0} {1} {2}\nДата рождения:\t {3:dd MMMM yyyy}\nВозраст:\t {4}", us1.Surname, us1.Name, us1.Patronymic, us1.BirthDate, us1.Age);
            Console.WriteLine("\nНажмите любую клавишу для продолжения.\n");
            Console.ReadKey();

            us1.Surname = "Иванов";
            us1.Name = "Иван";
            us1.Patronymic = "Иванович";
            us1.BirthDate = new DateTime(2010, 01, 01);
            Console.WriteLine("ФИО:\t\t {0} {1} {2}\nДата рождения:\t {3:dd MMMM yyyy}\nВозраст:\t {4}", us1.Surname, us1.Name, us1.Patronymic, us1.BirthDate, us1.Age);
            Console.WriteLine("\nНажмите любую клавишу для продолжения.\n");
            Console.ReadKey();

            us2 = new User("Шутов", "Алексей", "Андреевич", new DateTime(1996, 05, 02));
            Console.WriteLine("ФИО:\t\t {0} {1} {2}\nДата рождения:\t {3:dd MMMM yyyy}\nВозраст:\t {4}", us2.Surname, us2.Name, us2.Patronymic, us2.BirthDate, us2.Age);
            Console.WriteLine("\nНажмите любую клавишу для продолжения.\n");
            Console.ReadKey();
        }
    }
}
