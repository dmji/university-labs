using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public class SparseMatrix<T> : СertainMatrix<T>
    {
        public SparseMatrix(int rowsCount, int colsCount)
        {
            rows = rowsCount;
            cols = colsCount;
            mem = new SparseVector<IVector<T>>(rows);
        }
        public override T Get(int iRow, int iColumn)
        {
            var t = mem.Get(iRow);
            if(t is SparseVector<T>)
                return ((SparseVector<T>)t).Get(iColumn);
            else
                return default(T);
        }
        public override bool Set(int iRow, int iColumn, T value)
        {
            var t = mem.Get(iRow);
            if(t is default(IVector<T>))
                mem.Set(iRow,new SparseVector<T>(cols));
            return ((SparseVector<T>)mem.Get(iRow)).Set(iColumn, value);
        }
    }
}