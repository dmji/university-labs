using System;
using System.Collections.Generic;
using System.Text;

namespace lab1_matrix_bridge
{
    public interface IVector<T>
    {
        T Get(int index);
        bool Set(int index, T value);
        int Size();
        void Print(IPrinter t);
    }
    
    public interface IMatrix<T>
    {
        T Get(int iRow, int iColumn);
        bool Set(int iRow, int iColumn, T value);
        int nRow();
        int nColumn();
        public void Print(IPrinter p);
    }
}
