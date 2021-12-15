using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloFuncionarioRemuneracoes
    {
        private int id, idFuncionario, idRemuneracao;
        private double valor;

        public ModeloFuncionarioRemuneracoes(int id, int idFuncionario, int idRemuneracao, double valor) 
        {
            this.id = id;
            this.idFuncionario = idFuncionario;
            this.idRemuneracao = idRemuneracao;
            this.valor = valor;
        }

        public int getId() { return id; }
        public int getIdFuncionario() { return idFuncionario; }
        public int getIdRemuneracao() { return idRemuneracao; }
        public double getValor() { return valor; }
    }
}
