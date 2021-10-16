using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloHabilitacao
    {
        private int id;
        private String habilitacao;

        public ModeloHabilitacao(int id, String habilitacao)
        {
            this.id = id;
            this.habilitacao = habilitacao;
        }

        public int getId()
        {
            return id;
        }

        public String getHabilitacao()
        {
            return habilitacao;
        }
    }
}
