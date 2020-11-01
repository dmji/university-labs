namespace lab1_matrix_bridge
{
    public class SimpleMatrix<T> : СertainMatrix<T>
    {
        public SimpleMatrix(int rowsCount, int colsCount) : base(rowsCount, colsCount) { }

        protected override bool isEmpty(int rows,int cols)
        {
            return !(rows < nRow() && cols < nColumn());
        }

        protected override IVector<T> InitRow()
        {
            return new SimpleVector<T>(nColumn());
        }

        protected override IVector<IVector<T>> InitMatr() 
        {
            var mem = new SimpleVector<IVector<T>>(nRow());
            for(int i = 0; i < nRow(); i++)
                mem.Set(i,InitRow());
            return mem; 
        }
    }
}

