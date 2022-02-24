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
using System.Threading;

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
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível conectar a base de dados! Contacte o suporte técnico!" +tel);
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

        void abrirFormListagemFunc() 
        {
            frmVisualizarFuncionario f = new frmVisualizarFuncionario();
            //if (InvokeRequired)
            //{
            //    // after we've done all the processing, 
            //    this.Invoke(new MethodInvoker(delegate
            //    {
                    // load the control with the appropriate data
                    f.Show();
            //    }));
            //    return;
            //}
            f.Focus();
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (frmLoadingScreen l = new frmLoadingScreen(abrirFormListagemFunc)) 
            //{
            //    l.ShowDialog(this);
            //}
            abrirFormListagemFunc();
        }

        private void seguro()
        {
            frmCadastrarSeguro f = new frmCadastrarSeguro();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void segurosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(seguro))
            {
                l.ShowDialog(this);
            }
        }


        private void abrirFrmCadastrarCategoria() 
        {
            frmCadastrarCategoria f = new frmCadastrarCategoria();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmCadastrarCategoria))
            {
                l.ShowDialog(this);
            }
        }


        private void abrirFrmCadastrarContratos() 
        {
            frmCadastrarContrato f = new frmCadastrarContrato();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void contratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmCadastrarContratos))
            {
                l.ShowDialog(this);
            }
        }

        private void abirFrmCadastrarProfissao()
        {
            frmCadastrarProfissao f = new frmCadastrarProfissao();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void profissãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abirFrmCadastrarProfissao))
            {
                l.ShowDialog(this);
            }
        }


        private void abrirFrmCadastrarHabilitacao() 
        {
            frmCadastrarHabilitacoes f = new frmCadastrarHabilitacoes();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void habilitaçõToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmCadastrarHabilitacao))
            {
                l.ShowDialog(this);
            }
        }


        private void abrirFrmCadastrarSindicato() 
        {
            frmCadastrarSundicatos f = new frmCadastrarSundicatos();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void sindicatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmCadastrarSindicato))
            {
                l.ShowDialog(this);
            }
        }


        private void abrirFrmCadastrarEstabelecimentos() 
        {
            frmCadastrarEstabelecimentos f = new frmCadastrarEstabelecimentos();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void estabelecimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmCadastrarEstabelecimentos))
            {
                l.ShowDialog(this);
            }
        }


        private void abrirFrmCadastrarCentroDeCusto() 
        {
            frmCadastrarCentrosDeCusto f = new frmCadastrarCentrosDeCusto();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void centrosDeCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmCadastrarCentroDeCusto))
            {
                l.ShowDialog(this);
            }
        }

        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            
        }


        private void abrirFrmGestaoDeUtilizadores() 
        {
            frmGestaoUtilizador f = new frmGestaoUtilizador();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void gestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmGestaoDeUtilizadores))
            {
                l.ShowDialog(this);
            }
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


        private void abrirFrmIrps() 
        {
            frmCadastrarIRPS f = new frmCadastrarIRPS();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void iRPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmIrps))
            {
                l.ShowDialog(this);
            }
        }


        private void abrirFrmConectarScanner() 
        {
            frmConectarFPScanner f = new frmConectarFPScanner();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void conectarScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmConectarScanner))
            {
                l.ShowDialog(this);
            }
        }

        private void relógioDePontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void abrirFrmConfiguracao() 
        {
            frmNomeDaEmpresa f = new frmNomeDaEmpresa();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void configuraçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmConfiguracao))
            {
                l.ShowDialog(this);
            }
        }

        private void abrirFrmProcesamento() 
        {
            frmProcessamentoEmLote f = new frmProcessamentoEmLote();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void processamentoSaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmProcesamento))
            {
                l.ShowDialog(this);
            }
        }

        private void individualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcessamentoIndividual f = new frmProcessamentoIndividual();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }


        private void abrirFrmListagemFuncionarios() 
        {
            frmListagemFuncionarios f = new frmListagemFuncionarios();
            //if (InvokeRequired)
            //{
            //    // after we've done all the processing, 
            //    this.Invoke(new MethodInvoker(delegate
            //    {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
            //        f.TopMost = true;
            //    }));
            //    return;
            //}
        }
        private void listagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFrmListagemFuncionarios();
        }

        private void abrirFrmRemuneracoes() 
        {
            frmTabelaDeRemuneracoes f = new frmTabelaDeRemuneracoes();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void remuneraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmRemuneracoes))
            {
                l.ShowDialog(this);
            }
        }

        private void abrirFrmAdiantamentos() 
        {
            frmListagemFuncionariosAdiantamentos f = new frmListagemFuncionariosAdiantamentos();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    // load the control with the appropriate data
                    f.Show();
                    f.Focus();
                    f.TopMost = true;
                }));
                return;
            }
        }
        private void adiantamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLoadingScreen l = new frmLoadingScreen(abrirFrmAdiantamentos))
            {
                l.ShowDialog(this);
            }
        }

        private void pontualidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListagemDeFuncionariosDiasDeTrabalho f = new frmListagemDeFuncionariosDiasDeTrabalho();
            f.Show();
        }
    }
}
