using ProyectoProgramacionIII.ViewModels.AristasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.AristasViewCommands
{
    public class CancelarCommand : CommandBase
    {
        private AristasViewModel _viewModel;
        public CancelarCommand(AristasViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.CrearAristaVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.SelectedNodo1 = null;
            _viewModel.SelectedNodo2 = null;
            _viewModel.Peso = 0;
        }
    }
}
