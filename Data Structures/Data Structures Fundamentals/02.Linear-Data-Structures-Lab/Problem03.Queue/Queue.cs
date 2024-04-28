using System.Xml;

namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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
                : base()
            {
                this.element = element;
            }
        }

        private Node head;

        public int Count { get; private set; }
     

        public void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (this.head == null)
            {
                head = newNode;
            }
            else
            {
                var node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }
            this.Count++; 
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;
            this.head = oldHead.Next;
            this.Count--;

            return oldHead.element;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            return this.head.element;
        }

        public bool Contains(T item)
        {
            if (this.head == null)
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
            var node = this.head;
            while (node != null)
            {
                yield return node.element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}