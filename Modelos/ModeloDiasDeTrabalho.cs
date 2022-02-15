using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloDiasDeTrabalho
    {
        private int idFunc, diasDeTrabalho;
        private String data;
        public ModeloDiasDeTrabalho(int idFunc, int diasDeTrabalho, String data)
        {
            this.idFunc = idFunc;
            this.diasDeTrabalho = diasDeTrabalho;
            this.data = data;
        }

        public int getIdFunc() { return idFunc; }
        public int getDiasDeTrabalho() { return diasDeTrabalho; }
        public String getData() { return data; }
    }
}
