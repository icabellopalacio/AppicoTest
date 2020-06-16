using AppicoTest.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Executors
{
    public class AppicoExecutor : IAppicoExecutor
    {
        private IDictionary<CommandTypes, (Type CommandType, string MethodName)> _commandsDictionary => 
            new Dictionary<CommandTypes, (Type CommandType, string MethodName)> {
                    {CommandTypes.CreateContact,(typeof(ContactCommand),nameof(ContactCommand.CreateNewContact))},
                    {CommandTypes.ModelList,(typeof(ModelCommand),nameof(ModelCommand.ListOfModels))},
                    {CommandTypes.DealerList ,(typeof(DealerCommand),nameof(DealerCommand.ListOfDealer))},
                    {CommandTypes.InventoryList ,(typeof(InventoryCommand),nameof(InventoryCommand.ListOfInventory))},
                    {CommandTypes.ContactList ,(typeof(ContactCommand),nameof(ContactCommand.ListOfContacts))}
                };

        private (Type CommandType, string MethodName) _commandData { get; set; }

        private List<object> _commandparam { get; set; }

        public IAppicoExecutor InitExecutor() {
            _commandData = (null, "");
            _commandparam = new List<object>();
            return this;
        }

        public IAppicoExecutor CommandHandler(CommandTypes commandType)
        {
            _commandData = _commandsDictionary[commandType];
            return this;
        }

        public IAppicoExecutor CommandParameterAdd(object parameter) {
            _commandparam.Add(parameter);
            return this;
        }

        public object ExecuteCommand()
        {
            var commandObject = _commandData.CommandType.GetConstructor(Type.EmptyTypes).Invoke(new Object[0]) ;
            var commandMethod = commandObject.GetType().GetMethod(_commandData.MethodName);
            return commandMethod.Invoke(commandObject, _commandparam.ToArray());
        }

    }
}