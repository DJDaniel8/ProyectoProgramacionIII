using ProyectoProgramacionIII.ViewModels.AristasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.AristasViewCommands
{
    public class CrearAristaCommand : CommandBase
    {
        private AristasViewModel _viewModel;
        public CrearAristaCommand(AristasViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.CrearAristaVisibility = System.Windows.Visibility.Visible;
        }
    }
}
