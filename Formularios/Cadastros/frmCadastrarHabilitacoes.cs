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
            dt.Columns.Add("Habilitação");
            foreach (ModeloHabilitacao func in listaHabilitacoes)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Habilitação"] = func.getHabilitacao();
                dt.Rows.Add(dRow);
            }
            dataHabilitacoes.DataSource = dt;
            dataHabilitacoes.Refresh();
            dataHabilitacoes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
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
        private void limparCaixas()
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
            ArrayList listaHabilitacoes = ControllerHabilitacoes.recuperar();
            int id = int.Parse(txtCodigo.Text);
            String habilitacoes = txtNome.Text;
            int cod = 0;
            foreach (ModeloHabilitacao func in listaHabilitacoes)
            {
                if (func.getId() == id)
                {
                    cod = func.getId();
                }
            }
            if (cod != 0)
            {
                ControllerHabilitacoes.atualizar(id, habilitacoes);
                limparCaixas();
                mudarVisibilidadeLabels(false);
                refrescar();
            }
            else
            {
                ControllerHabilitacoes.gravar(id, habilitacoes);
                adicionar();
                refrescar();
            }
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerHabilitacoes.remover(id);
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

        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            refrescar();
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
            adicionar();
            refrescar();
            impedirBotoes();
        }

        private void porFoco()
        {
            this.ActiveControl = txtNome;
        }

        private void frmCadastrarHabilitacoes_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            refrescar();
            foreach (DataGridViewColumn col in dataHabilitacoes.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            porFoco();
        }

        private void frmCadastrarHabilitacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                if (btnAdicionar.Enabled)
                {
                    adicionar();
                }
            }
            if (e.KeyCode.ToString() == "F3")
            {
                if (btnAtualizar.Enabled)
                {
                    mudarVisibilidadeLabels(true);
                    atualizarBotoes();
                }
            }
            if (e.KeyCode.ToString() == "F4")
            {
                if (btnCancelar.Enabled)
                {
                    limparCaixas();
                    impedirBotoes();
                    mudarVisibilidadeLabels(false);
                }
            }
            if (e.KeyCode.ToString() == "F5")
            {
                if (btnConfirmar.Enabled)
                {
                    gravar();
                    impedirBotoes();
                }
            }
            if (e.KeyCode.ToString() == "F6")
            {
                if (btnEliminar.Enabled)
                {
                    eliminar();
                }
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
            atualizarBotoes();
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
            porFoco();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCaixas();
            impedirBotoes();
            mudarVisibilidadeLabels(false);
        }
    }
}
