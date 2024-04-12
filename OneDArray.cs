using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace task4_1
{
    internal class OneDArray<T> : IArray<T> where T : IComparable<T>
    {
        private int _size;
        private int _capacity;
        const int default_size = 4;

        private T[] _array;

        public delegate bool Condition();

        int IArray<T>.GetValues {
            get { return _size; }
        }

        //Создание массива с ёмкостью по умолчанию.
        public OneDArray()
        {
            _size = 0;
            _array = new T[0];
        }

        //Создание массива заданной ёмкости.
        public OneDArray(int capacity)
        {
            _capacity = capacity;
            _array = new T[capacity];
            _size = 0;
        }

        //Добавление элемента в массив. Если массив заполнен, увеличить его ёмкость по правилу 2n + 1 и добавить элемент на первую свободную позицию.
        public void Add(T elem)
        {
            if (_size >= _capacity)
            {
                _capacity = 2 * _capacity + 1;
                Array.Resize(ref _array, _size);
            }
            _array[_size] = elem;
            _size++;
            //_array.Append(elem);
        }


        //Удаление элемента из массива.
        public void Remove(T elem)
        {
            int index = Array.IndexOf(_array, elem);
            Array.Clear(_array, index, 1);
        }

        //Сортировка массива.
        public void Sort()
        {
            Array.Sort(_array);
        }

        //Подсчет количества элементов в массиве.
        public int Count()
        {
            return _array.Length;
        }

        //Подсчет количества элементов в массиве, удовлетворяющих переданному условию.
        public int Count(Func<T, bool> condition)
        {
            int count = 0;
            foreach (T elem in _array)
            {
                if (condition(elem))
                {
                    count++;
                }
            }
            return count;
        }

        //Проверка выполнения переданного условия хотя бы одного элемента массива.
        public bool Check(Func<T, bool> condition)
        {
            foreach (T elem in _array)
            {
                if(condition(elem))
                {
                    return true;
                }
            }
            return false;
        }

        //Проверка выполнения переданного условия для всех элементов массива.
        public bool CheckAll(Func<T, bool> condition)
        {
            foreach (T elem in _array)
            {
                if (!condition(elem))
                {
                    return false;
                }
            }
            return true;
        }

        //Проверка наличия элемента в массиве.
        public bool Find(T elem)
        {
            if(Array.IndexOf(_array, elem)==-1)
                return false;
            return true;
        }

        //Получение первого элемента в массиве, удовлетворяющего условию.
        public bool FindFirst(Func<T, bool> condition, ref T elem)
        {
            for (int i = 0; i < _size; i++)
            {
                if (condition(_array[i]))
                {
                    elem = _array[i];
                    return true;
                }
            }
            return false;
        }

        public static bool MyFunc(T el)
        { 
            if(el == null) 
                return false;    
            return true;
        }

        //Применение переданного действия ко всем элементам массива.
        public void ForEach( Action<T> action)
        {
            for(int i = 0; i < _size; i++)
            {
                action(_array[i]);
            }
            //Array.ForEach(_array, action);
        }

        //Получение элементов массива, удовлетворяющих переданному условию.
        public T[] GetElemntByCondition(Func<T, bool> condition)
        {
            T[] arr = {};
            foreach (T el in _array)
            {
                if(condition(el))
                    arr.Append(el);
            }
            return arr;
        }

        //Получение элементов массива выбранного типа.
        public T[] GetElemntByType(Type a)
        {
            //if(typeof(T)==)
            T[] arr  = { };
            foreach (T el in _array)
            {
                if (typeof(T) == a)
                    arr.Append(el);
            }
            return arr;
        }

        //Переворот массива.
        public void Reverse()
        {
            Array.Reverse(_array);
        }

        //Получение минимального/максимального элемента массива.
        public static T max<T>(T first, T second) where T : IComparable<T>
        {
            if (second.CompareTo(first) > 0)
            {
                return second;
            }
            return first;
        }

        //Получение минимального/максимального элемента массива по его проекции.
        public static T min<T>(T first, T second) where T : IComparable<T>
        {
            if (second.CompareTo(first) > 0)
            {
                return first;
            }
            return second;
        }


        //Проекция элементов массива в другой тип.
        public T[] proect(Type a)
        {
            T[] new_array = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                new_array[i] = _array[i];
            }
            return new_array;
        }

        //Получить заданное количество элементов массива с указанного индекса.
        public T[] getElemntsFromTo(int start, int end)
        {
            T[] temp_array = {};
            Array.Copy(_array, start, temp_array, 0, end-start);
            return temp_array;
        }

        //Итерирование по экземпляру массива с помощью цикла foreach
        public void AddIteration()
        {
            //foreach (T el in _array)
        }


        #region Enumerable
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
