using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.ProgramacionII.Entidades
{
    public class Fabricante
    {
        private string marca;
        private EPais pais;

        public Fabricante(string marca, EPais pais)
        {
            this.marca = marca;
            this.pais = pais;
        }

        public static implicit operator string(Fabricante f)
        {
            StringBuilder fabricante = new StringBuilder();
            fabricante.AppendFormat("{0} - {1}", f.marca, f.pais.ToString());
            return fabricante.ToString();
        }
        public static bool operator !=(Fabricante a, Fabricante b)
        {
            return !(a == b);
        }
        public static bool operator ==(Fabricante a, Fabricante b)
        {
            bool retBool = false;
            if (a.marca == b.marca && a.pais == b.pais)
            {
                retBool = true;
            }
            return retBool;
        }
    }
}
