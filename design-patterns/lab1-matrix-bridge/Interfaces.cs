using System;
using System.Collections.Generic;
using System.Text;

namespace lab1_matrix_bridge
{
    public interface IBaseElement
    {
        IBaseElement Copy();
        bool isZero();
        void Print(IPrinter p);
    }

    public interface IVector : IBaseElement
    {
        IBaseElement Get(int index);
        bool Set(int index, IBaseElement value);
        int Vector_Size();
    }

    public interface IMatrix : IBaseElement
    {
        IBaseElement Get(int iRow, int iColumn);
        bool Set(int iRow, int iColumn, IBaseElement value);
        int nRow();
        int nColumn();
    }
}
