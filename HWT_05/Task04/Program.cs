/// <summary>
/// Написать свой собственный класс MyString, описывающий строку как массив символов. 
/// Перегрузить для этого класса типовые операции.
/// </summary>
namespace Task04
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            MyString str1 = new MyString();
            MyString str2 = new MyString("Строка1");
            MyString str3 = new MyString("Строка2");

            str1 = "Строка";
            str2 = str2 + str3;

            Console.WriteLine("Исходные строки:");
            Console.WriteLine("str1 = {0}", str1.ToString());
            Console.WriteLine("str2 = {0}", str2.ToString());
            Console.WriteLine("str3 = {0}", str3.ToString());

            Console.WriteLine("\nТиповые операции класса MyString:");
            Console.WriteLine("str2.Contains('к') = {0}", str3.Contains('к'));
            Console.WriteLine("str2.EndWith('1') = {0}", str3.EndWith('2'));
            Console.WriteLine("str3.IndexOf('р') = {0}", str3.IndexOf('р'));
            Console.WriteLine("str1.Insert(0,\"Новая\") = {0}", str1.Insert(0, "Новая "));
            Console.WriteLine("str1.LastIndexOf('а') = {0}", str1.LastIndexOf('а'));
            Console.WriteLine("str1.Length = {0}", str1.Length);
            Console.WriteLine("str2.Remove(6) = {0}", str2.Remove(3));
            Console.WriteLine("str3.Remove(2,2) = {0}", str3.Remove(2, 2));
            Console.WriteLine("str1.Replace('а','б') = {0}", str1.Replace('а', 'б'));
            Console.WriteLine("str1.StartWith('б') = {0}", str1.StartWith('б'));
            Console.WriteLine("str1.Substring(4) = {0}", str1.Substring(4));
            Console.WriteLine("str1.Substring(4, 3) = {0}", str1.Substring(1, 3));
            Console.WriteLine("str1.ToLower() = {0}", str1.ToLower());
            Console.WriteLine("str2.ToUpper() = {0}", str2.ToUpper());
            Console.ReadKey();
        }
    }
}
