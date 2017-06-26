namespace Task02
{
    using System;

    class OfficeEventArgs
    {
        public string name { get; set; }
        public DateTime dTime { get; set; }

        public OfficeEventArgs(string n)
        {
            name = n;
        }

        public OfficeEventArgs(string n, DateTime dt)
        {
            name = n;
            dTime = dt;
        }
    }
}
