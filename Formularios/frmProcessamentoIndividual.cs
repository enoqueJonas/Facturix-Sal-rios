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
            this.ActiveControl = txtNome;
            dataProcessamentoSalario.AllowUserToAddRows = false;
            refrescarVencimento();
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
                    dRow["Valor Unit."] = fr.getValor();
                    dRow["Quantidade"] = fr.getQtd();
                    dRow["Total"] = fr.getValor() * fr.getQtd() + "";
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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            
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
            foreach (ModeloFuncionario func in listaFuncionarios)
            {
                nrRegistonr.Value = func.getCodigo();
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
            }
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
            txtSubAlimentacao.Text = subAlimentacao + "";
            txtOutrasRemuneracoes.Text = outroSub + "";
            txtTotalDescontar.Text = valorIrps + emprestimo + ipa + adiantamentos + "";
            txtTotalRemuneracoes.Text = subAlimentacao + vencimento + outroSub + "";
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
                MessageBox.Show("Salário/os processado/os com sucesso!");
            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message, "Erro");
            }
        }

        private void gravar() 
        {
            int id = 0;
            int idFunc = Convert.ToInt16(nrRegistonr.Value);
            String nome = txtNome.Text;
            String operacao = cbTipoProcessamento.Text;
            String dataProcessamnto = dtDataProcessamento.Value.ToString("yyyy-MM-dd");
            int mesRecebido = dtDataProcessamento.Value.Month;
            int anoRecebido = dtDataProcessamento.Value.Year;
            int anoProcessado, mesProcessado;
            DateTime dtProcessado;
            int diasDeTrabalho = Convert.ToInt16(nrDias.Value);
            double emprestimoMedico = double.Parse(txtemprestimoMedico.Text);
            double irps = double.Parse(txtIrps.Text);
            double ipa = double.Parse(txtIpa.Text);
            double adiantamentos = double.Parse(txtadiantamentos.Text);
            double salarioBruto = double.Parse(txtVencimento.Text);
            double subAlimentcao = double.Parse(txtSubAlimentacao.Text);
            double diversosSubsidios = double.Parse(txtOutrasRemuneracoes.Text);
            double ajudaDeCusto = 0, ajudaDeDeslocacao = 0, pagamentoFerias = 0, inss, totalADescontar, totalRetribuicoes, importanciaAPagar, salarioLiquido;
            
            salarioLiquido = Math.Round((salarioBruto / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
            inss = Math.Round((salarioLiquido * 0.07), 2, MidpointRounding.AwayFromZero); ;
            totalADescontar = emprestimoMedico + adiantamentos + irps + ipa + inss;
            totalRetribuicoes = subAlimentcao + salarioLiquido + diversosSubsidios + ajudaDeCusto + ajudaDeDeslocacao + pagamentoFerias;
            importanciaAPagar = totalRetribuicoes - totalADescontar;
           
            Boolean existe = false;
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            foreach (ModeloProcessamentoDeSalario f in listaProcessamento)
            {
                dtProcessado = Convert.ToDateTime(f.getDataProcessamento());
                anoProcessado = dtProcessado.Year;
                mesProcessado = dtProcessado.Month;
                if (f.getIdFuncionario() == idFunc && anoProcessado == anoRecebido && mesProcessado == mesRecebido)
                {
                    existe = true;
                    id = f.getId();
                }
            }

            if (existe)
            {
                ControllerProcessamentoDeSalario.atualizar(id, idFunc, nome, diasDeTrabalho, salarioLiquido, subAlimentcao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamnto, operacao);
            }
            else {
                id = getCodProcessamento() + 1;
                ControllerProcessamentoDeSalario.Guardar(id, idFunc, nome, diasDeTrabalho, salarioLiquido, subAlimentcao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamnto, operacao);
            }
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
                f.txtval.Text = fr.getValor() + "";
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
