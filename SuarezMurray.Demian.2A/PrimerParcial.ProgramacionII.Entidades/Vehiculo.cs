using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.ProgramacionII.Entidades
{
    public abstract class Vehiculo
    {
        protected Fabricante fabricante;
        protected static Random GeneradorDeVelocidades;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;

        public int VelocidadMaxima
        {
            get
            {
                if (this.velocidadMaxima == 0)
                {
                    this.velocidadMaxima = Vehiculo.GeneradorDeVelocidades.Next(100, 280);
                }
                return this.velocidadMaxima;
            }
        }

        static Vehiculo()
        {
            Vehiculo.GeneradorDeVelocidades = new Random();
        }
        public Vehiculo(float precio, string modelo, Fabricante fabri)
        {
            this.precio = precio;
            this.modelo = modelo;
            this.fabricante = fabri;
        }
        public Vehiculo(string marca, EPais pais, string modelo, float precio)
            :this (precio, modelo, new Fabricante(marca, pais))
        {        
        
        }

        private  string Mostrar()
        {
            StringBuilder vehiculo = new StringBuilder();
            vehiculo.AppendFormat("\n{0}\n", (string)this.fabricante);
            vehiculo.AppendFormat("MODELO: {0}\n",this.modelo);
            vehiculo.AppendFormat("VELOCIDAD MAXIMA: {0}\n", this.VelocidadMaxima.ToString());
            vehiculo.AppendFormat("PRECIO: {0}", this.precio.ToString());
            return vehiculo.ToString();
        }

        public static explicit operator string (Vehiculo v)
        {
            return v.Mostrar();
        }
        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            bool retBool = true;
            if (a.modelo == b.modelo && a.fabricante == b.fabricante)
            {
                retBool = true;
            }
            return retBool;
        }
        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }
    }
}
