namespace Task02
{
    using System;

    class OfficeEventArgs
    {
        public Person person { get; set; }
        public DateTime dTime { get; set; }

        public OfficeEventArgs(Person p)
        {
            person = p;
        }

        public OfficeEventArgs(Person p, DateTime dt)
        {
            person = p;
            dTime = dt;
        }
    }
}
