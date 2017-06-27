namespace Task02
{
    using System.Text;

    class Person : Write
    {
        public string Name { get; set; }

        public void Greet(object sender, OfficeEventArgs e)
        {
            IConsole link = e.person;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("'{0}, {1}!', - сказал {2}.",
                e.dTime.Hour >= 12 && e.dTime.Hour < 17 ? "Добрый день" : (e.dTime.Hour < 12 ? "Доброе утро" : "Добрый вечер"),
                e.person.Name,
                Name);  
            link.WriteLine(sb);
        }

        public void Goodbye(object sender, OfficeEventArgs e)
        {
            IConsole link = e.person;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("'До свидания, {0}!', - сказал {1}.", e.person.Name, Name);
            link.WriteLine(sb);
        }
    }
}
