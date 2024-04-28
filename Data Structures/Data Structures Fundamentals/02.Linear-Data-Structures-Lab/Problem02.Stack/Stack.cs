namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.element = element;
                this.Next = next;
            }

            public Node(T element)
            :base()
            {
                this.element = element;
            }
        }

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node node = new Node(item, this.top);
            this.top = node;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.top.element;
            this.top = this.top.Next;
            this.Count--;

            return element;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.top.element;
        }

        public bool Contains(T item)
        {
            if (this.Count == 0)
            {
                return false;
            }

            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.top;
            while (node != null)
            {
                yield return node.element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}