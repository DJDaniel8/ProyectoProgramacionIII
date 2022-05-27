using ProyectoProgramacionIII.Commands.AristasViewCommands;
using ProyectoProgramacionIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoProgramacionIII.ViewModels.AristasViewModels
{
    public class AristasViewModel : ViewModelBase
    {
        public AristasViewModel()
        {
            CrearAristaCommand = new CrearAristaCommand(this);
            CancelarCommand = new CancelarCommand(this);
            AceptarCommand = new AceptarCommand(this);
            EliminarCommand = new EliminarAristaCommand(this);
        }

        public IEnumerable<Nodo> Nodos => Models.Storage._Nodos;
        public IEnumerable<Arista> Aristas => Models.Storage.Aristas;

        public ICommand CrearAristaCommand { get; }
        public ICommand CancelarCommand { get; }
        public ICommand AceptarCommand { get; }
        public ICommand EliminarCommand { get; }

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

        private Visibility _CrearAristaVisibility = Visibility.Collapsed;
        public Visibility CrearAristaVisibility
        {
            get
            {
                return _CrearAristaVisibility;
            }
            set
            {
                _CrearAristaVisibility = value;
                OnPropertyChanged(nameof(CrearAristaVisibility));
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

        private Arista _SelectedArista;
        public Arista SelectedArista
        {
            get
            {
                return _SelectedArista;
            }
            set
            {
                _SelectedArista = value;
                OnPropertyChanged(nameof(SelectedArista));
            }
        }

        private double _Peso;
        public double Peso
        {
            get
            {
                return _Peso;
            }
            set
            {
                _Peso = value;
                OnPropertyChanged(nameof(Peso));
            }
        }
    }
}
