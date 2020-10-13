using System;

namespace lab1_matrix_bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleMatrix sim = new SimpleMatrix(10, 10);
            SparseMatrix spa = new SparseMatrix(10, 10);
            InicializeMatrix.init(spa, 10, 100);
            InicializeMatrix.init(sim, 10, 100);
            StatsMatrix a = new StatsMatrix(sim), b=new StatsMatrix(spa);
            PrinterConsole print = new PrinterConsole("[", "]");
            Console.WriteLine($"SimpleMatrix:\nSum={a.summary}\nAvg={a.avgValue}\nMax={a.maxValue}\nNotNull={a.notZero}");
            sim.Print(print);
            Console.WriteLine($"\nSparseMatrix:\nSum={b.summary}\nAvg={b.avgValue}\nMax={b.maxValue}\nNotNull={b.notZero}");
            spa.Print(print);
        }
    }
}
