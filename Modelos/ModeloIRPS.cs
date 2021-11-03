using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloIRPS
    {
        private int id , nrDependentes;
        private float valor, coeficiente;
        private double salarioMin, salarioMax;

        public ModeloIRPS(int id, double salarioMin, double salarioMax, float valor, int nrDependentes, float coeficiente)
        {
            this.id = id;
            this.salarioMin = salarioMin;
            this.salarioMax = salarioMax;
            this.nrDependentes = nrDependentes;
            this.valor = valor;
            this.coeficiente = coeficiente;
        }

        public int getId()
        {
            return id;
        }

        public double getSalarioMin()
        {
            return salarioMin;
        }
        public double getSalarioMax()
        {
            return salarioMax;
        }

        public int getNrDependentes()
        {
            return nrDependentes;
        }

        public float getValor()
        {
            return valor;
        }
        public float getCoeficiente()
        {
            return coeficiente;
        }
    }
}
