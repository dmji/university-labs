using System;
using System.IO;

namespace auditory_simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader dir = File.OpenText("..\\..\\..\\dirStudentsName.txt");
            StreamReader lectureText = File.OpenText("..\\..\\..\\lectureText.txt");
            Auditory main = new Auditory("112", 30);
            for (int i = 0; i < 1; i++)
                new Students(dir.ReadLine()).enterTo(main);
            for (int i = 0; i < 2; i++)
                new Magiters(dir.ReadLine()).enterTo(main);
            Professor host = new Professor("Vladimir Vladimirovich");
            host.enterTo(main);
            while(!lectureText.EndOfStream)
                host.say(lectureText.ReadLine());
            host.ReleaseRoom();
        }
    }
}
