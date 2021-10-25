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
    public partial class frmCadastrarContrato : Form
    {
        private int codigoCelSelecionada;
        public frmCadastrarContrato()
        {
            InitializeComponent();
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
            ArrayList listaContratos = ControllerContrato.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Contrato");
            foreach (ModeloContrato func in listaContratos)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Contrato"] = func.getContrato();
                dt.Rows.Add(dRow);
            }
            dataContrato.DataSource = dt;
            dataContrato.Refresh();
            dataContrato.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataContrato.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
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
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
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
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
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
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Default;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                btnAdicionar.Enabled = true;
                btnEliminar.Enabled = true;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private int getCod()
        {
            ArrayList listaContratos = ControllerContrato.recuperar();
            int cod = 0;
            foreach (ModeloContrato cat in listaContratos)
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
            int id = int.Parse(txtCodigo.Text);
            String contrato = txtNome.Text;
            ArrayList listaContratos = ControllerContrato.recuperar();
            int cod = 0;
            foreach (ModeloContrato func in listaContratos)
            {
                if (func.getId() == id)
                {
                    cod = func.getId();
                }
            }
            if (cod != 0)
            {
                ControllerContrato.atualizar(id, contrato);
                limparCaixas();
                mudarVisibilidadeLabels(false);
                refrescar();
            }
            else
            {
                ControllerContrato.gravar(id, contrato);
                adicionar();
                refrescar();
            }
        }

        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerContrato.remover(id);
        }

        public void modificar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerContrato.atualizar(id, regime);
        }

        private void adicionarItemsCb()
        {
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

        private void frmCadastrarContrato_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            setCod();
            refrescar();
            foreach (DataGridViewColumn col in dataContrato.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void frmCadastrarContrato_KeyDown(object sender, KeyEventArgs e)
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

        private void cbContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbContrato_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionarItemsCb();
            adicionar();
            refrescar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCaixas();
            impedirBotoes();
            mudarVisibilidadeLabels(false);
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }

        private void dataContrato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataContrato.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaContratos = ControllerContrato.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloContrato func in listaContratos)
            {
                txtCodigo.Text = func.getId() + "";
                txtNome.Text = func.getContrato();
            }
        }
    }
}
