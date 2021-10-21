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
    public partial class frmCadastrarHabilitacoes : Form
    {
        private int codigoCelSelecionada;
        public frmCadastrarHabilitacoes()
        {
            InitializeComponent();
            setCod();
            this.ActiveControl = txtNome;
        }

        private void refrescar()
        {
            ArrayList listaHabilitacoes = ControllerHabilitacoes.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Habilitações");
            foreach (ModeloHabilitacao func in listaHabilitacoes)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Habilitações"] = func.getHabilitacao();
                dt.Rows.Add(dRow);
            }
            dataHabilitacoes.DataSource = dt;
            dataHabilitacoes.Refresh();
            dataHabilitacoes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            dataHabilitacoes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private int getCod()
        {
            ArrayList listaHabilitacoes = ControllerHabilitacoes.recuperar();
            int cod = 0;
            foreach (ModeloHabilitacao cat in listaHabilitacoes)
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
        private void adicionar()
        {
            setCod();
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
        private void cancelar()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }


        private void setCod()
        {
            txtCodigo.Text = getCod() + 1 + "";
        }

        public void gravar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerHabilitacoes.gravar(id, regime);
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerHabilitacoes.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerHabilitacoes.atualizar(id, regime);
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            refrescar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            adicionar();
            refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            adicionar();
            refrescar();
        }

        private void frmCadastrarHabilitacoes_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            refrescar();
            foreach (DataGridViewColumn col in dataHabilitacoes.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void frmCadastrarHabilitacoes_KeyDown(object sender, KeyEventArgs e)
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

        private void cbHabilitacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbHabilitacoes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            refrescar();
        }

        private void dataHabilitacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataHabilitacoes.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaHabilitacoes = ControllerHabilitacoes.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloHabilitacao func in listaHabilitacoes)
            {
                txtCodigo.Text = func.getId() + "";
                txtNome.Text = func.getHabilitacao();
            }
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }
    }
}
