namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex;
        private int endIndex;
        public CircularQueue(int capacity = 4)
        {
            this.elements = new T[capacity];
        }
        

        public int Count { get; private set; }
        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            Count++;

        }
        private void Grow()
        {
            this.elements = this.CopyElements(new T[this.elements.Length * 2]);
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyElements(T[] resultArr)
        {
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }

            return resultArr;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            
            if (this.Count <= this.elements.Length / 2)
            {
                this.Shrink();
            }
            if (this.Count == 1)
            {
                this.Count--;
                return this.elements[startIndex];
            }

            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;

            return this.elements[startIndex - 1];
        }

        private void Shrink()
        {
            T[] newArr = new T[this.elements.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }

            this.elements = newArr;

            this.startIndex = 0;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;

        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[startIndex];
        }

        public T[] ToArray()
        {
            return this.CopyElements(new T[this.Count]);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int currentIndex = 0; currentIndex < Count; currentIndex++)
            {
                int index = (startIndex + currentIndex) % this.elements.Length;
                yield return this.elements[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator(); 
    }

}
