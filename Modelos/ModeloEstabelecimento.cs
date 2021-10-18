using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloEstabelecimento
    {
        private int id;
        private String estabelecimento;

        public ModeloEstabelecimento(int id, String estabelecimento)
        {
            this.id = id;
            this.estabelecimento = estabelecimento;
        }

        public int getId()
        {
            return id;
        }

        public String getEstabelecimento()
        {
            return estabelecimento;
        }
    }
}
