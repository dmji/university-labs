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
            {
                if(mem[i] is IMathElement)
                    mem[i].Print(p);
                else if(mem[i] is IVector)
                    p.Print((IVector)mem[i]);
            }
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
    
    public class SparseVector : IVector
    {
        public List<IBaseElement> memValue = new List<IBaseElement>();
        public List<int> memIndex = new List<int>();
        protected int size;
        public static readonly CInt zero = new CInt(0);

        public void Print(IPrinter p)
        {
            for(int i = 0; i < memValue.Count; i++)
                if(memValue[i] is IMathElement)
                    memValue[i].Print(p);
                else if(memValue[i] is IVector)
                    p.Print((IVector)memValue[i]);
        }

        public SparseVector(int vecSize)
        {
            size = vecSize;
        }
        public SparseVector(params IBaseElement[] vals)
        {
            size = vals.Length;
            for(int i=0;i<size;i++)
            {
                if(!vals[i].isZero())
                {
                    memValue.Add(vals[i]);
                    memIndex.Add(i);
                }
            }
        }
        public SparseVector(SparseVector src)
        {
            size = src.size;
            memIndex = new List<int>(src.memIndex);
            memValue = new List<IBaseElement>(src.memValue);
        }
        public IBaseElement Get(int index)
        {
            if(index < size)
            {
                if(memIndex.Count>0)
                    for(int j = 0; j < memIndex.Count; j++)
                        if(memIndex[j] == index)
                            return memValue[j];
                return zero;
            }
                return null;
        }
        public bool Set(int index, IBaseElement value)
        {
            if(index < size)
            {
                if(memIndex.Contains(index))
                {
                    memValue[memIndex.Find(x => x == index)] = value.Copy();
                }
                else
                {
                    for(int i = 0; i < memIndex.Count(); i++)
                    {
                        if(memIndex[i] > index)
                        {
                            memIndex.Insert(i, index);
                            memValue.Insert(i, value);
                            return true;
                        }
                    }
                    memIndex.Add(index);
                    memValue.Add(value);
                }
            }
            return false;
        }
        public int Vector_Size()
        {
            return size;
        }
        public IBaseElement Copy()
        {
            return new SimpleVector(this);
        }
        public bool isZero()
        {
            return memIndex.Count == 0;
        }
    }
}
