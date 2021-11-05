using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Day6
{
    public interface ISortedCollection<T>
    {
        void Add(T item);

        T RemoveFirst();

        int Count { get; }
    }
}
