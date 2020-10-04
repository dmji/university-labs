﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace lab1
{
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
            obj.Print(prn);
        }
    }


    public class PrinterSpecial : PrinterDefault
    {
        public override void Print(string obj)
        {
            base.Print("(" + obj + ")");
        }
    }
}
