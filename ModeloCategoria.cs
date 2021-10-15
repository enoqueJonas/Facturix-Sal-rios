using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloCategoria
    {
        private int id;
        private String categoria;

        public ModeloCategoria(int id, String categoria)
        {
            this.id = id;
            this.categoria = categoria;
        }

        public int getId()
        {
            return id;
        }

        public String getProfissao()
        {
            return categoria;
        }
    }
}
