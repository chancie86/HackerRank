using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Collections
{
    public class MinHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> _elements;

        public MinHeap()
        {
            _elements = new List<T>();
        }

        public bool IsEmpty => _elements.Any();

        public T Peek => _elements[0];

        public int Count => _elements.Count;

        public T Poll()
        {
            var result = _elements[0];
            _elements.RemoveAt(0);

            HeapifyDown();

            return result;
        }

        public void Add(T item)
        {
            _elements.Add(item);
            HeapifyUp();
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _elements.Count;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < _elements.Count;
        private bool HasParent(int index) => GetParentIndex(index) >= 0;
        private bool IsRoot(int index) => index == 0;

        private T GetLeftChild(int index) => _elements[GetLeftChildIndex(index)];
        private T GetRightChild(int index) => _elements[GetRightChildIndex(index)];
        private T GetParent(int index) => _elements[GetParentIndex(index)];

        private void Swap(int index1, int index2)
        {
            var temp = _elements[index1];
            _elements[index1] = _elements[index2];
            _elements[index2] = temp;
        }

        private void HeapifyUp()
        {
            var index = _elements.Count - 1; // Last item
            while (HasParent(index)
                   && GetParent(index).CompareTo(_elements[index]) > 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown()
        {
            var index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);

                if (HasRightChild(index)
                    && GetRightChild(index).CompareTo(GetLeftChild(index)) < 0)
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (_elements[index].CompareTo(_elements[smallerChildIndex]) < 0)
                {
                    break;
                }

                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }
    }
}
