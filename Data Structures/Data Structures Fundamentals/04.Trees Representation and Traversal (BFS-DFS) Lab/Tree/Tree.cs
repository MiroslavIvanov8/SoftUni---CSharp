using System.Collections;
using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private List<Tree<T>> children;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);
            result.Add(this.value);

            while(queue.Any())
            {
                var currentTree = queue.Dequeue();
                foreach (var child in currentTree.children)
                {
                   queue.Enqueue(child);
                   result.Add(child.value);
                }
            }

            return result;
        }

        public Tree<T> FindTreeWithBfs(T key)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Any())
            {
                var currentTree = queue.Dequeue();
                if (currentTree.value.Equals(key))
                {
                    return currentTree;
                }
                foreach (var child in currentTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public IEnumerable<T> OrderDfs()
        {
            List<T> list = new List<T>();
            this.Dfs(this, list);
            return list;
            
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {
            foreach (var child in node.children)
            {
                this.Dfs(child,result);
            }

            result.Add(node.value);
        }

        public IEnumerable<T> DfsWithStack()
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            var result = new Stack<T>();

            stack.Push(this);

            while (stack.Any())
            {
                var currentTree = stack.Pop();
                foreach (var child in currentTree.children)
                {
                    stack.Push(child);
                }

                result.Push(currentTree.value);
            }

            return result;

        }
        public void AddChild(T parentKey, Tree<T> child)
        {
            var node = this.FindTreeWithBfs(parentKey);

            if (node == null)
            {
                throw new ArgumentNullException();
            }

            node.children.Add(child);
            child.parent = node;
        }

        public void RemoveNode(T nodeKey)
        {
            var nodeToRemove = this.FindTreeWithBfs(nodeKey);

            if (nodeToRemove == null)
            {
                throw new ArgumentNullException();
            }

            if (nodeToRemove.parent == null)
            {
                throw new ArgumentException();
            }

            var parent = nodeToRemove.parent;

            parent.children.Remove(nodeToRemove);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindTreeWithBfs(firstKey);
            var secondNode = this.FindTreeWithBfs(secondKey);

            if(firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }

            if (firstNode.parent == null || secondNode.parent == null)
            {
                throw new ArgumentException();
            }

            var firstParent = firstNode.parent;
            var secondParent = secondNode.parent;

            int firstNodeIndex = firstParent.children.IndexOf(firstNode);
            int secondNodeIndex = secondParent.children.IndexOf(secondNode);

            firstParent.children[firstNodeIndex] = secondNode;
            secondParent.children[secondNodeIndex] = firstNode;

            firstNode.parent = secondParent;
            secondNode.parent = firstParent;

        }
    }
}
