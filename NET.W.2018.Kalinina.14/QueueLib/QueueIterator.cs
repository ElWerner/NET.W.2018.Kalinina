using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    public class QueueIterator<T>
    {
        private readonly Queue<T> collection;
        private int currentIndex;

        public QueueIterator(Queue<T> collection)
        {
            currentIndex = -1;
            this.collection = collection;
        }

        public T Current
        {
            get
            {
                if (currentIndex == -1 || currentIndex > collection.Count)
                    throw new ArgumentOutOfRangeException();

                return collection[currentIndex];
            }
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public bool MoveNext()
        {
            if(currentIndex < collection.Count)
            {
                currentIndex++;
                return (currentIndex < collection.Count);
            }

            return false;
        }
    }
}
