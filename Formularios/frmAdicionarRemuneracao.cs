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
    public partial class frmAdicionarRemuneracao : Form
    {
        public String qtd, valorUnit;
        public frmAdicionarRemuneracao()
        {
            InitializeComponent();
        }

        private void frmAdicionarRemuneracao_Load(object sender, EventArgs e)
        {
            adicionarItemsCb();
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

        private void cbRemuneracoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
            String natureza = cbRemuneracoes.Text;
            frmCadastrarFuncionarios f = new frmCadastrarFuncionarios();
            foreach (ModeloRemuneracoes r in listaRemuneracoes)
            {
                if (natureza.Equals(r.getNatureza()) && r.getQuantidade() != "Definido pelo utilizador")
                {
                    txtqtd.Enabled = false;
                    txtqtd.ReadOnly = true;
                    f.qtd = r.getQuantidade();
                }
                else 
                {
                    txtqtd.Enabled = true;
                    txtqtd.ReadOnly = false;
                }
                if (natureza.Equals(r.getNatureza()) && r.getValorUnitario() != "Definido pelo utilizador")
                {
                    txtval.Enabled = false;
                    txtval.ReadOnly = true;
                    valorUnit = r.getValorUnitario();
                }
                else {
                    txtval.Enabled = true;
                    txtval.ReadOnly = false;
                }
            }
        }
    }
}
