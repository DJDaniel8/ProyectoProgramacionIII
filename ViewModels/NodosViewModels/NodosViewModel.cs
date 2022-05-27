using ProyectoProgramacionIII.Commands.NodosViewCommands;
using ProyectoProgramacionIII.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoProgramacionIII.ViewModels.NodosViewModels
{
    public class NodosViewModel : ViewModelBase
    {
        public NodosViewModel()
        {
            CrearNodoCommand = new CrearNodoCommand(this);
            AceptarCommand = new AceptarCommand(this);
            CancelarCommand = new CancelarCommand(this);
            EliminarNodoCommand = new EliminarNodoCommand(this);
        }

        
        public IEnumerable<Nodo> Nodos => Models.Storage._Nodos;

        public ICommand CrearNodoCommand { get; }
        public ICommand AceptarCommand { get; }
        public ICommand CancelarCommand { get; }
        public ICommand EliminarNodoCommand { get; }

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

        private Visibility _CrearNodoVisility = Visibility.Collapsed;
        public Visibility CrearNodoVisility
        {
            get
            {
                return _CrearNodoVisility;
            }
            set
            {
                _CrearNodoVisility = value;
                OnPropertyChanged(nameof(CrearNodoVisility));
            }
        }

        private string _NombreNodo = string.Empty;
        public string NombreNodo
        {
            get
            {
                return _NombreNodo;
            }
            set
            {
                _NombreNodo = value;
                OnPropertyChanged(nameof(NombreNodo));
            }
        }

        private Nodo _SelectedNodo;
        public Nodo SelectedNodo    
        {
            get
            {
                return _SelectedNodo;
            }
            set
            {
                _SelectedNodo = value;
                OnPropertyChanged(nameof(SelectedNodo));
            }
        }


    }
}
