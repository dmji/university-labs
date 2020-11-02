using System;

namespace lab_matrix_bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            SimpleMatrix<int> sim = new SimpleMatrix<int>(10, 10);
            SparseMatrix<int> spa = new SparseMatrix<int>(10, 10);
            InicializeMatrix.init(spa, 10, 100);
            InicializeMatrix.init(sim, 10, 100);
            StatsMatrix a = new StatsMatrix(sim),
                        b = new StatsMatrix(spa);
            
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
            */
            ConsolePrinter p = new ConsolePrinter("[", "]");

            SimpleMatrix<int> m1 = new SimpleMatrix<int>(4, 4);
            SimpleMatrix<int> m2 = new SimpleMatrix<int>(4, 4);
            SimpleMatrix<int> m3 = new SimpleMatrix<int>(4, 4);
            SimpleMatrix<int> m4 = new SimpleMatrix<int>(4, 4);

            InicializeMatrix.init(m1, 10, 100);
            InicializeMatrix.init(m2, 10, 100);
            InicializeMatrix.init(m3, 10, 100);
            InicializeMatrix.init(m4, 10, 100);


            HorisontalCompositeMatrix<int> c1 = new HorisontalCompositeMatrix<int>(m1,m2);
            HorisontalCompositeMatrix<int> c2 = new HorisontalCompositeMatrix<int>(c1,m3);

            c2.Print(p);
            c1.Set(0, m4);
            Console.WriteLine("After change");
            c2.Print(p);
            Console.WriteLine("After change elem");
            m2.Set(0, 0, 100);
            c2.Print(p);
        }
    }
}
