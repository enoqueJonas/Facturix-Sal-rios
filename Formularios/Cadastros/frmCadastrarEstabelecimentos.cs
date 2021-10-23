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
            dataEst.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataEst.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        public void gravar()
        {
            ArrayList listaEstabelecimentos = ControllerEstabelecimento.recuperar();
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            int cod = 0;
            foreach (ModeloEstabelecimento func in listaEstabelecimentos)
            {
                if (func.getId() == id)
                {
                    cod = func.getId();
                }
            }
            if (cod != 0)
            {
                ControllerEstabelecimento.atualizar(id, regime);
                limparCaixas();
                mudarVisibilidadeLabels(false);
                refrescar();
            }
            else
            {
                ControllerEstabelecimento.gravar(id, regime);
                adicionar();
                refrescar();
            }
        }

        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerEstabelecimento.remover(id);
        }

        private void confirmarFechamento()
        {
            DialogResult dialogResult = MessageBox.Show("Pretende fechar o formulário?", "Atenção!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                frmMenu f = new frmMenu();
                f.Focus();
                f.ShowDialog();
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
            limparCaixas();
            setCod();
        }

        private void limparCaixas()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }

        private void impedirBotoes()
        {
            if (txtNome.Text == "" || txtCodigo.Text == "")
            {
                btnAdicionar.Enabled = true;
                btnCancelar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
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

        private void atualizarBotoes()
        {
            if (lbl1.Visible == true)
            {
                btnAdicionar.Enabled = false;
                btnEliminar.Enabled = false;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnAdicionar.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                btnAdicionar.Enabled = true;
                btnEliminar.Enabled = true;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            adicionar();
            impedirBotoes();
            porFoco();
            impedirBotoes();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
            atualizarBotoes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            limparCaixas();
            impedirBotoes();
            refrescar();
            impedirBotoes();
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
            limparCaixas();
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
                mudarVisibilidadeLabels(true);
                atualizarBotoes();
            }
            if (e.KeyCode.ToString() == "F4")
            {
                limparCaixas();
                impedirBotoes();
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
            atualizarBotoes();
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
