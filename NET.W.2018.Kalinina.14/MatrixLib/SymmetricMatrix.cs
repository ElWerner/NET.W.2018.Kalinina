using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int size) : base(size) { }

        public SymmetricMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException();
            }

            if (matrix.Length == 0)
            {
                throw new ArgumentNullException();
            }

            if (!IsSymmetricMatrix(matrix))
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
                if (IsSymmetricMatrix(value))
                {
                    matrix = value;
                }
            }
        }

        public static bool IsSymmetricMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                return false;
            }

            if (matrix.Length == 0)
            {
                return false;
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return false;
            }

            int size = matrix.GetLength(0);
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(!Equals(matrix[i, j], matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
