using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using lab1_matrix_bridge;

namespace lab1_matrix_bridge_gui
{
    public class PrinterWPF : IPrinter
    {
        public string df { get; set; }
        public string dl { get; set; }
        TextBlock b;
        public PrinterWPF(TextBlock block,string begin = "", string end = "")
        {
            df = begin;
            dl = end;
            b=block;
        }
        public void Print(string a, bool spaceInc = true)
        {
            if(spaceInc)
                b.Text += (a + " ");
            else
                b.Text += (a);
        }
        public void Print(IVector v)
        {
            Print(df);
            v.Print(this);
            Print(dl + '\n', false);
        }
    }
}
