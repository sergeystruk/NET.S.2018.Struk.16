using System;

namespace MatrixesProject
{
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="size">
        /// Size of matrix
        /// </param>
        public SquareMatrix(int size)
        {
            CountColumns = size;
            CountRows = size;
            array = new T[size, size];
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="arr">
        /// Array of matrix
        /// </param>
        public SquareMatrix(T[,] arr) : this(arr.Length)
        {
            array = arr;
        }

        /// <summary>
        /// Provides arithmetic operations for matrix
        /// </summary>
        /// <param name="other">
        /// Other parameter for operation
        /// </param>
        /// <param name="concreteOperation">
        /// Explanation of operation
        /// </param>
        /// <returns>
        /// Result of operation
        /// </returns>
        public sealed override Matrix<T> Operation(Matrix<T> other, Func<T[,], T[,], T[,]> concreteOperation)
        {
            if (ReferenceEquals(other, null))
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (this.CountColumns != other.CountColumns)
            {
                throw new ArgumentException(nameof(other));
            }

            return new SquareMatrix<T>(concreteOperation(array, other.array));
        }
    }
}