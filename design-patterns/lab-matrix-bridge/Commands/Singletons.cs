using System;
using System.Collections.Generic;
using System.Text;

namespace lab_matrix_bridge
{
    public class CommandManager
    {
        static CommandManager instance = null;
        CommandManager()
        {
        }
        public static CommandManager GetInstance()
        {
            if(instance == null)
                instance = new CommandManager();
            return instance;
        }
    }
}
