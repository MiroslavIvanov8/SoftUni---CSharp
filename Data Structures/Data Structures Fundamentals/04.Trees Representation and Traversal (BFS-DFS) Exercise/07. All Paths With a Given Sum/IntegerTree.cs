using System.Collections;
using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        //DFS
        public List<List<int>> PathsWithGivenSum(int sum)
        {
            List<List<int>> paths = new List<List<int>>();
            LinkedList<int> currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);

            int wantedSum = sum;

            this.Dfs(this ,paths,currentPath ,wantedSum);
            
            return paths;
        }

        private void Dfs(
            Tree<int> subTree,
            List<List<int>> paths,
            LinkedList<int> currentPath,
            int wantedSum)
        {
            foreach (var child in subTree.Children)
            {
                currentPath.AddLast(child.Key);
                this.Dfs(child,paths,currentPath, wantedSum); // most interesting part here.
            }

            if (currentPath.Sum() == wantedSum)
            {
                paths.Add(currentPath.ToList());
            }

            currentPath.RemoveLast(); // removing every new last node so can have new  path starting from root

        }

        //BFS
        public List<Tree<int>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<int>> subTrees = new List<Tree<int>>();
            Tree<int> root = this.GetRoot(this);
            var allNodes = this.GetAllNodesBfs(root);
            int wantedSum = sum;

            foreach (var node in allNodes)
            {
                int currentSum = node.Key;
                this.GetSubTreesWithGivenSumDfs(node, ref currentSum );

                if (currentSum == wantedSum)
                {
                    subTrees.Add(node);
                }
            }

            return subTrees;
        }

        private IntegerTree GetRoot(IntegerTree tree)
        {
            Queue<IntegerTree> queue = new Queue<IntegerTree>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IntegerTree node = queue.Dequeue();

                if (node.Parent == null)
                {
                    return node;
                }

                foreach (IntegerTree child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private void GetSubTreesWithGivenSumDfs(Tree<int> tree, ref int currentSum)
        {
            foreach (var child in tree.Children)
            {
                currentSum += child.Key;
                GetSubTreesWithGivenSumDfs(child, ref currentSum);
            }
        }


        private IEnumerable<Tree<int>> GetAllNodesBfs(Tree<int> node)
        {
            List<Tree<int>> allNodes = new List<Tree<int>>();
            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            queue.Enqueue(node);

            while (queue.Any())
            {
                var currentTree = queue.Dequeue(); 

                foreach (var child in currentTree.Children)
                {
                    allNodes.Add(currentTree); // why this is an issue if it's inside the foreach
                    queue.Enqueue(child);
                }
            }

            return allNodes;
        }
    }
}
