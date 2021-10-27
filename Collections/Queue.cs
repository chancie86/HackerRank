using System.Collections.Generic;

namespace HackerRank.Collections
{
    public class Queue<T>
    {
        private readonly List<T> _items;

        public Queue()
        {
            _items = new List<T>();
        }

        public T Peek()
        {
            return _items[0];
        }

        public void Enqueue(T item)
        {
            _items.Add(item);
        }

        public T Dequeue()
        {
            var item = _items[0];
            _items.RemoveAt(0);
            return item;
        }
    }
}
