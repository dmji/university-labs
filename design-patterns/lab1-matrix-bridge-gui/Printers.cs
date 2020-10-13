using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using lab1_matrix_bridge;

namespace lab1_matrix_bridge_gui
{
    public class PrinterWPF : IPrinter
    {
        string df;
        string dl;
        TextBlock b;

        public void SetDF(string DF) { df = DF; }
        public void SetDL(string DL) { dl = DL; }
        
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

        public void Print(IBaseElement v)
        {
            if(v is IVector)
            {
                Print(df);
                v.Print(this);
                Print(dl + '\n', false);
            }
            else
                v.Print(this);
        }
    }
}
