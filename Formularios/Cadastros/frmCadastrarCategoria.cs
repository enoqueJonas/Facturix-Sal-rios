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
using Facturix_Salários;

namespace Facturix_Salários
{
    public partial class frmCadastrarCategoria : Form
    {
        private int codigoCelSelecionada;
        public frmCadastrarCategoria()
        {
            InitializeComponent();
            setCod();
            this.ActiveControl = txtNome;
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

        private void refrescar()
        {
            ArrayList listaCategorias = ControllerCategoria.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Categoria");
            foreach (ModeloCategoria func in listaCategorias)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Categoria"] = func.getCategoria();
                dt.Rows.Add(dRow);
            }
            dataCategorias.DataSource = dt;
            dataCategorias.Refresh();
            tirarFocoCelula();
        }

        private void tirarFocoCelula() 
        {
            dataCategorias.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataCategorias.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private void impedirBotoes() 
        {
            if (txtNome.Text == "")
            {
                btnAdicionar.Enabled = true;
                btnCancelar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnConfirmar.Enabled = false;
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
        private int getCod() 
        {
            ArrayList listaCategorias = ControllerCategoria.recuperar();
            int cod = 0;
            foreach (ModeloCategoria cat in listaCategorias) 
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
            txtCodigo.Text = getCod() +  1 + "";
        }

        public void gravar()
        {
            ArrayList listaCategorias = ControllerCategoria.recuperar();
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            int cod = 0;
            foreach (ModeloCategoria func in listaCategorias)
            {
                if (func.getId() == id) 
                { 
                    cod = func.getId();
                }
            }
            if (cod != 0)
            {
                ControllerCategoria.atualizar(id, regime);
                limparCaixas();
                mudarVisibilidadeLabels(false);
                refrescar();
            }
            else 
            {
                ControllerCategoria.gravar(id, regime);
                adicionar();
                refrescar();
            }
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerCategoria.remover(id);
        }

        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            limparCaixas();
            refrescar();
            impedirBotoes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            adicionar();
            limparCaixas();
            refrescar();
            impedirBotoes();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
            atualizarBotoes();
        }

        private void frmCadastrarCategoria_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            refrescar();
            foreach (DataGridViewColumn col in dataCategorias.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void frmCadastrarCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                adicionar();
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

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            refrescar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCaixas();
            impedirBotoes();
        }

        private void cbCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataCategorias.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaCategoriaComCod = ControllerCategoria.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloCategoria func in listaCategoriaComCod)
            {
                txtCodigo.Text = func.getId()+"";
                txtNome.Text = func.getCategoria();
            }
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }
    }
}
