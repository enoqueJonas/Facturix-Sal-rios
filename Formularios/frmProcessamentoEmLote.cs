using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Formularios
{
    public partial class frmProcessamentoEmLote : Form
    {
        private int nrMes, diasDeTrabalho, codigoCelSelecionada;
        private void dataProcessamentoSalario_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {         
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                                                                            
            }
        }

        private void dataProcessamentoSalario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataProcessamentoSalario.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        private void dataProcessamentoSalario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataProcessamentoSalario.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(codigoCelSelecionada);
            ArrayList listaIrps = ControllerIRPS.recuperar();
            ArrayList listaDependentes = ControllerDependente.recuperarComCodFuncionario(codigoCelSelecionada);
            frmProcessamentoIndividual f = new frmProcessamentoIndividual();
            int codIrps = 0;
            double valorIrps = 0, emprestimo = 0, ipa = 0, adiantamentos = 0, vencimento = 0, outroSub = 0, subAlimentacao = 0;
            diasDeTrabalho  = getDiasDeTrabalho(codigoCelSelecionada);
            foreach (ModeloFuncionario func in listaFuncionarios) 
            {
                f.nrRegistonr.Value = func.getCodigo();
                f.txtNome.Text = func.getNome();
                emprestimo = 0;
                f.txtemprestimoMedico.Text = emprestimo + "";
                ipa = func.getImpostoMunicipal();
                f.txtIpa.Text = ipa + "";
                adiantamentos = 0;
                f.txtadiantamentos.Text = adiantamentos  + "";
                codIrps = func.getIdIRPS();
                vencimento = func.getVencimento();
                f.txtVencimento.Text = vencimento + " ";
            }
            foreach (ModeloIRPS conta in listaIrps)
            {
                if (codIrps == conta.getId())
                {
                    valorIrps = conta.getValor();
                    f.txtIrps.Text = valorIrps + "";
                }
            }
            ArrayList listaRemenuracoes = ControllerRemuneracoes.recuperar();
            ArrayList listaFuncRemuneracao = ControllerFuncionarioRemuneracoes.recuperar();
            foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracao)
            {
                if (codigoCelSelecionada == fr.getIdFuncionario())
                {
                    foreach (ModeloRemuneracoes r in listaRemenuracoes)
                    {
                        if (r.getGrupo().Equals("Subsídio de Alimentação"))
                        {
                            subAlimentacao = fr.getValor() * fr.getQtd();
                        }
                        else {
                            outroSub = (fr.getValor() * fr.getQtd()) + outroSub;
                        }
                    }
                }

            }
            f.nrDias.Value = diasDeTrabalho;
            f.txtSubAlimentacao.Text = subAlimentacao + "";
            f.txtOutrasRemuneracoes.Text = outroSub + "";
            f.txtTotalDescontar.Text = valorIrps + emprestimo + ipa + adiantamentos+"";
            f.txtTotalRemuneracoes.Text = subAlimentacao + vencimento + outroSub + "";
            f.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbOperacao.Text = "";
            chbVencimento.Checked = false;
            chbSubFerias.Checked = false;
            chbExtraordinario.Checked = false;
            cbMes.Text = "";
            dtProcessamento.Value = DateTime.Now;
            dtFaltasHorasExtra.Value = DateTime.Now;
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReportProcessamento f = new frmReportProcessamento();
            f.Show();
        }

        private void cbOperacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refrescar();
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                gravar();
                MessageBox.Show("Salário/os processado/os com sucesso!");
            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message, "Erro");
            }

        }

        public frmProcessamentoEmLote()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmProcessamentoEmLote_Load(object sender, EventArgs e)
        {
            //refrescar();
        }

        public void refrescar()
        {
            frmListagemFuncionarios listf = new frmListagemFuncionarios();
            //List<int> listagemFuncionario = listf.getFuncionarios();
            ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            List<int> funcionariosValidos = getFuncionariosValidos();
            ArrayList listaIrps = ControllerIRPS.recuperar();
            DataTable dt = new DataTable();
            double valorIrps = 0;
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Nome do funcionário");
            dt.Columns.Add("Dias de trab.");
            dt.Columns.Add("Mensal");
            dt.Columns.Add("SUB. ALIM.");
            dt.Columns.Add("AJUD. CUST.");
            dt.Columns.Add("AJUD. DESL.");
            dt.Columns.Add("PAG. FÉRIAS");
            dt.Columns.Add("DIVERSOS SUB EFIC.");
            dt.Columns.Add("TOTAL");
            dt.Columns.Add("EMPRÉSTIMO ASSIST. MÉDICA");
            dt.Columns.Add("IRPS");
            dt.Columns.Add("IPA");
            dt.Columns.Add("INSS");
            dt.Columns.Add("Total a descontar");
            dt.Columns.Add("Adiantamento");
            dt.Columns.Add("Importância a pagar");
            foreach (ModeloFuncionario f in listaFuncionario)
            {
                int idFuncionario, diasDeTrabalho;
                String nomeDoTrabalhador;
                double salarioLiquido = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0, irps = 0, ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;

                for (int i = 0; i < funcionariosValidos.Count; i++) 
                {
                    if (f.getCodigo() == funcionariosValidos[i])
                    {
                        DataRow dRow = dt.NewRow();
                        idFuncionario = f.getCodigo();
                        dRow["Registo n°"] = idFuncionario;

                        nomeDoTrabalhador = f.getNome();
                        dRow["Nome do funcionário"] = nomeDoTrabalhador;

                        diasDeTrabalho = getDiasDeTrabalho(funcionariosValidos[i]);
                        dRow["Dias de trab."] = diasDeTrabalho;

                        salarioLiquido = Math.Round((f.getVencimento() / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);                 
                        dRow["Mensal"] = salarioLiquido;

                        subAlimentacao = f.getSubAlimentacao();
                        dRow["SUB. ALIM."] = subAlimentacao;

                        ajudaDeCusto = 0;
                        dRow["AJUD. CUST."] = ajudaDeCusto = 0; ;

                        ajudaDeslocacao = f.getSubTransporte();
                        dRow["AJUD. DESL."] = ajudaDeslocacao;

                        pagamentoFerias = 0;
                        dRow["PAG. FÉRIAS"] = pagamentoFerias = 0;

                        diversosSubsidios = f.getSubComunicacao();
                        dRow["DIVERSOS SUB EFIC."] = diversosSubsidios;

                        totalRetribuicao = salarioLiquido + f.getSubAlimentacao() + f.getSubTransporte() + f.getSubComunicacao();
                        dRow["TOTAL"] = totalRetribuicao;

                        emprestimoMedico = 0;
                        dRow["EMPRÉSTIMO ASSIST. MÉDICA"] = emprestimoMedico;

                        foreach (ModeloIRPS ir in listaIrps)
                        {
                            if (f.getIdIRPS() == ir.getId())
                                valorIrps = ir.getValor();
                        }
                        dRow["IRPS"] = valorIrps;

                        ipa = f.getImpostoMunicipal();
                        dRow["IPA"] = ipa;

                        inss = f.getVencimento() * 0.07;
                        dRow["INSS"] = inss;

                        totalDescontar = valorIrps + f.getImpostoMunicipal() + emprestimoMedico + ipa + inss;
                        dRow["Total a descontar"] = totalDescontar;

                        adiantamentos = 0;
                        dRow["Adiantamento"] = adiantamentos;
                        dRow["Importância a pagar"] = (salarioLiquido + totalRetribuicao) - totalDescontar;
                        dt.Rows.Add(dRow);                       
                    }
                }
            }
            dataProcessamentoSalario.DataSource = dt;
            dataProcessamentoSalario.Refresh();
            dataProcessamentoSalario.AllowUserToAddRows = false;
            dataProcessamentoSalario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataProcessamentoSalario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        //private void gravarProcessamento()
        //{
        //    int id = 0;
        //    int idFunc = Convert.ToInt16(nrRegistonr.Value);
        //    String nome = txtNome.Text;
        //    String operacao = cbTipoProcessamento.Text;
        //    String dataProcessamnto = dtDataProcessamento.Value.ToString("yyyy-MM-dd");
        //    int mesRecebido = dtDataProcessamento.Value.Month;
        //    int anoRecebido = dtDataProcessamento.Value.Year;
        //    int anoProcessado, mesProcessado;
        //    DateTime dtProcessado;
        //    int diasDeTrabalho = Convert.ToInt16(nrDias.Value);
        //    double emprestimoMedico = double.Parse(txtemprestimoMedico.Text);
        //    double irps = double.Parse(txtIrps.Text);
        //    double ipa = double.Parse(txtIpa.Text);
        //    double adiantamentos = double.Parse(txtadiantamentos.Text);
        //    double salarioBruto = double.Parse(txtVencimento.Text);
        //    double subAlimentcao = double.Parse(txtSubAlimentacao.Text);
        //    double diversosSubsidios = double.Parse(txtOutrasRemuneracoes.Text);
        //    double ajudaDeCusto = 0, ajudaDeDeslocacao = 0, pagamentoFerias = 0, inss, totalADescontar, totalRetribuicoes, importanciaAPagar, salarioLiquido;
        //    salarioLiquido = Math.Round((salarioBruto / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
        //    inss = Math.Round((salarioLiquido * 0.07), 2, MidpointRounding.AwayFromZero); ;
        //    totalADescontar = emprestimoMedico + adiantamentos + irps + ipa + inss;
        //    totalRetribuicoes = subAlimentcao + salarioLiquido + diversosSubsidios + ajudaDeCusto + ajudaDeDeslocacao + pagamentoFerias;
        //    importanciaAPagar = totalRetribuicoes - totalADescontar;
        //    Boolean existe = false;
        //    ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
        //    foreach (ModeloProcessamentoDeSalario f in listaProcessamento)
        //    {
        //        dtProcessado = Convert.ToDateTime(f.getDataProcessamento());
        //        anoProcessado = dtProcessado.Year;
        //        mesProcessado = dtProcessado.Month;
        //        if (f.getIdFuncionario() == idFunc && anoProcessado == anoRecebido && mesProcessado == mesRecebido)
        //        {
        //            existe = true;
        //            id = f.getId();
        //        }
        //    }

        //    if (existe)
        //    {
        //        ControllerProcessamentoDeSalario.atualizar(id, idFunc, nome, diasDeTrabalho, salarioLiquido, subAlimentcao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamnto, operacao);
        //    }
        //    else
        //    {
        //        id = getCodProcessamento() + 1;
        //        ControllerProcessamentoDeSalario.Guardar(id, idFunc, nome, diasDeTrabalho, salarioLiquido, subAlimentcao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamnto, operacao);
        //    }
        //}

        private void gravar() 
        {
            int idFuncionario, diasDeTrabalho;
            String nomeDoTrabalhador, operacao, dataProcessamento;
            double salarioLiquido = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0, irps = 0, ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;

            int id = 0, i = 0;
            operacao = cbOperacao.Text;
            dataProcessamento = dtProcessamento.Value.Date.ToString("yyyy-MM-dd");
            double valorIrps = 0;
            List<int> lista = getFuncionariosValidos();
            List<int> codigoFuncionarioDtView = new List<int>(); ;
            int mesRecebido = dtProcessamento.Value.Month;
            int anoRecebido = dtProcessamento.Value.Year;
            int anoProcessado, mesProcessado;
            DateTime dtProcessado;
            Boolean existe = false;
            ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
            ArrayList listaFuncRemuneracoes = ControllerFuncionarioRemuneracoes.recuperar();
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            ArrayList listaIrps = ControllerIRPS.recuperar();

            foreach (DataGridViewRow row in dataProcessamentoSalario.Rows)
            {
                codigoFuncionarioDtView.Add(int.Parse(row.Cells[0].Value.ToString()));
            }

            foreach (ModeloFuncionario f in listaCadastroFuncionarios) 
            {
                idFuncionario = f.getCodigo();
                nomeDoTrabalhador = f.getNome();
                diasDeTrabalho = getDiasDeTrabalho(f.getCodigo());
                ajudaDeCusto = 0;
                ajudaDeslocacao = 0;
                pagamentoFerias = 0;
                emprestimoMedico = 0;
                foreach (ModeloIRPS ir in listaIrps)
                {
                    if (f.getIdIRPS() == ir.getId())
                        valorIrps = ir.getValor();
                }
                ipa = f.getImpostoMunicipal();
                foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracoes)
                {
                    if (idFuncionario == fr.getIdFuncionario())
                    {
                        foreach (ModeloRemuneracoes r in listaRemuneracoes)
                        {
                            if (r.getGrupo().Equals("Subsídio de Alimentação"))
                            {
                                subAlimentacao = fr.getValor() * fr.getQtd();
                            }
                            else
                            {
                                diversosSubsidios = (fr.getValor() * fr.getQtd()) + diversosSubsidios;
                            }
                        }
                    }
                    else {
                        subAlimentacao = 0;
                        diversosSubsidios = 0;
                    }

                }

                foreach (ModeloProcessamentoDeSalario pro in listaProcessamento)
                {
                    dtProcessado = Convert.ToDateTime(pro.getDataProcessamento());
                    anoProcessado = dtProcessado.Year;
                    mesProcessado = dtProcessado.Month;
                    for (int j = 0; j< codigoFuncionarioDtView.Count; j++)
                    {
                        if (pro.getIdFuncionario() == codigoFuncionarioDtView[j] && anoProcessado == anoRecebido && mesProcessado == mesRecebido)
                        {
                            existe = true;
                            id = pro.getId();
                        }
                    }
                }

                salarioLiquido = Math.Round((f.getVencimento() / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
                inss = Math.Round((salarioLiquido * 0.07), 2, MidpointRounding.AwayFromZero); ;
                totalDescontar = emprestimoMedico + adiantamentos + irps + ipa + inss;
                totalRetribuicao = subAlimentacao + salarioLiquido + diversosSubsidios + ajudaDeCusto + ajudaDeslocacao + pagamentoFerias;
                importanciaAPagar = totalRetribuicao - totalDescontar;

                if (codigoFuncionarioDtView[i] == f.getCodigo())
                {
                    if (existe)
                    {
                        ControllerProcessamentoDeSalario.atualizar(id, idFuncionario, nomeDoTrabalhador, diasDeTrabalho, salarioLiquido, subAlimentacao, ajudaDeCusto, ajudaDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, irps, ipa, inss, totalDescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, operacao);
                    }
                    else
                    {
                        id = getCodProcessamento() + 1;
                        ControllerProcessamentoDeSalario.Guardar(id, idFuncionario, nomeDoTrabalhador, diasDeTrabalho, salarioLiquido, subAlimentacao, ajudaDeCusto, ajudaDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, irps, ipa, inss, totalDescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, operacao);
                    }
                }
                i++;
            }
        }

        private int getCodProcessamento() 
        {
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            int cod = 0;
            foreach (ModeloProcessamentoDeSalario f in listaProcessamento) 
            {
                if (f.getId() != 0) 
                {
                    cod = f.getId();
                }
            }
            return cod;
        }
        private int getMes(String mes) 
        {
            int nr = 0;
            if (mes.ToLower().Equals("janeiro")) 
            {
                nr = 1;
            }
            if (mes.ToLower().Equals("fevereiro"))
            {
                nr = 2;
            }
            if (mes.ToLower().Equals("marco"))
            {
                nr = 3;
            }
            if (mes.ToLower().Equals("abril"))
            {
                nr = 4;
            }
            if (mes.ToLower().Equals("maio"))
            {
                nr = 5;
            }
            if (mes.ToLower().Equals("junho"))
            {
                nr = 6;
            }
            if (mes.ToLower().Equals("julho"))
            {
                nr = 7;
            }
            if (mes.ToLower().Equals("agosto"))
            {
                nr = 8;
            }
            if (mes.ToLower().Equals("setembro"))
            {
                nr = 9;
            }
            if (mes.ToLower().Equals("outubro"))
            {
                nr = 10;
            }
            if (mes.ToLower().Equals("novembro"))
            {
                nr = 11;
            }
            if (mes.ToLower().Equals("dezembro"))
            {
                nr = 12;
            }
            return nr;
        }

        ArrayList listaCadastroFuncionarios = new ArrayList();
        private List<int>getFuncionariosValidos() 
        {
            List<int> funcionario = new List<int>();
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperar();
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            decimal ano = nrAno.Value;
            DateTime dataAdimissao, dataRelogio/*, dataProcessamento*/;
            foreach (ModeloFuncionario f in listaFuncionarios) 
            {
                dataAdimissao = Convert.ToDateTime(f.getDataAdmissao());
                foreach (ModeloRelogioDePonto r in listaRelogioDePonto) 
                {
                    dataRelogio = Convert.ToDateTime(r.getData());
                    if (dataAdimissao.Year <= ano && dataRelogio.Year == ano && f.getCodigo() == r.getIdUsuario())
                    {
                        funcionario.Add(f.getCodigo());
                        listaCadastroFuncionarios.Add(new ModeloFuncionario(f.getCodigo(), f.getIdIRPS(), f.getNome(), f.getCell(), f.getCellSec(), f.getTel(), f.getEmail(), f.getEstadoCivil(), f.getDeficiencia(), f.getConjugue(), f.getSexo(), f.getDataNascimento(), f.getLinkImagem(), f.getCodigoPostal(), f.getBairro(), f.getLocalidade(), f.getMoradaGen(), f.getTipoContrato(), f.getDataAdmissao(), f.getDataDemissao(), f.getProfissao(), f.getCategoria(), f.getSeguro(), f.getLocalTrabalho(), f.getRegime(), f.getBi(), f.getNumeroBenificiario(), f.getNumeroFiscal(), f.getVencimento(), f.getSubAlimentacao(), f.getSubTransporte(), f.getHoras(), f.getDependentes(), f.getHabilitacoes(), f.getNacionalidade(), f.getUltimoEmprego(), f.getTurno(), f.getImpostoMunicipal(), f.getCentroDeCusto(), f.getSegurancaSocial(), f.getSindicato(), f.getSubComunicacao()));
                        break;
                    } 
                }
            }
            return funcionario;
        }

        private int getDiasDeTrabalho(int codFunc)
        {
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
            int dias = 0;
            foreach (ModeloRelogioDePonto f in listaRelogioDePonto)
            {
                if (codFunc == f.getIdUsuario()) 
                {
                    dias = dias + 1;
                }
            }
            if (dias % 2 != 0)
            {
                dias = dias - 1;
            }
            return dias/2;
        }
        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String mes = cbMes.Text;
            nrMes = getMes(mes);
            refrescar();
        }

        private void nrAno_ValueChanged(object sender, EventArgs e)
        {
            //refrescar();
        }
    }
}
