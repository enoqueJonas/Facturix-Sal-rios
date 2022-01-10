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
using Facturix_Salários.Modelos;
using Facturix_Salários.Controllers;

namespace Facturix_Salários.Formularios
{
    public partial class frmAdicionarRemuneracao : Form { 
    
        public frmAdicionarRemuneracao()
        {
            InitializeComponent();
        }

        public String natureza;
        public int cod = 0, qtd = 0;
        public float valorUnit = 0;
        private void frmAdicionarRemuneracao_Load(object sender, EventArgs e)
        {
            adicionarItemsCb();
            txtval.LostFocus += new EventHandler(txtval_LostFocus);
        }

        private void adicionarItemsCb() 
        {
            cbRemuneracoes.Items.Clear();
            ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
            foreach (ModeloRemuneracoes r in listaRemuneracoes) 
            {
                cbRemuneracoes.Items.Add(r.getNatureza());
            }
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtval_LostFocus(object sender, EventArgs e)
        {
            if (txtval.Text != "")
            {
                txtval.Text = string.Format("{0:#,##0.00}", double.Parse(txtval.Text));
            }
        }

        private int getCodFuncionarioRemu() 
        {
            int cod = 0;
            ArrayList lista = ControllerFuncionarioRemuneracoes.recuperar();
            foreach (ModeloFuncionarioRemuneracoes f in lista) 
            {
                if (f.getId()!=0) 
                {
                    cod = f.getId();
                }
            }
            return cod;
        }

        private void frmAdicionarRemuneracao_KeyDown(object sender, KeyEventArgs e)
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

        private void adicionar() 
        {
            ArrayList listaRemuneracoes = ControllerFuncionarioRemuneracoes.recuperar();
            ArrayList lista = ControllerRemuneracoes.recuperar();
            int idRem = 0;
            int idFunc = 0;
            String natureza = cbRemuneracoes.Text;
            if (txtqtd.Text != "")
                qtd = int.Parse(txtqtd.Text);

            if (txtval.Text != "")
                valorUnit = float.Parse(txtval.Text);

            if (txtIdFuncionario.Text != "")
                idFunc = int.Parse(txtIdFuncionario.Text);

            //if(txtIdRemuneracao.Text!="")
            //    idRem = int.Parse(txtIdFuncionario.Text);

            foreach (ModeloRemuneracoes r in lista)
            {
                if (r.getNatureza().Equals(natureza))
                    idRem = r.getId();
            }

            Boolean existe = false;
            foreach (ModeloFuncionarioRemuneracoes r in listaRemuneracoes)
            {
                if (idFunc == r.getIdFuncionario() && idRem == r.getIdRemuneracao())
                {
                    cod = r.getId();
                    existe = true;
                }
            }
            if (existe)
            {
                ControllerFuncionarioRemuneracoes.atualizar(cod, idFunc, idRem, valorUnit, qtd);
            }
            else
            {
                cod = getCodFuncionarioRemu() + 1;
                ControllerFuncionarioRemuneracoes.gravar(cod, idFunc, idRem, valorUnit, qtd);
            }
            this.Close();
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

        private void cbRemuneracoes_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtqtd_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtIdFuncionario_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtval_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down) 
            {
                btnConfirmar.Focus();
            }
        }

        private void txtIdRemuneracao_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            adicionar();
        }

        private void cbRemuneracoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
            String natureza = cbRemuneracoes.Text;
            frmCadastrarFuncionarios f = new frmCadastrarFuncionarios();
            //foreach (ModeloRemuneracoes r in listaRemuneracoes)
            //{
            //    if (natureza.Equals(r.getNatureza()) && r.getQuantidade() != "Definido pelo utilizador")
            //    {
            //        txtqtd.Enabled = false;
            //        txtqtd.ReadOnly = true;
            //        f.qtd = r.getQuantidade();
            //    }
            //    else 
            //    {
            //        txtqtd.Enabled = true;
            //        txtqtd.ReadOnly = false;
            //    }
            //    if (natureza.Equals(r.getNatureza()) && r.getValorUnitario() != "Definido pelo utilizador")
            //    {
            //        txtval.Enabled = false;
            //        txtval.ReadOnly = true;
            //        valorUnit = r.getValorUnitario();
            //    }
            //    else {
            //        txtval.Enabled = true;
            //        txtval.ReadOnly = false;
            //    }
            //}
        }
    }
}
