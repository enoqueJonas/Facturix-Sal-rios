using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using Facturix_Salários.Formularios;

namespace Facturix_Salários
{
    public partial class frmVisualizarFuncionario : Form
    {
        private int numeroFuncionarios = 0;
        public frmVisualizarFuncionario()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            Focus();
        }

        int codigoCelSelecionada;
        private void frmVisualizarF_Load(object sender, EventArgs e)
        {
            refrescar();
            foreach (DataGridViewColumn col in dataFuncionarios.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.BringToFront(); 
            this.Activate();
            this.ActiveControl = txtLocalizar;
            mostrarNumeroFuncionarios();
        }

        private void mostrarNumeroFuncionarios() 
        {
            txtNumeroFuncionarios.Text = numeroFuncionarios + "";
        }

        private void montarDataGridView(ArrayList listaRecebida) 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Telefone");
            foreach (ModeloFuncionario func in listaRecebida)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = func.getCodigo();
                dRow["Nome"] = func.getNome();
                dRow["Telefone"] = func.getTel();
                dt.Rows.Add(dRow);
                numeroFuncionarios += 1;
            }
            dataFuncionarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataFuncionarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataFuncionarios.AllowUserToAddRows = false;
            dataFuncionarios.DataSource = dt;
            dataFuncionarios.Refresh();
        }
        private void refrescar() 
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            montarDataGridView(listaFuncionarios);
        }

        private void eliminar() {
            ControllerConta.remover(codigoCelSelecionada);
            ControllerFuncionario.remover(codigoCelSelecionada);
            refrescar();
        }
        private void mostrar() 
        {
            frmNumeroRegisto f = new frmNumeroRegisto();
            f.ShowDialog();
            int cod = f.enterdCod;
            codigoCelSelecionada = cod;
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(cod);
            montarDataGridView(listaFuncionarios);
        }

        private void fecharJanela(KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
        }

        private void dataFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            rowSelected = rowIndex;
            DataGridViewRow row = dataFuncionarios.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            frmCadastrarFuncionarios f = new frmCadastrarFuncionarios();
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(codigoCelSelecionada);
            ArrayList listaContas = ControllerConta.recuperarComCod(codigoCelSelecionada);
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
                f.txtHoraSemana.Text = func.getHoras() + "";
                f.txtNrDependentes.Text = func.getDependentes() + "";
                f.cbHabilitacoes.Text = func.getHabilitacoes();
                f.txtNacionalidade.Text = func.getNacionalidade();
                f.txtUltimo.Text = func.getUltimoEmprego();
                f.cbTurno.Text = func.getTurno();
                f.txtImpostoM.Text = func.getImpostoMunicipal() +"";
                f.cbCentrocusto.Text = func.getCentroDeCusto();
                f.txtSeguranca.Text = func.getSegurancaSocial();
                f.txtVencimento.Text = string.Format("{0:#,##0.00}", func.getVencimento());
                f.txtAlimentacao.Text = string.Format("{0:#,##0.00}", func.getSubAlimentacao());
                foreach (ModeloConta conta in listaContas)
                {
                    if (codigoCelSelecionada == conta.idFuncionario)
                    {
                        f.txtNrConta.Text = conta.conta;
                        f.txtNib.Text = conta.nib;
                        f.txtBanco.Text = conta.banco;
                    }
                }
            }
            this.TopMost = false;
            f.Show();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVisualizarF_KeyDown(object sender, KeyEventArgs e)
        {
            fecharJanela(e);
            if (e.KeyCode.ToString() == "F1")
            {
                frmAdicionarFuncionario f = new frmAdicionarFuncionario();
                f.Show();
            }
            if (e.KeyCode.ToString() == "F2")
            {
                mostrar();
                btnEliminar.Enabled = true;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnImprimir.Enabled = true;
                btnImprimir.FlatStyle = FlatStyle.Standard;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (e.KeyCode.ToString() == "F6")
            {
                try
                {
                    try
                    {
                        if (MessageBox.Show("Tem certeza que deseja eliminar o funcionário?", "Atenção!",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            eliminar();
                            mostrarNumeroFuncionarios();
                            MessageBox.Show("Funcionário removido com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Não foi possível eliminar o Funcionário! Contacte o técnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Não foi possível eliminar o Funcionário! Contacte o técnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyCode.ToString() == "F7")
            {
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
        private void btnRegressar_KeyDown(object sender, KeyEventArgs e)
        {
            fecharJanela(e);
        }

        private void btnRegre(object sender, KeyEventArgs e)
        {
    
        }
        
        private void frmVisualizarF_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void abrirFrmAdicionarFunc() 
        {
            frmAdicionarFuncionario f = new frmAdicionarFuncionario();
            f.ShowDialog();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            abrirFrmAdicionarFunc();
        }

        private void txtLocalizar_TextChanged(object sender, EventArgs e)
        {
            String procura = txtLocalizar.Text;
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComString(procura);
            montarDataGridView(listaFuncionarios);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            mostrar();
            btnEliminar.Enabled = true;
            btnEliminar.FlatStyle = FlatStyle.Standard;
            btnImprimir.Enabled = true;
            btnImprimir.FlatStyle = FlatStyle.Standard;
            btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem certeza que deseja eliminar o funcionário?", "Atenção!",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    eliminar();
                    mostrarNumeroFuncionarios();
                    MessageBox.Show("Funcionário removido com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível eliminar o Funcionário! Contacte o técnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataFuncionarios.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            btnEliminar.Enabled = true;
            btnEliminar.FlatStyle = FlatStyle.Standard;
            btnImprimir.Enabled = true;
            btnImprimir.FlatStyle = FlatStyle.Standard;
            btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReportFuncionario f = new frmReportFuncionario();
            f.Show();
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                MySqlCommand comando = new MySqlCommand("SELECT nome, email, numeroFiscal FROM funcionario", conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "funcionario");
                Reports.reportFuncionario rep = new Reports.reportFuncionario();
                rep.SetDataSource(ds);
                f.crDataTable.ReportSource = rep;
                f.crDataTable.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.Trim(),"Nao foi possivel preencher report");
            }
            finally 
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        private void frmVisualizarFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void txtLocalizar_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow row in dataFuncionarios.Rows)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dataFuncionarios.MultiSelect = false;
                    dataFuncionarios.Rows[0].Selected = true;
                    dataFuncionarios.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;
                    dataFuncionarios.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                    dataFuncionarios.Focus();
                    btnEliminar.Enabled = true;
                    btnEliminar.FlatStyle = FlatStyle.Standard;
                    btnImprimir.Enabled = true;
                    btnImprimir.FlatStyle = FlatStyle.Standard;
                    btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
                }
            }
        }

        private void dataFuncionarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            rowSelected = rowIndex;
            DataGridViewRow row = dataFuncionarios.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
        }

        int rowSelected;
        private void dataFuncionarios_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex = rowSelected;
            while (this.IsAccessible) 
            {
                if (e.KeyCode == Keys.Up)
                {
                    dataFuncionarios.MultiSelect = false;
                    dataFuncionarios.Rows[rowIndex].Selected = true;
                    dataFuncionarios.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;
                    dataFuncionarios.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                    rowIndex--;
                }
                if (e.KeyCode == Keys.Down)
                {
                    dataFuncionarios.MultiSelect = false;
                    dataFuncionarios.Rows[rowIndex].Selected = true;
                    dataFuncionarios.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;
                    dataFuncionarios.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                    rowIndex++;
                }
            }
            if (e.KeyCode == Keys.Enter) 
            {
                rowIndex = rowSelected;
                rowSelected = rowIndex;
                DataGridViewRow row = dataFuncionarios.Rows[rowIndex];
                codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
                frmCadastrarFuncionarios f = new frmCadastrarFuncionarios();
                ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(codigoCelSelecionada);
                ArrayList listaContas = ControllerConta.recuperarComCod(codigoCelSelecionada);
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
                    f.txtHoraSemana.Text = func.getHoras() + "";
                    f.txtNrDependentes.Text = func.getDependentes() + "";
                    f.cbHabilitacoes.Text = func.getHabilitacoes();
                    f.txtNacionalidade.Text = func.getNacionalidade();
                    f.txtUltimo.Text = func.getUltimoEmprego();
                    f.cbTurno.Text = func.getTurno();
                    f.txtImpostoM.Text = func.getImpostoMunicipal() + "";
                    f.cbCentrocusto.Text = func.getCentroDeCusto();
                    f.txtSeguranca.Text = func.getSegurancaSocial();
                    f.txtVencimento.Text = string.Format("{0:#,##0.00}", func.getVencimento());
                    f.txtAlimentacao.Text = string.Format("{0:#,##0.00}", func.getSubAlimentacao());
                    foreach (ModeloConta conta in listaContas)
                    {
                        if (codigoCelSelecionada == conta.idFuncionario)
                        {
                            f.txtNrConta.Text = conta.conta;
                            f.txtNib.Text = conta.nib;
                            f.txtBanco.Text = conta.banco;
                        }
                    }
                }
                e.Handled = true;
                f.Show();
                this.Hide();
            }
        }

        private void dataFuncionarios_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
