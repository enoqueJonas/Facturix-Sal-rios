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
using Facturix_Salários.Modelos;
using Facturix_Salários.Controllers;
using System.Text.RegularExpressions;

namespace Facturix_Salários.Formularios
{
    public partial class frmAdiantamentos : Form
    {
        public frmAdiantamentos()
        {
            InitializeComponent();
        }

        private int getId() 
        {
            ArrayList lista = ControllerAdiantamento.recuperar();
            int id = 0;
            foreach (ModeloAdiantamento a in lista) 
            {
                if (a.getId()!=0) 
                {
                    id = a.getId();
                }
            }
            return id;
        }

        private void refrescarAdiantamentos(int idFunc) 
        {
            ArrayList lista = ControllerAdiantamento.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Sal. Bruto");
            dt.Columns.Add("Dias Trab.");
            dt.Columns.Add("Percentagem");
            dt.Columns.Add("Valor");
            foreach (ModeloAdiantamento func in lista)
            {
                if (idFunc == func.getIdFuncionario()) 
                {
                    DataRow dRow = dt.NewRow();
                    dRow["Registo n°"] = func.getId();
                    dRow["Sal. Bruto"] = string.Format("{0:#,##0.00}", func.getSalarioBruto());
                    dRow["Dias Trab."] = func.getDiasDeTrabalho();
                    dRow["Percentagem"] = func.getPercentagem() * 100+"%";
                    dRow["Valor"] = string.Format("{0:#,##0.00}", func.getDiantamento());
                    dt.Rows.Add(dRow);
                }
            }
            dataAdiantamentos.DataSource = dt;
            dataAdiantamentos.AllowUserToAddRows = false;
            dataAdiantamentos.Refresh();
        }

        int idAdiantamento;
        private Boolean existeAdiantamento(int idFunc) 
        {
            Boolean existe = false;
            ArrayList lista = ControllerAdiantamento.recuperar();
            DateTime dataForm = dtpAdiantamento.Value, dataAdiantamento;
            foreach (ModeloAdiantamento a in lista) 
            {
                dataAdiantamento = Convert.ToDateTime(a.getData());
                if (dataAdiantamento == dataForm && idFunc == a.getIdFuncionario()) 
                {
                    existe = true;
                    idAdiantamento = a.getId();
                }
            }
            return existe;
        }

        private int getDiasDeTrabalho(int codFunc)
        {
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
            int ano = DateTime.Now.Year, idFunc = 0;
            int nrMes = DateTime.Now.Month;
            DateTime dataRelogio;
            int dias = 0;
            foreach (ModeloRelogioDePonto f in listaRelogioDePonto)
            {
                dataRelogio = Convert.ToDateTime(f.getData());
                if (codFunc == f.getIdUsuario() && f.getEstado().Equals("Check in") && dataRelogio.Year == ano && dataRelogio.Month == nrMes)
                {
                    idFunc = f.getIdUsuario();
                    dias = dias + 1;
                }
            }
            if (dias % 2 != 0)
            {
                dias = dias - 1;
            }
            if (idFunc != 0)
            {
                ControllerDiasDeTrabalho.gravar(idFunc, dias / 2);
            }
            return dias / 2;
        }

        private void procurar(int idFunc) 
        {
            ArrayList lista = ControllerFuncionario.recuperarComCodigo(idFunc);
            int diasDeTrabalho = getDiasDeTrabalho(idFunc);
            String nome = "";
            int id = 0;
            double vencimento = 0;
            Boolean existe = false;
            foreach (ModeloFuncionario f in lista) 
            {
                existe = true;
                nome = f.getNome();
                vencimento = f.getVencimento();
                id = f.getCodigo();
            }

            if (existe)
            {
                nrRegisto.Value = id;
                txtNome.Text = nome;
                txtSalarioBruto.Text = string.Format("{0:#,##0.00}", vencimento);
            }
            else
            {
                txtNome.Text = "";
                txtSalarioBruto.Text = string.Format("{0:#,##0.00}", 0);
            }
            txtPercentagem.Text = "";
            txtDiasDeTrabalho.Text = diasDeTrabalho + "";
        }

        private void mostrar()
        {
            frmNumeroRegisto f = new frmNumeroRegisto();
            f.ShowDialog();
            int id = f.enterdCod;
            procurar(id);
            refrescarAdiantamentos(id);
            impedirBotoes();
        }

        private void gravar() 
        {
            int idFuncionario = Convert.ToInt16(nrRegisto.Value);
            double salarioBruto = double.Parse(txtSalarioBruto.Text);
            int diasDeTrabalho = int.Parse(txtDiasDeTrabalho.Text);
            String valorPercent = Regex.Match(txtPercentagem.Text, @"\d+").Value;
            float percent = float.Parse(valorPercent) / 100;
            String data = dtpAdiantamento.Value.ToString("yyyy-MM-dd");
            double adiantamento = ((salarioBruto * percent) / 30) * diasDeTrabalho;
            Boolean existe = existeAdiantamento(idFuncionario);
            if (existe)
            {
                ControllerAdiantamento.atualizar(idAdiantamento, idFuncionario, salarioBruto, diasDeTrabalho, percent, adiantamento, data);
            }
            else 
            {
                idAdiantamento = getId() + 1;
                ControllerAdiantamento.Guardar(idAdiantamento, idFuncionario, salarioBruto, diasDeTrabalho, percent, adiantamento, data);
            }
        }

        private void limpar() 
        {
            txtDiasDeTrabalho.Text = "";
            txtNome.Text = "";
            txtPercentagem.Text = "";
            txtSalarioBruto.Text = "";
            nrRegisto.Value = 0;
            dtpAdiantamento.Value = DateTime.Now;
        }

        private void adicionar() 
        {
            nrRegisto.Value = getId() + 1;
        }

        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
            lbl2.Visible = estado;
            lbl3.Visible = estado;
            lbl4.Visible = estado;
        }

        private void eliminar() 
        {
            int idFunc = Convert.ToInt16(nrRegisto.Value);
            Boolean existe = existeAdiantamento(idFunc);
            if (existe) 
            {
                ControllerAdiantamento.remover(idAdiantamento);
            }
        }

        public void impedirBotoes()
        {
            //|| txtNrFiscal.Text == ""
            if (txtPercentagem.Text == "")
            {
                //btnAdicionar.Enabled = true;
                btnMostrar.Enabled = true;
                btnAtualizar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnEliminar.Enabled = false;
                //btnAdicionar.FlatStyle = FlatStyle.Standard;
                btnAtualizar.FlatStyle = FlatStyle.Flat;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
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
                btnAtualizar.FlatStyle = FlatStyle.Standard;
                btnCancelar.FlatStyle = FlatStyle.Standard;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void atualizarBotoes()
        {
            if (lbl1.Visible == true)
            {
                //btnAdicionar.Enabled = false;
                btnMostrar.Enabled = false;
                btnEliminar.Enabled = false;
                btnAtualizar.Enabled = false;
                //btnAdicionar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnMostrar.FlatStyle = FlatStyle.Flat;
                //btnAdicionar.FlatStyle = FlatStyle.Flat;
                btnAtualizar.FlatStyle = FlatStyle.Flat;
                //btnAdicionar.Cursor = System.Windows.Forms.Cursors.Default;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                btnMostrar.Enabled = true;
                btnEliminar.Enabled = true;
                btnAtualizar.Enabled = true;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnMostrar.FlatStyle = FlatStyle.Standard;
                btnAtualizar.FlatStyle = FlatStyle.Standard;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void frmAdiantamentos_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSalarioBruto;
            int idFunc = Convert.ToInt16(nrRegisto.Value);
            refrescarAdiantamentos(idFunc);
            impedirBotoes();
            //txtPercentagem.LostFocus += new EventHandler(txtPercentagem_LostFocus);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int idFunc = Convert.ToInt16(nrRegisto.Value);
            try
            {
                gravar();
                mudarVisibilidadeLabels(false);
                refrescarAdiantamentos(idFunc);
                impedirBotoes();
            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message, "Não foi possível efectuar a operação! Contacte o técnico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int idFunc = Convert.ToInt16(nrRegisto.Value);
            try 
            {
                limpar();
                adicionar();
                refrescarAdiantamentos(idFunc);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível efectuar a operação! Contacte o técnico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
            atualizarBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(false);
            limpar();
            impedirBotoes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idFunc = Convert.ToInt16(nrRegisto.Value);
            try 
            {
                eliminar();
                txtPercentagem.Text = "";
                refrescarAdiantamentos(idFunc);
                impedirBotoes();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível efectuar a operação! Contacte o técnico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nrRegisto_ValueChanged(object sender, EventArgs e)
        {
            int idFunc = Convert.ToInt16(nrRegisto.Value);
            procurar(idFunc);
            refrescarAdiantamentos(idFunc);
            impedirBotoes();
        }

        private void txtSalarioBruto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                txtDiasDeTrabalho.Focus();
                //e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Right) 
            {
                txtDiasDeTrabalho.Focus();
                //e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Down) 
            {
                dtpAdiantamento.Focus();
            }
            e.Handled = true;
        }

        private void txtDiasDeTrabalho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPercentagem.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                txtPercentagem.Focus();
                e.Handled = true;
            }if (e.Alt && e.KeyCode == Keys.Left)
            {
                txtSalarioBruto.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Down)
            {
                dtpAdiantamento.Focus();
                e.Handled = true;
            }
        }

        private void txtPercentagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpAdiantamento.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                dtpAdiantamento.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                txtDiasDeTrabalho.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Down)
            {
                dtpAdiantamento.Focus();
                e.Handled = true;
            }
        }

        private void dtpAdiantamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                btnConfirmar.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                txtPercentagem.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Down)
            {
                btnConfirmar.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                txtSalarioBruto.Focus();
                e.Handled = true;
            }
        }

        int codigoCelSelecionada;
        private void dataAdiantamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataAdiantamentos.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList lista = ControllerAdiantamento.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloAdiantamento func in lista)
            {
                txtDiasDeTrabalho.Text = func.getDiasDeTrabalho() + "";
                txtPercentagem.Text = func.getPercentagem() * 100 + "%";
                dtpAdiantamento.Value = Convert.ToDateTime(func.getData());
            }
        }

        private void txtPercentagem_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }
        
        private void txtPercentagem_LostFocus(object sender, EventArgs e)
        {
            String valorPercent = Regex.Match(txtPercentagem.Text, @"\d+").Value;
            float percent = float.Parse(valorPercent) / 100;
            if (percent > 1) 
            {
                MessageBox.Show("Percentagem Inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtPercentagem.Focus();
        }

        private void frmAdiantamentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) 
            {
                mostrar();
            }
            if (e.KeyCode == Keys.F3) 
            {
                mudarVisibilidadeLabels(true);
                atualizarBotoes();
            }
            if (e.KeyCode == Keys.F4) 
            {
                mudarVisibilidadeLabels(false);
                limpar();
                impedirBotoes();
            }
            if (e.KeyCode == Keys.F5) 
            {
                int idFunc = Convert.ToInt16(nrRegisto.Value);
                try
                {
                    gravar();
                    mudarVisibilidadeLabels(false);
                    refrescarAdiantamentos(idFunc);
                    impedirBotoes();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Não foi possível efectuar a operação! Contacte o técnico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyCode == Keys.F6) 
            {
                int idFunc = Convert.ToInt16(nrRegisto.Value);
                try
                {
                    eliminar();
                    txtPercentagem.Text = "";
                    refrescarAdiantamentos(idFunc);
                    impedirBotoes();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Não foi possível efectuar a operação! Contacte o técnico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrar();
        }
    }
}
