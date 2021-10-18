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
    public partial class frmCadastrarSeguro : Form
    {
        ArrayList listaSeguros = ControllerSeguro.recuperar();
        public frmCadastrarSeguro()
        {
            InitializeComponent();
            setCod();
            this.ActiveControl = txtNome;
            impedirBotoes();
        }

        private int getCod()
        {
            int cod = 0;
            foreach (ModeloSeguro cat in listaSeguros)
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

        private void impedirBotoes()
        {
            if (txtNome.Text == "")
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
                btnCancelar.FlatStyle = FlatStyle.Standard;
            }
            if (txtNome.Text != "" && txtPercentagem.Text != "")
            {
                btnAtualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnConfirmar.Enabled = true;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnAtualizar.FlatStyle = FlatStyle.Standard;
            }
            else 
            {
                btnAtualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnAtualizar.FlatStyle = FlatStyle.Flat;
            }
        }
        private void adicionar() 
        {
            cancelar();
            setCod();
        }

        private void cancelar() 
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtPercentagem.Text = "";
            cbSeguros.Text = "";
        }
        private void setCod()
        {
            txtCodigo.Text = getCod() + 1 + "";
        }
        public void gravar() 
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            float percentagem = float.Parse(txtPercentagem.Text) ;
            ControllerSeguro.gravar(id, regime, percentagem);
        }

        public void eliminar() 
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerSeguro.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            float percentagem = float.Parse(txtPercentagem.Text);
            ControllerSeguro.atualizar(id, regime, percentagem);
        }

        private void adicionarItemsCb()
        {
            cbSeguros.Items.Clear();
            foreach (ModeloSeguro hab in listaSeguros)
            {
                cbSeguros.Items.Add(hab.getSeguro());
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
            adicionar();
            adicionarItemsCb();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            adicionar();
            adicionarItemsCb();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastrarSeguro_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            adicionarItemsCb();
        }

        private void frmCadastrarSeguro_KeyDown(object sender, KeyEventArgs e)
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

        private void cbRegime_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            impedirBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void txtPercentagem_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void cbSeguros_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ModeloSeguro seg in listaSeguros)
            {
                if (cbSeguros.Text == seg.getSeguro())
                {
                    txtCodigo.Text = seg.getId() + "";
                    txtNome.Text = seg.getSeguro();
                    txtPercentagem.Text = seg.getPercentagem() + "";
                }
            }
        }
    }
}
