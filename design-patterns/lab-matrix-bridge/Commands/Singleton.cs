using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace lab_matrix_bridge
{
    public class CommandManager
    {
        SparseVector<ICommand> mem = null;
        bool m_bUndo=false;
        static CommandManager instance = null;
        CommandManager()
        {
            mem = new SparseVector<ICommand>(100000);
        }
        public static CommandManager GetInstance()
        {
            if(instance == null)
                instance = new CommandManager();
            return instance;
        }
        public void Registry(ICommand cmd)
        {
            if(!m_bUndo)
                mem.Add(cmd);
        }
        public void Undo()
        {
            m_bUndo = true;
            if(mem.Length() > 1)
                mem.PopBack();
            for(int i = 0; i < mem.Length(); i++)
                mem.Get(i).Execute();
            m_bUndo = false;

        }
    }
}
