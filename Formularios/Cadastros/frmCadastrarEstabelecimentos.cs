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
    public partial class frmCadastrarEstabelecimentos : Form
    {
        private int codigoCelSelecionada;
        public frmCadastrarEstabelecimentos()
        {
            InitializeComponent();
        }

        private void refrescar()
        {
            ArrayList listaEstabelecimentos = ControllerEstabelecimento.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Estabelecimento");
            foreach (ModeloEstabelecimento func in listaEstabelecimentos)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Estabelecimento"] = func.getEstabelecimento();
                dt.Rows.Add(dRow);
            }
            dataEst.DataSource = dt;
            dataEst.Refresh();
            dataEst.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            dataEst.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        public void gravar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerEstabelecimento.gravar(id, regime);
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerEstabelecimento.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerEstabelecimento.atualizar(id, regime);
        }

        private void confirmarFechamento()
        {
            DialogResult dialogResult = MessageBox.Show("Pretende fechar o formulário?", "Atenção!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                frmMenu f = new frmMenu();
                f.TopMost = true;
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        private int getCod()
        {
            ArrayList listaEstabelecimentos = ControllerEstabelecimento.recuperar();
            int cod = 0;
            foreach (ModeloEstabelecimento cat in listaEstabelecimentos)
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            adicionar();
            impedirBotoes();
            porFoco();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            cancelar();
            impedirBotoes();
            refrescar();
            porFoco();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            cancelar();
            impedirBotoes();
            refrescar();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            impedirBotoes();
            refrescar();
            porFoco();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
            impedirBotoes();
        }

        private void frmCadastrarEstabelecimentos_KeyDown(object sender, KeyEventArgs e)
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

        private void porFoco()
        {
            this.ActiveControl = txtNome;
        }

        private void frmCadastrarEstabelecimentos_Load(object sender, EventArgs e)
        {
            setCod();
            impedirBotoes();
            refrescar();
            foreach (DataGridViewColumn col in dataEst.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            porFoco();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void cbEstabelecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataEst_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataEst.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaEst = ControllerEstabelecimento.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloEstabelecimento func in listaEst)
            {
                txtCodigo.Text = func.getId() + "";
                txtNome.Text = func.getEstabelecimento();
            }
        }
    }
}
