using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public class InicializeMatrix
    {
        public static bool init(IMatrix<int> mx, int notZero, int maxValue)
        {
            while(notZero > 0)
            {
                Random r = new Random();
                int a = r.Next(0, mx.nRow()), b = r.Next(0, mx.nColumn());
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

