using AppicoTest.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppicoTest.Models.Executors
{
    public interface IAppicoExecutor
    {
        IAppicoExecutor InitExecutor();

        IAppicoExecutor CommandHandler(CommandTypes commandType);

        IAppicoExecutor CommandParameterAdd(object parameter);

        object ExecuteCommand();
    }
}
