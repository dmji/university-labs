using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public interface BaseElement
    {
        BaseElement Copy();
        bool isZero();
    }

    public interface Vector : BaseElement
    {
        BaseElement Get(int index);
        bool Set(int index, BaseElement value);
        int Vector_Size();
    }

    public interface Matrix
    {
        BaseElement Get(int iRow, int iColumn);
        bool Set(int iRow, int iColumn, BaseElement value);
        int nRow();
        int nColumn();
    }
}
