using System.Collections.Generic;

namespace HackerRank.Collections
{
    public class Stack<T>
    {
        private readonly List<T> _elements;

        public Stack()
        {
            _elements = new List<T>();
        }

        public int Count => _elements.Count;

        public T Peek()
        {
            return _elements[_elements.Count - 1];
        }

        public void Push(T item)
        {
            _elements.Add(item);
        }

        public T Pop()
        {
            var result = _elements[_elements.Count - 1];
            _elements.RemoveAt(_elements.Count - 1);
            return result;
        }
    }
}
