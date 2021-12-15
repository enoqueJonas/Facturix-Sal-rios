using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloRemuneracoes
    {
        private int id;
        private float percentagem;
        private double valor;
        private String quantidade, grupo, natureza, isento, valorUnitario;
        private Boolean segurancaSocial, irps, seguro;

        public ModeloRemuneracoes(int id, float percentagem, String grupo, String natureza, String quantidade, String valorUnitario, Boolean segurancaSocial, Boolean irps, Boolean seguro, String isento, double valor) 
        {
            this.id = id;
            this.percentagem = percentagem;
            this.grupo = grupo;
            this.natureza = natureza;
            this.quantidade = quantidade;
            this.valorUnitario = valorUnitario;
            this.segurancaSocial = segurancaSocial;
            this.irps = irps;
            this.seguro = seguro;
            this.isento = isento;
            this.valor = valor;
        }

        public int getId() { return id; }

        public float getPercentagem() { return percentagem; }

        public String getGrupo() { return grupo; }

        public String getNatureza() { return natureza; }

        public String getQuantidade() { return quantidade; }

        public String getValorUnitario() { return valorUnitario; }

        public Boolean getSegurancaSocial() { return segurancaSocial; }

        public Boolean getIrps() { return irps; }

        public Boolean getSeguro() { return seguro; }

        public String getIsento() { return isento; }

        public double getValor() { return valor; }
    }
}
