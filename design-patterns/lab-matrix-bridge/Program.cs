using System;

namespace lab_matrix_bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter print = new ConsolePrinter("[", "]");
            IMatrix<int> sim = new SimpleMatrix<int>(10, 10);
            IMatrix<int> spa = new SparseMatrix<int>(10, 10);
            InicializeIntMatrix.init(spa, 10, 100);
            InicializeIntMatrix.init(sim, 10, 100);
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
            sim = dr;
            Console.WriteLine($"\nAssignedSimpleMatrix (x-y mirrored):");
            sim.Print(print);
            
            dr = new ReAssignMatrix<int>(spa);
            for(int i = 0; i < 10 / 2; i++)
            {
                dr.SwapCols(i, 9 - i);
                dr.SwapRows(i, 9 - i);
            }
            spa = dr;
            Console.WriteLine($"\nAssignedSparceMatrix (x-y mirrored):");
            spa.Print(print);

            Console.WriteLine($"\nHorisontalSimpleComposite (sim+sim):");
            HorisontalCompositeMatrix<int> cs = new HorisontalCompositeMatrix<int>(sim, sim);
            cs.Print(print);

            Console.WriteLine($"\nHorisontalSparceComposite (sim+sim):");
            HorisontalCompositeMatrix<int> cc = new HorisontalCompositeMatrix<int>(spa, spa);
            cc.Print(print);

            Console.WriteLine($"\nHorisontalSimpleComposite (sim+sim):");
            HorisontalCompositeMatrix<int> vcs = new HorisontalCompositeMatrix<int>(cs, sim);
            vcs.Print(print);

            Console.WriteLine($"\nHorisontalSparceComposite (sim+sim):");
            HorisontalCompositeMatrix<int> vcc = new HorisontalCompositeMatrix<int>(cc, spa);
            vcc.Print(print);

        }
    }
}
