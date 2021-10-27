using System.Collections.Generic;
using System.Linq;
using System.Text;
using HackerRank.Collections;

namespace HakerRank
{
    public class CookieList
    {
        private readonly SortedLinkedList<int> _cookies;
        private readonly int _sweetnessThreshold;

        public CookieList(List<int> list, int sweetnessThreshold)
        {
            _sweetnessThreshold = sweetnessThreshold;
            _cookies = new SortedLinkedList<int>(list.OrderBy(x => x));
        }

        public bool IsSweetEnough => _cookies[0] >= _sweetnessThreshold;

        public void Add(int value)
        {
            for (var i = 0; i < _cookies.Count; i++)
            {
                if (value <= _cookies[i])
                {
                    _cookies.InsertAt(i, value);
                    return;
                }
            }

            // Add to end of list
            _cookies.Add(value);
        }

        public int RemoveFirst()
        {
            var result = _cookies[0];
            _cookies.RemoveAt(0);
            return result;
        }

        public int Count() => _cookies.Count;

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in _cookies)
            {
                sb.Append($"{item.Data}, ");
            }

            return sb.ToString();
        }
    }
}
