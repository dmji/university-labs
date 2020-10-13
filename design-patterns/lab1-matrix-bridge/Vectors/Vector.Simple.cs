using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1_matrix_bridge
{
    public class SimpleVector : IVector
    {
        protected List<IBaseElement> mem=new List<IBaseElement>();
        protected int size;

        public void Print(IPrinter p)
        {
            for(int i = 0; i < mem.Count; i++)
                p.Print(mem[i]);
        }

        public SimpleVector(int vecSize)
        {
            size = vecSize;
            for(int i = 0; i < size; i++)
                mem.Add(new CInt(0));
        }
        public SimpleVector(params IBaseElement[] vals)
        {
            mem = new List<IBaseElement>(vals);
            size = mem.Count();
        }
        public IBaseElement Get(int index)
        { 
            return mem[index]; 
        }

        public bool Set(int index, IBaseElement value)
        {
            if(index < size)
            {
                mem[index] = value;
                return true;
            }
            return false;
        }
        public int Vector_Size()
        {
            return size;
        }
        public IBaseElement Copy()
        {
            return new SimpleVector(mem.ToArray());
        }
        public bool isZero()
        {
            return mem.Count == 0;
        }
    }
}
