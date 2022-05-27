using ProyectoProgramacionIII.ViewModels.NodosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.NodosViewCommands
{
    public class EliminarNodoCommand : CommandBase
    {
        private NodosViewModel _viewModel;
        public EliminarNodoCommand(NodosViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NodosViewModel.SelectedNodo))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return (_viewModel.SelectedNodo != null) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Models.Storage._Nodos.Remove(_viewModel.SelectedNodo);
        }
    }
}
