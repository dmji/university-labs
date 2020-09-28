using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace lab1
{
    public interface IPrinter
    {
        void Print(string obj);
        void Print(char obj);
    }

    public interface IPrinterDelegate : IPrinter
    {
        public void Print(IPrintable obj);
    }

    public interface IPrintable
    {
        void Print(IPrinter obj);
    }

    public class PrinterDefault : IPrinter
    {
        public virtual void Print(string obj)
        {
            Console.Write(obj);
        }
        public virtual void Print(char obj)
        {
            Console.Write(obj);
        }
    }

    public class PrinterDelegate : IPrinterDelegate
    {
        IPrinter prn;
        public PrinterDelegate(IPrinter obj)
        {
            prn = obj;
        }
        public virtual void Print(string obj)
        {
            prn.Print(obj);
        }
        public virtual void Print(char obj)
        {
            prn.Print(obj);
        }
        public void Print(IPrintable obj)
        {
            obj.Print(this);
        }
    }


    public class PrinterSpecial : PrinterDefault
    {
        public override void Print(string obj)
        {
            base.Print("(" + obj + ")");
        }
    }


    public class Word : IPrintable
    {
        private string word;
        public Word(string init)
        {
            word = init;
        }

        public void Print(IPrinter obj)
        {
            obj.Print(word);
        }
    }

    public class Sign : IPrintable
    {
        private char word;
        public Sign(char init)
        {
            word = init;
        }

        public void Print(IPrinter obj)
        {
            obj.Print(word);
        }
    }

    public class Text : IPrintable
    {
        private IPrintable [] word;
        public Text(params IPrintable [] init)
        {
            word = init;
        }

        public void Print(IPrinter obj)
        {
            foreach(IPrintable a in word)
                a.Print(obj);
        }
    }
}
