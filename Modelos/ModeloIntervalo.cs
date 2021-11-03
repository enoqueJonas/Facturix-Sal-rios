using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloIntervalo
    {
        private int id = 0;
        private float salarioBrutoMin = 0, salarioBrutoMax = 0;

        public ModeloIntervalo(int id, float salarioBrutoMin, float salarioBrutoMax)
        {
            this.id = id;
            this.salarioBrutoMin = salarioBrutoMin;
            this.salarioBrutoMax = salarioBrutoMax;
        }

        public int getId()
        {
            return id;
        }

        public float getSalarioBrutoMin()
        {
            return salarioBrutoMin;
        }
        
        public float getSalarioBrutoMax()
        {
            return salarioBrutoMax;
        }
    }
}
