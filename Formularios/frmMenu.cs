using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using Facturix_Salários.Formularios.Definicoes;
using Facturix_Salários.Formularios.Cadastros;
using Facturix_Salários.Formularios;
using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;
using Facturix_Salários.Conexoes;
using ZDC2911Demo.Entity;

namespace Facturix_Salários
{
    public partial class frmMenu : Form
    {
        public Boolean ligacaoBaseDados;
        private string tel = "+258 863451038";
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
                gravarItems();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível conectar a base de dados! Contacte o suporte técnico!" +tel);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
            //carregarMenu();
        }

        private void carregarMenu() 
        {
            ArrayList listaMenus = ControllerPermissao.recuperar();
            foreach (ModeloPermissao f in listaMenus) 
            {
                for (int i = 0; i<menuStrip1.Items.Count; i++) 
                {
                    if (f.getCabecalho().ToLower().Equals(menuStrip1.Items[i].Text.ToLower()))
                    {
                        menuStrip1.Items[i].Visible = true;
                    }
                    else 
                    {
                        menuStrip1.Items[i].Visible = false;
                    }
                }
            }
        }
        private int getCod()
        {
            int cod = 0;
            ArrayList listaTabelas = ControllerTabela.recuperar();
            foreach (ModeloTabela cat in listaTabelas)
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

        private void gravarItems() 
        {
            ControllerTabela.remover();
            int id;
            String nome, label;
            ArrayList listaTabelas = ControllerTabela.recuperar();
            foreach (ToolStripMenuItem itm in menuStrip1.Items)
            {
                foreach (ToolStripDropDownItem item in itm.DropDownItems)
                {
                    id = getCod() + 1;
                    nome = item.Name;
                    label = item.Text;
                    ControllerTabela.gravar(id, nome, label);
                }
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

        private void gestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestaoUtilizador f = new frmGestaoUtilizador();
            f.Show();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (MessageBox.Show("Pretende fechar o Menu?", "Atenção!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void iRPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarIRPS f = new frmCadastrarIRPS();
            f.Show();
        }

        private void conectarScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConectarFPScanner f = new frmConectarFPScanner();
            f.Show();
        }

        private void relógioDePontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void configuraçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNomeDaEmpresa f = new frmNomeDaEmpresa();
            f.Show();
        }

        private void processamentoSaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcessamentoEmLote f = new frmProcessamentoEmLote();
            f.Show();
        }

        private void individualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcessamentoIndividual f = new frmProcessamentoIndividual();
            f.Show();
        }

        private void listagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListagemFuncionarios f = new frmListagemFuncionarios();
            f.Show();
        }
    }
}
