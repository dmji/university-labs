using System.Linq;

namespace lab1_matrix_bridge
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
        public T Get(int index)
        { 
            return mem[index]; 
        }

        public bool Set(int index, T value)
        {
            if(index < mem.Count())
            {
                mem[index] = value;
                return true;
            }
            return false;
        }
        
        public int Size()
        {
            return mem.Count();
        }
       
        public void Print(IPrinter t)
        {
            t.PrintBoard();
            foreach(T a in mem)
                t.Print(a);
            t.PrintBoard();
        }
    }
}
