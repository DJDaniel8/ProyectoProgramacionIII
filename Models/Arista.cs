using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Models
{
    public class Arista
    {
        public Arista()
        {

        }

        public Arista(Nodo nodo1, Nodo nodo2, double peso)
        {
            Nodo1 = nodo1;
            Nodo2 = nodo2;
            Peso = peso;
        }
        public double Peso { get; set; }
        public Nodo Nodo1 { get; set; }
        public Nodo Nodo2 { get; set; }
    }
}
