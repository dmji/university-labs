using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public class SimpleMatrix : СertainMatrix
    {
        public SimpleMatrix(int rowsCount, int colsCount)
        {
            rows = rowsCount;
            cols = colsCount;
            mem = new SimpleVector(rows);
            for(int i = 0; i < rows; i++)
                mem.Set(i, new SimpleVector(cols));
        }
        public override IBaseElement Get(int iRow, int iColumn)
        {
            return ((SimpleVector)mem.Get(iRow)).Get(iColumn);
        }
        public override bool Set(int iRow, int iColumn, IBaseElement value)
        {
            return ((SimpleVector)mem.Get(iRow)).Set(iColumn, value);
        }
        public override IBaseElement Copy()
        {
            SimpleMatrix res = new SimpleMatrix(rows, cols);
            res.mem = new SimpleVector(mem.Copy());
            return res;
        }
    }
}

