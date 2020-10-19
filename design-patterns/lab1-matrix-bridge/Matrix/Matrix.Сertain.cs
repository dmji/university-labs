using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace lab1_matrix_bridge
{
    public abstract class СertainMatrix<T> : IMatrix<T>
    {
        protected IVector<IVector<T>> mem;
        protected int rows;
        protected int cols;

        public void Print(IPrinter p)
        {
            for(int i = 0; i < rows; i++)
            {
                if(mem.Get(i) != null)
                {
                    mem.Get(i).Print(p);
                    p.NewLine();
                }
            }
        }
        public abstract T Get(int iRow, int iColumn);
        public abstract bool Set(int iRow, int iColumn, T value);
        public int nRow()
        {
            return cols;
        }
        public int nColumn()
        {
            return rows;
        }
    }
}

