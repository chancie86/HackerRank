using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.OneWeekPreparationKit.Day6
{
    public class SortedList<T>
        : ISortedCollection<T>
        where T : IComparable
    {
        private readonly List<T> _list;

        public SortedList(IEnumerable<T> list)
        {
            _list = new List<T>(list.OrderBy(x => x));
        }

        public void Add(T value)
        {
            for (var i = 0; i < _list.Count; i++)
            {
                if (value.CompareTo(_list[i]) < 0)
                {
                    _list.Insert(i, value);
                    return;
                }
            }

            // Add to end of list
            _list.Add(value);
        }

        public T RemoveFirst()
        {
            var result = _list[0];
            _list.RemoveAt(0);
            return result;
        }

        public int Count => _list.Count;

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in _list)
            {
                sb.Append($"{item}, ");
            }

            return sb.ToString();
        }
    }
}
