namespace Task02
{
    using System;
    using System.Text;

    public interface IConsole
    {
        void WriteLine(StringBuilder sb);
    }

    class Write : IConsole
    {
        void IConsole.WriteLine(StringBuilder sb)
        {
            Console.WriteLine(sb.ToString());
        }
    }
}
