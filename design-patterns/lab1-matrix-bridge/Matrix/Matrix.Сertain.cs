using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public abstract class СertainMatrix : IMatrix
    {
        protected IVector mem;
        protected int rows;
        protected int cols;

        public void Print(IPrinter p)
        {
            mem.Print(p);
        }
        public abstract IBaseElement Get(int iRow, int iColumn);
        public abstract bool Set(int iRow, int iColumn, IBaseElement value);
        public int nRow()
        {
            return cols;
        }
        public int nColumn()
        {
            return rows;
        }
        public abstract IBaseElement Copy();
        public bool isZero()
        {
            return mem.Vector_Size() == 0;
        }
    }
}

