namespace MatrixesProject
{
    /// <summary>
    /// Class discribes diagonal matrix
    /// </summary>
    /// <typeparam name="T">
    /// Type of elements
    /// </typeparam>
    public class DiagonalMatrix<T>:SquareMatrix<T>
    {
        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="size">
        /// Size of matrix
        /// </param>
        public DiagonalMatrix(int size) : base(size)
        {
            for (int i = 0; i < CountColumns; i++)
            {
                for (int j = 0; j < CountRows; j++)
                {
                    if (i != j)
                    {
                        array[i, j] = default(T);
                    }
                }
            }
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="arr">
        /// Array of matrix
        /// </param>
        public DiagonalMatrix(T[,] arr) : base(arr)
        {
            for (int i = 0; i < CountColumns; i++)
            {
                for (int j = 0; j < CountRows; j++)
                {
                    if (i != j)
                    {
                        array[i, j] = default(T);
                    }
                }
            }
        }
    }
}