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
        public ModeloDiasDeTrabalho(int idFunc, int diasDeTrabalho)
        {
            this.idFunc = idFunc;
            this.diasDeTrabalho = diasDeTrabalho;
        }

        public int getIdFunc() { return idFunc; }
        public int getDiasDeTrabalho() { return diasDeTrabalho; }
    }
}
