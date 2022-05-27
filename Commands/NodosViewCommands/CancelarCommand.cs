using ProyectoProgramacionIII.ViewModels.NodosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.NodosViewCommands
{
    public class CancelarCommand : CommandBase
    {
        private NodosViewModel _viewModel;

        public CancelarCommand(NodosViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.CrearNodoVisility = System.Windows.Visibility.Collapsed;
            _viewModel.NombreNodo = String.Empty;
        }
    }
}
