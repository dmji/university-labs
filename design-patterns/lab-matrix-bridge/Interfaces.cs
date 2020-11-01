namespace lab_matrix_bridge
{
    public interface IVector<T>
    {
        T Get(int index);
        bool Set(int index, T value);
        int Size();
        int findFirst(T value);
    }
    
    public interface IMatrix<T>
    {
        T Get(int iRow, int iColumn);
        bool Set(int iRow, int iColumn, T value);
        int nRow();
        int nCol();
        void Print(IPrinter p);
        bool isEmpty(int row, int col);
        IMatrix<T> getOriginal();
    }

    public interface IPrinter
    {
        void PrintBorder();
        void PrintBorderElement();
        void Print<T>(T m, int group = 0);
        void setElementBorder(string left="", string right="");
        void setBorder(string left="", string right="");
        void ReleasePrint();
    }
}
