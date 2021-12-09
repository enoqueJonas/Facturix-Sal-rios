using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloProcessamentoDeSalario
    {
        private String nomeDoTrabalhador, operacao, dataProcessamento, tipo;
        private int id, idFuncionario, diasDeTrabalho;
        private double salarioBrutoMensal, subAlimentacao, ajudaDeCusto, ajudaDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, irps, ipa, inss, totalDescontar, adiantamentos, importanciaAPagar;

        public ModeloProcessamentoDeSalario(int id, int idFuncionario, String nomeDoTrabalhador, int diasDeTrabalho, double salarioBrutoMensal, double subAlimentacao, double ajudaDeCusto, double ajudaDeslocacao, double pagamentoFerias, double diversosSubsidios, double totalRetribuicao, double emprestimoMedico, double irps, double ipa, double inss, double totalDescontar, double adiantamentos, double importanciaAPagar, String operacao, String dataProcessamento, String tipo) 
        {
            this.id = id;
            this.idFuncionario = idFuncionario;
            this.diasDeTrabalho = diasDeTrabalho;
            this.nomeDoTrabalhador = nomeDoTrabalhador;
            this.salarioBrutoMensal = salarioBrutoMensal;
            this.subAlimentacao = subAlimentacao;
            this.ajudaDeCusto = ajudaDeCusto;
            this.ajudaDeslocacao = ajudaDeslocacao;
            this.pagamentoFerias = pagamentoFerias;
            this.diversosSubsidios = diversosSubsidios;
            this.totalRetribuicao = totalRetribuicao;
            this.emprestimoMedico = emprestimoMedico;
            this.irps = irps;
            this.ipa = ipa;
            this.inss = inss;
            this.totalDescontar = totalDescontar;
            this.adiantamentos = adiantamentos;
            this.importanciaAPagar = importanciaAPagar;
            this.operacao = operacao;
            this.dataProcessamento = dataProcessamento;
            this.tipo = tipo;
        }

        public int getId() { return id; }
        public int getIdFuncionario() { return idFuncionario; }
        public int getIdDiasDeTrabalho() { return diasDeTrabalho; }
        public String getNome() { return nomeDoTrabalhador; }
        public String getOperacao() { return operacao; }
        public String getDataProcessamento() { return dataProcessamento; }
        public String getTipo() { return tipo; }
        public double getSalarioBrutoMensal() { return salarioBrutoMensal; }
        public double getSubAlimentacao() { return subAlimentacao; }
        public double getAjudaDeCusto() { return ajudaDeCusto; }
        public double getAjudaDeslocacao() { return ajudaDeslocacao; }
        public double getPagamentoFerias() { return pagamentoFerias; }
        public double getDiversosSubsidios() { return diversosSubsidios; }
        public double getTotalRetribuicao() { return totalRetribuicao; }
        public double getEmprestimoMedico() { return emprestimoMedico; }
        public double getIrps() { return irps; }
        public double getIpa() { return ipa; }
        public double getInss() { return inss; }
        public double getTotalADescontar() { return totalDescontar; }
        public double getAdiantamentos() { return adiantamentos; }
        public double getImportanciaApagar() { return importanciaAPagar; }

    }
}
