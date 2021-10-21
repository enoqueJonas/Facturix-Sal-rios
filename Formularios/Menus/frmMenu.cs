using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using Facturix_Salários;

namespace Facturix_Salários
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void f_menu_Load(object sender, EventArgs e)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
            }
            catch (Exception) 
            {
                MessageBox.Show("Não foi possível conectar a base de dados! Contacte o técnico!");
            }     
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dd(object sender, DragEventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
        private void refrescar()
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            MySqlConnection conexao = Conexao.conectar();
            foreach(ModeloFuncionario func in listaFuncionarios)
            {
                ListViewItem item = new ListViewItem();
                item.Text = func.getCodigo() + "";
                item.SubItems.Add(func.getNome());
                item.SubItems.Add(func.getCell());
                item.SubItems.Add(func.getCellSec());
                item.SubItems.Add(func.getTel());
                item.SubItems.Add(func.getEmail());
                item.SubItems.Add(func.getEstadoCivil());
                item.SubItems.Add(func.getDeficiencia());
                item.SubItems.Add(func.getConjugue());
                item.SubItems.Add(func.getSexo());
            }
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisualizarFuncionario f = new frmVisualizarFuncionario();
            f.Show();
        }

        private void segurosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarSeguro f = new frmCadastrarSeguro();
            f.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarCategoria f = new frmCadastrarCategoria();
            f.Show();
        }

        private void contratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarContrato f = new frmCadastrarContrato();
            f.Show();
        }

        private void profissãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarProfissao f = new frmCadastrarProfissao();
            f.Show();
        }

        private void habilitaçõToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarHabilitacoes f = new frmCadastrarHabilitacoes();
            f.Show();
        }

        private void sindicatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarSundicatos f = new frmCadastrarSundicatos();
            f.Show();
        }

        private void estabelecimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarEstabelecimentos f = new frmCadastrarEstabelecimentos();
            f.Show();
        }

        private void centrosDeCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarCentrosDeCusto f = new frmCadastrarCentrosDeCusto();
            f.Show();
        }

        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
