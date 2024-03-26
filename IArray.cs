using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_1
{
    internal interface IArray<T> : IEnumerable<T>
    {
        int GetValues { get; }

        public void Add(T elem);

        public void Remove(T elem);

        public void Sort();

        public int Count();

    }
}
