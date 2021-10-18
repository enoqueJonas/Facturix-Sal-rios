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
        private float percentagem;

        public ModeloSeguro(int id, String seguro, float percentagem)
        {
            this.id = id;
            this.seguro = seguro;
            this.percentagem = percentagem;
        }

        public int getId()
        {
            return id;
        }

        public String getSeguro()
        {
            return seguro;
        }

        public float getPercentagem() 
        {
            return percentagem;
        }
    }
}
