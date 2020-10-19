using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public class SimpleMatrix<T> : СertainMatrix<T>
    {
        public SimpleMatrix(int rowsCount, int colsCount)
        {
            rows = rowsCount;
            cols = colsCount;
            mem = new SimpleVector<IVector<T>>(rows);
            for(int i = 0; i < rows; i++)
                mem.Set(i, new SimpleVector<T>(cols));
        }
        public override T Get(int iRow, int iColumn)
        {
            return ((SimpleVector<T>)mem.Get(iRow)).Get(iColumn);
        }
        public override bool Set(int iRow, int iColumn, T value)
        {
            return ((SimpleVector<T>)mem.Get(iRow)).Set(iColumn, value);
        }
    }
}

