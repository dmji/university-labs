using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public class SparseMatrix : СertainMatrix
    {
        public SparseMatrix(int rowsCount, int colsCount)
        {
            rows = rowsCount;
            cols = colsCount;
            mem = new SparseVector(rows);
        }
        public override IBaseElement Get(int iRow, int iColumn)
        {
            var t = mem.Get(iRow);
            if(t is SparseVector)
                return ((SparseVector)t).Get(iColumn);
            else
                return SparseVector.zero.Copy();
        }
        public override bool Set(int iRow, int iColumn, IBaseElement value)
        {
            var t = mem.Get(iRow);
            if(t is CInt)
                mem.Set(iRow,new SparseVector(cols));
            return ((SparseVector)mem.Get(iRow)).Set(iColumn, value);
        }
        public override IBaseElement Copy()
        {
            SparseMatrix res = new SparseMatrix(rows, cols);
            res.mem = new SparseVector(mem.Copy());
            return res;
        }
    }
}

