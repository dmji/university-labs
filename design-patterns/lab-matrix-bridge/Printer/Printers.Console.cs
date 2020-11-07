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
        bool A = true, E = true;

        List<stack> toRelease = new List<stack>();
        int padding = 0;

        abstract class stack
        {
            public string val { get; }
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
            this.rightBorder = rightBorder + "\n";
            this.leftElementBorder = leftElementBorder == "" ? leftElementBorder : leftElementBorder + " ";
            this.rightElementBorder = (rightElementBorder == "" ? rightElementBorder : " " + rightElementBorder) + " ";
        }
        public void PrintBorder()
        {
             toRelease.Add(new sign(getBorder()));
        }
        public void PrintBorderElement()
        {
            toRelease.Add(new sign(getElementBorder()));
        }
        public void Print<T>(T m, int group=0)
        {
            if(padding < m.ToString().Length)
                padding = m.ToString().Length;
            toRelease.Add(new element(m.ToString()));
        }
        public void setElementBorder(string left, string right)
        {
            leftElementBorder = left;
            rightElementBorder = right;
        }
        public void setBorder(string left = "", string right = "")
        {
            leftBorder = left + " ";
            rightBorder = right+"\n";
        }
        protected string getBorder() { A = !A; return !A ? leftBorder : rightBorder; }
        protected string getElementBorder() { E = !E; return !E ? leftElementBorder : rightElementBorder; }
        public virtual void ReleasePrint()
        {
            foreach(stack a in toRelease)
                a.Print(padding);
            toRelease.Clear();
        }
    }
}

