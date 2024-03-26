using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace task4_1
{
    internal class OneDArray<T> : IArray<T>
    {
        private int _size;

        const int default_size = 4;

        private T[] _array;

        int IArray<T>.GetValues{
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
            if(_array.Length==0)
                Array.Resize(ref _array, 2*_size+1);
            _array.Append(elem);
        }

        //Удаление элемента из массива.
        public void Remove(T elem)
        {
            //Array.FindIndex<T>(_array, elem);

            foreach (T el  in _array)
            {
                
            } 
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

        //Проверка наличия элемента в массиве.
        public bool Find()
        {
            return true;
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
