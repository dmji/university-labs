using System;

namespace lab_matrix_bridge
{
    class Program
    {
        static void Main(string[] args)
        { 
            SimpleMatrix<int> sim = new SimpleMatrix<int>(10, 10);
            SparseMatrix<int> spa = new SparseMatrix<int>(10, 10);
            InicializeMatrix.init(spa, 10, 100);
            InicializeMatrix.init(sim, 10, 100);
            StatsMatrix a = new StatsMatrix(sim),
                        b = new StatsMatrix(spa);
            ConsolePrinter print = new ConsolePrinter("[", "]");
            Console.WriteLine($"SimpleMatrix:\nSum={a.summary}\nAvg={a.avgValue}\nMax={a.maxValue}\nNotNull={a.notZero}");
            sim.Print(print);
            Console.WriteLine($"\nSparseMatrix:\nSum={b.summary}\nAvg={b.avgValue}\nMax={b.maxValue}\nNotNull={b.notZero}");
            spa.Print(print);

            ReAssignMatrix<int> dr = new ReAssignMatrix<int>(sim);
            for(int i = 0; i < 10 / 2; i++)
            {
                dr.SwapCols(i, 9 - i);
                dr.SwapRows(i, 9 - i);
            }
            sim = new SimpleMatrix<int>(dr);
            Console.WriteLine($"\nAssignedSimpleMatrix (x-y mirrored):");
            sim.Print(print);

            dr = new ReAssignMatrix<int>(spa);
            for(int i = 0; i < 10 / 2; i++)
            {
                dr.SwapCols(i, 9 - i);
                dr.SwapRows(i, 9 - i);
            }
            spa = new SparseMatrix<int>(dr);
            Console.WriteLine($"\nAssignedSparceMatrix (x-y mirrored):");
            spa.Print(print);
        }
    }
}
