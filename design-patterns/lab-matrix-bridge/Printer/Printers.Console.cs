using System;
using System.Collections.Generic;

namespace lab_matrix_bridge
{
    public class ConsolePrinter : IPrinter
    {
        string leftBorder,
               rightBorder,
               leftElementBorder,
               rightElementBorder;
        bool A = true, E = true, bDisRBoard=false, bDisLBoard=false;
        static readonly element filler = new element("");
        int cursor = -1;

        SimpleVector<SimpleVector<stack>> toRelease = new SimpleVector<SimpleVector<stack>>();
        int padding = 0;

        abstract class stack
        {
            public string val { set;  get; }
            protected stack(string value)
            {
                val = value;
            }
            public abstract void Print(int padding);
        }
        class element : stack
        {
            public element(string value) : base(value) { }
            public override void Print(int padding) { Console.Write(val.PadLeft(padding)); }
        }
        class sign : stack
        {
            public sign(string value) : base(value) { }
            public override void Print(int padding) { Console.Write(val); }
        }

        public ConsolePrinter(string leftBorder = "", string rightBorder = "", string leftElementBorder = "", string rightElementBorder = "")
        {
            this.leftBorder = leftBorder + " ";
            this.rightBorder = rightBorder;
            this.leftElementBorder = leftElementBorder == "" ? leftElementBorder : leftElementBorder + " ";
            this.rightElementBorder = (rightElementBorder == "" ? rightElementBorder : " " + rightElementBorder) + " ";
        }
        public void PrintBorder()
        {
            A = !A;
            if(A)
            {
                if(!bDisRBoard)
                    toRelease.Get(cursor).Add(new sign(rightBorder));
            }
            else
            {
                cursor++;
                var iii = toRelease.Size();
                if(toRelease.Size() - 1 <= cursor)
                    toRelease.Add(new SimpleVector<stack>());
                if(!bDisLBoard)
                    toRelease.Get(cursor).Add(new sign(leftBorder));
            }
        }
        public string getBorderElement()
        {
            E = !E;
            return !E ? leftElementBorder : rightElementBorder;
        }
        public void Print<T>(T m, int group=0)
        {
            if(padding < m.ToString().Length)
                padding = m.ToString().Length;
            toRelease.Get(cursor).Add(new element(getBorderElement() + m.ToString() + getBorderElement()));
        }
        public void setElementBorder(string left, string right)
        {
            leftElementBorder = left;
            rightElementBorder = right+" ";
        }
        public void setBorder(string left = "", string right = "")
        {
            leftBorder = left + " ";
            rightBorder = right;
        }
        public virtual void ReleasePrint()
        {
            int max = 0;
            padding+=(getBorderElement().Length+getBorderElement().Length);
            for(int i = 0; i < toRelease.Size(); i++)
                if(toRelease.Get(i).Size() > max)
                    max = toRelease.Get(i).Size();
            for(int i = 0; i < toRelease.Size(); i++)
            {
                var a = toRelease.Get(i);
                if(a.Size() > 0)
                {
                    stack endb = a.Get(a.Size() - 1);
                    for(int j = 0; j < max - 1; j++)
                    {
                        if(a.Size() - 1 > j)
                            a.Get(j).Print(padding);
                        else
                            filler.Print(padding);
                    }
                    endb.val += "\n";
                    endb.Print(padding);
                }
            }
            toRelease = new SimpleVector<SimpleVector<stack>>();
            padding = 0;
            cursor = -1;
        }

        public void disableBorders(bool left, bool right)
        {
            bDisRBoard = right;
            bDisLBoard = left;
        }
        public void flush()
        {
            cursor = -1;
            int max = 0;
            for(int i = 0; i < toRelease.Size(); i++)
                if(toRelease.Get(i).Size() > max)
                    max = toRelease.Get(i).Size();
            for(int i = 0; i < toRelease.Size(); i++)
            {
                SimpleVector<stack> a = toRelease.Get(i);
                while(a.Size() < max)
                    a.Add(filler);
            }
        }        
    }
}

