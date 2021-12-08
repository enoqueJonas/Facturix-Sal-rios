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
        private float coeficiente;
        private double salarioMin, valor, salarioMax;

        public ModeloIRPS(int id, double salarioMin, double salarioMax, double valor, int nrDependentes, float coeficiente)
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

        public double getValor()
        {
            return valor;
        }
        public float getCoeficiente()
        {
            return coeficiente;
        }
    }
}
