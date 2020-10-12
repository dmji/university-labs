using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1
{
    public class SimpleVector : Vector
    {
        protected List<BaseElement> mem=new List<BaseElement>();
        protected int size;

        public SimpleVector(int vecSize)
        {
            size = vecSize;
            for(int i = 0; i < size; i++)
                mem.Add(new CInt(0));
        }
        public SimpleVector(params BaseElement[] vals)
        {
            mem = new List<BaseElement>(vals);
            size = mem.Count();
        }
        public BaseElement Get(int index)
        { 
            return mem[index]; 
        }

        public bool Set(int index, BaseElement value)
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
        public BaseElement Copy()
        {
            return new SimpleVector(mem.ToArray());
        }
        public bool isZero()
        {
            return mem.Count == 0;
        }
    }
    
    public class SparseVector : Vector
    {
        public List<BaseElement> memValue = new List<BaseElement>();
        public List<int> memIndex = new List<int>();
        protected int size;
        public static readonly CInt zero = new CInt(0);

        public SparseVector(int vecSize)
        {
            size = vecSize;
        }
        public SparseVector(params BaseElement[] vals)
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
            memValue = new List<BaseElement>(src.memValue);
        }
        public BaseElement Get(int index)
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
        public bool Set(int index, BaseElement value)
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
        public BaseElement Copy()
        {
            return new SimpleVector(this);
        }
        public bool isZero()
        {
            return memIndex.Count == 0;
        }
    }
}
