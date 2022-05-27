using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionIII.Models
{
    public class Grafo
    {
        public List<Arista> Aristas { get; set; } = new();
        public List<Nodo> Nodos { get; set; } = new();


        public List<Etiqueta> Dijkstra(Nodo origen)
        {
            List<Nodo> Visitados = new();
            List<Etiqueta> EtiquetasPermanentes = new();
            Etiqueta EtiquetaPermanente = new() { Peso = 0 };
            Nodo NodoPermanente = origen;
            List<Etiqueta> EtiquetasReservadas = new();
            List<Etiqueta> ERAux = new();
            bool continuar = true;
            while (continuar)
            {
                continuar = false;
                Visitados.Add(NodoPermanente);
                Etiqueta? etiquetaAux = null;
                foreach (var item in NodoPermanente.Vecinos)
                {
                    if (!Visitados.Contains(item.Item1))
                    {
                        continuar = true;
                        Etiqueta etiqueta = new Etiqueta(NodoPermanente, item.Item1, EtiquetaPermanente.Peso + item.Item2.Peso);
                        if (etiquetaAux == null || etiquetaAux.Peso > etiqueta.Peso)
                        {
                            if (etiquetaAux != null) EtiquetasReservadas.Add(etiquetaAux);
                            etiquetaAux = etiqueta;
                        }
                        else
                        {
                            bool agregar = true;
                            foreach (var item2 in EtiquetasReservadas)
                            {
                                if (item2.Destino == etiqueta.Destino)
                                {
                                    //agregar = false;
                                    if (item2.Peso > etiqueta.Peso)
                                    {

                                        ERAux.Add(item2);
                                        //EtiquetasReservadas.Add(etiqueta);
                                    }
                                }
                            }
                            foreach (var item2 in ERAux)
                            {
                                EtiquetasReservadas.Remove(item2);
                            }
                            ERAux.Clear();
                            if (agregar) EtiquetasReservadas.Add(etiqueta);
                        }
                    }
                }
                List<Etiqueta> ERAux2 = new();
                foreach (var item in EtiquetasReservadas)
                {
                    if (etiquetaAux != null && item.Peso < etiquetaAux.Peso)
                    {
                        foreach (var item2 in EtiquetasReservadas)
                        {
                            if (item2.Destino == etiquetaAux.Destino)
                            {
                                if (item2.Peso > etiquetaAux.Peso)
                                {

                                    ERAux.Add(item2);
                                    ERAux2.Add(etiquetaAux);
                                }
                            }
                            //else ERAux2.Add(etiquetaAux);
                        }
                        ERAux2.Add(etiquetaAux);
                        etiquetaAux = item;
                    }
                }
                foreach (var item2 in ERAux)
                {
                    EtiquetasReservadas.Remove(item2);
                }
                foreach (var item2 in ERAux2)
                {
                    EtiquetasReservadas.Add(item2);
                }
                ERAux2.Clear();
                EtiquetaPermanente = etiquetaAux;
                if (EtiquetaPermanente != null)
                {
                    NodoPermanente = EtiquetaPermanente.Destino;
                    EtiquetasPermanentes.Add(EtiquetaPermanente);
                }
                foreach (var item in EtiquetasReservadas)
                {
                    if (EtiquetaPermanente != null)
                    {
                        if (item.Destino == EtiquetaPermanente.Destino)
                        {
                            ERAux.Add(item);
                        }
                    }
                }
                foreach (var item2 in ERAux)
                {
                    EtiquetasReservadas.Remove(item2);
                }
                ERAux.Clear();
            }

            if (EtiquetasReservadas.Count > 0)
            {
                foreach (var item in EtiquetasReservadas)
                {
                    EtiquetasPermanentes.Add(item);
                }
            }

            return EtiquetasPermanentes;
        }

        public void CrearArista(Nodo g1, Nodo g2, double peso)
        {
            Arista a = new(g1, g2, peso);
            g1.Vecinos.Add(new Tuple<Nodo, Arista>(g2, a));
            g2.Vecinos.Add(new Tuple<Nodo, Arista>(g1, a));
            Models.Storage.Aristas.Add(a);
            
        }

        public void MostrarCamino(Nodo inicio, Nodo destino, List<Etiqueta> etiquetas)
        {
            Nodo destinoaux = destino;
            bool continuar = true;
            while (continuar)
            {
                IEnumerable<Etiqueta> filtrado =
                    from etiqueta in etiquetas
                    where etiqueta.Destino == destinoaux
                    select etiqueta;

                Console.WriteLine(filtrado.First().Destino.Nombre);
                destinoaux = filtrado.First().Origen;
                if (destinoaux == inicio) continuar = false;
            }
            Console.WriteLine(inicio.Nombre);
        }
    }
}
