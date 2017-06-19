namespace Task01
{
    using System;

    /// <summary>
    /// Класс Employee, описывающий сотрудника фирмы.
    /// </summary>
    class Employee : User
    {
        public string Position { get; set; }
        private int lengthOfService;

        public Employee()
        {
            Position = string.Empty;
            lengthOfService = LengthOfService;
        }

        public Employee(string f, string n, string o, DateTime bd, string p, int l) : base(f, n, o, bd)
        {
            Position = p;
            LengthOfService = l;
        }

        public int LengthOfService
        {
            get
            {
                return lengthOfService;
            }

            set
            {
                if (value >= 0 && value < Age)
                {
                    lengthOfService = value;
                }
                else
                {
                    lengthOfService = 0;
                    Console.WriteLine("Некорректное значение стажа работы! Использовано значение по умолчанию: {0}.\n", lengthOfService);
                }
            }
        }
    }
}
