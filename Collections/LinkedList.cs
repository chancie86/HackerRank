using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Collections
{
    public class SortedLinkedList<T>
        : LinkedList<T>
        where T : IComparable<T>
    {
        public SortedLinkedList(IEnumerable<T> items)
        {
            var orderedList = items.OrderBy(x => x);

            foreach (var item in orderedList)
            {
                base.Add(item);
            }
        }

        public override void Add(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (item.CompareTo(this[i]) < 0)
                {
                    InsertAt(i, item);
                    return;
                }
            }

            // Add to end of list
            base.Add(item);
        }

        public override T this[int index]
        {
            get => base[index];
            set => throw new NotImplementedException();
        }
    }

    public class LinkedList<T>
        : IEnumerable<Node<T>>
    {
        private Node<T> _first;
        private Node<T> _last;

        public int Count { get; private set; }

        public virtual void Add(T data)
        {
            var node = new Node<T>(data);

            if (_first == null)
            {
                _first = node;
            }

            if (_last != null)
            {
                _last.Next = node;
            }

            node.Previous = _last;
            _last = node;

            Count++;
        }

        public void Remove(T data)
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return;
                }

                current = current.Next;
            }
        }

        public void RemoveAt(int index)
        {
            var node = Get(index);
            var previousNode = node.Previous;
            var nextNode = node.Next;

            if (previousNode == null)
            {
                // We're removing the first node
                _first = nextNode;
            }
            else
            {
                previousNode.Next = nextNode;
            }

            if (nextNode == null)
            {
                // We're removing the last node
                _last = node.Previous;
            }
            else
            {
                nextNode.Previous = previousNode;
            }
            
            Count--;
        }

        public void InsertAt(int index, T value)
        {
            var nextNode = Get(index);
            var previousNode = nextNode.Previous;
            var newNode = new Node<T>(value);

            if (previousNode != null)
            {
                previousNode.Next = newNode;
            }

            newNode.Next = nextNode;
            nextNode.Previous = newNode;
            newNode.Previous = previousNode;

            Count++;
        }

        public virtual T this[int index]
        {
            get
            {
                var node = Get(index);
                return node.Data;
            }
            set
            {
                var node = Get(index);
                node.Data = value;
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        private Node<T> Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            var current = _first;
            for (var i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return new NodeEnumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class NodeEnumerator
            : IEnumerator<Node<T>>
        {
            private bool _first = true;
            private Node<T> _current;

            public NodeEnumerator(Node<T> first)
            {
                _current = first;
            }

            public bool MoveNext()
            {
                if (_first)
                {
                    _first = false;
                    return true;
                }

                _current = _current.Next;
                return _current != null;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public Node<T> Current => _current;

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }
}
