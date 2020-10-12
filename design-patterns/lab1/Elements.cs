using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace lab1
{
    public interface MathElement : BaseElement
    {
        public object Value();
        public static bool operator <(MathElement a, MathElement b)
        {
            if(System.Convert.ToDouble(a.Value()) < System.Convert.ToDouble(b.Value()))
                return true;
            else
                return false;
        }

        public static bool operator >(MathElement a, MathElement b)
        {
            if(System.Convert.ToDouble(a.Value()) > System.Convert.ToDouble(b.Value()))
                return true;
            else
                return false;
        }

        public static MathElement operator +(MathElement a, MathElement b)
        {
            if(a is CDouble || b is CDouble)
                return new CDouble(System.Convert.ToDouble(a.Value()) + System.Convert.ToDouble(b.Value()));
            else
                return new CInt(System.Convert.ToInt32(a.Value()) + System.Convert.ToInt32(b.Value()));
        }
    }

    public class CInt : MathElement
    {
        int val;
        public CInt(int value=0)
        {
            val = value;
        }
        public bool isZero()
        {
            return val == 0;

        }
        public BaseElement Copy()
        {
            return new CInt(val);
        }
        public object Value() { return val; }
    }

    public class CDouble : MathElement
    {
        double val;
        public CDouble(double value = 0.0)
        {
            val = value;
        }
        public bool isZero()
        {
            return val == 0.0;

        }
        public BaseElement Copy()
        {
            return new CDouble(val);
        }
        public object Value() { return val; }
    }
}
