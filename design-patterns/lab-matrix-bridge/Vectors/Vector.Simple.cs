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
        public int Size() => mem.Count();
        public T Get(int index) => mem[index]; 
        public bool Set(int index, T value)
        {
            if(index < mem.Count())
            {
                mem[index] = value;
                return true;
            }
            return false;
        }

        public int findFirst(T value)
        {
            if(mem != null)
            {
                var bContaint = mem.Contains(value);
                if(bContaint)
                {
                    for(int i = 0; i < mem.Length; i++)
                    {
                        if(mem[i].Equals(value))
                            return i;
                    }
                }
            }
            return -1;
        }
    }
}
