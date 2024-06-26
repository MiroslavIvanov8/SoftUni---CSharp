﻿using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.Win32.SafeHandles;

namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }
            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree()
        {

        }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        public bool Contains(T element)
        {
            //return Contains(element, this.root);
            return FindNode(element) != null;
        }

        private bool Contains(T element, Node node)
        {
            if (node == null) 
            {
                return false;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                return this.Contains(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                return this.Contains(element, node.Right);
            }

            return true;
        }

        private Node FindNode(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }
        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);

            action.Invoke(node.Value);

            this.EachInOrder(action, node.Right);
            
        }


        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }
            
            return new BinarySearchTree<T>(node);
        }
    }
}
