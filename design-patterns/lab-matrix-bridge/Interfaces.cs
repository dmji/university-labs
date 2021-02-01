namespace lab_matrix_bridge
{
    public interface Clonable<T>
    {
        T Clone();
    }

    public interface IVector<T> : Clonable<IVector<T>>
    {
        T Get(int index);
        bool Set(int index, T value);
        int Size();
    }
    
    public interface IMatrix<T> : Clonable<IMatrix<T>>
    {
        T Get(int iRow, int iColumn);
        bool Set(int iRow, int iColumn, T value);
        int nRow();
        int nCol();
        void Print(IPrinter p, bool bRelease=true);
        bool isEmpty(int row, int col);
        IMatrix<T> getOriginal();
    }

    public interface IPrinter
    {
        void PrintBorder();
        string getBorderElement();
        void Print<T>(T m, int group = 0);
        void setElementBorder(string left="", string right="");
        void setBorder(string left="", string right="");
        void ReleasePrint();
        void disableBorders(bool left, bool right);
        void flush();
    }
}
