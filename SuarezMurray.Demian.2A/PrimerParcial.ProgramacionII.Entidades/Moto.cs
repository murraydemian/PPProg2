using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.ProgramacionII.Entidades
{
    public class Moto : Vehiculo
    {
        public ECilindrada cilindrada;

        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada)
            :base(precio,modelo,new Fabricante(marca, pais))
        {
            this.cilindrada = cilindrada;
        }

        public static bool operator ==(Moto a, Moto b)
        {
            bool retBool = false;
            if (a.fabricante == b.fabricante && a.cilindrada == b.cilindrada && a.modelo == b.modelo)
            {
               // if ()
                //{
                    retBool = true;
                //}
            }
            return retBool;
        }
        public static bool operator !=(Moto a, Moto b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            bool retBool = false;
            if (obj is Moto)
            {
                retBool = (this == (Moto)obj);
            }
            return retBool;
        }
        public static implicit operator float(Moto m)
        {
            return m.precio;
        }
        public override string ToString()
        {
            StringBuilder moto = new StringBuilder();
            moto.AppendLine((string)this);
            moto.AppendFormat("CILINDRADA: {0}\n", this.cilindrada.ToString());
            return moto.ToString();
        }
    }
}
