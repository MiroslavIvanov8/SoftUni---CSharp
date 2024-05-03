using Problem02.DoublyLinkedList;
using System;

namespace LiveDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
        }
    }
}
