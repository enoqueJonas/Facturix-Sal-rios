using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class frmProcessamentoIndividual : Form
    {
        public frmProcessamentoIndividual()
        {
            InitializeComponent();
        }
        int codigoCelSelecionadaVencimento;
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReportProcessamento f = new frmReportProcessamento();
            f.Show();
        }

        private void frmProcessamentoIndividual_Load(object sender, EventArgs e)
        {
            this.ActiveControl = nrDias;
            dataProcessamentoSalario.AllowUserToAddRows = false;
            refrescarVencimento();
            txtOutrasRemuneracoes.LostFocus += new EventHandler(txtOutrasRemuneracoes_LostFocus);
            txtVencimento.LostFocus += new EventHandler(txtVencimento_LostFocus);
            txtSubAlimentacao.LostFocus += new EventHandler(txtSubAlimentacao_LostFocus);
            txtemprestimoMedico.LostFocus += new EventHandler(txtemprestimoMedico_LostFocus);
            txtIrps.LostFocus += new EventHandler(txtIrps_LostFocus);
            txtIpa.LostFocus += new EventHandler(txtIpa_LostFocus);
            txtadiantamentos.LostFocus += new EventHandler(txtadiantamentos_LostFocus);
        }

        private void txtVencimento_LostFocus(object sender, EventArgs e)
        {
            if (txtVencimento.Text!= "") 
            {
                txtVencimento.Text = string.Format("{0:#,##0.00}", double.Parse(txtVencimento.Text));
            }
        }

        private void txtSubAlimentacao_LostFocus(object sender, EventArgs e)
        {
            if (txtSubAlimentacao.Text != "")
            {
                txtSubAlimentacao.Text = string.Format("{0:#,##0.00}", double.Parse(txtSubAlimentacao.Text));
            }
        }

        private void txtemprestimoMedico_LostFocus(object sender, EventArgs e)
        {
            if (txtemprestimoMedico.Text != "")
            {
                txtemprestimoMedico.Text = string.Format("{0:#,##0.00}", double.Parse(txtemprestimoMedico.Text));
            }
        }

        private void txtIrps_LostFocus(object sender, EventArgs e)
        {
            if (txtIrps.Text != "")
            {
                txtIrps.Text = string.Format("{0:#,##0.00}", double.Parse(txtIrps.Text));
            }
        }

        private void txtIpa_LostFocus(object sender, EventArgs e)
        {
            if (txtIpa.Text != "")
            {
                txtIpa.Text = string.Format("{0:#,##0.00}", double.Parse(txtIpa.Text));
            }
        }

        private void txtadiantamentos_LostFocus(object sender, EventArgs e)
        {
            if (txtadiantamentos.Text != "")
            {
                txtadiantamentos.Text = string.Format("{0:#,##0.00}", double.Parse(txtadiantamentos.Text));
            }
        }

        private void txtOutrasRemuneracoes_LostFocus(object sender, EventArgs e)
        {
            if (txtOutrasRemuneracoes.Text != "")
            {
                txtOutrasRemuneracoes.Text = string.Format("{0:#,##0.00}", double.Parse(txtOutrasRemuneracoes.Text));
            }
        }

        private void limpar() 
        {
            nrDias.Value = 0;
            nrRegistonr.Value = 0;
            txtNome.Text = "";
            txtOutrasRemuneracoes.Text = "";
            txtSubAlimentacao.Text = "";
            txtTotalDescontar.Text = "";
            txtTotalRemuneracoes.Text = "";
            txtVencimento.Text = "";
            txtemprestimoMedico.Text = "";
            txtIrps.Text = "";
            txtIpa.Text = "";
            txtadiantamentos.Text = "";
            cbMes.Text = "";
            nrAno.Value = 2022;
        }

        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
            lbl2.Visible = estado;
            lbl3.Visible = estado;
            lbl4.Visible = estado;
            lbl5.Visible = estado;
            lbl6.Visible = estado;
            lbl7.Visible = estado;
            nrRegistonr.ReadOnly = estado;
        }

        Control ctrl;
        private void mexerTeclado(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (ctrl is TextBox)
            {
                if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down || e.Alt && e.KeyCode == Keys.Right)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.Alt && e.KeyCode == Keys.Up || e.Alt && e.KeyCode == Keys.Left)
                {
                    this.SelectNextControl(ctrl, false, true, true, true);
                }
                else
                    return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.KeyCode == Keys.Up && e.Control)
                {
                    this.SelectNextControl(ctrl, false, true, true, true);
                }
                else
                    return;
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        int idProcessamento = 0;
        private Boolean existeProcessamento(int idFunc)
        {
            Boolean existe = false;
            ArrayList lista = ControllerProcessamentoDeSalario.recuperar();
            //ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            int ano = Convert.ToInt32(nrAno.Value);
            String mes = cbMes.Text;
            int nrMes = getMes(mes), anoProcess, mesProcess;
            DateTime dataProcess;
            foreach (ModeloProcessamentoDeSalario p in lista)
            {
                dataProcess = Convert.ToDateTime(p.getDataProcessamento());
                anoProcess = dataProcess.Year;
                mesProcess = dataProcess.Month;
                if (idFunc == p.getIdFuncionario() && anoProcess == ano && mesProcess == nrMes)
                {
                    existe = true;
                    idProcessamento = p.getId();
                }
            }
            return existe;
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


        private void refrescarVencimento()
        {
            int idFunc = Convert.ToInt16(nrRegistonr.Value);
            ArrayList listaRemenuracoes = ControllerRemuneracoes.recuperar();
            ArrayList listaFuncRemuneracao = ControllerFuncionarioRemuneracoes.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Natureza");
            dt.Columns.Add("Valor Unit.");
            dt.Columns.Add("Quantidade");
            dt.Columns.Add("Total");
            foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracao)
            {
                DataRow dRow = dt.NewRow();
                if (idFunc == fr.getIdFuncionario())
                {
                    dRow["Registo n°"] = fr.getId();
                    foreach (ModeloRemuneracoes r in listaRemenuracoes)
                    {
                        if (fr.getIdRemuneracao() == r.getId())
                        {
                            dRow["Natureza"] = r.getNatureza();
                        }
                    }
                    dRow["Valor Unit."] = string.Format("{0:#,##0.00}", fr.getValor());
                    dRow["Quantidade"] = fr.getQtd();
                    dRow["Total"] = string.Format("{0:#,##0.00}", fr.getValor() * fr.getQtd());
                }
                    dt.Rows.Add(dRow);
            }
            DataView dtView = new DataView(dt);
            DataTable dtTable = dtView.ToTable(true, "Registo n°", "Natureza", "Valor Unit.", "Quantidade", "Total");
            dataProcessamentoSalario.DataSource = dtTable;
            dataProcessamentoSalario.Refresh();
            dataProcessamentoSalario.AllowUserToAddRows = false;
            dataProcessamentoSalario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataProcessamentoSalario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private void nrRegistonr_ValueChanged(object sender, EventArgs e)
        {
            refrescarVencimento();
            int id = Convert.ToUInt16(nrRegistonr.Value);
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(id);
            ArrayList listaIrps = ControllerIRPS.recuperar();
            ArrayList listaDependentes = ControllerDependente.recuperarComCodFuncionario(id);
            int codIrps = 0;
            double valorIrps = 0, emprestimo = 0, ipa = 0, adiantamentos = 0, vencimento = 0, outroSub = 0, subAlimentacao = 0;
            Boolean existe = false;
            foreach (ModeloFuncionario func in listaFuncionarios)
            {
                txtNome.Text = func.getNome();
                emprestimo = 0;
                txtemprestimoMedico.Text = emprestimo + "";
                ipa = func.getImpostoMunicipal();
                txtIpa.Text = ipa + "";
                adiantamentos = 0;
                txtadiantamentos.Text = adiantamentos + "";
                codIrps = func.getIdIRPS();
                vencimento = func.getVencimento();
                txtVencimento.Text = vencimento + " ";
                subAlimentacao = func.getSubAlimentacao();
                if (id == func.getCodigo()) 
                {
                    existe = true;
                }
            }
            if (existe == false)
            {
                nrDias.Value = 0;
                txtNome.Text = "";
                txtOutrasRemuneracoes.Text = "";
                txtSubAlimentacao.Text = "";
                txtTotalDescontar.Text = "";
                txtTotalRemuneracoes.Text = "";
                txtVencimento.Text = "";
                txtemprestimoMedico.Text = "";
                txtIrps.Text = "";
                txtIpa.Text = "";
                txtadiantamentos.Text = "";
                cbMes.Text = "";
            }
            else 
            {
                foreach (ModeloIRPS conta in listaIrps)
                {
                    if (codIrps == conta.getId())
                    {
                        valorIrps = conta.getValor();
                        txtIrps.Text = valorIrps + "";
                    }
                }
                ArrayList listaRemenuracoes = ControllerRemuneracoes.recuperar();
                ArrayList listaFuncRemuneracao = ControllerFuncionarioRemuneracoes.recuperar();
                foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracao)
                {
                    if (id == fr.getIdFuncionario())
                    {
                            outroSub = (fr.getValor() * fr.getQtd()) + outroSub;
                    }
                }
                txtSubAlimentacao.Text = subAlimentacao + "";
                txtOutrasRemuneracoes.Text = outroSub + "";
                txtTotalDescontar.Text = valorIrps + emprestimo + ipa + adiantamentos + "";
                txtTotalRemuneracoes.Text = subAlimentacao + vencimento + outroSub + "";
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                gravar();
                mudarVisibilidadeLabels(false);
                MessageBox.Show("Os dados para o procesaamento foram atualizados com sucesso!");
            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message, "Erro");
            }
        }

        public int diasDeTrabalho, codEnviado, idFunc;
        public double ajudaDeCusto = 0, ajudaDeDeslocacao = 0, pagamentoFerias = 0, inss = 0, totalADescontar = 0, totalRetribuicoes = 0, importanciaAPagar= 0, salarioBruto = 0, subAlimentacao = 0, ipa;
        private void gravar() 
        {
            idFunc = Convert.ToInt16(nrRegistonr.Value);
            Boolean existe = existeProcessamento(idFunc);
            String nome = txtNome.Text, dataProcessamento = "";
            diasDeTrabalho = Convert.ToInt16(nrDias.Value);
            double emprestimoMedico = double.Parse(txtemprestimoMedico.Text);
            double irps = double.Parse(txtIrps.Text);
            ipa = double.Parse(txtIpa.Text);
            double adiantamentos = double.Parse(txtadiantamentos.Text);
            salarioBruto =  double.Parse(txtVencimento.Text);
            subAlimentacao = double.Parse(txtSubAlimentacao.Text);           
            double diversosSubsidios = double.Parse(txtOutrasRemuneracoes.Text);
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            ControllerDiasDeTrabalho.gravar(idFunc, diasDeTrabalho);
            if (existe == false)
            {
                ControllerDiasDeTrabalho.atualizar(idFunc, diasDeTrabalho);
                ControllerFuncionario.atualizarVenc(idFunc, salarioBruto, subAlimentacao, ipa);
            }
            else 
            {
                foreach (ModeloProcessamentoDeSalario p in listaProcessamento)
                {
                    ajudaDeCusto = p.getAjudaDeCusto();
                    ajudaDeDeslocacao = p.getPagamentoFerias();
                    pagamentoFerias = p.getPagamentoFerias();
                    inss = p.getInss();
                    dataProcessamento = p.getDataProcessamento();
                    //totalADescontar = ;

                    //totalRetribuicoes = ;

                }
                ControllerProcessamentoDeSalario.atualizar(idProcessamento, idFunc, nome, diasDeTrabalho, salarioBruto, subAlimentacao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, "", dataProcessamento, "");
            }
            //double ajudaDeCusto = 0, ajudaDeDeslocacao = 0, pagamentoFerias = 0, inss, totalADescontar, totalRetribuicoes, importanciaAPagar, salarioLiquido;

            //salarioLiquido = Math.Round((salarioBruto / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
            //inss = Math.Round((salarioLiquido * 0.07), 2, MidpointRounding.AwayFromZero); ;
            //totalADescontar = emprestimoMedico + adiantamentos + irps + ipa + inss;
            //totalRetribuicoes = subAlimentcao + salarioLiquido + diversosSubsidios + ajudaDeCusto + ajudaDeDeslocacao + pagamentoFerias;
            //importanciaAPagar = totalRetribuicoes - totalADescontar;

            //Boolean existe = false;
            //ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            //foreach (ModeloProcessamentoDeSalario f in listaProcessamento)
            //{
            //    dtProcessado = Convert.ToDateTime(f.getDataProcessamento());
            //    anoProcessado = dtProcessado.Year;
            //    mesProcessado = dtProcessado.Month;
            //    if (f.getIdFuncionario() == idFunc && anoProcessado == anoRecebido && mesProcessado == mesRecebido)
            //    {
            //        existe = true;
            //        id = f.getId();
            //    }
            //}

            //if (existe)
            //{
            //    ControllerProcessamentoDeSalario.atualizar(id, idFunc, nome, diasDeTrabalho, salarioLiquido, subAlimentcao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamnto, operacao);
            //}
            //else {
            //    id = getCodProcessamento() + 1;
            //    ControllerProcessamentoDeSalario.Guardar(id, idFunc, nome, diasDeTrabalho, salarioLiquido, subAlimentcao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamnto, operacao);
            //}
        }

        private int getCodRemuneracao()
        {
            ArrayList listaFuncRemuneracao = ControllerFuncionarioRemuneracoes.recuperar();
            int cod = 0;
            foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracao)
            {
                if (fr.getId() != 0)
                {
                    cod = fr.getId();
                }
            }
            return cod;
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionarRemuneracao_Click(object sender, EventArgs e)
        {
            frmAdicionarRemuneracao f = new frmAdicionarRemuneracao();
            f.txtIdFuncionario.Text = nrRegistonr.Value + "";
            f.ShowDialog();
            //int cod = f.cod, qtd = f.qtd, idFunc = Convert.ToInt16(nrRegistonr.Value);
            //double valor = f.valorUnit;
            //ControllerFuncionarioRemuneracoes.gravar(getCodRemuneracao() + 1, idFunc, cod, valor, qtd);
            //refrescarVencimento();
        }

        private void btnEditarRemuneracoes_Click(object sender, EventArgs e)
        {
            frmAdicionarRemuneracao f = new frmAdicionarRemuneracao();
            ArrayList listaFuncRemuneracoes = ControllerFuncionarioRemuneracoes.recuperarComCod(codigoCelSelecionadaVencimento);
            int id = 0;
            ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
            foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracoes)
            {
                id = fr.getIdRemuneracao();
                f.txtIdFuncionario.Text = fr.getIdFuncionario()+"";
                f.txtIdRemuneracao.Text = id+"";
                f.txtqtd.Text = fr.getQtd() + "";
                f.txtval.Text = string.Format("{0:#,##0.00}", fr.getValor());
            }
            foreach (ModeloRemuneracoes r in listaRemuneracoes)
            {
                if (r.getId() == id)
                {
                    f.cbRemuneracoes.Text = r.getNatureza();
                }
            }
            f.ShowDialog();
        }

        private void dataProcessamentoSalario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataProcessamentoSalario.Rows[rowIndex];
            try
            {
                codigoCelSelecionadaVencimento = int.Parse(row.Cells[0].Value.ToString());
            }
            catch (Exception err) { }
            btnEditarRemuneracoes.Enabled = true;
            btnEliminarRemuneracoes.Enabled = true;
        }

        private void btnEliminarRemuneracoes_Click(object sender, EventArgs e)
        {
            ControllerFuncionarioRemuneracoes.remover(codigoCelSelecionadaVencimento);
            refrescarVencimento();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            refrescarVencimento();
        }

        private void nrRegistonr_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbTipoProcessamento_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void nrAno_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(false);
            limpar();
            refrescarVencimento();
        }

        private void txtemprestimoMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        int mesSelecionado;
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            frmConsultarProcessamento f = new frmConsultarProcessamento();
            mesSelecionado = f.mesSelecionado;
        }

        private void cbMes_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void nrDias_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void dtDataHorasExtraEFaltas_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void dtDataProcessamento_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtemprestimoMedico_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtIrps_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtIpa_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtadiantamentos_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtSubAlimentacao_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtOutrasRemuneracoes_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }
    }
}
