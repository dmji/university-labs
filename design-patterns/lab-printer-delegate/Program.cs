using System;

namespace lab_printer_delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Text txt = new Text(
                new Word("Тестируем"), new Sign(' '),
                new Word("мою"), new Sign(' '),
                new Word("архитектуру"), new Sign('!') );
            
            IPrinterDelegate prn = new PrinterDelegate(new lab0pecial());
            
            
            Console.Write('\n');
            prn.Print(txt);
        }
    }
}
