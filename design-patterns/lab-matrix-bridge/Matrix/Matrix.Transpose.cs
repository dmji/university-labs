namespace lab_matrix_bridge
{
    public class TransposeMatrix<T> : IMatrix<T>
    {
        IMatrix<T> mem;
        public TransposeMatrix(IMatrix<T> val)
        {
            mem = val;
        }

        public int nCol() => mem.nRow();
        public int nRow() => mem.nCol();
        
        public bool isEmpty(int iRow, int iColumn) => mem.isEmpty(iColumn,iRow);
        public void Print(IPrinter p)
        {
            for(int i = 0; i < nRow(); i++)
            {
                int printed = 0;
                for(int j = 0; j < nCol(); j++)
                {
                    if(!isEmpty(i, j))
                    {
                        if(printed == 0)
                            p.PrintBorder();
                        p.PrintBorderElement();
                        p.Print<T>(Get(i, j));
                        p.PrintBorderElement();
                        printed++;
                    }
                }
                if(printed > 0)
                    p.PrintBorder();
            }
            p.ReleasePrint();
        }

        public T Get(int iRow, int iColumn) => mem.Get(iColumn, iRow);

        public bool Set(int iRow, int iColumn, T value) => mem.Set(iColumn, iRow, value);
        

        public IMatrix<T> getOriginal() => mem;
    }
}
