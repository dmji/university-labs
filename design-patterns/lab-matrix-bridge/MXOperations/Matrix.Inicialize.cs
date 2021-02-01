using System;

namespace lab_matrix_bridge
{
    public class InicializeIntMatrix
    {
        public static bool init(IMatrix<int> mx, int notZero, int maxValue)
        {
            if(notZero > mx.nCol() * mx.nRow())
                notZero = mx.nRow() * mx.nCol();
            Random r = new Random();
            while(notZero > 0)
            {
                int a = r.Next(0, mx.nRow()), b = r.Next(0, mx.nCol());
                if(mx.Get(a, b)==0)
                {
                    mx.Set(a, b, r.Next(0, maxValue));
                    notZero--;
                }
            }
            return true;
        }
    }
}

