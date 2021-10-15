using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloRegime
    {
        private int id;
        private String regime;

        public ModeloRegime(int id, String regime)
        {
            this.id = id;
            this.regime = regime;
        }

        public int getId()
        {
            return id;
        }

        public String getProfissao()
        {
            return regime;
        }
    }
}
