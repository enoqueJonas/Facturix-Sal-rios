using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloAdiantamento
    {
        private int id, idFuncionario, diasDeTrabalho;
        private double salarioBruto, adiantamento;
        private float percentagem;
        private String data;

        public ModeloAdiantamento(int id, int idFuncionario, double salarioBruto, int diasDeTrabalho, float percentagem, double adiantamento, String data) 
        {
            this.id = id;
            this.salarioBruto = salarioBruto;
            this.idFuncionario = idFuncionario;
            this.diasDeTrabalho = diasDeTrabalho;
            this.percentagem = percentagem;
            this.adiantamento = adiantamento;
            this.data = data;
        }

        public int getId() { return id; }
        public int getIdFuncionario() { return idFuncionario; }
        public double getSalarioBruto() { return salarioBruto; }
        public int getDiasDeTrabalho() { return diasDeTrabalho; }
        public float getPercentagem() { return percentagem; }
        public double getDiantamento() { return adiantamento; }
        public String getData() { return data; }
    }
}
