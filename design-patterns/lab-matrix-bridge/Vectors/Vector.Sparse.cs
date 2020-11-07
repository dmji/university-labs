using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lab_matrix_bridge
{
     public class SparseVector<T> : IVector<T>
    {
        T[] memValue;
        int[] memIndex;
        int size;

        public SparseVector(int vecSize)
        {
            memValue = new T[0];
            memIndex = new int[0];
            size = vecSize;
        }

        public int findFirst(T value)
        {
            if(memValue != null)
            {
                var bContaint = memValue.Contains(value);
                if(bContaint)
                {
                    for(int i = 0; i < memValue.Length; i++)
                    {
                        if(memValue[i].Equals(value))
                            return memIndex[i];
                    }
                }
            }
            return -1;
        }

        public SparseVector(SparseVector<T> src)
        {
            size = src.size;
            src.memIndex.CopyTo(memIndex, 0);
            src.memValue.CopyTo(memValue, 0);
        }
        public T Get(int index)
        {
            if(index < size)
            {
                if(memIndex!=null && memIndex.Length > 0)
                {
                    for(int j = 0; j < memIndex.Length; j++)
                        if(memIndex[j] == index)
                            return memValue[j];
                }
            }
            return default(T);
        }
        public bool Set(int index, T value)
        {
            if(index < size)
            {
                if(memIndex==null)
                {
                    memIndex = new int[1];
                    memIndex[0] = index;
                    memValue = new T[1];
                    memValue[0] = value;
                    return true;
                }
                int fInd = -1, fPast=0;
                for(int i = 0; i < memIndex.Length; i++)
                { 
                    if(index == memIndex[i])
                        fInd = i;
                    if(memIndex[i] < index)
                        fPast++;
                }
                if(fInd != -1)
                {
                    if(value == null || value.Equals(default(T)))
                    {
                        T[] vnew = new T[memValue.Length - 1];
                        int[] inew = new int[memIndex.Length - 1];
                        int ind = 0;
                        for(int i = 0; i < vnew.Length; i++)
                        {
                            if(fInd != i)
                            {
                                vnew[ind] = memValue[i];
                                inew[ind++] = memIndex[i];
                            }
                        }
                        memValue = vnew;
                        memIndex = inew;
                        return true;
                    }
                    else
                        memValue[fInd] = value;
                    return true;
                }
                else
                {
                    T[] vnew = new T[memValue.Length + 1];
                    int[] inew = new int[memIndex.Length + 1];
                    for(int i = 0; i < vnew.Length; i++)
                    {
                        if(fPast > i)
                        {
                            vnew[i] = memValue[i];
                            inew[i] = memIndex[i];
                        }
                        else if(fPast == i)
                        {
                            vnew[i] = value;
                            inew[i] = index;
                        }
                        else
                        {
                            vnew[i] = memValue[i - 1];
                            inew[i] = memIndex[i - 1];
                        }
                    }
                    memValue = vnew;
                    memIndex = inew;
                    return true;
                }
            }
            return false;
        }
        public int Size() => size;
        public int Length() => memIndex.Length;

        public T PopBack()
        {
            T sval = memValue[Length()-1];
            Set(Length() - 1, default(T));
            return sval;
        }
        public bool Add(T val) => Set(Length(), val);
    }
}