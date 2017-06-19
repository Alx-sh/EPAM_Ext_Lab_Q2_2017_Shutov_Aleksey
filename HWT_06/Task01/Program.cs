/// <summary>
/// На основе класса User (см. задание 3 из предыдущей темы), создать класс Employee, описывающий сотрудника фирмы. 
/// В дополнение к полям пользователя добавить поля «стаж работы» и «должность». 
/// Обеспечить нахождение класса в заведомо корректном состоянии.
/// </summary>
namespace Task01
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Employee emp1;
            Employee emp2;

            emp1 = new Employee();
            Console.WriteLine("ФИО:\t\t {0} {1} {2}\nДата рождения:\t {3:dd MMMM yyyy}\nВозраст:\t {4}\nДолжность:\t {5}\nСтаж работы:\t {6}", emp1.Surname, emp1.Name, emp1.Patronymic, emp1.BirthDate, emp1.Age, emp1.Position, emp1.LengthOfService);
            Console.WriteLine("\nНажмите любую клавишу для продолжения.\n");
            Console.ReadKey();

            emp1.Surname = "Иванов";
            emp1.Name = "Иван";
            emp1.Patronymic = "Иванович";
            emp1.BirthDate = new DateTime(2000, 01, 01);
            emp1.Position = "Программист";
            emp1.LengthOfService = 1;
            Console.WriteLine("ФИО:\t\t {0} {1} {2}\nДата рождения:\t {3:dd MMMM yyyy}\nВозраст:\t {4}\nДолжность:\t {5}\nСтаж работы:\t {6}", emp1.Surname, emp1.Name, emp1.Patronymic, emp1.BirthDate, emp1.Age, emp1.Position, emp1.LengthOfService);
            Console.WriteLine("\nНажмите любую клавишу для продолжения.\n");
            Console.ReadKey();

            emp2 = new Employee("Шутов", "Алексей", "Андреевич", new DateTime(1996, 05, 02), "Директор", 5);
            Console.WriteLine("ФИО:\t\t {0} {1} {2}\nДата рождения:\t {3:dd MMMM yyyy}\nВозраст:\t {4}\nДолжность:\t {5}\nСтаж работы:\t {6}", emp2.Surname, emp2.Name, emp2.Patronymic, emp2.BirthDate, emp2.Age, emp2.Position, emp2.LengthOfService);
            Console.WriteLine("\nНажмите любую клавишу для продолжения.\n");
            Console.ReadKey();
        }
    }
}
