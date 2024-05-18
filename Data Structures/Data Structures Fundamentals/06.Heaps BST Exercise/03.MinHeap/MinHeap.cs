using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);

            while (index >= 0 && this.IsSmaller(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(parentIndex);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private protected bool IsSmaller(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) < 0;
        }

        protected int GetParentIndex(int index)
        {
            return (index -1) / 2;
        }

        public T ExtractMin()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            int smallerChildIndex = this.GetSmallerChildIndex(index);
            while (IsIndexValid(smallerChildIndex) && this.IsSmaller(smallerChildIndex, index))
            {
                this.Swap(index, smallerChildIndex);

                index = smallerChildIndex;
                smallerChildIndex = this.GetSmallerChildIndex(index);
            }
        }

        internal bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }

        private protected int GetSmallerChildIndex(int index)
        {
            int leftChildIndex = (index * 2) + 1; // different formulas for heapifyUp and heapifyDown
            int rightChildIndex = (index * 2) + 2;

            //interesting part !!!
            if (rightChildIndex < this.elements.Count)
            {
                if (this.elements[leftChildIndex].CompareTo(this.elements[rightChildIndex]) < 0)
                {
                    return leftChildIndex;
                }

                return rightChildIndex;
            }
            else if (leftChildIndex < this.elements.Count)
            {
                return leftChildIndex;
            }
            else
            {

                return -1;
            }


            return default;
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }
    }
}
