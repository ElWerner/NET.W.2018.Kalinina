using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLib
{
    /// <summary>
    /// A class that represents tree node entity
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class TreeNode<T>
    {
        /// <summary>
        /// Tree node data
        /// </summary>
        public T data;

        /// <summary>
        /// Reference to the left node
        /// </summary>
        public TreeNode<T> leftNode;

        /// <summary>
        /// Reference to the right node
        /// </summary>
        public TreeNode<T> rightNode;

        /// <summary>
        /// Reference to the parent node
        /// </summary>
        public TreeNode<T> parentNode;

        /// <summary>
        /// Initializes a new instance of the <see cref=TreeNode{T}/> class
        /// </summary>
        /// <param name="data"></param>
        public TreeNode(T data)
        {
            this.data = data;
        }
    }

    /// <summary>
    /// Represents a class providing binary tree search operations
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class BinaryTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// Tree root
        /// </summary>
        public TreeNode<T> rootNode;

        /// <summary>
        /// Provides method that compares two objects with the same type
        /// </summary>
        public Comparison<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class
        /// </summary>
        /// <param name="collection">Collection of data</param>
        /// <param name="comparison">Comparision method</param>
        /// <exception cref="ArgumentNullException">Thrown when data collection or comparision method is null</exception>
        public BinaryTree(IEnumerable<T> collection, Comparison<T> comparison)
        {
            if(collection == null )
            {
                throw new ArgumentNullException("Data collection is null.");
            }

            if(comparison == null)
            {
                throw new ArgumentNullException("Comparision method is null.");
            }

            rootNode = null;
            comparer = comparison;

            foreach (var element in collection)
            {
                InsertNode(element);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class with default comparision method
        /// </summary>
        /// <param name="collection">Data collection</param>
        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default.Compare)
        {
        }

        /// <summary>
        /// Inserts new node into binary tree
        /// </summary>
        /// <param name="data">New node data</param>
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

        /// <summary>
        /// Chechks if current binary tree contains specified element
        /// </summary>
        /// <param name="element">Element to find</param>
        /// <returns>True if binary tree contains element. False otherwise</returns>
        public bool Contains(T element)
        {
            if(rootNode == null)
            {
                return false;
            }

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

        /// <summary>
        /// Provides infix traversal of the binary tree
        /// </summary>
        /// <returns>Enumareble infix traverse</returns>
        public IEnumerable<T> InOrder()
        {
            return InOrder(rootNode);
        }

        /// <summary>
        /// Provides prefix traversal of the binary tree
        /// </summary>
        /// <returns>Enumareble prefix traverse</returns>
        public IEnumerable<T> PreOrder()
        {
            return PreOrder(rootNode);
        }

        /// <summary>
        /// Provides postfix traversal of the binary tree
        /// </summary>
        /// <returns>Enumareble postfix traverse</returns>
        public IEnumerable<T> PostOrder()
        {
            return PostOrder(rootNode);
        }

        /// <summary>
        /// Provides infix traversal of the binary tree
        /// </summary>
        /// <returns>Enumareble infix traverse</returns>
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

        /// <summary>
        /// Provides prefix traversal of the binary tree
        /// </summary>
        /// <returns>Enumareble prefix traverse</returns>
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

        /// <summary>
        /// Provides postfix traversal of the binary tree
        /// </summary>
        /// <returns>Enumareble postfix traverse</returns>
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

        /// <summary>
        ///Returns enumerable infix traversal of the binary tree
        /// </summary>
        /// <returns>enumerable infix traversal</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        /// <summary>
        /// Returns enumerotor for the binary tree
        /// </summary>
        /// <returns>Enumerator for the binary tree</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
