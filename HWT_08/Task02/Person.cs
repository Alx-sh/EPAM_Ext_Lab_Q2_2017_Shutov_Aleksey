namespace Task02
{
    using System;

    class Person
    {
        public string Name { get; set; }

        public void Greet(object sender, OfficeEventArgs e)
        {
            Console.WriteLine("'{0}, {1}!', - сказал {2}.",
                e.dTime.Hour >= 12 && e.dTime.Hour < 17 ? "Добрый день" : (e.dTime.Hour < 12 ? "Доброе утро" : "Добрый вечер"), 
                e.person.Name, 
                Name);
        }

        public void Goodbye(object sender, OfficeEventArgs e)
        {
            Console.WriteLine("'До свидания, {0}!', - сказал {1}.", e.person.Name, Name);
        }
    }
}
