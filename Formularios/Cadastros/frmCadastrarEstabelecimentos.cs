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
        ArrayList listaEstabelecimentos = ControllerEstabelecimento.recuperar();
        public frmCadastrarEstabelecimentos()
        {
            InitializeComponent();
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

        private int getCod()
        {
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

        private void adicionarItemsCb()
        {
            cbEstabelecimento.Items.Clear();
            foreach (ModeloEstabelecimento hab in listaEstabelecimentos)
            {
                cbEstabelecimento.Items.Add(hab.getEstabelecimento());
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            adicionar();
            impedirBotoes();
            adicionarItemsCb();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            cancelar();
            impedirBotoes();
            adicionarItemsCb();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            cancelar();
            impedirBotoes();
            adicionarItemsCb();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            impedirBotoes();
            adicionarItemsCb();
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
                this.Close();
            }
        }

        private void frmCadastrarEstabelecimentos_Load(object sender, EventArgs e)
        {
            setCod();
            impedirBotoes();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void cbEstabelecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ModeloEstabelecimento seg in listaEstabelecimentos)
            {
                if (cbEstabelecimento.Text == seg.getEstabelecimento())
                {
                    txtCodigo.Text = seg.getId() + "";
                    txtNome.Text = seg.getEstabelecimento();
                }
            }
        }
    }
}
