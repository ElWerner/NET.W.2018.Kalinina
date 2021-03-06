﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    /// <summary>
    /// Represents a class providing basic operations with queue
    /// </summary>
    /// <typeparam name="T">Type of queue elements</typeparam>
    public class Queue<T>
    {
        #region Constants

        /// <summary>
        /// Default queue size
        /// </summary>
        private const int DEFAULTSIZE = 32;

        #endregion

        #region Fields

        /// <summary>
        /// An array to hold queue elements
        /// </summary>
        private T[] container;

        /// <summary>
        /// Head index of the queue
        /// </summary>
        private int head;

        /// <summary>
        /// Tail index of the queue
        /// </summary>
        private int tail;

        /// <summary>
        /// Amount of elements stored in the queue
        /// </summary>
        private int size;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class with default capacity
        /// </summary>
        public Queue() : this(DEFAULTSIZE)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class with specified capacity
        /// </summary>
        /// <param name="capacity">Queue capacity</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when capacity is less or equal than 0</exception>
        public Queue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capacuty must be greater than 0.");
            }

            container = new T[capacity];
            head = 0;
            tail = 0;
            size = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class with specified elements
        /// </summary>
        /// <param name="elements">Queue elements</param>
        /// <exception cref="ArgumentNullException">Thrown when elements are not initialized</exception>
        public Queue(params T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Elements is null.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Elements is null.");
            }

            container = new T[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                Enqueue(elements[i]);
            }

            size = elements.Length;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets amount of elements in the queue
        /// </summary>
        public int Count
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Gets or sets queue element on specified index
        /// </summary>
        /// <param name="index">Index of queue element</param>
        /// <returns>Queue element on specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is less than head index or greater than tail index</exception>
        public T this[int index]
        {
            get
            {
                if (index < head || index > tail)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }

                return container[index];
            }

            set
            {
                if (index < head || index > tail)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }

                container[index] = value;
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Adds new element at the queue tail
        /// </summary>
        /// <param name="element">Added element</param>
        public void Enqueue(T element)
        {
            if (size == container.Length)
            {
                SetCapacity(DEFAULTSIZE * 2);
            }

            container[size] = element;
            size++;
            tail++;
        }

        /// <summary>
        /// Deletes an element from the queue head
        /// </summary>
        /// <returns>Deleted element</returns>
        /// <exception cref="Exception">Thrown when queue is null</exception>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new Exception("Queue is null.");
            }

            T dequeuedElement = container[head];
            container[head] = default(T);
            head++;
            size--;
            return dequeuedElement;
        }

        /// <summary>
        /// Returns an element from the queue head, but doesn't delete it
        /// </summary>
        /// <returns>First queue element</returns>
        /// <exception cref="Exception">Thrown when queue is null</exception>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new Exception();
            }

            return container[head];
        }

        /// <summary>
        /// Returns queue iterator
        /// </summary>
        /// <returns>Queue iterator</returns>
        public QueueIterator<T> Iterator()
        {
            return new QueueIterator<T>(this);
        }

        #endregion

        #region Private API

        /// <summary>
        /// Creates new queue with increased size
        /// </summary>
        /// <param name="newCapacity">Increased queue</param>
        private void SetCapacity(int newCapacity)
        {
            T[] newContainer = new T[newCapacity];
            Array.Copy(container, head, newContainer, 0, size);

            container = newContainer;
            head = 0;
            tail = size;
        }

        #endregion
    }
}
