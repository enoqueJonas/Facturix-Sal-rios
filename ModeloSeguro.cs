using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloSeguro
    {
        private int id;
        private String seguro;

        public ModeloSeguro(int id, String seguro)
        {
            this.id = id;
            this.seguro = seguro;
        }

        public int getId()
        {
            return id;
        }

        public String getSeguro()
        {
            return seguro;
        }
    }
}
