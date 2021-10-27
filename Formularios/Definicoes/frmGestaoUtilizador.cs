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
using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Formularios.Definicoes
{
    public partial class frmGestaoUtilizador : Form
    {
        private int codigoCelSelecionada;
        public frmGestaoUtilizador()
        {
            InitializeComponent();
        }
        private void impedirBotoes()
        {
            if (txtNome.Text == "" || txtPass.Text == "" || txtApelido.Text == "" || txtEmail.Text == "" || txtContacto.Text == "" || cbNivel.Text == "")
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
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
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
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void tirarFocoCelula()
        {
            dataUtilizadores.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataUtilizadores.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private void refrescar()
        {
            ArrayList listaUtilizadores = ControllerUtilizador.recuperar();
            montarDataGridView(listaUtilizadores);
        }

        private int getCod()
        {
            ArrayList listaUtilizadores = ControllerUtilizador.recuperar();
            int cod = 0;
            foreach (ModeloUtilizador cat in listaUtilizadores)
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
            txtRegisto.Text = getCod() + 1 + "";
        }

        private void alinharTextoCabecalhoCelulas()
        {
            foreach (DataGridViewColumn col in dataUtilizadores.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void limparCaixas()
        {
            txtRegisto.Text = "";
            txtNome.Text = "";
            txtApelido.Text = "";
            txtEmail.Text = "";
            txtContacto.Text = "";
            cbNivel.Text = "";
        }

        private void adicionar()
        {
            limparCaixas();
            setCod();
        }
        private void mostrarLabels(Boolean estado)
        {
            lbl1.Visible = estado;
            lbl2.Visible = estado;
            lbl3.Visible = estado;
            lbl4.Visible = estado;
            lbl5.Visible = estado;
            lbl6.Visible = estado;
            lbl7.Visible = estado;
            lbl8.Visible = estado;
            lbl9.Visible = estado;
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            porFoco();
            impedirBotoes();
        }

        private void gravar()
        {
            int id = int.Parse(txtRegisto.Text);
            String nome = txtNome.Text;
            String apelido = txtApelido.Text;
            String contacto = txtContacto.Text;
            String password = txtPass.Text;
            String nivel = cbNivel.Text;
            String email = txtEmail.Text;
            String nomeUtilizador = txtNomeUtilizador.Text;
            String dataNascimento = dtNascimento.Value.ToString("yyyy-MM-dd");
            int cod = 0;
            ArrayList listaUtilizadores = ControllerUtilizador.recuperar();
            foreach (ModeloUtilizador cat in listaUtilizadores)
            {
                if (id == cat.getId())
                {
                    cod = cat.getId();
                }
            }
            if (cod == 0)
            {
                ControllerUtilizador.Guardar(id, nome, apelido, password, email, contacto, nivel, nomeUtilizador, dataNascimento);
                limparCaixas();
            }
            else
            {
                ControllerUtilizador.atualizar(id, nome, apelido, password, email, contacto, nivel, nomeUtilizador, dataNascimento);
                mostrarLabels(false);
                limparCaixas();
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

        private void montarDataGridView(ArrayList lista)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Nível");
            foreach (ModeloUtilizador func in lista)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Nome"] = func.getNome();
                dRow["Nível"] = func.getNivel();
                dt.Rows.Add(dRow);
            }
            dataUtilizadores.DataSource = dt;
            dataUtilizadores.Refresh();
            tirarFocoCelula();
        }

        private void mostrar()
        {
            frmNumeroRegisto f = new frmNumeroRegisto();
            f.ShowDialog();
            int cod = f.enterdCod;
            ArrayList listaFuncionarios = ControllerUtilizador.recuperarComCodigo(cod);
            montarTextBoxs(listaFuncionarios);
        }

        private void montarTextBoxs(ArrayList lista) 
        {
            foreach (ModeloUtilizador u in lista)
            {
                txtRegisto.Text = u.getId() + "";
                txtNome.Text = u.getNome();
                txtApelido.Text = u.getApelido();
                txtNomeUtilizador.Text = u.getNomeUtilizador();
                txtEmail.Text = u.getEmail();
                txtContacto.Text = u.getContacto();
                cbNivel.Text = u.getNivel();
                dtNascimento.Value = Convert.ToDateTime(u.getDataNascimento());
                txtPass.Text = u.getPassword();
            }
        }
        private void porFoco()
        {
            this.ActiveControl = txtNome;
        }
        private void eliminar()
        {
            int id = int.Parse(txtRegisto.Text);
            ControllerUtilizador.remover(id);
            limparCaixas();
        }

        private void frmGestaoUtilizador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1" && btnAdicionar.Enabled)
            {
                porFoco();
                adicionar();
                impedirBotoes();
            }
            if (e.KeyCode.ToString() == "F2" && btnConsultar.Enabled)
            {
                mostrar();
            }
            if (e.KeyCode.ToString() == "F3" && btnAtualizar.Enabled)
            {
                mostrarLabels(true);
                atualizarBotoes();
            }
            if (e.KeyCode.ToString() == "F4" && btnCancelar.Enabled)
            {
                limparCaixas();
                mostrarLabels(false);
                impedirBotoes();
            }
            if (e.KeyCode.ToString() == "F5" && btnConfirmar.Enabled)
            {
                gravar();
                impedirBotoes();
                refrescar();
            }
            if (e.KeyCode.ToString() == "F6" && btnEliminar.Enabled)
            {
                eliminar();
                limparCaixas();
                impedirBotoes();
                refrescar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                confirmarFechamento();
            }
        }

        private void frmGestaoUtilizador_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            refrescar();
            setCod();
            alinharTextoCabecalhoCelulas();
            mostrarLabels(false);
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            adicionar();
            porFoco();
            impedirBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCaixas();
            mostrarLabels(false);
            impedirBotoes();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            impedirBotoes();
            refrescar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mostrarLabels(true);
            atualizarBotoes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            limparCaixas();
            impedirBotoes();
            refrescar();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtApelido_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtNomeUtilizador_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtContacto_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void cbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void dtNascimento_ValueChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void dataUtilizadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataUtilizadores.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaUtilizadores = ControllerUtilizador.recuperarComCodigo(codigoCelSelecionada);
            montarTextBoxs(listaUtilizadores);
        }
    }
}
