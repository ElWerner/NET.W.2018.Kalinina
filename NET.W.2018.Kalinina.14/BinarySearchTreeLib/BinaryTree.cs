using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLib
{
    public class TreeNode<T>
    {
        public T data;
        public TreeNode<T> leftNode;
        public TreeNode<T> rightNode;
        public TreeNode<T> parentNode;

        public TreeNode(T data)
        {
            this.data = data;
        }
    }

    public class BinaryTree<T> : IEnumerable<T>
    {
        public TreeNode<T> rootNode;
        public Comparison<T> comparer;

        public BinaryTree(IEnumerable<T> collection, Comparison<T> comparison)
        {
            rootNode = null;
            comparer = comparison;

            foreach (var element in collection)
            {
                InsertNode(element);
            }
        }

        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default.Compare)
        {
        }

        public void InsertNode(T data)
        {
            TreeNode<T> newNode = new TreeNode<T>(data);

            if(rootNode == null)
            {
                rootNode = newNode;
            }
            else
            {
                TreeNode<T> currentNode = rootNode;

                TreeNode<T> parentNode = null;
                while(currentNode != null)
                {
                    parentNode = currentNode;
                    if (comparer(data, currentNode.data) < 0)
                    {

                        currentNode = currentNode.leftNode;
                        if(currentNode == null)
                        {
                            parentNode.leftNode = newNode;
                        }
                    }
                    else if (comparer(data, currentNode.data) == 0)
                    {
                        currentNode.data = data;
                    }
                    else
                    {
                        currentNode = currentNode.rightNode;
                        if (currentNode == null)
                        {
                            parentNode.rightNode = newNode;
                        }
                    }
                }
            }
        }

        public bool Contains(T element)
        {
            TreeNode<T> currentNode = rootNode;

            while(currentNode != null)
            {
                if(comparer(element, currentNode.data) == 0)
                {
                    return true;
                }
                else if(comparer(element, currentNode.data) < 0)
                {
                    currentNode = currentNode.leftNode;
                }
                else
                {
                    currentNode = currentNode.rightNode;
                }
            }

            return false;
        }

        public IEnumerable<T> InOrder()
        {
            return InOrder(rootNode);
        }

        public IEnumerable<T> PreOrder()
        {
            return PreOrder(rootNode);
        }

        public IEnumerable<T> PostOrder()
        {
            return PostOrder(rootNode);
        }

        private IEnumerable<T> InOrder(TreeNode<T> currentNode)
        {
            if(currentNode.leftNode != null)
            {
                foreach(var node in InOrder(currentNode.leftNode))
                {
                    yield return node;
                }
            }

            yield return currentNode.data;

            if (currentNode.rightNode != null)
            {
                foreach (var node in InOrder(currentNode.rightNode))
                {
                    yield return node;
                }
            }
        }

        private IEnumerable<T> PreOrder(TreeNode<T> currentNode)
        {
            yield return currentNode.data;

            if (currentNode.leftNode != null)
            {
                foreach (var node in PreOrder(currentNode.leftNode))
                {
                    yield return node;
                }
            }

            if (currentNode.rightNode != null)
            {
                foreach (var node in PreOrder(currentNode.rightNode))
                {
                    yield return node;
                }
            }
        }

        private IEnumerable<T> PostOrder(TreeNode<T> currentNode)
        {
            if (currentNode.leftNode != null)
            {
                foreach (var node in PostOrder(currentNode.leftNode))
                {
                    yield return node;
                }
            }

            if (currentNode.rightNode != null)
            {
                foreach (var node in PostOrder(currentNode.rightNode))
                {
                    yield return node;
                }
            }

            yield return currentNode.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
