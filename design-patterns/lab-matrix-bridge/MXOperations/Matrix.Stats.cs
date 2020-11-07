namespace lab_matrix_bridge
{
    public class StatsMatrix
    {
        public int summary { get; }
        public double avgValue { get; }
        public int maxValue { get; }
        public int notZero { get; }

        public StatsMatrix(IMatrix<int> mx)
        {
            notZero = 0;
            summary = 0;
            maxValue = 0;
            for(int i=0;i<mx.nRow();i++)
                for(int j=0;j<mx.nCol();j++)
                {
                    int temp = mx.Get(i, j);
                    if(temp!=0)
                        notZero++;
                    summary += temp;
                    if(maxValue < temp)
                        maxValue = temp;
                }
            avgValue = summary / (double)(mx.nCol() * mx.nRow());
        }
    }
}
