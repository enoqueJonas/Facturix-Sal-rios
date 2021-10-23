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
    public partial class frmCadastrarProfissao : Form
    {
        private int codigoCelSelecionada;
        public frmCadastrarProfissao()
        {
            InitializeComponent();
            setCod();
            this.ActiveControl = txtNome;
        }

        private void refrescar()
        {
            ArrayList listaProfissao = ControllerProfissao.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Profissões");
            foreach (ModeloProfissao func in listaProfissao)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Profissões"] = func.getProfissao();
                dt.Rows.Add(dRow);
            }
            dataProfissao.DataSource = dt;
            dataProfissao.Refresh();
            dataProfissao.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataProfissao.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private int getCod()
        {
            ArrayList listaProfissao = ControllerProfissao.recuperar();
            int cod = 0;
            foreach (ModeloProfissao cat in listaProfissao)
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
        private void impedirBotoes()
        {
            if (txtNome.Text == "")
            {
                btnAdicionar.Enabled = true;
                btnAtualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
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

        public void gravar()
        {
            ArrayList listaProfissoes = ControllerProfissao.recuperar();
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            int cod = 0;
            foreach (ModeloProfissao func in listaProfissoes)
            {
                if (func.getId() == id)
                {
                    cod = func.getId();
                }
            }
            if (cod != 0)
            {
                ControllerProfissao.atualizar(id, regime);
                limparCaixas();
                mudarVisibilidadeLabels(false);
                refrescar();
            }
            else
            {
                ControllerProfissao.gravar(id, regime);
                adicionar();
                refrescar();
            }
            adicionar();
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerProfissao.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerProfissao.atualizar(id, regime);
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
        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            refrescar();
            impedirBotoes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            limparCaixas();
            refrescar();
            impedirBotoes();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
            atualizarBotoes();
        }

        private void frmCadastrarProfissao_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            refrescar();
            foreach (DataGridViewColumn col in dataProfissao.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void frmCadastrarProfissao_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
            atualizarBotoes();
        }

        private void cbProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbProfissoes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCaixas();
            impedirBotoes();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }

        private void dataProfissao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataProfissao.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaEst = ControllerProfissao.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloProfissao func in listaEst)
            {
                txtCodigo.Text = func.getId() + "";
                txtNome.Text = func.getProfissao();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            refrescar();
        }
    }
}
