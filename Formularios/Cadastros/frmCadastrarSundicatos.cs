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

namespace Facturix_Salários
{
    public partial class frmCadastrarSundicatos : Form
    {
        private int codigoCelSelecionada;
        public frmCadastrarSundicatos()
        {
            InitializeComponent();
            impedirBotoes();
        }

        private void refrescar()
        {
            ArrayList listaSindicatos = ControllerSindicato.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Sindicatos");
            foreach (ModeloSindicato func in listaSindicatos)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Sindicatos"] = func.getSindicato();
                dt.Rows.Add(dRow);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        public void gravar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerSindicato.gravar(id, regime);
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerSindicato.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerSindicato.atualizar(id, regime);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            adicionar();
            refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            cancelar();
            refrescar();
        }

        private int getCod()
        {
            ArrayList listaSindicatos = ControllerSindicato.recuperar();
            int cod = 0;
            foreach (ModeloSindicato cat in listaSindicatos)
            {
                if (cat.getId() != 0)
                {
                    cod = cat.getId();
                }
                else
                {
                    cod = 0;
                }
            }
            return cod;
        }

        private void confirmarFechamento()
        {
            DialogResult dialogResult = MessageBox.Show("Pretende fechar o formulário?", "Atenção!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                frmMenu f = new frmMenu();
                f.TopMost = true;
                f.Show();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        private void setCod()
        {
            txtCodigo.Text = getCod() + 1 + "";
        }
        private void adicionar()
        {
            setCod();
            txtNome.Text = "";
        }

        private void cancelar()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }

        private void impedirBotoes()
        {
            if (txtNome.Text == "" || txtCodigo.Text == "")
            {
                btnCancelar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnCancelar.FlatStyle = FlatStyle.Flat;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnAtualizar.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                btnCancelar.Enabled = true;
                btnAtualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnConfirmar.Enabled = true;
                btnCancelar.FlatStyle = FlatStyle.Standard;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnAtualizar.FlatStyle = FlatStyle.Standard;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            cancelar();
            refrescar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            impedirBotoes();
            refrescar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }

        private void frmCadastrarSundicatos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == "F1")
            {
                adicionar();
            }
            if (e.KeyCode.ToString() == "F2")
            {

            }
            if (e.KeyCode.ToString() == "F3")
            {
                modificar();
            }
            if (e.KeyCode.ToString() == "F4")
            {
                cancelar();
            }
            if (e.KeyCode.ToString() == "F5")
            {
                gravar();
            }
            if (e.KeyCode.ToString() == "F6")
            {
                eliminar();
            }
            if (e.KeyCode.ToString() == "F7")
            {
            }
            if (e.KeyCode == Keys.Escape)
            {
                confirmarFechamento();
            }
        }

        private void frmCadastrarSundicatos_Load(object sender, EventArgs e)
        {
            setCod();
            refrescar();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void cbSindicatos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaEst = ControllerSindicato.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloSindicato func in listaEst)
            {
                txtCodigo.Text = func.getId() + "";
                txtNome.Text = func.getSindicato();
            }
        }
    }
}
