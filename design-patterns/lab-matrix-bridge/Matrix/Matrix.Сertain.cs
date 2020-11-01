namespace lab_matrix_bridge
{
    public abstract class СertainMatrix<T> : IMatrix<T>
    {
        IVector<IVector<T>> mem;
        int rows;
        int cols;

        protected abstract IVector<IVector<T>> InitMatr();
        protected abstract IVector<T> InitRow();
        public abstract bool isEmpty(int row, int col);

        protected СertainMatrix(int nrows, int ncols)
        {
            rows = nrows;
            cols = ncols;
            mem = InitMatr();
        }
        
        protected СertainMatrix(IMatrix<T> src) :this(src.nRow(),src.nCol())
        {
            for(int i = 0;i<rows;i++)
                for(int j = 0;j<cols;j++)
                {
                    Set(i, j, src.Get(i, j));
                }
        }
        public void Print(IPrinter p)
        {
            for(int i = 0; i < nRow(); i++)
            {
                int printed = 0;
                for(int j = 0; j < nCol(); j++)
                {
                    if(!isEmpty(i, j))
                    {
                        if(printed==0)
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
        public int nRow() => rows;
        public int nCol() => cols;
        
        public T Get(int iRow, int iColumn)
        {
            if(nRow() > iRow)
            {
                var t = mem.Get(iRow);
                if(t != default(IVector<T>))
                    return t.Get(iColumn);
            }
            return default(T);
        }
        public bool Set(int iRow, int iColumn, T value)
        {
            var t = mem.Get(iRow);
            if(t == default(IVector<T>))
                mem.Set(iRow,InitRow());
            return mem.Get(iRow).Set(iColumn, value);
        }

        public IMatrix<T> getOriginal() => this;
    }
}

