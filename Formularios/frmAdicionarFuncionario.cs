using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturix_Salários.Formularios
{
    public partial class frmAdicionarFuncionario : Form
    {
        public decimal id;
        public String nome, venciemnto, subAlimentacao;
        public frmAdicionarFuncionario()
        {
            InitializeComponent();
        }

        private void frmAdicionarFuncionario_Load(object sender, EventArgs e)
        {
            nrRegistoNumero.Value = getCod() + 1;
            txtVencimento.LostFocus += new EventHandler(txtVencimento_LostFocus);
            txtAlimentacao.LostFocus += new EventHandler(txtAlimentacao_LostFocus);
            txtNome.Focus();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdicionarFuncionario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F5")
            {
                adicionar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        Control ctrl;
        private void mexerTeclado(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (ctrl is TextBox || ctrl is ComboBox || ctrl is DateTimePicker || ctrl is Button)
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
                else if (e.KeyCode == Keys.Up && e.Alt)
                {
                    this.SelectNextControl(ctrl, false, true, true, true);
                }
                else
                    return;
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        private void adicionar() 
        {
            id = nrRegistoNumero.Value;
            nome = txtNome.Text;
            venciemnto = txtVencimento.Text;
            subAlimentacao = txtAlimentacao.Text;
            frmCadastrarFuncionarios f = new frmCadastrarFuncionarios();
            f.txtCodigo.Text = id + "";
            f.txtNome.Text = nome;
            f.txtVencimento.Text = venciemnto;
            f.txtAlimentacao.Text = subAlimentacao;
            f.Show();
            this.Close();
            frmVisualizarFuncionario frm = new frmVisualizarFuncionario();
            frm.Close();
        }

        private void nrRegistoNumero_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtAlimentacao_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down) 
            {
                btnConfirmar.Focus();
            }
        }

        private void txtVencimento_Leave(object sender, EventArgs e)
        {
            //if (txtVencimento.Text != "") 
            //{
            //    txtVencimento.Text = string.Format("{0:#,##0.00}", double.Parse(txtVencimento.Text));
            //}
        }

        private void txtVencimento_LostFocus(object sender, EventArgs e)
        {
            if (txtVencimento.Text != "")
            {
                txtVencimento.Text = string.Format("{0:#,##0.00}", double.Parse(txtVencimento.Text));
            }
        }
        
        private void txtAlimentacao_LostFocus(object sender, EventArgs e)
        {
            if (txtAlimentacao.Text != "")
            {
                txtAlimentacao.Text = string.Format("{0:#,##0.00}", double.Parse(txtAlimentacao.Text));
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            adicionar();
        }
        private int getCod()
        {
            int cod = 0;
            ArrayList listaFunc = ControllerFuncionario.recuperar();
            foreach (ModeloFuncionario func in listaFunc)
            {
                cod = func.getCodigo();
            }
            return cod;
        }
    }
}
