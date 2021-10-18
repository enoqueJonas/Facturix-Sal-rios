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
        ArrayList listaProfissao = ControllerProfissao.recuperar();
        public frmCadastrarProfissao()
        {
            InitializeComponent();
            setCod();
            this.ActiveControl = txtNome;
        }

        private int getCod()
        {
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

        public void gravar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerProfissao.gravar(id, regime);
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
        private void adicionarItemsCb()
        {
            cbProfissoes.Items.Clear();
            foreach (ModeloProfissao hab in listaProfissao)
            {
                cbProfissoes.Items.Add(hab.getProfissao());
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            adicionarItemsCb();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            cancelar();
            adicionarItemsCb();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            cancelar();
            adicionarItemsCb();
        }

        private void frmCadastrarProfissao_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            adicionarItemsCb();
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

        private void cbProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbProfissoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ModeloProfissao seg in listaProfissao)
            {
                if (cbProfissoes.Text == seg.getProfissao())
                {
                    txtCodigo.Text = seg.getId() + "";
                    txtNome.Text = seg.getProfissao();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
