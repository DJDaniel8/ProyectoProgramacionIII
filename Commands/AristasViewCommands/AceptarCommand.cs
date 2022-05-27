using ProyectoProgramacionIII.ViewModels.AristasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.AristasViewCommands
{
    public class AceptarCommand : CommandBase
    {
        private AristasViewModel _viewModel;
        public AceptarCommand(AristasViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(AristasViewModel.SelectedNodo1) ||
                e.PropertyName == nameof(AristasViewModel.SelectedNodo2) ||
                e.PropertyName == nameof(AristasViewModel.Peso))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return (_viewModel.SelectedNodo1 != null) &&
                    (_viewModel.SelectedNodo2 != null) &&
                    (_viewModel.SelectedNodo1 != _viewModel.SelectedNodo2) &&
                    (_viewModel.Peso > 0) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Models.Storage.Grafo.CrearArista(_viewModel.SelectedNodo1, _viewModel.SelectedNodo2, _viewModel.Peso);
            _viewModel.CrearAristaVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.SelectedNodo1 = null;
            _viewModel.SelectedNodo2 = null;
            _viewModel.Peso = 0;
        }
    }
}
