using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Text txt = new Text(
                new Word("Тестируем"), new Sign(' '),
                new Word("мою"), new Sign(' '),
                new Word("архитектуру"), new Sign('!') );
            
            IPrinterDelegate prn = new PrinterDelegate(new PrinterSpecial());
            
            
            txt.Print(prn);
            Console.Write('\n');
            prn.Print(txt);
        }
    }
}
