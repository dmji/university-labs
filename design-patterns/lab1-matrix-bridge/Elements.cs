using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace lab1_matrix_bridge
{
    public interface IMathElement : IBaseElement
    {
        public object Value();
        public static bool operator <(IMathElement a, IMathElement b)
        {
            if(System.Convert.ToDouble(a.Value()) < System.Convert.ToDouble(b.Value()))
                return true;
            else
                return false;
        }

        public static bool operator >(IMathElement a, IMathElement b)
        {
            if(System.Convert.ToDouble(a.Value()) > System.Convert.ToDouble(b.Value()))
                return true;
            else
                return false;
        }

        public static IMathElement operator +(IMathElement a, IMathElement b)
        {
            if(a is CDouble || b is CDouble)
                return new CDouble(System.Convert.ToDouble(a.Value()) + System.Convert.ToDouble(b.Value()));
            else
                return new CInt(System.Convert.ToInt32(a.Value()) + System.Convert.ToInt32(b.Value()));
        }
    }

    public class CInt : IMathElement
    {
        int val;

        public void Print(IPrinter p)
        {
            p.Print(val.ToString());
        }
        public CInt(int value=0)
        {
            val = value;
        }
        public bool isZero()
        {
            return val == 0;

        }
        public IBaseElement Copy()
        {
            return new CInt(val);
        }
        public object Value() { return val; }
        public static IBaseElement zero() { return new CInt(0); } 
    }

    public class CDouble : IMathElement
    {
        double val;
        public void Print(IPrinter p)
        {
            p.Print(val.ToString());
        }
        public CDouble(double value = 0.0)
        {
            val = value;
        }
        public bool isZero()
        {
            return val == 0.0;

        }
        public IBaseElement Copy()
        {
            return new CDouble(val);
        }
        public object Value() { return val; }
    }
}
