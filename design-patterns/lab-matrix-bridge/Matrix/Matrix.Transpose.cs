namespace lab_matrix_bridge
{
    public class TransposeMatrix<T> : AMatrix<T>
    {
        IMatrix<T> mem;
        public TransposeMatrix(IMatrix<T> val)
        {
            mem = val;
        }

        public override int nCol() => mem.nRow();
        public override int nRow() => mem.nCol();
        public override bool isEmpty(int iRow, int iColumn) => mem.isEmpty(iColumn,iRow);
        public override T Get(int iRow, int iColumn) => mem.Get(iColumn, iRow);
        public override bool Set(int iRow, int iColumn, T value) => mem.Set(iColumn, iRow, value);
        public override IMatrix<T> getOriginal() => mem;
    }
}
