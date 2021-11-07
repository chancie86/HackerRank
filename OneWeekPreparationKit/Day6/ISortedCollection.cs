using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.OneWeekPreparationKit.Day6
{
    public interface ISortedCollection<T>
    {
        void Add(T item);

        T RemoveFirst();

        int Count { get; }
    }
}
