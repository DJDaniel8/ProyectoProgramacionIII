using ProyectoProgramacionIII.Models;
using ProyectoProgramacionIII.ViewModels.AristasViewModels;
using ProyectoProgramacionIII.ViewModels.NodosViewModels;
using ProyectoProgramacionIII.ViewModels.NosotrosViewModels;
using ProyectoProgramacionIII.ViewModels.ViajeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.ViewModels.MainWindowViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            NosotrosViewModel = new();
            NodosViewModel = new();
            AristasViewModel = new();
            ViajeViewModel = new();
            
        }

        public NosotrosViewModel NosotrosViewModel { get; set; }
        public NodosViewModel NodosViewModel { get; set; }
        public AristasViewModel AristasViewModel { get; set; }
        public ViajeViewModel ViajeViewModel { get; set; }

        private bool _IsNosotrosChecked = true;
        public bool IsNosotrosChecked
        {
            get
            {
                return _IsNosotrosChecked;
            }
            set
            {
                _IsNosotrosChecked = value;
                if (value == true) NosotrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else NosotrosViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsNosotrosChecked));
            }
        }

        private bool _IsNodosChecked;
        public bool IsNodosChecked
        {
            get
            {
                return _IsNodosChecked;
            }
            set
            {
                _IsNodosChecked = value;
                if(value == true) NodosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else NodosViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsNodosChecked));
            }
        }

        private bool _IsAristasChecked;
        public bool IsAristasChecked
        {
            get
            {
                return _IsAristasChecked;
            }
            set
            {
                _IsAristasChecked = value;
                if (value == true) AristasViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else AristasViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsAristasChecked));
            }
        }

        private bool _IsViajeChecked;
        public bool IsViajeChecked
        {
            get
            {
                return _IsViajeChecked;
            }
            set
            {
                _IsViajeChecked = value;
                if (value == true) ViajeViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else ViajeViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsViajeChecked));
            }
        }
    }
}
