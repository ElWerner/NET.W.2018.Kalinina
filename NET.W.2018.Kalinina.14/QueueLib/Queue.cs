using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    public class Queue<T>
    {
        private T[] container;

        private int head;

        private int tail;

        private int size;

        private const int DEFAULTSIZE = 32;

        public Queue() : this(DEFAULTSIZE)
        {            
        }

        public Queue(int capacity)
        {
            if(capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            container = new T[capacity];
            head = 0;
            tail = 0;
            size = 0;
        }

        public Queue(params T[] elements)
        {
            if(elements == null)
            {
                throw new ArgumentNullException();
            }

            if(elements.Length == 0)
            {
                throw new ArgumentException();
            }

            container = new T[elements.Length];
            for(int i = 0; i < elements.Length; i++)
            {
                Enqueue(elements[i]);
            }

            size = elements.Length;
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public T this[int index]
        {
            get
            {
                if(index < head || index > tail)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return container[index];
            }
            set
            {
                if (index < head || index > tail)
                {
                    throw new ArgumentOutOfRangeException();
                }

                container[index] = value;
            }
        }

        public void Enqueue (T element)
        {
            if(size == container.Length)
            {
                SetCapacity(DEFAULTSIZE * 2);
            }

            container[size] = element;
            size++;
            tail++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new Exception();
            }

            T dequeuedElement = container[head];
            container[head] = default(T);
            head++;
            size--;
            return dequeuedElement;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new Exception();
            }

            return container[head];
        }

        public QueueIterator<T> Iterator()
        {
            return new QueueIterator<T>(this);
        }

        private void SetCapacity(int newCapacity)
        {
            T[] newContainer = new T[newCapacity];
            Array.Copy(container, head, newContainer, 0, size);

            container = newContainer;
            head = 0;
            tail = size;
        }

    }
}
