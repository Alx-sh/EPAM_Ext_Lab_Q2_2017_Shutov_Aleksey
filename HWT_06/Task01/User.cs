﻿namespace Task01
{
    using System;

    /// <summary>
    /// Класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст). 
    /// </summary>
    class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        protected int age;

        public User()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Patronymic = string.Empty;
            BirthDate = DateTime.Now;
        }

        public User(string f, string n, string o, DateTime bd)
        {
            Surname = f;
            Name = n;
            Patronymic = o;
            BirthDate = bd;
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
}

