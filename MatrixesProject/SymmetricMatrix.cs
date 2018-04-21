namespace MatrixesProject
{
    /// <summary>
    /// Class discribes Symmetric matrix
    /// </summary>
    /// <typeparam name="T">
    /// Type of elements
    /// </typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="size">
        /// Size of matrix
        /// </param>
        public SymmetricMatrix(int size) : base(size) { }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="arr">
        /// Array of matrix
        /// </param>
        public SymmetricMatrix(T[,] arr) : base(arr)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[j, i] = array[i, j];
                }
            }
        }
    }
}