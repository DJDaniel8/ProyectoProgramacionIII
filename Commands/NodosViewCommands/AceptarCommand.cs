using ProyectoProgramacionIII.Models;
using ProyectoProgramacionIII.ViewModels.NodosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.NodosViewCommands
{
    public class AceptarCommand : CommandBase
    {
        private NodosViewModel _viewModel;
        public AceptarCommand(NodosViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(NodosViewModel.NombreNodo))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return (!String.IsNullOrEmpty(_viewModel.NombreNodo)) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Nodo n = new Nodo(_viewModel.NombreNodo);
            Models.Storage._Nodos.Add(n);
            _viewModel.NombreNodo = String.Empty;
            _viewModel.CrearNodoVisility = System.Windows.Visibility.Collapsed;
        }
    }
}
