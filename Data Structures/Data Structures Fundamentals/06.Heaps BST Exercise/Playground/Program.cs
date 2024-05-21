using System;
using System.Threading.Channels;
using _02.BinarySearchTree;
using _03.MinHeap;
using _04.CookiesProblem;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>();

            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(37);
            tree.Insert(43);
            tree.Insert(60);
            tree.Insert(50);
            tree.Insert(49);
            tree.Insert(51);
            tree.Insert(48);
            tree.Insert(5);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);

            tree.Delete(50);
            

            tree.EachInOrder(Console.WriteLine);
        }
    }

    
}
