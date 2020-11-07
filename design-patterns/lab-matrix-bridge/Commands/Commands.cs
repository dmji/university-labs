using System;
using System.Collections.Generic;
using System.Text;

namespace lab_matrix_bridge
{
    public interface ICommand
    {
        void Execute();
        ICommand Clone();
    }
    public abstract class ACommands : ICommand
    {
        protected ACommands()
        {
            int i = 1+1;
        }
        public void Execute()
        {
            CommandManager.GetInstance().Registry(this);
            doExecute();
        }
        protected abstract void doExecute();
        public abstract ICommand Clone();
    }
}
