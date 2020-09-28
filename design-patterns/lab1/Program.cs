using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrintable[] text = {new Word("Тестируем"), new Sign(' '),
                new Word("мою"), new Sign(' '),
                new Word("архитектуру"), new Sign('!') };
            /*Text txt = new Text(
                new Word("Тестируем"), new Sign(' '),
                new Word("мою"), new Sign(' '),
                new Word("архитектуру"), new Sign('!') );
            */
            Text txt = new Text(text);

            IPrinterDelegate prn = new PrinterDelegate(new PrinterSpecial());
            
            
            txt.Print(prn);
            Console.Write('\n');
            prn.Print(txt);
        }
    }
}
