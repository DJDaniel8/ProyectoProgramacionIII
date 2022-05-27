using ProyectoProgramacionIII.Models;
using ProyectoProgramacionIII.ViewModels.ViajeViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Commands.ViajeViewCommands
{
    public class ViajeCommand : CommandBase
    {
        private ViajeViewModel _viewModel;
        public ViajeCommand(ViajeViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ViajeViewModel.SelectedNodo1) ||
                e.PropertyName == nameof(ViajeViewModel.SelectedNodo2))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return (_viewModel.SelectedNodo1 != null) &&
                    (_viewModel.SelectedNodo2 != null) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Storage.Etiquetas.Clear();
            List<Etiqueta> lista = Storage.Grafo.Dijkstra(_viewModel.SelectedNodo1);
            Nodo aux = _viewModel.SelectedNodo2;
            while(aux != _viewModel.SelectedNodo1)
            {
                IEnumerable<Etiqueta> list =
                from b in lista
                where b.Destino == aux
                select b;
                Etiqueta et = list.First();
                Storage.Etiquetas.Add(et);
                aux = et.Origen;
            }
            var a = Extensions.ToObservableCollection<Etiqueta>(Storage.Etiquetas.Reverse());
            double mayor = 0;
            Etiqueta Emayor = new();
            Storage.Etiquetas.Clear();
            foreach (var item in a)
            {
                if(item.Peso > mayor)
                {
                    mayor = item.Peso;
                    Emayor = item;
                }
                Storage.Etiquetas.Add(item);
            }
            _viewModel.Costo = $"Kilometraje Total: {Emayor.Peso}";
        }

    }
}
