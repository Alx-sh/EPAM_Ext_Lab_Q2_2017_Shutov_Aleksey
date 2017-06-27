namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Office : Write
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
            IConsole link = p;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\n[На работу пришел {0}]", p.Name);
            link.WriteLine(sb);

            OnCame?.Invoke(this, new OfficeEventArgs(p, dt));
            OnCame += p.Greet;
            OnLeave += p.Goodbye;
            office.Add(p);
        }

        public void Remove(Person p)
        {
            IConsole link = p;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\n[{0} ушел домой]", p.Name);
            link.WriteLine(sb);

            office.Remove(p);
            OnLeave -= p.Goodbye;
            OnLeave?.Invoke(this, new OfficeEventArgs(p));
            OnCame -= p.Greet;
        }
    }
}
