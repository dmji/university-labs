﻿using System;
using System.Linq;
using System.Reflection.Metadata;

namespace lab_matrix_bridge
{
    public class HorisontalCompositeMatrix<T> : IMatrix<T>
    {
        SimpleVector<IMatrix<T>> mem;

        public HorisontalCompositeMatrix(params IMatrix<T>[] vals)
        {
            mem = new SimpleVector<IMatrix<T>>(vals);
        }
        public HorisontalCompositeMatrix(HorisontalCompositeMatrix<T> src)
        {
            mem = new SimpleVector<IMatrix<T>>(src.mem);
        }

        public IMatrix<T> getOriginal() => mem.Get(0).getOriginal();
        virtual public IMatrix<T> Clone() => new HorisontalCompositeMatrix<T>(this);
        virtual public bool Set(int i, IMatrix<T> mx) => mem.Set(i, mx);

        public int nCol()
        {
            int res = 0;
            for(int i = 0; i < mem.Size(); i++)
                    res += mem.Get(i).nCol();
            return res;
        }

        public int nRow()
        {
            int res = 0;
            for(int i = 0; i < mem.Size(); i++)
            {
                if(res < mem.Get(i).nRow())
                    res = mem.Get(i).nRow();
            }
            return res;
        }

        public bool isEmpty(int iRow, int iColumn)
        {
            int sCol = 0;
            int iMx = GetBase(iRow, iColumn, ref sCol);

            var mx = mem.Get(iMx);
            if(mx.nCol() <= iColumn - sCol || mx.nRow() <= iRow)
                return false;
            else
                return mx.isEmpty(iRow, iColumn - sCol);
        }

        public T Get(int iRow, int iColumn)
        {
            int sCol = 0;
            int iMx = GetBase(iRow, iColumn, ref sCol);
            IMatrix<T> mx=null;
            if(iMx != -1)
                mx = mem.Get(iMx);
            if(mx == null || mx.nCol() <= iColumn - sCol || mx.nRow() <= iRow)
                return default(T);
            return mx.Get(iRow, iColumn - sCol);
        }

        public bool Set(int iRow, int iColumn, T value)
        {
            if(!isEmpty(iRow, iColumn))
            {
                int sCol = 0;
                int iMx = GetBase(iRow, iColumn, ref sCol);

                return mem.Get(iMx).Set(iRow, iColumn - sCol, value);
            }
            return false;
        }
        
        public void Append(IMatrix<T> mx)
        {
            mem.Add(mx);
        }

        public void TransponceGroup()
        {
            for(int i = 0; i < mem.Size(); i++)
            {
                if(mem.Get(i) is HorisontalCompositeMatrix<T>)
                    ((HorisontalCompositeMatrix<T>)mem.Get(i)).TransponceGroup();
                else
                    mem.Set(i, new TransposeMatrix<T>(mem.Get(i)));
            }
        }

        int GetBase(int row, int col, ref int step)
        {
            step = 0;
            for(int i = 0; i < mem.Size(); i++)
                if(step + mem.Get(i).nCol() > col)
                    return i;
                else
                    step += mem.Get(i).nCol();
            return -1;
        }

        public void Print(IPrinter p,bool bRelease = true)
        {
            p.disableBorders(false,true);
            mem.Get(0).Print(p, false);
            p.flush();
            p.disableBorders(true, true);
            for(int i = 1; i < mem.Size() - 1; i++)
            {
                mem.Get(i).Print(p, false);
                p.flush();
            }
            p.disableBorders(true,false);
            mem.Get(mem.Size() - 1).Print(p, bRelease);
        }
    }
}
