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
using Facturix_Salários.Modelos;
using Facturix_Salários.Controllers;

namespace Facturix_Salários.Formularios
{
    public partial class frmListagemFuncionarios : Form
    {
        private int nrMes, idFuncionario, diasDeTrabalho, codigoCelSelecionada;
        private String nomeDoTrabalhador, operacao, dataProcessamento;
        private double salarioBrutoMensal = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0, irps = 0, ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;
        public frmListagemFuncionarios()
        {
            InitializeComponent();
        }

        private void frmListagemFuncionarios_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        private void refrescar()
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            montarDataGridView(listaFuncionarios);
        }

        private void montarDataGridView(ArrayList listaRecebida)
        {
            DataTable dt = new DataTable();
            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Telefone");
            foreach (ModeloFuncionario func in listaRecebida)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = func.getCodigo();
                dRow["Nome"] = func.getNome();
                dRow["Telefone"] = func.getTel();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "Chk";
                dgvCmb.HeaderText = "Selecionar";
                dgvCmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvCmb.Width = 60;
                dt.Rows.Add(dRow);
            }
            dataFuncionarios.Columns.Add(dgvCmb);
            dataFuncionarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataFuncionarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataFuncionarios.AllowUserToAddRows = false;
            dataFuncionarios.DataSource = dt;
            dataFuncionarios.Refresh();
        }

        private void btnSelecionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataFuncionarios.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            getFuncionarios();
            if (getFuncionarios().Count > 1 && getFuncionarios().Count != 0)
            {
                carregarFuncionariosLote();
            } else if (getFuncionarios().Count == 1 && getFuncionarios().Count != 0) 
            {
                carregarFuncionarioIndividual();
            }
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
            return dias / 2;
        }
        public void carregarFuncionariosLote()
        {
            frmProcessamentoEmLote frm = new frmProcessamentoEmLote();
            //List<int> listagemFuncionario = listf.getFuncionarios();
            ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            List<int> funcionariosValidos = getFuncionarios();
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
            frm.dataProcessamentoSalario.DataSource = dt;
            frm.dataProcessamentoSalario.Refresh();
            frm.dataProcessamentoSalario.AllowUserToAddRows = false;
            frm.dataProcessamentoSalario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            frm.dataProcessamentoSalario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            frm.Show();
            this.Close();
        }

        private void carregarFuncionarioIndividual() {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(codigoCelSelecionada);
            ArrayList listaIrps = ControllerIRPS.recuperar();
            ArrayList listaDependentes = ControllerDependente.recuperarComCodFuncionario(codigoCelSelecionada);
            frmProcessamentoIndividual f = new frmProcessamentoIndividual();
            int codIrps = 0;
            double valorIrps = 0, emprestimo = 0, ipa = 0, adiantamentos = 0, vencimento = 0, outroSub = 0, subAlimentacao = 0;
            diasDeTrabalho = getDiasDeTrabalho(codigoCelSelecionada);
            foreach (ModeloFuncionario func in listaFuncionarios)
            {
                f.nrRegistonr.Value = func.getCodigo();
                f.txtNome.Text = func.getNome();
                emprestimo = 0;
                f.txtemprestimoMedico.Text = emprestimo + "";
                ipa = func.getImpostoMunicipal();
                f.txtIpa.Text = ipa + "";
                adiantamentos = 0;
                f.txtadiantamentos.Text = adiantamentos + "";
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
                        else
                        {
                            outroSub = (fr.getValor() * fr.getQtd()) + outroSub;
                        }
                    }
                }

            }
            f.nrDias.Value = diasDeTrabalho;
            f.txtSubAlimentacao.Text = subAlimentacao + "";
            f.txtOutrasRemuneracoes.Text = outroSub + "";
            f.txtTotalDescontar.Text = valorIrps + emprestimo + ipa + adiantamentos + "";
            f.txtTotalRemuneracoes.Text = subAlimentacao + vencimento + outroSub + "";
            f.Show();
            this.Hide();
        }
        public List<int> getFuncionarios() 
        {
            List<int> listaFuncionarios = new List<int>();
            foreach (DataGridViewRow row in dataFuncionarios.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value != null)
                {
                    listaFuncionarios.Add(int.Parse(row.Cells[1].Value.ToString()));
                    codigoCelSelecionada = int.Parse(row.Cells[1].Value.ToString());
                }
            }
            return listaFuncionarios;
        }
    }
}
