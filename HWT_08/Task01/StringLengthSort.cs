namespace Task01
{
    using System.Collections.Generic;

    class StringLengthSort : IComparer<string>
    {
        public int Compare(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                return 1;
            }
            else
            {
                if (str1.Length < str2.Length)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < str1.Length; i++)
                    {
                        if (!str1[i].Equals(str2[i]))
                        {
                            return str1[i] > str2[i] ? 1 : -1;
                        }
                    }

                    return 0;
                }
            }
        }
    }
}
