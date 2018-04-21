using System;

namespace MatrixesProject
{
    /// <summary>
    /// Abstract matrix
    /// </summary>
    /// <typeparam name="T">
    /// Type of elements
    /// </typeparam>
    public abstract class Matrix<T>
    {
        
        #region Fields

        public T[,] array;
        private int countRows;
        private int countColumns;

        #endregion
        
        #region Properties

        
        internal int CountRows
        {
            get { return countRows;}
            set
            {
                if (value > 0)
                {
                    countRows = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        internal int CountColumns
        {
            get { return countColumns; }
            set
            {
                if (value > 0)
                {
                    countColumns = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        #endregion

        #region API

        public abstract Matrix<T> Operation(Matrix<T> other, Func<T[,], T[,], T[,]> concreteOperation);

        #endregion

        #region API for event handling

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public void ChangeElement(int i, int j, T value)
        {
            array[i, j] = value;
            OnElementChanged(this, new ElementChangedEventArgs<T>(i, j, value));
        }

        protected virtual void OnElementChanged(object source, ElementChangedEventArgs<T> args)
        {
            ElementChanged?.Invoke(this, args);
        }

        #endregion

    }

    /// <summary>
    /// EventArgs for ElementChanged event
    /// </summary>
    /// <typeparam name="T">
    /// Arg of event
    /// </typeparam>
    public sealed class ElementChangedEventArgs<T> : EventArgs
    {
        public int FirstIndex { get; }

        public int SecondIndex { get; }

        public T Element { get; }

        public string Message
        {
            get => message;
        }

        public ElementChangedEventArgs(int i, int j, T value)
        {
            this.FirstIndex = i;
            this.SecondIndex = j;
            Element = value;
        }
        
    }

    /// <summary>
    /// Listener for event handling
    /// </summary>
    /// <typeparam name="T">
    /// Arg for event
    /// </typeparam>
    public sealed class Listener<T>
    {
        public Listener() { }

        public void Register(Matrix<T> matrix)
        {
            matrix.ElementChanged += SendMessage;
        }

        public void Unregister(Matrix<T> matrix)
        {
            matrix.ElementChanged -= SendMessage;
        }

        private void SendMessage(object source, ElementChangedEventArgs<T> args)
        {
            Console.WriteLine($"Element at {args.FirstIndex} column and {args.SecondIndex} row changed on {args.Element}");
        }
    }
}
