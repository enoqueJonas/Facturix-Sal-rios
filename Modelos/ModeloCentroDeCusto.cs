using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloCentroDeCusto
    {

        private int id;
        private String centroDeCusto;

        public ModeloCentroDeCusto(int id, String centroDeCusto)
        {
            this.id = id;
            this.centroDeCusto = centroDeCusto;
        }

        public int getId()
        {
            return id;
        }

        public String getCentroDeCusto()
        {
            return centroDeCusto;
        }
    }
}
