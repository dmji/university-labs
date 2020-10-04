using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
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
        private IPrintable[] word;
        public Text(params IPrintable[] init)
        {
            word = init;
        }
        public void Print(IPrinter obj)
        {
            foreach (IPrintable a in word)
                a.Print(obj);
        }
    }
}
