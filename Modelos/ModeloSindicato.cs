using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloSindicato
    {
        private int id;
        private String sindicato;

        public ModeloSindicato(int id, String sindicato)
        {
            this.id = id;
            this.sindicato = sindicato;
        }

        public int getId()
        {
            return id;
        }

        public String getSindicato()
        {
            return sindicato;
        }
    }
}
