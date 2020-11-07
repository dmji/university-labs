namespace lab_matrix_bridge
{
    public class SparseMatrix<T> : СertainMatrix<T>
    {
        public SparseMatrix(int rowsCount, int colsCount) : base(rowsCount, colsCount) { }
        public SparseMatrix(IMatrix<T> src) : base(src) { }
        public override bool isEmpty(int rows, int cols) => Get(rows,cols).Equals(default(T));
        protected override IVector<T> InitRow() => new SparseVector<T>(nCol());
        protected override IVector<IVector<T>> InitMatr() => new SparseVector<IVector<T>>(nRow());
        public override IMatrix<T> Clone() => new SimpleMatrix<T>(this);
    }
}