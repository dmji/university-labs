using System.Linq;
using System.Reflection.Metadata;

namespace lab_matrix_bridge
{
    public class HorisontalCompositeMatrix<T> : AMatrix<T>
    {
        SparseVector<IMatrix<T>> mem;
        int size = 0;
        public HorisontalCompositeMatrix(params IMatrix<T>[] vals)
        {
            mem = new SparseVector<IMatrix<T>>(1000);
            foreach(var a in vals)
                mem.Set(size++, a);
        }
        public override int nCol()
        {
            int res = 0;
            for(int i = 0; i < size; i++)
                    res += mem.Get(i).nCol();
            return res;
        }
        public override int nRow()
        {
            int res = 0;
            for(int i = 0; i < size; i++)
                if(res < mem.Get(i).nRow())
                    res = mem.Get(i).nRow();
            return res;
        }
        public override bool isEmpty(int iRow, int iColumn)
        {
            int sCol = 0, iMx = GetBase(iRow, iColumn);
            for(int i = 0; i < iMx; i++)
                sCol += mem.Get(i).nCol();
            return mem.Get(iMx).isEmpty(iRow, iColumn - sCol);
        }
        public override T Get(int iRow, int iColumn)
        {
            int sCol = 0, iMx = GetBase(iRow, iColumn);
            for(int i = 0; i < iMx;i++)
                sCol += mem.Get(i).nCol();
            return mem.Get(iMx).Get(iRow, iColumn - sCol);
        }
        public override bool Set(int iRow, int iColumn, T value)
        {
            int sCol = 0, iMx = GetBase(iRow, iColumn);
            for(int i = 0; i < iMx; i++)
                sCol += mem.Get(i).nCol();
            return mem.Get(iMx).Set(iRow, iColumn - sCol, value);
        }
        public override IMatrix<T> getOriginal() => mem.Get(0).getOriginal();
        public void Append(IMatrix<T> mx)
        {
            mem.Set(size++, mx);
        }
        public bool Set(int i, IMatrix<T> mx) => mem.Set(i, mx);
        int GetBase(int row, int col)
        {
            int t = 0;
            for(int i = 0; i < mem.Length(); i++)
                if(t + mem.Get(i).nCol() > col)
                    return i;
                else
                    t += mem.Get(i).nCol();
            return -1;
        }
    }
}
