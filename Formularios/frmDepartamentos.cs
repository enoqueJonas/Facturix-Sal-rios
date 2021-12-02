using System;
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

namespace Facturix_Salários.Formularios
{
    public partial class frmDepartamentos : Form
    {
        private int codigoCelSelecionada;
        public frmDepartamentos()
        {
            InitializeComponent();
        }

        private void frmDepartamentos_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtDepartamento;
            refrescar();
            impedirBotoes();
        }

        private void impedirBotoes()
        {
            if (txtDepartamento.Text == "")
            {
                btnAdicionar.Enabled = true;
                btnCancelar.Enabled = false;
                btnEditar.Enabled = false;
                btnRemover.Enabled = false;
                btnConfirmar.Enabled = false;
                btnAdicionar.FlatStyle = FlatStyle.Popup;
                btnEditar.FlatStyle = FlatStyle.Flat;
                btnRemover.FlatStyle = FlatStyle.Flat;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
                btnCancelar.FlatStyle = FlatStyle.Flat;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
                btnEditar.Cursor = System.Windows.Forms.Cursors.Default;
                btnRemover.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else if (txtDepartamento.Text != "")
            {
                btnEditar.Enabled = true;
                btnRemover.Enabled = true;
                btnConfirmar.Enabled = true;
                btnCancelar.Enabled = true;
                btnEditar.FlatStyle = FlatStyle.Popup;
                btnRemover.FlatStyle = FlatStyle.Popup;
                btnConfirmar.FlatStyle = FlatStyle.Popup;
                btnCancelar.FlatStyle = FlatStyle.Popup;
                btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnRemover.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void atualizarBotoes()
        {
            if (lbl1.Visible == true)
            {
                btnAdicionar.Enabled = false;
                btnRemover.Enabled = false;
                btnRemover.FlatStyle = FlatStyle.Flat;
                btnAdicionar.FlatStyle = FlatStyle.Flat;
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Default;
                btnRemover.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                btnAdicionar.Enabled = true;
                btnRemover.Enabled = true;
                btnRemover.FlatStyle = FlatStyle.Popup;
                btnAdicionar.FlatStyle = FlatStyle.Popup;
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnRemover.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void tirarFocoCelula()
        {
            dataDepertamentos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataDepertamentos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private void refrescar()
        {
            ArrayList listaDepartamnetos = ControllerDepartamento.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Departamneto");
            foreach (ModeloDepartamento func in listaDepartamnetos)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = func.getId();
                dRow["Departamneto"] = func.getNome();
                dt.Rows.Add(dRow);
            }
            dataDepertamentos.DataSource = dt;
            dataDepertamentos.AllowUserToAddRows = false;
            dataDepertamentos.Refresh();
            tirarFocoCelula();
        }
        private int getCod()
        {
            int cod = 0;
            ArrayList listaDepartamnetos = ControllerDepartamento.recuperar();
            foreach (ModeloDepartamento f in listaDepartamnetos)
            {
                if (f.getId() != 0)
                {
                    cod = f.getId();
                }
            }
            return cod;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            txtDepartamento.Text = "";
            impedirBotoes();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int cod = 0;
            String nome = txtDepartamento.Text;
            ArrayList listaDepartamnetos = ControllerDepartamento.recuperar();
            foreach (ModeloDepartamento f in listaDepartamnetos)
            {
                if (f.getId() == codigoCelSelecionada)
                {
                    cod = f.getId();
                }
            }
            if (cod == 0)
            {
                int id = getCod() + 1;
                ControllerDepartamento.Guardar(id, nome);
            }
            else 
            {
                ControllerDepartamento.atualizar(cod, nome);
            }
            lbl1.Visible = false;
            txtDepartamento.Text = "";
            refrescar();
            impedirBotoes();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            ControllerDepartamento.remover(codigoCelSelecionada);
            txtDepartamento.Text = "";
            refrescar();
            impedirBotoes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lbl1.Visible = true;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            this.ActiveControl = txtDepartamento;
            txtDepartamento.Text = "";
            codigoCelSelecionada = 0;
        }

        private void dataDepertamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataDepertamentos.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaDepartamentos = ControllerDepartamento.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloDepartamento func in listaDepartamentos)
            {
                txtDepartamento.Text = func.getNome();
            }
        }

        private void txtDepartamento_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }
        private void btnAdicionar_MouseEnter(object sender, EventArgs e)
        {
            lblAdicionar.Visible = true;
        }

        private void btnAdicionar_MouseLeave(object sender, EventArgs e)
        {
            lblAdicionar.Visible = false;
        }

        private void btnEditar_MouseEnter(object sender, EventArgs e)
        {
            lblEditar.Visible = true;
        }

        private void btnEditar_MouseLeave(object sender, EventArgs e)
        {
            lblEditar.Visible = false;
        }

        private void btnRemover_MouseEnter(object sender, EventArgs e)
        {
            lblRemover.Visible = true;
        }

        private void btnRemover_MouseLeave(object sender, EventArgs e)
        {
            lblRemover.Visible = false;
        }

        private void btnConfirmar_MouseEnter(object sender, EventArgs e)
        {
            lblConfirmar.Visible = true;
        }

        private void btnConfirmar_MouseLeave(object sender, EventArgs e)
        {
            lblConfirmar.Visible = false;
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            lblCancelar.Visible = true;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            lblCancelar.Visible = false;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            frmTempoDeServico f = new frmTempoDeServico();
            f.Show();
            this.Close();
        }

        private void btnSeguinte_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
