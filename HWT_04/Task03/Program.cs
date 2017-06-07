namespace Task03
{
    using System;
    using System.Diagnostics;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100;

            //Тест string
            Console.WriteLine("Тест string");
            sw.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            sw.Stop();

            ////Тест StringBuilder
            //Console.WriteLine("Тест StringBuilder");
            //sw.Start();
            //for (int i = 0; i < N; i++)
            //{
            //    sb.Append("*");
            //}
            //sw.Stop();

            Console.WriteLine("Общее затраченное время в миллисекундах (long):   {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("Общее затраченное время в миллисекундах (double): {0}", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("Общее затраченное время в тактах таймера (long):  {0}", sw.ElapsedTicks);
            Console.ReadKey();
        }
    }
}
