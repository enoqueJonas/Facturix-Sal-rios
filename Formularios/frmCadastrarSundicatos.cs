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
        }

        private void refrescar()
        {
            ArrayList listaSindicatos = ControllerSindicato.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Sindicato");
            foreach (ModeloSindicato func in listaSindicatos)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = func.getId();
                dRow["Sindicato"] = func.getSindicato();
                dt.Rows.Add(dRow);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        public void gravar()
        {
            ArrayList listaSindicatos = ControllerSindicato.recuperar();
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            int cod = 0;
            foreach (ModeloSindicato func in listaSindicatos)
            {
                if (func.getId() == id)
                {
                    cod = func.getId();
                }
            }
            if (cod != 0)
            {
                ControllerSindicato.atualizar(id, regime);
                limparCaixas();
                mudarVisibilidadeLabels(false);
                refrescar();
            }
            else
            {
                ControllerSindicato.gravar(id, regime);
                adicionar();
                refrescar();
            }
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerSindicato.remover(id);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            adicionar();
            refrescar();
            porFoco();
            impedirBotoes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            limparCaixas();
            refrescar();
            impedirBotoes();
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
            DialogResult dialogResult = MessageBox.Show("Pretende fechar o formulário Cadastro de Seguros?", "Atenção!", MessageBoxButtons.YesNo);
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

        private void porFoco() 
        {
            this.ActiveControl = txtNome;
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
                btnCancelar.FlatStyle = FlatStyle.Flat;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
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

        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
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
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
            atualizarBotoes();
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
            mudarVisibilidadeLabels(false);
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastrarSundicatos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == "F1" && btnAdicionar.Enabled)
            {
                adicionar();
            }
            if (e.KeyCode.ToString() == "F3" && btnAtualizar.Enabled)
            {
                mudarVisibilidadeLabels(true);
                atualizarBotoes();
            }
            if (e.KeyCode.ToString() == "F4" && btnCancelar.Enabled)
            {
                limparCaixas();
                impedirBotoes();
                mudarVisibilidadeLabels(false);
            }
            if (e.KeyCode.ToString() == "F5" && btnConfirmar.Enabled)
            {
                gravar();
                impedirBotoes();
            }
            if (e.KeyCode.ToString() == "F6" && btnEliminar.Enabled)
            {
                eliminar();
            }
            if (e.KeyCode.ToString() == "F7")
            {
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmCadastrarSundicatos_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            setCod();
            refrescar();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
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

        private void frmCadastrarSundicatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (MessageBox.Show("Pretende retornar ao menu geral?", "Atenção!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }
    }
}
