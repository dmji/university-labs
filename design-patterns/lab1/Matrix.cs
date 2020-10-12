using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace lab1
{
    public abstract class СertainMatrix : Matrix
    {
        protected Vector mem;
        protected int rows;
        protected int cols;

        public abstract BaseElement Get(int iRow, int iColumn);
        public abstract bool Set(int iRow, int iColumn, BaseElement value);
        public int nRow()
        {
            return cols;
        }
        public int nColumn()
        {
            return rows;
        }
    }

    public class SimpleMatrix : СertainMatrix
    {
        public SimpleMatrix(int rowsCount, int colsCount)
        {
            rows = rowsCount;
            cols = colsCount;
            mem = new SimpleVector(rows);
            for(int i = 0; i < rows; i++)
                mem.Set(i, new SimpleVector(cols));
        }

        public override BaseElement Get(int iRow, int iColumn)
        {
            return ((SimpleVector)mem.Get(iRow)).Get(iColumn);
        }
        public override bool Set(int iRow, int iColumn, BaseElement value)
        {
            return ((SimpleVector)mem.Get(iRow)).Set(iColumn, value);
        }
    }
    
    public class SparseMatrix : СertainMatrix
    {
        public SparseMatrix(int rowsCount, int colsCount)
        {
            rows = rowsCount;
            cols = colsCount;
            mem = new SparseVector(rows);
        }

        public override BaseElement Get(int iRow, int iColumn)
        {
            var t = mem.Get(iRow);
            if(t is SparseVector)
                return ((SparseVector)t).Get(iColumn);
            else
                return SparseVector.zero;
        }
        public override bool Set(int iRow, int iColumn, BaseElement value)
        {
            var t = mem.Get(iRow);
            if(t is CInt)
                mem.Set(iRow,new SparseVector(cols));
            return ((SparseVector)mem.Get(iRow)).Set(iColumn, value);
        }
    }


    public class InicializeMatrix
    {
        public static bool init(Matrix mx, int notZero, int maxValue)
        {
            while(notZero > 0)
            {
                Random r = new Random();
                int a = r.Next(0, mx.nRow()), b = r.Next(0, mx.nColumn());
                if(mx.Get(a, b).isZero())
                {
                    mx.Set(a, b, new CInt(r.Next(0, maxValue)));
                    notZero--;
                }
            }
            return true;
        }
    }

    public class StatsMatrix
    {
        public double summary { get; }
        public double avgValue { get; }
        public double maxValue { get; }
        public int notZero { get; }

        public StatsMatrix(Matrix mx)
        {
            notZero = 0;
            MathElement sum = new CInt(0),
                temp,
                maxVal = new CInt(0);
            for(int i=0;i<mx.nRow();i++)
                for(int j=0;j<mx.nColumn();j++)
                {
                    temp = (MathElement)(mx.Get(i, j));
                    if(!temp.isZero())
                        notZero++;
                    sum += temp;
                    if(maxVal < temp)
                        maxVal = temp;
                }
            summary = Convert.ToDouble(sum.Value());
            avgValue = summary / (mx.nColumn() * mx.nRow());
            maxValue = Convert.ToDouble(maxVal.Value());
        }
    }
}
