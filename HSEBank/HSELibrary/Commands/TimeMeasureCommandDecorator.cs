using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Commands
{
    /// <summary>
    /// Декоратор для измерения времени выполнения команд.
    /// </summary>
    public class TimeMeasureCommandDecorator : ICommand
    {
        private readonly ICommand _innerCommand;

        public TimeMeasureCommandDecorator(ICommand innerCommand)
        {
            _innerCommand = innerCommand;
        }

        public void Execute()
        {
            Stopwatch sw = Stopwatch.StartNew();
            _innerCommand.Execute();
            sw.Stop();
            Console.WriteLine($"Команда выполнена за {sw.ElapsedMilliseconds} мс.");
        }
    }
}
