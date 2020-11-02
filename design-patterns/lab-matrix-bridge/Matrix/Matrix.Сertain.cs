namespace lab_matrix_bridge
{
    public abstract class AMatrix<T> : IMatrix<T>
    {
        public abstract T Get(int iRow, int iColumn);
        public abstract IMatrix<T> getOriginal();
        public abstract bool isEmpty(int row, int col);
        public abstract int nCol();
        public abstract int nRow();
        public abstract bool Set(int iRow, int iColumn, T value);
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
    }

    public abstract class СertainMatrix<T> : AMatrix<T>
    {
        IVector<IVector<T>> mem;
        int rows;
        int cols;

        protected abstract IVector<IVector<T>> InitMatr();
        protected abstract IVector<T> InitRow();

        protected СertainMatrix(int nrows, int ncols)
        {
            rows = nrows;
            cols = ncols;
            mem = InitMatr();
        }

        protected СertainMatrix(IMatrix<T> src) : this(src.nRow(), src.nCol())
        {
            for(int i = 0;i<rows;i++)
                for(int j = 0;j<cols;j++)
                    Set(i, j, src.Get(i, j));
        }
        
        public override int nRow() => rows;
        public override int nCol() => cols;
        
        public override T Get(int iRow, int iColumn)
        {
            if(nRow() > iRow)
            {
                if(mem.Get(iRow) != default(IVector<T>))
                    return mem.Get(iRow).Get(iColumn);
            }
            return default(T);
        }
        public override bool Set(int iRow, int iColumn, T value)
        {
            if(mem.Get(iRow) == default(IVector<T>))
                mem.Set(iRow,InitRow());
            return mem.Get(iRow).Set(iColumn, value);
        }

        public override IMatrix<T> getOriginal() => this;
    }
}

