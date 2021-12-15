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
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
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
