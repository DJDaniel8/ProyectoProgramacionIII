using ProyectoProgramacionIII.Models;
using ProyectoProgramacionIII.ViewModels.AristasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.AristasViewCommands
{
    public class EliminarAristaCommand : CommandBase
    {
        private AristasViewModel _viewModel;
        public EliminarAristaCommand(AristasViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AristasViewModel.SelectedArista)) OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return (_viewModel.SelectedArista != null) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Arista a = _viewModel.SelectedArista;
            IEnumerable<Tuple<Nodo, Arista>> list =
                from b in a.Nodo1.Vecinos
                where (b.Item1 == a.Nodo1 || b.Item1 == a.Nodo2) && b.Item2 == a
                select b;
            a.Nodo1.Vecinos.Remove(list.First());

            list =
                from b in a.Nodo2.Vecinos
                where (b.Item1 == a.Nodo1 || b.Item1 == a.Nodo2) && b.Item2 == a
                select b;

            a.Nodo2.Vecinos.Remove(list.First());

            Storage.Aristas.Remove(a);
        }
    }
}
