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
    public partial class frmCadastrarContrato : Form
    {
        private int codigoCelSelecionada;
        public frmCadastrarContrato()
        {
            InitializeComponent();
            this.ActiveControl = txtNome;
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
        private void refrescar()
        {
            ArrayList listaContratos = ControllerContrato.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Contrato");
            foreach (ModeloContrato func in listaContratos)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Contrato"] = func.getContrato();
                dt.Rows.Add(dRow);
            }
            dataContrato.DataSource = dt;
            dataContrato.Refresh();
            dataContrato.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            dataContrato.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private void impedirBotoes()
        {
            if (txtNome.Text == "")
            {
                btnAtualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAtualizar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
                btnCancelar.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                btnAtualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnConfirmar.Enabled = true;
                btnCancelar.Enabled = true;

                btnAtualizar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnCancelar.FlatStyle = FlatStyle.Standard;
            }
        }

        private int getCod()
        {
            ArrayList listaContratos = ControllerContrato.recuperar();
            int cod = 0;
            foreach (ModeloContrato cat in listaContratos)
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

        public void gravar()
        {
            int id = int.Parse(txtCodigo.Text);
            String contrato = txtNome.Text;
            ControllerContrato.gravar(id, contrato);
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerContrato.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerContrato.atualizar(id, regime);
        }

        private void adicionarItemsCb()
        {
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            adicionarItemsCb();
            adicionar();
            refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            cancelar();
            adicionarItemsCb();
            refrescar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            adicionar();
            adicionarItemsCb();
            cancelar();
            refrescar();
        }

        private void frmCadastrarContrato_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            setCod();
            refrescar();
            foreach (DataGridViewColumn col in dataContrato.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void frmCadastrarContrato_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void cbContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbContrato_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionarItemsCb();
            adicionar();
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

        private void dataContrato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataContrato.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaContratos = ControllerContrato.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloContrato func in listaContratos)
            {
                txtCodigo.Text = func.getId() + "";
                txtNome.Text = func.getContrato();
            }
        }
    }
}
