using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Collections
{
    public class ComparableList<T>
        : List<T>
    {
        public override bool Equals(object? obj)
        {
            var otherList = obj as List<T>;

            if (otherList == null
                || Count != otherList.Count)
            {
                return false;
            }

            for (var i = 0; i < Count; i++)
            {
                if (!this[i].Equals(otherList[i]))
                {
                    Console.WriteLine($"Expected {this}, but got {ToString(otherList)}");
                    return false;
                }
            }

            return true;
        }

        public static string ToString(IEnumerable list)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
