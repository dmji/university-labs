using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public class StatsMatrix
    {
        public double summary { get; }
        public double avgValue { get; }
        public double maxValue { get; }
        public int notZero { get; }

        public StatsMatrix(IMatrix mx)
        {
            notZero = 0;
            IMathElement sum = new CInt(0),
                temp,
                maxVal = new CInt(0);
            for(int i=0;i<mx.nRow();i++)
                for(int j=0;j<mx.nColumn();j++)
                {
                    temp = (IMathElement)(mx.Get(i, j));
                    if(!temp.isZero())
                        notZero++;
                    sum += temp;
                    if(maxVal < temp)
                        maxVal = temp;
                }
            summary = Convert.ToDouble(sum.Value());
            avgValue = summary / (mx.nColumn() * mx.nRow());
            maxValue = Convert.ToDouble(maxVal.Value());
        }
    }
}
