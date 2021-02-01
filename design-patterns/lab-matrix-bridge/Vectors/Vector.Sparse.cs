using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lab_matrix_bridge
{
    public class SparseVector<T> : SimpleVector<T>
    {
        SimpleVector<int> memIndex;
        int size;
        T defVal = default(T);

        public void setDefault(T val) { defVal = val; }
        public SparseVector(int vecSize=0) : base()
        {
            memIndex = new SimpleVector<int>();
            size = vecSize;
        }

        public int findFirst(T value)
        {
            for(int i = 0; i < base.Size(); i++)
                if(base.Get(i).Equals(value))
                    return memIndex.Get(i);
            return -1;
        }

        public SparseVector(IVector<T> src) : base()
        {
            size = src.Size();
            for(int i = 0; i < size; i++)
            {
                T cur = src.Get(i);
                if(!cur.Equals(defVal))
                { 
                    memIndex.Add(i);
                    base.Add(cur);
                } 
            }
            if(src is SparseVector<T>)
                defVal = ((SparseVector<T>)src).defVal;
        }
        
        public override T Get(int index)
        {
            if(index > size)
                throw new System.Exception("out of range");
            if(memIndex.Size() > 0)
            {
                for(int j = 0; j < memIndex.Size(); j++)
                    if(memIndex.Get(j) == index)
                        return base.Get(j);
            }
            return defVal;
        }

        public override bool Set(int index, T value)
        {
            if(index < size)
            {
                if(memIndex.Size() == 0 && value != null && !value.Equals(defVal))
                {
                    memIndex.Add(index);
                    base.Add(value);
                    return true;
                }
                int fInd = -1, fPast = 0;
                for(int i = 0; i < memIndex.Size(); i++)
                {
                    if(index == memIndex.Get(i))
                        fInd = i;
                    if(memIndex.Get(i) < index)
                        fPast++;
                }
                if(fInd != -1)
                {
                    if(value == null || value.Equals(defVal))
                    {
                        base.RemoveAt(index);
                        memIndex.RemoveAt(index);
                        return true;
                    }
                    else
                        base.Set(fInd, value);
                    return true;
                }
                else if(value != null && !value.Equals(defVal))
                {
                    base.Insert(fInd, value);
                    memIndex.Insert(fInd, index);
                    return true;
                }
            }
            return false;
        }

        public override int Size() => size;

        public int Length() => memIndex.Size();

        public override IVector<T> Clone() => new SparseVector<T>(this);
    }
}