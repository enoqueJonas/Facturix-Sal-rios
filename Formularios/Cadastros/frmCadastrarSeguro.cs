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
        private int codigoCelSelecionada;
        public frmCadastrarSeguro()
        {
            InitializeComponent();
            setCod();
            porFoco();
        }

        private void porFoco() 
        {
            this.ActiveControl = txtPercentagem;
        }
        private void refrescar()
        {
            ArrayList listaSeguros = ControllerSeguro.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Seguros");
            dt.Columns.Add("Percentagem");
            foreach (ModeloSeguro func in listaSeguros)
            {
                DataRow dRow = dt.NewRow();
                dRow["ID"] = func.getId();
                dRow["Seguros"] = func.getSeguro();
                dRow["Percentagem"] = func.getPercentagem()+"%";
                dt.Rows.Add(dRow);
            }
            dataSeguro.DataSource = dt;
            dataSeguro.Refresh();
            dataSeguro.Columns["Percentagem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataSeguro.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataSeguro.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private int getCod()
        {
            ArrayList listaSeguros = ControllerSeguro.recuperar();
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
                btnAdicionar.Enabled = true;
                btnCancelar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
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
            limparCaixas();
            setCod();
        }

        private void limparCaixas() 
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtPercentagem.Text = "";
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
            ArrayList listaSeguros = ControllerSeguro.recuperar();
            int cod = 0;
            foreach (ModeloSeguro func in listaSeguros)
            {
                if (func.getId() == id)
                {
                    cod = func.getId();
                }
            }
            if (cod != 0)
            {
                ControllerSeguro.atualizar(id, regime, percentagem);
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

        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
            lbl2.Visible = estado;
        }

        public void eliminar() 
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerSeguro.remover(id);
        }

        private void confirmarFechamento()
        {
            DialogResult dialogResult = MessageBox.Show("Pretende fechar o formulário?", "Atenção!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                frmMenu f = new frmMenu();
                f.Focus();
                f.ShowDialog(); ;
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }


        Control ctrl;
        private void mexerTeclado(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (ctrl is TextBox)
            {
                if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down || e.Alt && e.KeyCode == Keys.Right)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.Alt && e.KeyCode == Keys.Up || e.Alt && e.KeyCode == Keys.Left)
                {
                    this.SelectNextControl(ctrl, false, true, true, true);
                }
                else
                    return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.KeyCode == Keys.Up && e.Control)
                {
                    this.SelectNextControl(ctrl, false, true, true, true);
                }
                else
                    return;
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
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
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
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
            adicionar();
            refrescar();
            impedirBotoes();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
            atualizarBotoes();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }

        private void frmCadastrarSeguro_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            refrescar();
            foreach (DataGridViewColumn col in dataSeguro.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            porFoco();
        }

        private void frmCadastrarSeguro_KeyDown(object sender, KeyEventArgs e)
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

        private void cbRegime_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            porFoco();
            adicionar();
            impedirBotoes();
            refrescar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCaixas();
            impedirBotoes();
            mudarVisibilidadeLabels(false);
        }

        private void txtPercentagem_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
            atualizarBotoes();
        }

        private void cbSeguros_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataSeguro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataSeguro.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaEst = ControllerSeguro.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloSeguro func in listaEst)
            {
                txtCodigo.Text = func.getId() + "";
                txtNome.Text = func.getSeguro();
                txtPercentagem.Text = func.getPercentagem()+"";
            }
        }

        private void txtPercentagem_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtNome_KeyDown_1(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }
    }
}
