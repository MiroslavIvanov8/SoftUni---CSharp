using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        private Dictionary<T, int> indexes;
        public PriorityQueue()
        {
            this.indexes = new Dictionary<T, int>();
            this.elements = new List<T>();
        }

        public void Enqueue(T element)
        {
            this.elements.Add(element);

            indexes.Add(element, indexes.Count - 1);

            this.HeapifyUp(this.elements.Count -1);
        }

        public T Dequeue()
        {
            if (this.elements.Count == 0)
            {
                return default(T);
            }

            var element = this.elements[0];

            this.elements.RemoveAt(0);

            this.indexes.Remove(element);

            this.HeapifyDown(0);

            return element;
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

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = elements[parentIndex];
            this.elements[parentIndex] = temp;

            this.indexes[this.elements[index]] = index;
            this.indexes[this.elements[parentIndex]] = parentIndex;
        }

        public void DecreaseKey(T key)
        {
            this.HeapifyUp(this.indexes[key]);

            //int smallerParentIndex = this.GetParentIndex(index);
            //while (IsIndexValid(smallerParentIndex) && this.IsSmaller(index, smallerParentIndex)) 
            //{
            //    this.Swap(index, smallerParentIndex);

            //    index = smallerParentIndex;
            //    smallerParentIndex = GetParentIndex(index);
            //}
        }

        public void DecreaseKey(T key, T newKey)
        {
            var oldIndex = this.indexes[key];
            this.elements[oldIndex] = newKey;
            this.indexes.Remove(key);
            this.indexes[newKey] = oldIndex;
            this.HeapifyUp(oldIndex);
        }
    }
}
