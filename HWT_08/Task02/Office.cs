namespace Task02
{
    using System;
    using System.Collections.Generic;

    class Office
    {
        List<Person> office = new List<Person>();

        public Office()
        {
            Console.WriteLine("Офис открывается.");
        }

        private delegate void GreetMessage(object sender, OfficeEventArgs e);
        private delegate void ByeMessage(object sender, OfficeEventArgs e);
        private event GreetMessage OnCame;
        private event ByeMessage OnLeave;

        public void Add(Person p, DateTime dt)
        {
            Console.WriteLine("\n[На работу пришел {0}]", p.Name);
            OnCame?.Invoke(this, new OfficeEventArgs(p.Name, dt));
            OnCame += p.Greet;
            OnLeave += p.Goodbye;
            office.Add(p);
        }

        public void Remove(Person p)
        {
            Console.WriteLine("\n[{0} ушел домой]", p.Name);
            office.Remove(p);
            OnLeave -= p.Goodbye;
            OnLeave?.Invoke(this, new OfficeEventArgs(p.Name));
            OnCame -= p.Greet;
        }
    }
}
