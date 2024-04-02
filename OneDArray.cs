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

        const int default_size = 4;

        private T[] _array;

        public delegate bool Condition();

        int IArray<T>.GetValues {
            get { return _size; }
        }

        //Создание массива с ёмкостью по умолчанию.
        public OneDArray()
        {
            _array = new T[default_size];
        }

        //Создание массива заданной ёмкости.
        public OneDArray(int size)
        {
            _array = new T[size];
        }

        //Добавление элемента в массив. Если массив заполнен, увеличить его ёмкость по правилу 2n + 1 и добавить элемент на первую свободную позицию.
        public void Add(T elem)
        {
            if (_array.Length == 0 || _size == _array.Length)
            {
                _size = 2 * _size + 1;
                Array.Resize(ref _array, _size);
            }
            _array.Append(elem);
        }

        //Удаление элемента из массива.
        public void Remove(T elem)
        {
            T[] temp_array = new T[_size];

            int index = Array.IndexOf(_array, elem);

            for (int i = 0; i < _size; i++)
            {
                if (i == index)
                {
                    continue;
                }
                else
                {
                    temp_array.Append(temp_array[i]);
                }
            }
            _array = temp_array;
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
        public int Count(bool condition)
        {
            int count = 0;
            if(condition) count++;
            return count;
        }

        //Проверка выполнения переданного условия хотя бы одного элемента массива.
        public bool Check(bool condition)
        {
            foreach (T elem in _array)
            {
                if(condition)
                {
                    return true;
                }
            }
            return false;
        }

        //Проверка выполнения переданного условия для всех элементов массива.
        public bool CheckAll(bool condition)
        {
            foreach (T elem in _array)
            {
                if (!condition)
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
        public T? FindFirst(T el)
        {
            T? first = Array.Find(_array, MyFunc);
            return first;

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
            Array.ForEach(_array, action);
        }

        //Получение элементов массива, удовлетворяющих переданному условию.
        public T[] GetElemntByCondition(Condition condition)
        {
            T[] arr = {};
            foreach (T el in _array)
            {
                if(condition())
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
        public T GetMin()
        {
            T[] array = _array;
            Array.Sort(array);
            return array[0];
        }
        public T GetMax()
        {
            T[] array = _array;
            Array.Sort(array);
            return array[_array.Length-1];
        }
        //Получение минимального/максимального элемента массива по его проекции.
        
        //Проекция элементов массива в другой тип.
        
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
