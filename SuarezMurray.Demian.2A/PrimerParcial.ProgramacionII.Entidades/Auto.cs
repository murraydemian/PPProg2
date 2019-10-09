using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.ProgramacionII.Entidades
{
    public class Auto : Vehiculo
    {
        public ETipo tipo;

        public Auto(string modelo, float precio, Fabricante fabri, ETipo tipo)
            : base(precio, modelo, fabri)
        {
            this.tipo = tipo;
        }


        public static explicit operator float(Auto a)
        {
            return a.precio;
        }
        public static bool operator ==(Auto a, Auto b)
        {
            bool retBool = false;
            if ((Vehiculo)a == (Vehiculo)b)
            {
                if (a.tipo == b.tipo)
                {
                    retBool = true;
                }
            }
            return retBool;
        }
        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            bool retBool = false;
            if (obj is Auto)
            {
                retBool = (this == (Auto)obj);
            }
            return retBool;
        }
        public override string ToString()
        {
            StringBuilder auto = new StringBuilder();
            auto.AppendFormat("\n{0}", (string)this);
            auto.AppendFormat("\nTIPO: {0}\n", this.tipo.ToString());            
            return auto.ToString();
        }

    }
}
