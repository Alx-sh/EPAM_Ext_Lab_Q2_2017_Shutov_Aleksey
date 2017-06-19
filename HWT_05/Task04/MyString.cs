namespace Task04
{
    /// <summary>
    /// Класс MyString.
    /// </summary>
    class MyString
    {
        private char[] str { get; set; }

        /// <summary>
        /// Возвращает число знаков в текущем объекте MyString.
        /// </summary>
        public int Length
        {
            get
            {
                return str.Length;
            }
        }

        /// <summary>
        /// Получает индекс элемента в текущем объекте MyString.
        /// </summary>
        /// <param name="i">Индекс элемента.</param>
        /// <returns>Элемент по заданному индексу</returns>
        public char this[int i]
        {
            get
            {
                return str[i];
            }

            set
            {
                str[i] = value;
            }
        }

        public MyString()
        {
        }

        public MyString(char[] arr)
        {
            str = arr;
        }

        public MyString(string arr)
        {
            str = arr.ToCharArray();
        }

        /// <summary>
        /// Возвращает значение, указывающее, встречается ли указанный символ внутри этой строки.
        /// </summary>
        /// <param name="ch">Символ.</param>
        /// <returns>Содержит ли строка заданный символ.</returns>
        public bool Contains(char ch)
        {
            return IndexOf(ch) != -1;
		}

        /// <summary>
        /// Определяет, совпадает ли начало данного экземпляра строки с указанным символом.
        /// </summary>
        /// <param name="ch">Символ</param>
        /// <returns>Совпадает ли начало строки с заданным символом.</returns>
        public bool StartWith(char ch)
        {
            return str[0] == ch;
		}

        /// <summary>
        /// Определяет, совпадает ли конец данного экземпляра строки с указанным символом.
        /// </summary>
        /// <param name="ch">Символ.</param>
        /// <returns>Совпадает ли конец строки с заданным символом.</returns>
        public bool EndWith(char ch)
        {
            return str[str.Length - 1] == ch;
		}

        /// <summary>
        /// Возвращает копию этой строки, переведенный в нижний регистр.
        /// </summary>
        /// <returns>Новая строка.</returns>
        public MyString ToLower()
        {
            char[] newStr = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                newStr[i] = char.ToLower(str[i]);
            }

            return new MyString(newStr);
        }

        /// <summary>
        /// Возвращает копию этой строки, переведенный в верхний регистр.
        /// </summary>
        /// <returns>Новая строка.</returns>
        public MyString ToUpper()
        {
            char[] newStr = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                newStr[i] = char.ToUpper(str[i]);
            }

            return new MyString(newStr);
        }

        /// <summary>
        /// Возвращает новую строку, в которой все вхождения заданного знака Юникода в текущем экземпляре заменены другим заданным знаком Юникода.
        /// </summary>
        /// <param name="oldCh">Символ, который требуется заменить.</param>
        /// <param name="newCh">Символ, на который требуется заменить.</param>
        /// <returns>Новая строка.</returns>
        public MyString Replace(char oldCh, char newCh)
        {
            char[] newStr = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                newStr[i] = str[i] == oldCh ? newCh : str[i];
            }

            return new MyString(newStr);
        }

        /// <summary>
        /// Возвращает новую строку, в которой были удалены все символы, начиная с указанной позиции и до конца в текущем экземпляре.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <returns>Новая строка.</returns>
        public MyString Remove(int index)
        {
            index = index > str.Length ? str.Length : index;

            char[] newStr = new char[index];

            for (int i = 0; i < index; i++)
            {
                newStr[i] = str[i];
            }

            return new MyString(newStr);
        }

        /// <summary>
        /// Возвращает новую строку, в которой было удалено указанное число символов в указанной позиции.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <param name="count">Количество символов.</param>
        /// <returns>Новая строка.</returns>
        public MyString Remove(int index, int count)
        {
            index = index > str.Length ? str.Length : index;
            count = (count + index > str.Length) ? (str.Length - index) : (str.Length - index - count);

            char[] newStr = new char[str.Length - count];

            for (int i = 0; i < index; i++)
            {
                newStr[i] = str[i];
            }

            for (int i = index; i < str.Length - count; i++)
            {
                newStr[i] = str[i + count];
            }

            return new MyString(newStr);
        }

        /// <summary>
        /// Возвращает новую строку, в которой указанная строка вставляется на указанной позиции индекса в данном экземпляре.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <param name="arr">Вставляемая строка.</param>
        /// <returns>Новая строка.</returns>
        public MyString Insert(int index, MyString arr)
        {
            index = index > str.Length ? str.Length : index;

            char[] newStr = new char[str.Length + arr.Length];

            for (int i = 0; i < index; i++)
            {
                newStr[i] = str[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                newStr[i + index] = arr[i];
            }

            for (int i = index; i < str.Length; i++)
            {
                newStr[i + arr.Length] = str[i];
            }

            return new MyString(newStr);
        }

        /// <summary>
        /// Вовзвращает индекс с отсчетом от нуля первого вхождения указанного символа Юникода в данной строке.
        /// </summary>
        /// <param name="ch">Символ.</param>
        /// <returns>Индекс символа.</returns>
        public int IndexOf(char ch)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Вовзвращает позицию индекса с отсчетом от нуля последнего вхождения указанного символа Юникода в пределах данного экземпляра.
        /// </summary>
        /// <param name="ch">Символ.</param>
        /// <returns>Индекс символа.</returns>
        public int LastIndexOf(char ch)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Извлекает подстроку из данного экземпляра. Подстрока начинается в указанном положении символов и продолжается до конца строки.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <returns>Новая строка.</returns>
        public MyString Substring(int index)
        {
            index = index > str.Length ? str.Length : index;

            char[] arr = new char[str.Length - index];

            for (int i = 0; i < str.Length - index; i++)
            {
                arr[i] = str[index + i];
            }

            return new MyString(arr);
        }

        /// <summary>
        /// Извлекает подстроку из данного экземпляра. Подстрока начинается с указанной позиции знака и имеет указанную длину.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <param name="count">Длина строки.</param>
        /// <returns>Новая строка.</returns>
        public MyString Substring(int index, int count)
        {
            index = index > str.Length ? str.Length : index;
            count = (count + index > str.Length) ? (str.Length - index) : (str.Length - index - count);

            char[] arr = new char[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = str[index + i];
            }

            return new MyString(arr);
        }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        /// <returns>Новая строка.</returns>
        public override string ToString()
        {
            return new string(str);
        }

        /// <summary>
        /// Конкатенация строк.
        /// </summary>
        /// <param name="arr1">Первая строка.</param>
        /// <param name="arr2">Вторая строка.</param>
        /// <returns>Новая строка.</returns>
        public static MyString operator +(MyString arr1, MyString arr2)
        {
            char[] arr = new char[arr1.Length + arr2.Length];
            arr1.str.CopyTo(arr, 0);
            arr2.str.CopyTo(arr, arr1.Length);
            return new MyString(arr);
        }

        /// <summary>
        /// Неявное приведение.
        /// </summary>
        /// <param name="arr">Строка.</param>
        public static implicit operator MyString(string arr)
        {
            return new MyString(arr);
        }
    }
}
