﻿using System;
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
        private int diasDeTrabalho, codigoCelSelecionada;

        private void frmListagemFuncionarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            //switch (e.CloseReason)
            //{
            //    case CloseReason.UserClosing:
            //        if (MessageBox.Show("Pretende Voltar ao menu principal?", "Atenção!",
            //                            MessageBoxButtons.YesNo,
            //                            MessageBoxIcon.Question) == DialogResult.No)
            //        {
            //            e.Cancel = true;
            //        }
            //        break;
            //}
        }

        public frmListagemFuncionarios()
        {
            InitializeComponent();
        }

        private void frmListagemFuncionarios_Load(object sender, EventArgs e)
        {
            refrescar();
            ControllerDiasDeTrabalho.remover();
            lblEstado.Visible = estaVazio();
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
            using (frmLoadingScreen l = new frmLoadingScreen(carregarFuncionariosLote))
            {
                l.ShowDialog(this);
            }
        }

        private int getDiasDeTrabalho(int codFunc)
        {
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
            int ano = DateTime.Now.Year, idFunc = 0;
            int nrMes = DateTime.Now.Month;
            DateTime dataProcess;
            int dias = 0;
            foreach (ModeloRelogioDePonto f in listaRelogioDePonto)
            {
                dataProcess = Convert.ToDateTime(f.getData());
                if (codFunc == f.getIdUsuario() && f.getEstado().Equals("Check in") && dataProcess.Year == ano && dataProcess.Month == nrMes)
                {
                    idFunc = f.getIdUsuario();
                    dias = dias + 1;
                }
            }
            if (dias % 2 != 0)
            {
                dias = dias - 1;
            }
            if (idFunc!=0) 
            {
                ControllerDiasDeTrabalho.gravar(idFunc, dias/2);
            }
            return dias / 2;
        }

        public void carregarFuncionariosLote()
        {
            int idFuncionario;
            String nomeDoTrabalhador;
            double salarioBrutoMensal = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0, ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;
            ajudaDeslocacao = 0;
            frmProcessamentoEmLote frm = new frmProcessamentoEmLote();
            //List<int> listagemFuncionario = listf.getFuncionarios();
            ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            ArrayList listaAdiantamentos = ControllerAdiantamento.recuperar();
            ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
            List<int> funcionariosValidos = getFuncionarios();
            ArrayList listaIrps = ControllerIRPS.recuperar();
            ArrayList listaFuncRemuneracoes = ControllerFuncionarioRemuneracoes.recuperar();
            ArrayList listaSeguros = ControllerSeguro.recuperar();
            DataTable dt = new DataTable();
            double valorIrps = 0;
            emprestimoMedico = 0;
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
            dt.Columns.Add("ASSIST. MÉDICA");
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
                        diasDeTrabalho = getDiasDeTrabalho(funcionariosValidos[i]);
                        if (diasDeTrabalho!=0) 
                        {
                            DataRow dRow = dt.NewRow();
                            idFuncionario = f.getCodigo();
                            dRow["Registo n°"] = idFuncionario;

                            foreach (ModeloIRPS ir in listaIrps)
                            {
                                if (f.getIdIRPS() == ir.getId())
                                    valorIrps = ir.getValor();
                            }

                            foreach (ModeloSeguro seg in listaSeguros) 
                            {
                                if (seg.getSeguro().Equals(f.getSeguro())) 
                                {
                                    emprestimoMedico = f.getVencimento() * (seg.getPercentagem() / 100);
                                }
                            }

                            foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracoes)
                            {
                                foreach (ModeloRemuneracoes r in listaRemuneracoes)
                                {
                                    if (idFuncionario == fr.getIdFuncionario() && fr.getIdRemuneracao() == r.getId())
                                    {
                                        if (r.getNatureza().Equals("A- Ajudas De Custo e Transportes"))
                                        {
                                            ajudaDeslocacao = fr.getValor() * fr.getQtd();
                                        }
                                        else
                                        {
                                            diversosSubsidios = (fr.getValor() * fr.getQtd()) + diversosSubsidios;
                                        }
                                    }
                                }
                            }

                            nomeDoTrabalhador = f.getNome();
                            dRow["Nome do funcionário"] = nomeDoTrabalhador;

                            dRow["Dias de trab."] = diasDeTrabalho;

                            salarioBrutoMensal = Math.Round((f.getVencimento() / 30) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
                            dRow["Mensal"] = string.Format("{0:#,##0.00}", salarioBrutoMensal);

                            subAlimentacao = f.getSubAlimentacao();
                            dRow["SUB. ALIM."] = string.Format("{0:#,##0.00}", subAlimentacao);

                            ajudaDeCusto = 0;
                            dRow["AJUD. CUST."] = string.Format("{0:#,##0.00}", ajudaDeCusto);

                            dRow["AJUD. DESL."] = string.Format("{0:#,##0.00}", ajudaDeslocacao);

                            pagamentoFerias = 0;
                            dRow["PAG. FÉRIAS"] = string.Format("{0:#,##0.00}", pagamentoFerias);

                            dRow["DIVERSOS SUB EFIC."] = string.Format("{0:#,##0.00}", diversosSubsidios);

                            totalRetribuicao = salarioBrutoMensal + subAlimentacao + diversosSubsidios + ajudaDeCusto + pagamentoFerias + ajudaDeslocacao;
                            dRow["TOTAL"] = string.Format("{0:#,##0.00}", totalRetribuicao);

                            dRow["ASSIST. MÉDICA"] = string.Format("{0:#,##0.00}", emprestimoMedico);

                            dRow["IRPS"] = string.Format("{0:#,##0.00}", valorIrps);

                            ipa = f.getImpostoMunicipal();
                            dRow["IPA"] = string.Format("{0:#,##0.00}", ipa);

                            inss = salarioBrutoMensal * 0.03;
                            dRow["INSS"] = string.Format("{0:#,##0.00}", inss);

                            dRow["Total a descontar"] = string.Format("{0:#,##0.00}", totalDescontar);

                            foreach (ModeloAdiantamento a in listaAdiantamentos) 
                            {
                                if (a.getIdFuncionario() == f.getCodigo()) 
                                {
                                    adiantamentos = a.getDiantamento();
                                }
                            }
                            dRow["Adiantamento"] = string.Format("{0:#,##0.00}", adiantamentos);
                            totalDescontar = valorIrps + emprestimoMedico + ipa + inss + adiantamentos;

                            importanciaAPagar = totalRetribuicao - totalDescontar;
                            dRow["Importância a pagar"] = string.Format("{0:#,##0.00}", importanciaAPagar);
                            dt.Rows.Add(dRow);
                        }
                    }
                }
            }
            frm.dataProcessamentoSalario.DataSource = dt;
            frm.dataProcessamentoSalario.Refresh();
            frm.dataProcessamentoSalario.AllowUserToAddRows = false;
            frm.dataProcessamentoSalario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            frm.dataProcessamentoSalario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            if (frm.estaVazio() == true) 
            {
                frm.lblEstado.Visible = true;
            }
            frm.ShowDialog();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    this.Close();
                }));
                return;
            }
        }

        public Boolean estaVazio() 
        {
            if (dataFuncionarios.Rows.Count == 0)
                return true;

            return false;
        }

        public List<int> getFuncionarios() 
        {
            List<int> listaFuncionarios = new List<int>();
            List<int> listaValida = new List<int>();
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperar();
            //ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            foreach (DataGridViewRow row in dataFuncionarios.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value != null)
                {
                    listaFuncionarios.Add(int.Parse(row.Cells[1].Value.ToString()));
                    codigoCelSelecionada = int.Parse(row.Cells[1].Value.ToString());
                }
            }
            foreach (ModeloRelogioDePonto r in listaRelogioDePonto)
            {
                for (int i = 0; i < listaFuncionarios.Count; i++)
                {
                    if (listaFuncionarios[i] == r.getIdUsuario())
                    {
                        listaValida.Add(r.getIdUsuario());
                    }
                }
            }
            HashSet<int> unique = new HashSet<int>(listaValida);
            List<int> listaSemRep = unique.ToList();
            listaSemRep.Sort();
            return listaSemRep;
        }
    }
}
