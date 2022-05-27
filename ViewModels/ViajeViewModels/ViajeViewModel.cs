using ProyectoProgramacionIII.Commands.ViajeViewCommands;
using ProyectoProgramacionIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoProgramacionIII.ViewModels.ViajeViewModels
{
    public class ViajeViewModel : ViewModelBase
    {
        public ViajeViewModel()
        {
            ViajarCommand = new ViajeCommand(this);
        }

        public IEnumerable<Nodo> Nodos => Models.Storage._Nodos;
        public IEnumerable<Etiqueta> Etiquetas => Storage.Etiquetas;

        public ICommand ViajarCommand { get; }

        private Visibility _ControlVisibility = Visibility.Collapsed;
        public Visibility ControlVisibility
        {
            get
            {
                return _ControlVisibility;
            }
            set
            {
                _ControlVisibility = value;
                OnPropertyChanged(nameof(ControlVisibility));
            }
        }

        private string _Costo;
        public string Costo
        {
            get
            {
                return _Costo;
            }
            set
            {
                _Costo = value;
                OnPropertyChanged(nameof(Costo));
            }
        }

        private Nodo _SelectedNodo1;
        public Nodo SelectedNodo1
        {
            get
            {
                return _SelectedNodo1;
            }
            set
            {
                _SelectedNodo1 = value;
                OnPropertyChanged(nameof(SelectedNodo1));
            }
        }

        private Nodo _SelectedNodo2;
        public Nodo SelectedNodo2
        {
            get
            {
                return _SelectedNodo2;
            }
            set
            {
                _SelectedNodo2 = value;
                OnPropertyChanged(nameof(SelectedNodo2));
            }
        }


    }
}
