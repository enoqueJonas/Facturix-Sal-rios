using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloContrato
    {
        private int id;
        private String contrato;

        public ModeloContrato(int id, String contrato)
        {
            this.id = id;
            this.contrato = contrato;
        }

        public int getId()
        {
            return id;
        }

        public String getContrato()
        {
            return contrato;
        }
    }
}
