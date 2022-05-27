using ProyectoProgramacionIII.ViewModels.NodosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.NodosViewCommands
{
    public class CrearNodoCommand : CommandBase
    {
        private NodosViewModel _viewModel;

        public CrearNodoCommand(NodosViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.CrearNodoVisility = System.Windows.Visibility.Visible;
        }
    }
}
