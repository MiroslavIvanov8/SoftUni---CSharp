using System.Runtime.CompilerServices;

namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
           this.elements.Add(element);
           this.HeapifyUp(this.elements.Count -1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);
            while (index >= 0 && this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var element = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = element;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public T ExtractMax()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            int biggerChildIndex = this.GetBiggerChildIndex(index);
            while (IsIndexValid(biggerChildIndex) && this.IsGreater(biggerChildIndex, index))
            {
                this.Swap(index, biggerChildIndex);

                index = biggerChildIndex;
                biggerChildIndex = GetBiggerChildIndex(index);
            }
        }



        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }

        private int GetBiggerChildIndex(int index)
        {
            int leftChildIndex = (index * 2) + 1;
            int rightChildIndex = (index * 2) + 2;


            //interesting part !!!
            if (rightChildIndex < this.elements.Count)
            {
                if (this.elements[leftChildIndex].CompareTo(this.elements[rightChildIndex]) > 0)
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
