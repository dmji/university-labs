using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace lab_matrix_bridge
{
    public class CommandManager
    {
        SimpleVector<ICommand> mem = null;
        bool m_bUndo=false;
        static CommandManager instance = null;

        CommandManager()
        {
            mem = new SimpleVector<ICommand>();
        }

        public static CommandManager GetInstance() => instance == null ? instance = new CommandManager() : instance;

        public void Registry(ICommand cmd)
        {
            if(!m_bUndo)
                mem.Add(cmd);
        }

        public void Undo()
        {
            m_bUndo = true;
            if(mem.Size() > 1)
                mem.Pop();
            for(int i = 0; i < mem.Size(); i++)
                mem.Get(i).Execute();
            m_bUndo = false;
        }
    }
}
