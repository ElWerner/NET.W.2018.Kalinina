using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class SquareMatrix<T>
    {
        protected T[,] matrix;

        internal int size;

        private delegate void MsgEventHandler(MatrixEventArgs e);

        private event MsgEventHandler onElementChanging;

        public SquareMatrix() { }

        public SquareMatrix(int size)
        {
            if(size < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            EventHandler handler = new EventHandler();
            onElementChanging += handler.OnNewMessage;

            matrix = new T[size, size];
            this.size = size;
        }

        public SquareMatrix(T[,] matrix)
        {
            if(matrix == null)
            {
                throw new ArgumentNullException();
            }

            if(!IsSquareMatrix(matrix))
            {
                throw new ArgumentException();
            }

            EventHandler handler = new EventHandler();
            onElementChanging += handler.OnNewMessage;

            this.matrix = matrix;
            size = matrix.GetLength(0);
        }

        public virtual T[,] Matrix
        {
            get
            {
                return matrix;
            }

            set
            {
                if(IsSquareMatrix(value))
                {
                    matrix = value;
                }
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public T this [int i, int j]
        {
            get
            {
                if(i < 0 || j < 0 || i > Size || j > Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return matrix[i, j];
            }

            set
            {

                if (i < 0 || j < 0 || i > Size || j > Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                onElementChanging?.Invoke(new MatrixEventArgs(i, j));
                matrix[i, j] = value;
            }
        }

        public static bool IsSquareMatrix(T[,] matrix)
        {
            if(matrix == null)
            {
                return false;
            }

            if(matrix.Length == 0)
            {
                return false;
            }

            return (matrix.GetLength(0) == matrix.GetLength(1));
        }
    }
}
