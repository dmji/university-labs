namespace lab_matrix_bridge
{
    public class ReAssignMatrix<T> : AMatrix<T>
    {
        IMatrix<T> mem;
        SparseVector<int> rows;
        SparseVector<int> cols;
        public ReAssignMatrix(IMatrix<T> val)
        {
            mem = val;
            cols = new SparseVector<int>(nCol());
            rows = new SparseVector<int>(nRow());
        }
        public override int nCol() => mem.nCol();
        public override int nRow() => mem.nRow();
        public override bool isEmpty(int iRow, int iColumn)
        {
            int fRow = rows.findFirst(iRow);
            int fCol = cols.findFirst(iColumn);
            return mem.isEmpty(fRow == -1 ? iRow : fRow, fCol == -1 ? iColumn : fCol);
        }
        public override T Get(int iRow, int iColumn)
        {
            int fRow = rows.findFirst(iRow);
            int fCol = cols.findFirst(iColumn);
            return mem.Get(fRow == -1 ? iRow : fRow, fCol == -1 ? iColumn : fCol);
        }
        public override bool Set(int iRow, int iColumn, T value)
        {
            int fRow = rows.findFirst(iRow);
            int fCol = cols.findFirst(iColumn);
            return mem.Set(fRow == -1 ? iRow : fRow, fCol == -1 ? iColumn : fCol, value);
        }
        public override IMatrix<T> getOriginal() => mem.getOriginal();
        public bool SwapCols(int i1, int i2)
        {
            if(i1 >= 0 && i1 < nCol() && i2 >= 0 && i2 < nCol())
            {
                cols.Set(i1, i2);
                cols.Set(i2, i1);
                return true;
            }
            return false;
        }
        public bool SwapRows(int i1, int i2)
        {
            if( i1 >=0 && i1 < nRow() && i2 >= 0 && i2 < nRow())
            {
                rows.Set(i1, i2);
                rows.Set(i2, i1);
                return true;
            }
            return false;
        }
    }
}
