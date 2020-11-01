using System;
using System.Collections.Generic;
using System.Text;

namespace lab1_matrix_bridge
{
    public class MatrixDecoreAssign<T> : IMatrix<T>
    {
        IMatrix<T> mem;

        public MatrixDecoreAssign(IMatrix<T> val)
        {
            mem = val;
        }

        public T Get(int iRow, int iColumn)
        {
            return mem.Get(iRow, iColumn);
        }

        public int nColumn()
        {
            return mem.nColumn();
        }

        public int nRow()
        {
            return mem.nRow();
        }

        public void Print(IPrinter p)
        {
            mem.Print(p);
        }

        public bool Set(int iRow, int iColumn, T value)
        {
            return mem.Set(iRow, iColumn, value);
        }
    }
}
