namespace lab1_matrix_bridge
{
    public abstract class СertainMatrix<T> : IMatrix<T>
    {
        IVector<IVector<T>> mem;
        int rows;
        int cols;

        protected abstract bool isEmpty(int row, int col);
        protected abstract IVector<IVector<T>> InitMatr();
        protected abstract IVector<T> InitRow();

        protected СertainMatrix(int nrows, int ncols)
        {
            rows = nrows;
            cols = ncols;
            mem = InitMatr();
        }
        /*
        public void Print(IPrinter p)
        {
            for(int i = 0; i < rows; i++)
            {
                if(mem.Get(i) != null)
                {
                    mem.Get(i).Print(p);
                }
            }
        }
        */
        public void Print(IPrinter p)
        {
            for(int i = 0; i < rows; i++)
            {
                p.PrintBoard();
                int printed = 0;
                for(int j = 0; j < rows; j++)
                {
                    if(isEmpty(i, j) == false)
                    {
                        p.PrintBoardElement();
                        p.Print<T>(Get(i, j));
                        p.PrintBoardElement();
                        printed++;
                    }
                }
                p.PrintBoard();
            }
        }

        public int nRow()
        {
            return cols;
        }
        public int nColumn()
        {
            return rows;
        }
        public T Get(int iRow, int iColumn)
        {
            var t = mem.Get(iRow);
            if(t != default(IVector<T>))
                return t.Get(iColumn);
            else
                return default(T);
        }
        public bool Set(int iRow, int iColumn, T value)
        {
            var t = mem.Get(iRow);
            if(t == default(IVector<T>))
                mem.Set(iRow,InitRow());
            return mem.Get(iRow).Set(iColumn, value);
        }
        
    }
}

