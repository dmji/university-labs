using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public class SimpleVector<T> : IVector<T>
    {
        T[] mem;
        public SimpleVector(int vecSize)
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
        public bool isZero()
        {
            return mem.Count() == 0;
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
