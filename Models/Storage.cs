using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Models
{
    public static class Storage
    {
        public static Grafo Grafo { get; set; } = new();
        public static ObservableCollection<Nodo> _Nodos { get; set; } = new();
        public static ObservableCollection<Arista> Aristas { get; set; } = new();
        public static ObservableCollection<Etiqueta> Etiquetas { get; set; } = new();
    }
}
