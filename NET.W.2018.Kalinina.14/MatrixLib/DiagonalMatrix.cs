using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size) { }

        public DiagonalMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException();
            }

            if (matrix.Length == 0)
            {
                throw new ArgumentNullException();
            }

            if (!IsDiagonalMatrix(matrix))
            {
                throw new ArgumentException();
            }

            this.matrix = matrix;
            this.size = matrix.GetLength(0);
        }

        public override T[,] Matrix
        {
            get
            {
                return matrix;
            }

            set
            {
                if (IsDiagonalMatrix(value))
                {
                    matrix = value;
                }
            }
        }

        public static bool IsDiagonalMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                return false;
            }

            if (matrix.Length == 0)
            {
                return false;
            }

            if(matrix.GetLength(0) != matrix.GetLength(1))
            {
                return false;
            }

            int size = matrix.GetLength(0);
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(i != j && !Equals(matrix[i,j], default(T)))
                    {
                        T t = matrix[i, j];
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
