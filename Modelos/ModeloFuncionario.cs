using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    public class ModeloFuncionario 
    {
        private int codigo, codigoPostal, dependentes, idIRPS;
        private double vencimento, subTransporte, subAlimentacao, subComunicacao;
        private float horas, impostoMunicipal;
        private String 
            nome, 
            cell, 
            cellSec, 
            tel, 
            email, 
            estadoCivil, 
            sexo, 
            deficiencia, 
            conjugue, 
            linkImagem, 
            bairro, 
            localidade, 
            moradaGen, 
            dataNascimento,
            tipoContrato,
            dataAdmissao,
            dataDemissao,
            profissao,
            categoria,
            seguro,
            localTrabalho,
            regime,
            bi,
            numeroBenificiario,
            numeroFiscal,
            habilitacoes,
            nacionalidade,
            ultimoEmprego,
            turno,
            centroDeCusto,
            segurancaSocial,
            sindicato;
        public ModeloFuncionario
            (
                int codigo,
                int idIRPS,
                String nome,
                String cell,
                String cellSec,
                String telefone,
                String email,
                String estadoCivil,
                String deficiencia,
                String conjugue,
                String sexo,
                String dataNascimento,
                String linkImagem,
                int codigoPostal,
                String bairro,
                String localidade,
                String moradaGen,
                String tipoContrato,
                String dataAdmissao,
                String dataDemissao,
                String profissao,
                String categoria,
                String seguro,
                String localTrabalho,
                String regime,
                String bi,
                String numeroBenificiario,
                String numeroFiscal,
                double vencimento,
                double subAlimentacao,
                double subTransporte,
                float horas,
                int dependentes,
                String habilitacoes,
                String nacionalidade,
                String ultimoEmprego,
                String turno, 
                float impostoMunicipal,
                String centroDeCusto,
                String segurancaSocial,
                String sindicato,
                double subComunicacao
            )
        {
            this.codigo = codigo;
            this.nome = nome;
            this.cell = cell;
            this.cellSec = cellSec;
            this.tel = telefone;
            this.email = email;
            this.estadoCivil = estadoCivil;
            this.sexo = sexo;
            this.deficiencia = deficiencia;
            this.conjugue = conjugue;
            this.estadoCivil = estadoCivil;
            this.dataNascimento = dataNascimento;
            this.linkImagem = linkImagem;
            this.codigoPostal = codigoPostal;
            this.bairro = bairro;
            this.localidade = localidade;
            this.moradaGen = moradaGen;
            this.tipoContrato = tipoContrato;
            this.dataAdmissao = dataAdmissao;
            this.dataDemissao = dataDemissao;
            this.profissao = profissao;
            this.categoria = categoria;
            this.seguro = seguro;
            this.localTrabalho = localTrabalho;
            this.regime = regime;
            this.bi = bi;
            this.numeroBenificiario = numeroBenificiario;
            this.numeroFiscal = numeroFiscal;
            this.vencimento = vencimento;
            this.subTransporte = subTransporte;
            this.subAlimentacao = subAlimentacao;
            this.horas = horas;
            this.dependentes = dependentes;
            this.habilitacoes = habilitacoes;
            this.nacionalidade = nacionalidade;
            this.ultimoEmprego = ultimoEmprego;
            this.turno = turno;
            this.impostoMunicipal = impostoMunicipal;
            this.centroDeCusto = centroDeCusto;
            this.segurancaSocial = segurancaSocial;
            this.sindicato = sindicato;
            this.idIRPS = idIRPS;
            this.subComunicacao = subComunicacao;
        }

        public int getCodigo() { return codigo; }
        public int getIdIRPS() { return idIRPS; }

        public String getNome() { return nome; }

        public String getCell() { return cell; }

        public String getCellSec() { return cellSec; }

        public String getTel() { return tel; }

        public String getEmail() { return email; }

        public String getSexo() { return sexo; }

        public String getEstadoCivil() { return estadoCivil; }

        public String getConjugue() { return conjugue; }

        public String getDeficiencia() { return deficiencia; }

        public String getDataNascimento() { return dataNascimento; }

        public String getLinkImagem() { return linkImagem; }

        public int getCodigoPostal() { return codigoPostal; }

        public String getBairro() { return bairro; }

        public String getLocalidade() { return localidade; }

        public String getMoradaGen() { return moradaGen; }

        public String getTipoContrato() { return tipoContrato; }

        public String getDataAdmissao() { return dataAdmissao; }

        public String getDataDemissao() { return dataDemissao; }

        public String getProfissao() { return profissao; }

        public String getCategoria() { return categoria; }

        public String getSeguro() { return seguro; }

        public String getRegime() { return regime; }

        public String getLocalTrabalho() { return localTrabalho; }

        public String getBi() { return bi; }

        public String getNumeroBenificiario() { return numeroBenificiario; }

        public String getNumeroFiscal() { return numeroFiscal; }

        public double getVencimento() { return vencimento; }

        public double getSubTransporte() { return subTransporte; }

        public double getSubAlimentacao() { return subAlimentacao; }

        public double getHoras() { return horas; }

        public double getSubComunicacao() { return subComunicacao; }

        public int getDependentes() { return dependentes; }

        public String getHabilitacoes() { return habilitacoes; }

        public String getNacionalidade() { return nacionalidade; }

        public String getUltimoEmprego() { return ultimoEmprego; }

        public String getTurno() { return turno; }

        public float getImpostoMunicipal() { return impostoMunicipal; }

        public String getCentroDeCusto() { return centroDeCusto;}

        public String getSegurancaSocial() { return segurancaSocial; }

        public String getSindicato() { return sindicato; }
    }
}
