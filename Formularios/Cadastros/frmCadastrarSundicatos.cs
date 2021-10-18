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
        ArrayList listaSindicatos = ControllerSindicato.recuperar();
        public frmCadastrarSundicatos()
        {
            InitializeComponent();
            impedirBotoes();
        }

        public void gravar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerSindicato.gravar(id, regime);
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerSindicato.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerSindicato.atualizar(id, regime);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            adicionar();
            adicionarItemsCb();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            cancelar();
            adicionarItemsCb();
        }

        private int getCod()
        {
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

        private void adicionarItemsCb()
        {
            cbSindicatos.Items.Clear();
            foreach (ModeloSindicato hab in listaSindicatos)
            {
                cbSindicatos.Items.Add(hab.getSindicato());
            }
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            cancelar();
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
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastrarSundicatos_KeyDown(object sender, KeyEventArgs e)
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

        private void frmCadastrarSundicatos_Load(object sender, EventArgs e)
        {
            setCod();
            adicionarItemsCb();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void cbSindicatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ModeloSindicato seg in listaSindicatos)
            {
                if (cbSindicatos.Text == seg.getSindicato())
                {
                    txtCodigo.Text = seg.getId() + "";
                    txtNome.Text = seg.getSindicato();
                }
            }
        }
    }
}
