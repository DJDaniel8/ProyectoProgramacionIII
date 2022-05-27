using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Models
{
    public class Nodo
    {
        public Nodo()
        {

        }
        public Nodo(string nombre)
        {
            Nombre = nombre;
        }
        public string Nombre { get; set; }
        public List<Tuple<Nodo, Arista>> Vecinos { get; set; } = new();
    }
}
