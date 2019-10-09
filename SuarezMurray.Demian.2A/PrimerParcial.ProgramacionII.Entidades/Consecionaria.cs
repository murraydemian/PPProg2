using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.ProgramacionII.Entidades
{
    public class Concesionaria
    {
        private int capacidad;
        private List<Vehiculo> vehiculos;

        private Concesionaria()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        private Concesionaria(int capacidad)
            :this()
        {
            this.capacidad = capacidad;
        }


        public double PrecioDeAutos
        {
            get
            {
                double precioAutos = 0;
                foreach(Vehiculo item in this.vehiculos)
                {
                    if (item is Auto)
                    {
                        

                        precioAutos += (float)(Auto)item;

                    }
                }
                return precioAutos;
            }
        }
        public double PrecioDeMotos
        {
            get
            {
                double precioMotos = 0;
                foreach(Vehiculo item in this.vehiculos)
                {
                    if (item is Moto)
                    {

                        //float precio = (Moto)item;
                        precioMotos += (Moto)item;

                    }
                }
                return precioMotos;
            }
        }
        public double PrecioTotal
        {
            get
            {
                return this.PrecioDeAutos + this.PrecioDeMotos;
            }
        }


        public static string Mostrar(Concesionaria c)
        {
            StringBuilder concesionaria = new StringBuilder();
            concesionaria.AppendFormat("Capacidad: {0}\n", c.capacidad.ToString());
            concesionaria.AppendFormat("Total por autos: {0}\n", c.PrecioDeAutos.ToString());
            concesionaria.AppendFormat("Total por motos: {0}\n", c.PrecioDeMotos.ToString());
            concesionaria.AppendFormat("Total: {0}\n", c.PrecioTotal.ToString());
            concesionaria.AppendLine("****************************************");
            concesionaria.AppendLine("Listado de vehiculos");
            concesionaria.AppendLine("****************************************");
            foreach(Vehiculo item in c.vehiculos)
            {
                concesionaria.AppendFormat("{0}", item.ToString());
            }
            return concesionaria.ToString();
        }
        private double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            double retPrice = 0;
            switch(tipoVehiculo)
            {
                case EVehiculo.PrecioDeAutos:
                    retPrice = this.PrecioDeAutos;
                    break;
                case EVehiculo.PrecioDeMotos:
                    retPrice = this.PrecioDeMotos;
                    break;
                case EVehiculo.PrecioTotal:
                    retPrice = this.PrecioTotal;
                    break;
            }
            return retPrice;
        }


        public static implicit operator Concesionaria(int capacidad)
        {
            return new Concesionaria(capacidad);
        }
        public static bool operator ==(Concesionaria c, Vehiculo v)
        {
            bool retBool = false;
            foreach(Vehiculo item in c.vehiculos)
            {
                if (item.Equals(v))
                {
                    retBool = true;
                    break;
                }
            }
            return retBool;
        }
        public static bool operator !=(Concesionaria c, Vehiculo v)
        {
            return !(c == v);
        }
        public static Concesionaria operator +(Concesionaria c, Vehiculo v)
        {
            if (c.capacidad > c.vehiculos.Count)
            {
                if (c != v)
                {
                    c.vehiculos.Add(v);
                }
                else
                {
                    Console.WriteLine("El vehiculo ya esta en la concesionaria!!!");
                }
            }
            else
            {
                Console.WriteLine("No hay mas lugar en la concesionaria!!!");
            }
            return c;
        }
    }
}
