using System.Linq;
using System.Text;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.children.Add(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.Dfs(this, sb, 0);

            return sb.ToString().Trim();

        }


        private void Dfs(Tree<T> tree, StringBuilder sb, int indent)
        {
            sb.Append(' ', indent)
              .AppendLine(tree.Key.ToString());
                

            foreach (var child in tree.children)
            {
                this.Dfs(child, sb,indent + 2);
            }
        }

        public List<T> GetMiddleKeys()
        {
            var internalNodes = BfsGetResultNodes(x => x.Children.Count > 0 && x.Parent != null)
                .Select(t => t.Key)
                .ToList();

            return internalNodes;
        }

        public List<T> GetLeafKeys()
        {
            var leafs = BfsGetResultNodes(x => x.Children.Count == 0)
                .Select(t => t.Key)
                .ToList();

            return leafs;
        }

        private IEnumerable<Tree<T>> BfsGetResultNodes(Predicate<Tree<T>> predicate)
        {
            List<Tree<T>> result = new List<Tree<T>>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Any())
            {
                var currNode = queue.Dequeue();
                if (predicate.Invoke(currNode))
                {
                    result.Add(currNode);
                }
                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }

            }

            return result;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var deepestKey = this.GetDeepestNode();

            return deepestKey;
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = this.BfsGetResultNodes(t => t.children.Count == 0);
            Tree<T> deepestNode = null;
            var maxDepth = 0;

            foreach (var leaf in leafs)
            {
                var depth = this.GetDepth(leaf);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;

            var tree = leaf;
            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = this.GetDeepestNode();
            var longestPathStack = new Stack<T>();

            var longestRoute = new List<T>();
            
            while (deepestNode.Parent != null)
            {
                longestPathStack.Push(deepestNode.Key);

                deepestNode = deepestNode.Parent;
            }

            longestPathStack.Push(deepestNode.Key);

            longestRoute.AddRange(longestPathStack);

            return longestRoute;
        }
        private Tree<T> GetSecondDeepestNode(IEnumerable<T> longestRoute)
        {
            var leafs = this.BfsGetResultNodes(t => t.children.Count == 0);
            Tree<T> secondDeepestNode = null;
            var maxDepth = 0;

            foreach (var leaf in leafs)
            {
                var depth = this.GetDepth(leaf);

                if (depth > maxDepth && !longestRoute.Contains(leaf.Key) && !longestRoute.Contains(leaf.Parent.Key))
                {
                    maxDepth = depth;
                    secondDeepestNode = leaf;
                }
            }

            return secondDeepestNode;
        }
        
        public List<T> GetLongestPathFromLeafToLeaf()
        {
            var deepestNode = this.GetDeepestNode();

            IEnumerable<T> firstRoute = this.GetRouteToRoot(deepestNode);

            var secondDeepestNode = this.GetSecondDeepestNode(firstRoute);

            IEnumerable<T> secondRoute = this.GetRouteToRoot(secondDeepestNode);

            ICollection<T> longestRoute = new List<T>();

            foreach (var node in firstRoute.Reverse())
            {
                longestRoute.Add(node);
            }

            foreach (var node in secondRoute)
            {
                if (longestRoute.Contains(node))
                {
                    continue;
                }

                longestRoute.Add(node);
            }


            return longestRoute.ToList();
        }

        private IEnumerable<T> GetRouteToRoot(Tree<T> node)
        {
            var longestRoute = new Stack<T>();
            while (node.Parent != null)
            {
                longestRoute.Push(node.Key);

                node = node.Parent;
            }

            longestRoute.Push(node.Key);

            return longestRoute;
        }
    }
}
