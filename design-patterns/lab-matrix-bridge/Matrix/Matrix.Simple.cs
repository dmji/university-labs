namespace lab_matrix_bridge
{
    public class SimpleMatrix<T> : СertainMatrix<T>
    {
        public SimpleMatrix(int rowsCount, int colsCount) : base(rowsCount, colsCount) { }
        public SimpleMatrix(IMatrix<T> src) : base(src) { }
        public override bool isEmpty(int rows,int cols) =>  false;
        protected override IVector<T> InitRow() => new SimpleVector<T>(nCol());
        protected override IVector<IVector<T>> InitMatr() 
        {
            var mem = new SimpleVector<IVector<T>>(nRow());
            for(int i = 0; i < nRow(); i++)
                mem.Set(i,InitRow());
            return mem; 
        }

        public override IMatrix<T> Clone() => new SimpleMatrix<T>(this);

    }
}

