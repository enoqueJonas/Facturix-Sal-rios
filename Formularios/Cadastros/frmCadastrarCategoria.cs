﻿using System;
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
        ArrayList listaCategorias = ControllerCategoria.recuperar();
        public frmCadastrarCategoria()
        {
            InitializeComponent();
            setCod();
            this.ActiveControl = txtNome;
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
            cbCentro.Text = "";
        }
        private int getCod() 
        {
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

        private void adicionarItemsCb()
        {
            cbCentro.Items.Clear();
            foreach (ModeloCategoria hab in listaCategorias)
            {
                cbCentro.Items.Add(hab.getCategoria());
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            cancelar();
            adicionarItemsCb();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            adicionar();
            adicionarItemsCb();
            cancelar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            adicionar();
            adicionarItemsCb();
            cancelar();
        }

        private void frmCadastrarCategoria_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            adicionarItemsCb();
        }

        private void frmCadastrarCategoria_KeyDown(object sender, KeyEventArgs e)
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

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            adicionarItemsCb();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void cbCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ModeloCategoria seg in listaCategorias)
            {
                if (cbCentro.Text == seg.getCategoria())
                {
                    txtCodigo.Text = seg.getId() + "";
                    txtNome.Text = seg.getCategoria();
                }
            }
        }
    }
}