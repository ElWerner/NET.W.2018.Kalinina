using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public static class MatrixExtension
    {
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            if(firstMatrix == null || secondMatrix == null)
            {
                throw new ArgumentNullException();
            }

            if(firstMatrix.Size != secondMatrix.Size)
            {
                throw new ArgumentException();
            }

            SquareMatrix<T> resultantMatrix = new SquareMatrix<T>(firstMatrix.Size);

            try
            {
                for(int i = 0; i < resultantMatrix.Size; i++)
                {
                    for (int j = 0; j < resultantMatrix.Size; j++)
                    {
                        resultantMatrix[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                    }
                }
            }
            catch
            {
                throw new InvalidOperationException();
            }

            return resultantMatrix;
        }
    }
}
