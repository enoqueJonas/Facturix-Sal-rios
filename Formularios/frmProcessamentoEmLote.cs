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
        private int nrMes, idFuncionario, diasDeTrabalho, codigoCelSelecionada;
        private String nomeDoTrabalhador, operacao, dataProcessamento;
        private double salarioBrutoMensal = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0, irps = 0, ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;

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
            ArrayList listaContas = ControllerConta.recuperarComCod(codigoCelSelecionada);
            ArrayList listaDependentes = ControllerDependente.recuperarComCodFuncionario(codigoCelSelecionada);
            frmCadastrarFuncionarios f = new frmCadastrarFuncionarios();
            foreach (ModeloFuncionario func in listaFuncionarios) 
            {
                f.txtCodigo.Text = func.getCodigo() + "";
                f.txtNome.Text = func.getNome();
                f.txtConjugue.Text = func.getConjugue();
                f.txtEmail.Text = func.getEmail();
                f.txtCell.Text = func.getCell();
                f.txtCellSec.Text = func.getCellSec();
                f.txtTel.Text = func.getTel();
                f.cbSexo.Text = func.getSexo();
                f.cbEstadoCivil.Text = func.getEstadoCivil();
                f.cbDeficiencia.Text = func.getDeficiencia();
                f.dtNascimento.Value = Convert.ToDateTime(func.getDataNascimento());
                if (System.IO.File.Exists(func.getLinkImagem()))
                {
                    f.pbFoto.Image = Image.FromFile(func.getLinkImagem());
                }
                f.txtCodPostal.Text = func.getCodigoPostal() + "";
                f.txtMorada.Text = func.getMoradaGen();
                f.txtBairro.Text = func.getBairro();
                f.txtLocalidade.Text = func.getLocalidade();
                f.cbContrato.Text = func.getTipoContrato();
                f.dtDataAdmissao.Value = Convert.ToDateTime(func.getDataAdmissao());
                f.dtDataDemissao.Value = Convert.ToDateTime(func.getDataDemissao());
                f.cbProfissao.Text = func.getProfissao();
                f.cbCategoria.Text = func.getCategoria();
                f.cbSeguro.Text = func.getSeguro();
                f.cbLocalTrabalho.Text = func.getLocalTrabalho();
                f.cbRegime.Text = func.getRegime();
                f.txtBi.Text = func.getBi();
                f.txtNrBenificiario.Text = func.getNumeroBenificiario();
                f.txtNrFiscal.Text = func.getNumeroFiscal() + "";
                f.txtVencimento.Text = func.getVencimento() + "";
                f.txtAlimentacao.Text = func.getSubAlimentacao() + "";
                f.txtSubTransporte.Text = func.getSubTransporte() + "";
                f.txtHoraSemana.Text = func.getHoras() + "";
                f.txtNrDependentes.Text = func.getDependentes() + "";
                f.cbHabilitacoes.Text = func.getHabilitacoes();
                f.txtNacionalidade.Text = func.getNacionalidade();
                f.txtUltimo.Text = func.getUltimoEmprego();
                f.cbTurno.Text = func.getTurno();
                f.txtImpostoM.Text = func.getImpostoMunicipal() + "";
                f.cbCentrocusto.Text = func.getCentroDeCusto();
                f.txtSeguranca.Text = func.getSegurancaSocial();
            }
            foreach (ModeloConta conta in listaContas)
            {
                if (codigoCelSelecionada == conta.idFuncionario)
                {
                    f.txtNrConta.Text = conta.conta;
                    f.txtNib.Text = conta.nib;
                    f.txtBanco.Text = conta.banco;
                }
            }
            f.Show();
            f.TopMost = true;
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
            refrescar();
        }

        ArrayList listaCadastroFuncionarios = new ArrayList();

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            refrescar();
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
            refrescar();
        }

        public void refrescar()
        {
            frmListagemFuncionarios listf = new frmListagemFuncionarios();
            List<int> listagemFuncionario = listf.getFuncionarios();
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
                for (int i = 0; i < listagemFuncionario.Count; i++) 
                {
                    if (f.getCodigo() == funcionariosValidos[i] && f.getCodigo() == listagemFuncionario[i])
                    {
                        DataRow dRow = dt.NewRow();
                        idFuncionario = f.getCodigo();
                        dRow["Registo n°"] = idFuncionario;

                        nomeDoTrabalhador = f.getNome();
                        dRow["Nome do funcionário"] = nomeDoTrabalhador;

                        diasDeTrabalho = getDiasDeTrabalho(funcionariosValidos[i]);
                        dRow["Dias de trab."] = diasDeTrabalho;

                        salarioBrutoMensal = Math.Round((f.getVencimento() / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);                 
                        dRow["Mensal"] = salarioBrutoMensal;

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

                        totalRetribuicao = salarioBrutoMensal + f.getSubAlimentacao() + f.getSubTransporte() + f.getSubComunicacao();
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
                        dRow["Importância a pagar"] = (salarioBrutoMensal + totalRetribuicao) - totalDescontar;
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

        private void gravar() 
        {
            int id = getCodProcessamento() + 1;
            operacao = cbOperacao.Text;
            dataProcessamento = dtProcessamento.Value.Date.ToString("yyyy-MM-dd");
            double valorIrps = 0;
            String tipo = "";
            if (chbVencimento.Checked) 
            {
                tipo = "Vencimento";
            }
            if (chbSubFerias.Checked)
            {
                tipo = "Ferias";
            }
            if (chbVencimento.Checked)
            {
                tipo = "Extraordinario";
            }
            ArrayList listaIrps = ControllerIRPS.recuperar();
            foreach (ModeloFuncionario f in listaCadastroFuncionarios) 
            {
                idFuncionario = f.getCodigo();
                nomeDoTrabalhador = f.getNome();
                diasDeTrabalho = getDiasDeTrabalho(f.getCodigo());
                salarioBrutoMensal = Math.Round((f.getVencimento() / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
                subAlimentacao = f.getSubAlimentacao();
                ajudaDeCusto = 0;
                ajudaDeslocacao = f.getSubTransporte();
                pagamentoFerias = 0;
                diversosSubsidios = f.getSubComunicacao();
                totalRetribuicao = salarioBrutoMensal + f.getSubAlimentacao() + f.getSubTransporte() + f.getSubComunicacao();
                emprestimoMedico = 0;
                foreach (ModeloIRPS ir in listaIrps)
                {
                    if (f.getIdIRPS() == ir.getId())
                        valorIrps = ir.getValor();
                }
                ipa = f.getImpostoMunicipal();
                inss = Math.Round(f.getVencimento() * 0.07, 2, MidpointRounding.AwayFromZero);
                totalDescontar = valorIrps + f.getImpostoMunicipal() + emprestimoMedico + ipa + inss;
                adiantamentos = 0;
                importanciaAPagar = Math.Round((salarioBrutoMensal + totalRetribuicao) - totalDescontar, 2, MidpointRounding.AwayFromZero);
                if (cbOperacao.Text.Equals("Processar"))
                {
                    id = id + 1;
                    ControllerProcessamentoDeSalario.Guardar(id, idFuncionario, nomeDoTrabalhador, diasDeTrabalho, salarioBrutoMensal, subAlimentacao, ajudaDeCusto, ajudaDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, irps, ipa, inss, totalDescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, tipo);
                } else if (cbOperacao.Text.Equals("Anular")) 
                {
                    ControllerProcessamentoDeSalario.Guardar(id, idFuncionario, nomeDoTrabalhador, diasDeTrabalho, salarioBrutoMensal, subAlimentacao, ajudaDeCusto, ajudaDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, irps, ipa, inss, totalDescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, tipo);
                }
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

        private List<int>getFuncionariosValidos() 
        {
            List<int> funcionario = new List<int>();
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperar();
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            decimal ano = nrAno.Value;
            DateTime dataAdimissao, dataRelogio, dataProcessamento;
            Boolean processaodo = false;
            foreach (ModeloFuncionario f in listaFuncionarios) 
            {
                dataAdimissao = Convert.ToDateTime(f.getDataAdmissao());
                foreach (ModeloRelogioDePonto r in listaRelogioDePonto) 
                {
                    dataRelogio = Convert.ToDateTime(r.getData());
                    foreach (ModeloProcessamentoDeSalario p in listaProcessamento) 
                    {
                        dataProcessamento = Convert.ToDateTime(p.getDataProcessamento());
                        if (p.getOperacao().Equals("Processar") /* && cbOperacao.Text.Equals("Processar") || cbOperacao.Text == ""*/)
                        {
                            processaodo = true;
                        }
                        /* else if (p.getOperacao().Equals("Processar") && cbOperacao.Text.Equals("Anular")) 
                        {
                            processaodo = false;
                        }*/
                    }
                    if (dataAdimissao.Year <= ano && dataAdimissao.Month <= nrMes && dataRelogio.Month == nrMes && dataRelogio.Year == ano && processaodo == false && cbOperacao.Text == "Processar")
                    {
                        funcionario.Add(f.getCodigo());
                        listaCadastroFuncionarios.Add(new ModeloFuncionario(f.getCodigo(), f.getIdIRPS(), f.getNome(), f.getCell(), f.getCellSec(), f.getTel(), f.getEmail(), f.getEstadoCivil(), f.getDeficiencia(), f.getConjugue(), f.getSexo(), f.getDataNascimento(), f.getLinkImagem(), f.getCodigoPostal(), f.getBairro(), f.getLocalidade(), f.getMoradaGen(), f.getTipoContrato(), f.getDataAdmissao(), f.getDataDemissao(), f.getProfissao(), f.getCategoria(), f.getSeguro(), f.getLocalTrabalho(), f.getRegime(), f.getBi(), f.getNumeroBenificiario(), f.getNumeroFiscal(), f.getVencimento(), f.getSubAlimentacao(), f.getSubTransporte(), f.getHoras(), f.getDependentes(), f.getHabilitacoes(), f.getNacionalidade(), f.getUltimoEmprego(), f.getTurno(), f.getImpostoMunicipal(), f.getCentroDeCusto(), f.getSegurancaSocial(), f.getSindicato(), f.getSubComunicacao()));
                        break;
                    } else if (dataAdimissao.Year <= ano && dataAdimissao.Month <= nrMes && dataRelogio.Month == nrMes && dataRelogio.Year == ano && processaodo == true && cbOperacao.Text == "Anular") 
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
            refrescar();
        }
    }
}
