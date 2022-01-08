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
using Facturix_Salários.DataSets;
using Facturix_Salários.Reports;
using MySql.Data.MySqlClient;

namespace Facturix_Salários.Formularios
{
    public partial class frmProcessamentoIndividual : Form
    {
        public frmProcessamentoIndividual()
        {
            InitializeComponent();
        }
        int codigoCelSelecionadaVencimento;
        private void imprimir() 
        {
            ArrayList listaFunc = ControllerFuncionario.recuperar();
            int codTextBox = Convert.ToInt16(nrRegistonr.Value);
            frmReportProcessamento f = new frmReportProcessamento();
            f.Show();
            reportProcessamento objRpt = new reportProcessamento();
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();

                //String Query1 = "SELECT categoria, numeroBenificiario, numeroFiscal, vencimento from funcionario WHERE exists (select nomeTrabalhador from processamento_salario)";
                String Query2 = "SELECT nomeTrabalhador, diasDeTrabalho, salarioBrutoMensal, subsidioAlimentacao, importanciaAPagar, totalADescontar, totalRetribuicao, dataProcessamento, ajudaDeDeslocacao, ajudaDeCusto, categoria, numeroBenificiario, numeroFiscal, vencimento from processamento_salario, funcionario WHERE processamento_salario.nomeTrabalhador = funcionario.nome AND idFuncionario=" + codTextBox + "";
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query2, conexao);

                DataSet Ds = new DtSetProcessamento();

                adapter.Fill(Ds, "dtTableProcessamento");

                //adapter = new MySqlDataAdapter(Query2, conexao);
                //adapter.Fill(Ds, "dtTableProcessamento");

                if (Ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No data Found", "CrystalReportWithOracle");
                    return;
                }

                //Setting data source of our report object
                objRpt.SetDataSource(Ds);

                //CrystalDecisions.CrystalReports.Engine.TextObject root;
                //root = (CrystalDecisions.CrystalReports.Engine.TextObject);
                //objRpt.ReportDefinition.ReportObjects["txt_header"];
                //root.Text = "Sample Report By Using Data Table!!";

                //Binding the crystalReportViewer with our report object. 
                f.crystalReportViewer1.ReportSource = objRpt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível preencher o report! Contacte o técnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
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
            if (ctrl is TextBox || ctrl is ComboBox || ctrl is NumericUpDown)
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
                    dtProcessamentoExistente = Convert.ToDateTime(p.getDataProcessamento());
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

        private void montarCaixas(int id) 
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(id);
            ArrayList listaIrps = ControllerIRPS.recuperar();
            ArrayList listaDependentes = ControllerDependente.recuperarComCodFuncionario(id);
            int codIrps = 0;
            String estado = "";
            double valorIrps = 0, emprestimo = 0, ipa = 0, adiantamentos = 0, vencimento = 0, outroSub = 0, subAlimentacao = 0;
            Boolean existe = false, existeProcess = existeProcessamento(id);
            foreach (ModeloFuncionario func in listaFuncionarios)
            {
                txtNome.Text = func.getNome();
                emprestimo = 0;
                ipa = func.getImpostoMunicipal();
                adiantamentos = 0;
                codIrps = func.getIdIRPS();
                vencimento = func.getVencimento();
                subAlimentacao = func.getSubAlimentacao();
                if (id == func.getCodigo())
                {
                    existe = true;
                }
            }

            if (existeProcess)
            {
                ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperarComCod(id);
                foreach (ModeloProcessamentoDeSalario p in listaProcessamento)
                {
                    adiantamentos = p.getAdiantamentos();
                    emprestimo = p.getEmprestimoMedico();
                    valorIrps = p.getIrps();
                    subAlimentacao = p.getSubAlimentacao();
                    vencimento = p.getSalarioBrutoMensal();
                    ipa = p.getIpa();
                    outroSub = p.getDiversosSubsidios();
                    diasDeTrabalho = p.getIdDiasDeTrabalho();
                    estado = "Processado";
                }
            }
            else
            {
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
                }
                estado = "Não processado";
            }
            txtemprestimoMedico.Text = string.Format("{0:#,##0.00}", emprestimo);
            txtIpa.Text = string.Format("{0:#,##0.00}", ipa);
            txtadiantamentos.Text = string.Format("{0:#,##0.00}", adiantamentos);
            txtVencimento.Text = string.Format("{0:#,##0.00}", vencimento);
            txtEstado.Text = string.Format("{0:#,##0.00}", estado);
            txtSubAlimentacao.Text = string.Format("{0:#,##0.00}", subAlimentacao);
            txtOutrasRemuneracoes.Text = string.Format("{0:#,##0.00}", outroSub);
            txtTotalDescontar.Text = string.Format("{0:#,##0.00}", valorIrps + emprestimo + ipa + adiantamentos);
            txtTotalRemuneracoes.Text = string.Format("{0:#,##0.00}", subAlimentacao + vencimento + outroSub);
            txtIrps.Text = string.Format("{0:#,##0.00}", valorIrps);
        }

        public void impedirBotoes()
        {
            //|| txtNrFiscal.Text == ""
            if (txtNome.Text == "")
            {
                btnMostrar.Enabled = true;
                btnAtualizar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnEliminar.Enabled = false;
                btnImprimir.Enabled = false;
                btnAtualizar.FlatStyle = FlatStyle.Flat;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnImprimir.FlatStyle = FlatStyle.Flat;
                btnMostrar.FlatStyle = FlatStyle.Standard;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
                btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else if (txtNome.Text != "")
            {
                btnAtualizar.Enabled = true;
                btnCancelar.Enabled = true;
                btnConfirmar.Enabled = true;
                btnEliminar.Enabled = true;
                btnImprimir.Enabled = true;
                btnAtualizar.FlatStyle = FlatStyle.Standard;
                btnCancelar.FlatStyle = FlatStyle.Standard;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnImprimir.FlatStyle = FlatStyle.Standard;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }


        private void nrRegistonr_ValueChanged(object sender, EventArgs e)
        {
            refrescarVencimento();
            int id = Convert.ToUInt16(nrRegistonr.Value);
            montarCaixas(id);
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
                btnMostrar.Enabled = true;
                btnAtualizar.Enabled = true;
                btnConfirmar.Enabled = true;
                btnCancelar.Enabled = true;
                btnEliminar.Enabled = true;
                btnImprimir.Enabled = true;
                btnAtualizar.FlatStyle = FlatStyle.Standard;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnCancelar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnImprimir.FlatStyle = FlatStyle.Standard;
                btnMostrar.FlatStyle = FlatStyle.Standard;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
                btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
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
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperarComCod(idProcessamento);
            //ControllerDiasDeTrabalho.gravar(idFunc, diasDeTrabalho);
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
                    ajudaDeDeslocacao = p.getAjudaDeslocacao();
                    pagamentoFerias = p.getPagamentoFerias();
                    diversosSubsidios = p.getDiversosSubsidios();
                    emprestimoMedico = p.getEmprestimoMedico();
                    adiantamentos = p.getAdiantamentos();
                    DateTime dataP = Convert.ToDateTime(p.getDataProcessamento());
                    dataProcessamento = dataP.ToString("yyyy-MM-dd");
                }

                int idFunc = Convert.ToInt16(nrRegistonr.Value);
                if (existe == true && dtProcessamentoExistente.Date < DateTime.Now.Date)
                {
                    if (MessageBox.Show("O processamento já foi submetido à segurança social! Modificar o mesmo virá com Repercussões. Deseja Continuar?", "Atenção!",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ControllerProcessamentoDeSalario.atualizar(idProcessamento, idFunc, nome, diasDeTrabalho, salarioBruto, subAlimentacao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, "", dataProcessamento, "");

                    }
                }
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
            catch (Exception er) { er.ToString(); }
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
            btnMostrar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnConfirmar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnImprimir.Enabled = false;
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.FlatStyle = FlatStyle.Standard;
            btnCancelar.FlatStyle = FlatStyle.Standard;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnMostrar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
            btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(false);
            limpar();
            refrescarVencimento();
            btnMostrar.Enabled = true;
            btnAtualizar.Enabled = true;
            btnConfirmar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = true;
            btnImprimir.Enabled = true;
            btnAtualizar.FlatStyle = FlatStyle.Standard;
            btnConfirmar.FlatStyle = FlatStyle.Standard;
            btnCancelar.FlatStyle = FlatStyle.Standard;
            btnEliminar.FlatStyle = FlatStyle.Standard;
            btnImprimir.FlatStyle = FlatStyle.Standard;
            btnMostrar.FlatStyle = FlatStyle.Standard;
            btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
            btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
            btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
            btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void txtemprestimoMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        int mesSelecionado;
        private void mostrar() 
        {
            frmConsultarProcessamento f = new frmConsultarProcessamento();
            f.ShowDialog();
            mesSelecionado = f.mesSelecionado;
            int id = Convert.ToInt16(nrRegistonr.Value);
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(id);
            ArrayList listaIrps = ControllerIRPS.recuperar();
            int codIrps = 0;
            String estado = "";
            double valorIrps = 0, emprestimo = 0, ipa = 0, adiantamentos = 0, vencimento = 0, outroSub = 0, subAlimentacao = 0;
            Boolean existe = false, existeProcess = false;
            foreach (ModeloFuncionario func in listaFuncionarios)
            {
                txtNome.Text = func.getNome();
                emprestimo = 0;
                ipa = func.getImpostoMunicipal();
                adiantamentos = 0;
                codIrps = func.getIdIRPS();
                vencimento = func.getVencimento();
                subAlimentacao = func.getSubAlimentacao();
                if (id == func.getCodigo())
                {
                    existe = true;
                }
            }

            ArrayList lista = ControllerProcessamentoDeSalario.recuperar();
            int ano = DateTime.Now.Year;
            int nrMes = mesSelecionado, anoProcess, mesProcess;
            DateTime dataProcess;
            foreach (ModeloProcessamentoDeSalario p in lista)
            {
                dataProcess = Convert.ToDateTime(p.getDataProcessamento());
                anoProcess = dataProcess.Year;
                mesProcess = dataProcess.Month;
                if (id == p.getIdFuncionario() && anoProcess == ano && mesProcess == nrMes)
                {
                    existeProcess = true;
                    idProcessamento = p.getId();
                    dtProcessamentoExistente = Convert.ToDateTime(p.getDataProcessamento());
                }
            }
            if (existeProcess)
            {
                ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperarComCod(id);
                foreach (ModeloProcessamentoDeSalario p in listaProcessamento)
                {
                    adiantamentos = p.getAdiantamentos();
                    emprestimo = p.getEmprestimoMedico();
                    valorIrps = p.getIrps();
                    subAlimentacao = p.getSubAlimentacao();
                    vencimento = p.getSalarioBrutoMensal();
                    ipa = p.getIpa();
                    outroSub = p.getDiversosSubsidios();
                    diasDeTrabalho = p.getIdDiasDeTrabalho();
                    estado = "Processado";
                }
            }
            else
            {
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
                }
                estado = "Não processado";
            }
            txtemprestimoMedico.Text = string.Format("{0:#,##0.00}", emprestimo);
            txtIpa.Text = string.Format("{0:#,##0.00}", ipa);
            txtadiantamentos.Text = string.Format("{0:#,##0.00}", adiantamentos);
            txtVencimento.Text = string.Format("{0:#,##0.00}", vencimento);
            txtEstado.Text = string.Format("{0:#,##0.00}", estado);
            txtSubAlimentacao.Text = string.Format("{0:#,##0.00}", subAlimentacao);
            txtOutrasRemuneracoes.Text = string.Format("{0:#,##0.00}", outroSub);
            txtTotalDescontar.Text = string.Format("{0:#,##0.00}", valorIrps + emprestimo + ipa + adiantamentos);
            txtTotalRemuneracoes.Text = string.Format("{0:#,##0.00}", subAlimentacao + vencimento + outroSub);
            txtIrps.Text = string.Format("{0:#,##0.00}", valorIrps);
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        DateTime dtProcessamentoExistente;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idFunc = Convert.ToInt16(nrRegistonr.Value);
            Boolean existe = existeProcessamento(idFunc);
            if (existe == true && dtProcessamentoExistente.Date < DateTime.Now.Date) 
            {
                if (MessageBox.Show("O processamento já foi submetido à segurança social! Eliminar o mesmo virá com Repercussões. Deseja Continuar?", "Atenção!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ControllerProcessamentoDeSalario.remover(idProcessamento);
                    
                }
            }
        }

        private void nrAno_ValueChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(nrRegistonr.Value);
            montarCaixas(id);
            refrescarVencimento();
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(nrRegistonr.Value);
            montarCaixas(id);
            refrescarVencimento();
        }

        private void txtVencimento_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionarRemuneracao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                if (btnEditarRemuneracoes.Enabled) 
                {
                    this.ActiveControl = btnEditarRemuneracoes;
                }
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = btnConfirmar;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = txtIpa;
            }
        }

        private void btnEditarRemuneracoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                if (btnEditarRemuneracoes.Enabled)
                {
                    this.ActiveControl = btnEliminar;
                }
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = btnConfirmar;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = txtSubAlimentacao;
            }if (e.Alt && e.KeyCode == Keys.Left)
            {
                this.ActiveControl = btnAdicionarRemuneracao;
            }
        }

        private void btnEliminarRemuneracoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                    this.ActiveControl = btnMostrar;
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = btnMostrar;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = txtSubAlimentacao;
            }
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                this.ActiveControl = btnEditarRemuneracoes;
            }
        }

        private void frmProcessamentoIndividual_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmProcessamentoIndividual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2" && btnMostrar.Enabled)
            {
                mostrar();
            }
            if (e.KeyCode.ToString() == "F3" && btnAtualizar.Enabled)
            {
                mudarVisibilidadeLabels(true);
                btnMostrar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnConfirmar.Enabled = true;
                btnCancelar.Enabled = true;
                btnEliminar.Enabled = false;
                btnImprimir.Enabled = false;
                btnAtualizar.FlatStyle = FlatStyle.Flat;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnCancelar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnImprimir.FlatStyle = FlatStyle.Flat;
                btnMostrar.FlatStyle = FlatStyle.Flat;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            if (e.KeyCode.ToString() == "F4" && btnCancelar.Enabled)
            {
                mudarVisibilidadeLabels(false);
                limpar();
                refrescarVencimento();
                btnMostrar.Enabled = true;
                btnAtualizar.Enabled = true;
                btnConfirmar.Enabled = true;
                btnCancelar.Enabled = true;
                btnEliminar.Enabled = true;
                btnImprimir.Enabled = true;
                btnAtualizar.FlatStyle = FlatStyle.Standard;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnCancelar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnImprimir.FlatStyle = FlatStyle.Standard;
                btnMostrar.FlatStyle = FlatStyle.Standard;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
                btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            if (e.KeyCode.ToString() == "F5" && btnConfirmar.Enabled)
            {
                try
                {
                    gravar();
                    mudarVisibilidadeLabels(false);
                    MessageBox.Show("Os dados para o procesaamento foram atualizados com sucesso!");
                    btnMostrar.Enabled = true;
                    btnAtualizar.Enabled = true;
                    btnConfirmar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnImprimir.Enabled = true;
                    btnAtualizar.FlatStyle = FlatStyle.Standard;
                    btnConfirmar.FlatStyle = FlatStyle.Standard;
                    btnCancelar.FlatStyle = FlatStyle.Standard;
                    btnEliminar.FlatStyle = FlatStyle.Standard;
                    btnImprimir.FlatStyle = FlatStyle.Standard;
                    btnMostrar.FlatStyle = FlatStyle.Standard;
                    btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                    btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                    btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
                    btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
                    btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Erro");
                }
            }
            if (e.KeyCode.ToString() == "F6" && btnEliminar.Enabled)
            {
                int idFunc = Convert.ToInt16(nrRegistonr.Value);
                Boolean existe = existeProcessamento(idFunc);
                ArrayList lista = ControllerProcessamentoDeSalario.recuperar();
                if (existe == true && dtProcessamentoExistente.Date < DateTime.Now.Date)
                {
                    if (MessageBox.Show("O processamento já foi submetido à segurança social! Eliminar o mesmo virá com Repercussões. Deseja Continuar?", "Atenção!",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ControllerProcessamentoDeSalario.remover(idProcessamento);

                    }
                }
            }
            if (e.KeyCode.ToString() == "F7" && btnImprimir.Enabled)
            {
                imprimir();
            }
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }
        }

        private void cbMes_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void nrDias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = txtemprestimoMedico;
            }
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                this.ActiveControl = txtemprestimoMedico;
            }
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
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                this.ActiveControl = txtVencimento;
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = txtIrps;
            }if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = nrDias;
            }
        }

        private void txtIrps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                this.ActiveControl = txtSubAlimentacao;
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = txtIpa;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = txtemprestimoMedico;
            }
        }

        private void txtIpa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                this.ActiveControl = txtSubAlimentacao;
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = txtadiantamentos;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = txtIrps;
            }
        }

        private void txtadiantamentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                this.ActiveControl = btnAdicionarRemuneracao;
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = btnAdicionarRemuneracao;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = txtIpa;
            }
        }

        private void txtVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                this.ActiveControl = txtemprestimoMedico;
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = txtSubAlimentacao;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = nrDias;
            }
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                this.ActiveControl = txtIrps;
            }
        }

        private void txtSubAlimentacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                this.ActiveControl = txtIrps;
            }
            if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl = btnAdicionarRemuneracao;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl = txtVencimento;
            }
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                this.ActiveControl = txtIpa;
            }
        }

        private void txtOutrasRemuneracoes_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
