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
            this.ActiveControl = txtPercentagem;
            impedirBotoes();
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
            dataSeguro.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
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

        private void confirmarFechamento()
        {
            DialogResult dialogResult = MessageBox.Show("Pretende fechar o formulário?", "Atenção!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                frmMenu f = new frmMenu();
                f.TopMost = true;
                f.Show();
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
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            adicionar();
            refrescar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            cancelar();
            refrescar();
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
        }

        private void frmCadastrarSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
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
                confirmarFechamento();
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
            refrescar();
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
