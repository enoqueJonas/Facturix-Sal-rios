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
    public partial class frmCadastrarCategoria : Form
    {
        private int codigoCelSelecionada;
        public frmCadastrarCategoria()
        {
            InitializeComponent();
            setCod();
            this.ActiveControl = txtNome;
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
            dataCategorias.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            dataCategorias.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerCategoria.gravar(id, regime);
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerCategoria.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerCategoria.atualizar(id, regime);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            cancelar();
            refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            adicionar();
            cancelar();
            refrescar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            adicionar();
            cancelar();
            refrescar();
        }

        private void frmCadastrarCategoria_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            refrescar();
        }

        private void frmCadastrarCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                adicionar();
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
                this.Close();
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
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
            cancelar();
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
    }
}
