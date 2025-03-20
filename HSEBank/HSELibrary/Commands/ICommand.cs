using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Commands
{
    /// <summary>
    /// Интерфейс команды, который должен реализовывать каждый пользовательский сценарий.
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }
}
