using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Models
{
    public class Etiqueta
    {
        public Etiqueta()
        {

        }

        public Etiqueta(Nodo origen, Nodo destino, double peso)
        {
            Origen = origen;
            Destino = destino;
            Peso = peso;
        }
        public double Peso { get; set; }
        public Nodo Destino { get; set; }
        public Nodo Origen { get; set; }
    }
}
