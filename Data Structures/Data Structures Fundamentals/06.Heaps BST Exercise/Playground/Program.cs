using System;
using _02.BinarySearchTree;
using _03.MinHeap;
using _04.CookiesProblem;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            IBinarySearchTree<int> bts = new BinarySearchTree<int>();

            bts.Insert(10);
            bts.Insert(20);
            bts.Insert(30);
            bts.Insert(11);
            

            bts.DeleteMin();
        }
    }
}
