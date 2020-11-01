namespace lab1_matrix_bridge
{
    public class SparseMatrix<T> : СertainMatrix<T>
    {
        public SparseMatrix(int rowsCount, int colsCount) : base(rowsCount, colsCount) { }

        protected override bool isEmpty(int rows, int cols)
        {
            return Get(rows,cols).Equals(default(T));
        }

        protected override IVector<T> InitRow()
        {
            return new SparseVector<T>(nColumn());
        }

        protected override IVector<IVector<T>> InitMatr()
        {
            var mem = new SparseVector<IVector<T>>(nRow());
            return mem;
        }
    }
}