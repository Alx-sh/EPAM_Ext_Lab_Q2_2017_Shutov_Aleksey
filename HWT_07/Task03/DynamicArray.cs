namespace Task03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
    { 
        private const int defaultCapacity = 8;
        private T[] arr;
        private int count = 0;
        private int position = -1;

        public DynamicArray()
        {
            arr = new T[defaultCapacity];
        }

        public DynamicArray(int len)
        {
            if (len < 0)
            {
                len = defaultCapacity;
            }

            arr = new T[len];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            arr = new T[defaultCapacity];
            AddRange(collection);    
        }

        /// <summary>
        /// Добавление элемента в конец массива.
        /// </summary>
        /// <param name="item">Элемент.</param>
        public void Add(T item)
        {
            CheckSize(2 * count);//todo не очень хорошее решение с т.з. производительности. Представь, что у тебя в массиве 1млн элементов, а добавить нужно штук 100. Для чего выделять дополнительно ещё 1млн пустых записей? Лучше задать константой какое-то значение, на которое ты увеличиваешь массив при переполнении.
            arr[count++] = item;
        }

        /// <summary>
        /// Добавляет в конец массива содержимое коллекции.
        /// </summary>
        /// <param name="collection">Добавляемая коллекция.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            int enumCount = 0;
            IEnumerator<T> enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                enumCount++;
            }

            enumerator.Reset();
            CheckSize(count + enumCount);

            for (int i = count; enumerator.MoveNext(); i++)
            {
                arr[i] = enumerator.Current;
            }

            count += enumCount;
        }

        /// <summary>
        /// Удаление по индексу.
        /// </summary>
        /// <param name="index">Индекс начала удаления.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index + 1 < count)
            {
                Array.Copy(arr, index + 1, arr, index, arr.Length - index - 1);
            }

            count--;
        }

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="item">Объект.</param>
        /// <returns>Удаление.</returns>
        public bool Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (arr[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Добавление объекта в указанной позиции.
        /// </summary>
        /// <param name="index">Позиция.</param>
        /// <param name="item">Объект.</param>
        public void Insert(int index, T item)
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            CheckSize(2 * count);
            Array.Copy(arr, index, arr, index + 1, count - index);
            arr[index] = item;
            count++;
        }

        /// <summary>
        /// Проверка на свободное место в массиве, увеличение его при необходимости.
        /// </summary>
        /// <param name="newSize">Новый размер массива.</param>
        private void CheckSize(int newSize)
        {
            if (count >= arr.Length)
            {
                int len = arr.Length == 0 ? defaultCapacity : newSize;
                T[] newArr = new T[len];

                arr.CopyTo(newArr, 0);
                arr = newArr;
            }
        }

        /// <summary>
        /// Информация о массиве.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Элементы массива:");
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Количество элементов массива - {0}\nРазмер массива - {1}\n", Length, Capacity);
        }

        /// <summary>
        /// Количество элементов массива.
        /// </summary>
        public int Length
        {
            get
            {
                return count;
            }
        }

        /// <summary>
        /// Размер массива.
        /// </summary>
        public int Capacity
        {
            get
            {
                return arr.Length;
            }
        }

        public void Dispose()
        {
            Reset();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return arr[index];
            }

            set
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                arr[index] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            position++;
            return (position < count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return arr[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
