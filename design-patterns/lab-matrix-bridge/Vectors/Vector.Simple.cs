using System.Linq;

namespace lab_matrix_bridge
{
    public class SimpleVector<T> : IVector<T>
    {
        T[] mem;

        public SimpleVector(int vecSize=0)
        {
            mem = new T[vecSize];
        } 

        public SimpleVector(params T[] vals)
        {
            mem = vals;
        }

        public SimpleVector(IVector<T> val)
        {
            mem = new T[val.Size()];
            for(int i = 0, n = val.Size(); i < n; i++)
                mem[i] = val.Get(i);
        }

        public virtual int Size() => mem.Count();

        public virtual T Get(int index)
        {
            if(index <0 || index >= Size())
                throw new System.Exception("out of range");
            return mem[index];
        }

        public virtual bool Set(int index, T value)
        {
            if(index >= 0 && index < mem.Count())
            {
                mem[index] = value;
                return true;
            }
            return false;
        }

        public void Add(T value)
        {
            mem = mem.Concat(new T[] { value }).ToArray();
        }

        public T Pop() => RemoveAt(Size()-1);

        /// <summary>Insert value after index</summary>
        public void Insert(int index, T value)
        {
            mem = mem.Take(index+1).Concat(new T[] { value }).Concat(mem.TakeLast(mem.Length - index - 1)).ToArray();
        }

        public T RemoveAt(int index)
        {
            T res = mem[mem.Count() - 1];
            mem = mem.Take(index).Concat(mem.TakeLast(mem.Length - index-1)).ToArray();
            return res;
        }

        public virtual IVector<T> Clone() => new SimpleVector<T>(this);
    }
}
