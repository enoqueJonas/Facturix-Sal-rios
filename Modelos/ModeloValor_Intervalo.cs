using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloValor_Intervalo
    {
        private int id = 0, nrDependentes = 0, idIntervalo = 0;
        private float valor = 0;

        public ModeloValor_Intervalo(int id, int idIntervalo, int nrDependentes, float valor)
        {
            this.id = id;
            this.idIntervalo = idIntervalo;
            this.nrDependentes = nrDependentes;
            this.valor = valor;
        }

        public int getId()
        {
            return id;
        }
        
        public int getIdIntervalo()
        {
            return idIntervalo;
        }

        public int getNrDependentes()
        {
            return nrDependentes;
        }

        public float getValor()
        {
            return valor;
        }
    }
}
