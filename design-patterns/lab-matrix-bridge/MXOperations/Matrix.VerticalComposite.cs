using System.Linq;
using System.Reflection.Metadata;

namespace lab_matrix_bridge
{
    public class VerticalCompositeMatrix<T> : HorisontalCompositeMatrix<T>
    {
        SimpleVector<TransposeMatrix<T>> mem;

        public VerticalCompositeMatrix(params IMatrix<T>[] vals)
        {
            mem = new SimpleVector<TransposeMatrix<T>>();
            for(int i = 0; i < vals.Length; i++)
                mem.Add(new TransposeMatrix<T>(vals[i]));
        }
        public VerticalCompositeMatrix(VerticalCompositeMatrix<T> src)
        {
            mem = new SimpleVector<TransposeMatrix<T>>(src.mem);
        }

        public override IMatrix<T> Clone() => new VerticalCompositeMatrix<T>(this);
        public override bool Set(int i, IMatrix<T> mx) => mem.Set(i, new TransposeMatrix<T>(mx));

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

        bool isEmpty(int iRow, int iColumn)
        {
            int sCol = 0;
            int iMx = GetBase(iRow, iColumn, ref sCol);

            var mx = mem.Get(iMx);
            return iMx!=-1 && (mx.nCol() <= iColumn - sCol || mx.nRow() <= iRow);
        }

        public T Get(int iRow, int iColumn)
        {
            if(!isEmpty(iRow, iColumn))
            {
                int sCol = 0;
                int iMx = GetBase(iRow, iColumn, ref sCol);
                IMatrix<T> mx = mem.Get(iMx);
                if(mx == null || mx.nCol() <= iColumn - sCol || mx.nRow() <= iRow)
                    return mx.Get(iRow, iColumn - sCol);
            }
            return default(T);
        }

        public bool Set(int iRow, int iColumn, T value)
        {
            int sCol=0;
            int iMx = GetBase(iRow, iColumn,ref sCol);
            return mem.Get(iMx).Set(iRow, iColumn - sCol, value);
        }
        
        public void Append(IMatrix<T> mx)
        {
            mem.Add(new TransposeMatrix<T>(mx));
        }

        public void TransponceGroup()
        {
            for(int i = 0; i < mem.Size(); i++)
            {
                var mx = mem.Get(i);
                if(mx.unTranspose() is HorisontalCompositeMatrix<T>)
                    ((HorisontalCompositeMatrix<T>)mx.unTranspose()).TransponceGroup();
                else
                    mem.Set(i, new TransposeMatrix<T>(mx));
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
