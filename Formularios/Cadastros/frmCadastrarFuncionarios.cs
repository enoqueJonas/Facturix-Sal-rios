using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;

namespace Facturix_Salários
{
    public partial class frmCadastrarFuncionarios : Form
    {
        String linkImagem = "";
        ArrayList listaCategorias = ControllerCategoria.recuperar();
        ArrayList listaContratos = ControllerContrato.recuperar();
        ArrayList listaHabilitacoes = ControllerHabilitacoes.recuperar();
        ArrayList listaProfissao = ControllerProfissao.recuperar();
        ArrayList listaSeguros = ControllerSeguro.recuperar();
        private int codigoCelSelecionada;
        public frmCadastrarFuncionarios()
        {
            InitializeComponent();
            setCod();
            adicionarItemsCb();
        }
        
        /// <summary>Monta a lista de dependestes na DataGridView.</summary>
        private void refrescarDependentes() 
        {
            int idFunc = int.Parse(txtCodigo.Text);
            ArrayList listaDependentes = ControllerDependente.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Data Nasc.");
            dt.Columns.Add("Grau Parent.");
            foreach (ModeloDependente func in listaDependentes)
            {
                if (idFunc == func.getIdFuncionario()) 
                {
                    DataRow dRow = dt.NewRow();
                    dRow["ID"] = func.getId();
                    dRow["Nome"] = func.getNome();
                    dRow["Data Nasc."] = func.getDataNascimento();
                    dRow["Grau Parent."] = func.getGrauParentesco();
                    dt.Rows.Add(dRow);
                }
            }
            dataDependentes.DataSource = dt;
            dataDependentes.Refresh();
            dataDependentes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataDependentes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        /// <summary>Adiciona Items como seguro, contrato... nas ComboBox.</summary>
        private void adicionarItemsCb() 
        {
            foreach (ModeloCategoria cat in listaCategorias)
            {
                cbCategoria.Items.Add(cat.getCategoria());
            }
            foreach (ModeloContrato cont in listaContratos)
            {
                cbContrato.Items.Add(cont.getContrato());
            }
            foreach (ModeloHabilitacao hab in listaHabilitacoes)
            {
                cbHabilitacoes.Items.Add(hab.getHabilitacao());
            }
            foreach (ModeloProfissao prof in listaProfissao)
            {
                cbProfissao.Items.Add(prof.getProfissao());
            }
            foreach (ModeloSeguro seg in listaSeguros)
            {
                cbSeguro.Items.Add(seg.getSeguro());
            }
        }

        /// <summary>Ativa ou distativa(dependendo do parametro recebiodo) as labels do modo edição.</summary>
        private void mostrarLabels(Boolean estado) 
        {
            lblMod1.Visible = estado;
            lblMod2.Visible = estado;
            lblMod3.Visible = estado;
            lblMod4.Visible = estado;
            lblMod5.Visible = estado;
            lblMod6.Visible = estado;
            lblMod7.Visible = estado;
            lblMod8.Visible = estado;
            lblMod9.Visible = estado;
            lblMod10.Visible = estado;
            lblMod11.Visible = estado;
            lblMod12.Visible = estado;
            lblMod13.Visible = estado;
            lblMod14.Visible = estado;
            lblMod15.Visible = estado;
            lblMod16.Visible = estado;
            lblMod17.Visible = estado;
            lblMod18.Visible = estado;
            lblMod19.Visible = estado;
            lblMod20.Visible = estado;
            lblMod21.Visible = estado;
            lblMod22.Visible = estado;
            lblMod23.Visible = estado;
            lblMod24.Visible = estado;
            lblMod25.Visible = estado;
            lblMod26.Visible = estado;
            lblMod27.Visible = estado;
            lblMod28.Visible = estado;
            lblMod29.Visible = estado;
            lblMod30.Visible = estado;
            lblMod31.Visible = estado;
            lblMod32.Visible = estado;
            lblMod33.Visible = estado;
            lblMod34.Visible = estado;
            lblMod35.Visible = estado;
            lblMod36.Visible = estado;
            lblMod37.Visible = estado;
            lblMod38.Visible = estado;
            lblMod39.Visible = estado;
            lblMod40.Visible = estado;
            lblMod41.Visible = estado;
            lblMod42.Visible = estado;
        }

        /// <summary>Foca na TextBox txtNome.</summary>
        private void porFoco() 
        {
            this.ActiveControl = txtNome;
        }

        /// <summary>Restringe Textboxs para apenas aceitar números.</summary>
        private void aceitarApenasNumeros(KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        /// <summary>Adiciona na TextBox txtCodigo o ID do registo a seguir.</summary>
        private void setCod()
        {
            int cod = 0;
            ArrayList listaFunc = ControllerFuncionario.recuperar();
            foreach (ModeloFuncionario func in listaFunc)
            {
                cod = func.getCodigo();
            }
            txtCodigo.Text = cod + 1 + ""; ;
        }

        /// <summary>Procura o último ID do do registo.</summary>
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

        /// <summary>Controla que botões ficam ativos dependendo das TextBox preenchidas.</summary>
        public void impedirBotoes()
        {
            //|| txtNrFiscal.Text == ""
            if (txtNome.Text == "" )
                {
                    btnAdicionar.Enabled = true;
                    btnAtualizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnConfirmar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnAdicionar.FlatStyle = FlatStyle.Standard;
                    btnAtualizar.FlatStyle = FlatStyle.Flat;
                    btnCancelar.FlatStyle = FlatStyle.Flat;
                    btnConfirmar.FlatStyle = FlatStyle.Flat;
                    btnEliminar.FlatStyle = FlatStyle.Flat;
                    btnImprimir.FlatStyle = FlatStyle.Flat;
                    btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
                    btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                    btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                    btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
                if (txtNome.Text != "" )
                {
                    btnAtualizar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnConfirmar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnImprimir.Enabled = true;
                    btnAtualizar.FlatStyle = FlatStyle.Standard;
                    btnCancelar.FlatStyle = FlatStyle.Standard;
                    btnConfirmar.FlatStyle = FlatStyle.Standard;
                    btnEliminar.FlatStyle = FlatStyle.Standard;
                    btnImprimir.FlatStyle = FlatStyle.Standard;
                    btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        /// <summary>Grava na base de dados se o registo não existie, e atualiza se existir.</summary>
        private void gravar  ()
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            int codigo = int.Parse(txtCodigo.Text);
            String nome = txtNome.Text;
            String morada = txtMorada.Text;
            String bairro = txtBairro.Text;
            int codPostal;
            if (txtCodPostal.Text == "")
            {
                codPostal = 0000;
            }
            else {
                codPostal = int.Parse(txtCodPostal.Text);
            }
            String cell = txtCell.Text;
            String telefone = txtTel.Text;
            String email = txtEmail.Text;
            String cellSec = txtCellSec.Text;
            String sexo = cbSexo.Text;
            String localidade = txtLocalidade.Text;
            String estadoCivil = cbEstadoCivil.Text;
            String def = cbDeficiencia.Text;
            String conj;
            if (txtConjugue.Text == "")
            {
                conj = "Solteiro";
            }
            else
            {
                conj = txtConjugue.Text;
            }
            String dataNasc = dtNascimento.Value.ToString("yyyy-MM-dd");
            String tipoContrato = cbContrato.Text;
            String dataAdmissao = dtDataAdmissao.Value.ToString("yyyy-MM-dd");
            String dataDemissao = dtDataDemissao.Value.ToString("yyyy-MM-dd");
            String profissao = cbProfissao.Text;
            String categoria = cbCategoria.Text;
            String seguro = cbSeguro.Text;
            String localTrabalho = cbLocalTrabalho.Text;
            String regime = cbRegime.Text;
            String bi = txtBi.Text;
            String numeroBenificiario = txtNrBenificiario.Text;
            String numeroFiscal = txtNrFiscal.Text;
            double vencimento = 0;
            double subAlimentacao = 0;
            double subTransporte = 0;
            float horas = 0;
            float impostoMunicipal = 0;
            if (txtImpostoM.Text == "%")
                txtImpostoM.Text = "";
            if (txtVencimento.Text == "")
            {
                vencimento = 0;
            }
            else 
            {
                vencimento = double.Parse(txtVencimento.Text);
            }
            if (txtAlimentacao.Text == "")
            {
                subAlimentacao = 0;
            }
            else 
            {
                subAlimentacao = double.Parse(txtAlimentacao.Text);
            }
            if (txtSubTransporte.Text == "")
            {
                subTransporte = 0;
            }
            else 
            {
                subTransporte = double.Parse(txtSubTransporte.Text);
            }
            if (txtHoraSemana.Text == "")
            {
                horas = 0;
            }
            else 
            {
                horas = float.Parse(txtHoraSemana.Text);
            }
            if (txtImpostoM.Text == "")
            {
                impostoMunicipal = 0;
            }
            else 
            {
                impostoMunicipal = float.Parse(txtImpostoM.Text);
            }
            /*
            if (txtVencimento.Text == "" || txtAlimentacao.Text == "" || txtSubTransporte.Text == "" || txtHoraSemana.Text == "" || txtImpostoM.Text == "")
            {
                MessageBox.Show("Prencha os dados do salario do funcionario!");
            }
            else { 
                vencimento = double.Parse(txtVencimento.Text);
                subAlimentacao = double.Parse(txtAlimentacao.Text);
                subTransporte = double.Parse(txtSubTransporte.Text);
                horas = float.Parse(txtHoraSemana.Text);
                impostoMunicipal = float.Parse(txtImpostoM.Text);
            }
            */
            int dependentes;
            if (txtNrDependentes.Text == "")
            {
                dependentes = 0;
            }
            else {
                dependentes = int.Parse(txtNrDependentes.Text);
            }
            String habilitacoes = cbHabilitacoes.Text;
            String banco = txtBanco.Text;
            String nib = txtNib.Text;
            String conta = txtNrConta.Text;
            String nacionalidade = txtNacionalidade.Text;
            String ultimoEmprego = txtUltimo.Text;
            String turno = cbTurno.Text;
            String centroDeCusto = cbCentrocusto.Text;
            String segurancaSocial = txtSeguranca.Text;
            String sindicato = cbSindicato.Text;
            int cod = 0;
            foreach (ModeloFuncionario func in listaFuncionarios)
            {
                if (func.getCodigo() == codigo) 
                {
                    cod = func.getCodigo();
                }
            }
            if (cod!=0)
            {
                ControllerFuncionario.atualizar(codigo, nome, cell, cellSec, telefone, email, estadoCivil, def, conj, sexo, dataNasc, linkImagem, codPostal, bairro, localidade, morada, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto, segurancaSocial, sindicato);
                ControllerConta.Guardar(codigo, banco, nib, conta);
                limparCaixas();
                mostrarLabels(false);
            }
            else 
            {
                ControllerFuncionario.Guardar(codigo, nome, cell, cellSec, telefone, email, estadoCivil, def, conj, sexo, dataNasc, linkImagem, codPostal, bairro, localidade, morada, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal,centroDeCusto, segurancaSocial, sindicato);
                ControllerConta.Guardar(codigo, banco, nib, conta);
                adicionar();
                setCod();
            }
        }

        /// <summary>Monta no form os dados do registo.</summary>
        private void montarCaixasDeTexto(ArrayList listaFuncionarios, ArrayList listaContas, int cod) 
        {
            foreach (ModeloFuncionario func in listaFuncionarios)
            {
                txtCodigo.Text = func.getCodigo() + "";
                txtNome.Text = func.getNome();
                txtConjugue.Text = func.getConjugue();
                txtEmail.Text = func.getEmail();
                txtCell.Text = func.getCell();
                txtCellSec.Text = func.getCellSec();
                txtTel.Text = func.getTel();
                cbSexo.Text = func.getSexo();
                cbEstadoCivil.Text = func.getEstadoCivil();
                cbDeficiencia.Text = func.getDeficiencia();
                dtNascimento.Value = Convert.ToDateTime(func.getDataNascimento());
                if (System.IO.File.Exists(func.getLinkImagem()))
                {
                    pbFoto.Image = Image.FromFile(func.getLinkImagem());
                }
                else 
                {
                    pbFoto.Image = null;
                }
                txtCodPostal.Text = func.getCodigoPostal() + "";
                txtMorada.Text = func.getMoradaGen();
                txtBairro.Text = func.getBairro();
                txtLocalidade.Text = func.getLocalidade();
                cbContrato.Text = func.getTipoContrato();
                dtDataAdmissao.Value = Convert.ToDateTime(func.getDataAdmissao());
                dtDataDemissao.Value = Convert.ToDateTime(func.getDataDemissao());
                cbProfissao.Text = func.getProfissao();
                cbCategoria.Text = func.getCategoria();
                cbSeguro.Text = func.getSeguro();
                cbLocalTrabalho.Text = func.getLocalTrabalho();
                cbRegime.Text = func.getRegime();
                txtBi.Text = func.getBi();
                txtNrBenificiario.Text = func.getNumeroBenificiario();
                txtNrFiscal.Text = func.getNumeroFiscal() + "";
                txtVencimento.Text = func.getVencimento() + "";
                txtAlimentacao.Text = func.getSubAlimentacao() + "";
                txtSubTransporte.Text = func.getSubTransporte() + "";
                txtHoraSemana.Text = func.getHoras() + "";
                txtNrDependentes.Text = func.getDependentes() + "";
                txtNacionalidade.Text = func.getNacionalidade();
                txtUltimo.Text = func.getUltimoEmprego();
                cbTurno.Text = func.getTurno();
                txtImpostoM.Text = func.getImpostoMunicipal() + "";
                cbCentrocusto.Text = func.getCentroDeCusto();
                txtSeguranca.Text = func.getSegurancaSocial();
                foreach (ModeloConta conta in listaContas)
                {
                    if (cod == conta.idFuncionario)
                    {
                        txtNrConta.Text = conta.conta;
                        txtNib.Text = conta.nib;
                        txtBanco.Text = conta.banco;
                    }
                }
            }
        }

        /// <summary>Permite pesquisar no registo.</summary>
        public void mostrar()
        {
            frmNumeroRegisto f = new frmNumeroRegisto();
            f.ShowDialog();
            int cod = f.enterdCod;
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(cod);
            ArrayList listaContas = ControllerConta.recuperarComCod(cod);
            montarCaixasDeTexto(listaFuncionarios, listaContas, cod);
        }

        private void procurar(int cod)
        {
            //Procura na lista de funcionarios
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(cod);
            ArrayList listaContas = ControllerConta.recuperarComCod(cod);
            montarCaixasDeTexto(listaFuncionarios, listaContas, cod);
            limparCaixasDependente();
        }

        private void imprimir() 
        {
            ArrayList listaFunc = ControllerFuncionario.recuperar();
            int codTextBox = int.Parse(txtCodigo.Text);
            int codFuncionario = 0;
            foreach (ModeloFuncionario func in listaFunc)
            {
                if (codTextBox == func.getCodigo()) 
                {
                    codFuncionario = func.getCodigo();
                }
            }

            if (codTextBox == codFuncionario)
            {
                frmReportFuncionario f = new frmReportFuncionario();
                f.Show();
                MySqlConnection conexao = Conexao.conectar();
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand("SELECT nome, email, numeroFiscal FROM funcionario where id="+codTextBox+"", conexao);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "funcionario");
                    Reports.reportFuncionario rep = new Reports.reportFuncionario();
                    rep.SetDataSource(ds);
                    f.crDataTable.ReportSource = rep;
                    f.crDataTable.Refresh();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message.Trim(), "Nao foi possivel preencher report");
                }
                finally
                {
                    if (conexao != null)
                        conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Nenhum funcionário com esse número de registo existe na base de dados! Selecione um funcionário válido!");
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
            txtMorada.Text = "";
            txtBairro.Text = "";
            txtCodPostal.Text = "";
            txtCell.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            txtCellSec.Text = "";
            cbSexo.Text = "";
            txtLocalidade.Text = "";
            cbEstadoCivil.Text = "";
            cbDeficiencia.Text = "";
            txtConjugue.Text = "";
            pbFoto.Image = null;
            cbHabilitacoes.Text = "";
            cbLocalTrabalho.Text = "";
            txtNrDependentes.Text = "";
            cbProfissao.Text = "";
            txtNib.Text = "";
            txtNrBenificiario.Text = "";
            txtNrFiscal.Text = "";
            txtVencimento.Text = "";
            txtSubTransporte.Text = "";
            txtAlimentacao.Text = "";
            txtHoraSemana.Text = "";
            dtNascimento.Value = DateTime.Now;
            dtDataAdmissao.Value = DateTime.Now;
            dtDataDemissao.Value = DateTime.Now;
            cbContrato.Text = "";
            cbLocalTrabalho.Text = "";
            cbSeguro.Text = "";
            cbHabilitacoes.Text = "";
            txtBi.Text = "";
            txtNrConta.Text = "";
            txtBanco.Text = "";
            cbCategoria.Text = "";
            cbRegime.Text = "";
            txtUltimo.Text = "";
            txtNacionalidade.Text = "";
            txtImpostoM.Text = "";
            cbTurno.Text = "";
            cbCentrocusto.Text = "";
            txtSeguranca.Text = "";
            cbSindicato.Text = "";
            porFoco();
        }
        private void remover()
        {
            int codigoFun = int.Parse(txtCodigo.Text);
            ControllerConta.remover(codigoFun);
            ControllerFuncionario.remover(codigoFun);
            limparCaixas();
        }

        private void gravarDependente() 
        {
            ArrayList listaFunc = ControllerFuncionario.recuperar();
            int idFunc = int.Parse(txtCodigo.Text);
            String nome = txtNomeDep.Text;
            String dt = dtNascimentoDep.Value.Date.ToString("yyyy-MM-dd");
            String dataNasc = dt.Substring(0,9);
            String grauParen = cbParentescoDep.Text;
            ControllerDependente.Guardar(idFunc, nome, dataNasc, grauParen);
            limparCaixasDependente();
            refrescarDependentes();
        }

        private void modificarDependente() 
        {
            String nome = txtNomeDep.Text;
            string dataNasc = dtNascimentoDep.Text;
            string grauParen = cbParentescoDep.Text;
            ControllerDependente.atualizar(codigoCelSelecionada, nome, dataNasc, grauParen);
            limparCaixasDependente();
            refrescarDependentes();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            impedirBotoes();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            int cod = 0;
            if (txtCodigo.Text == "")
            {
                cod = getCod();
            }
            else
            {
                cod = int.Parse(txtCodigo.Text) + 1;
            }
            procurar(cod);
            impedirBotoes();
            refrescarDependentes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int cod = 0;
            if (txtCodigo.Text == "")
            {
                cod = getCod();
            }
            else 
            {
                cod = int.Parse(txtCodigo.Text) - 1;
            }
            procurar(cod);
            impedirBotoes();
            refrescarDependentes();
        }

        private void txtNovo_Click(object sender, EventArgs e)
        {
            limparCaixas();
            impedirBotoes();
            mostrarLabels(false);
        }

        private void frmFuncionarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                if (btnAdicionar.Enabled) 
                {
                    porFoco();
                    adicionar();
                }
            }
            if (e.KeyCode.ToString() == "F2")
            {
                if (btnMostrar.Enabled) 
                {
                    mostrar();
                }
            }
            if (e.KeyCode.ToString() == "F3")
            {
                if (btnAtualizar.Enabled) 
                {
                    mostrarLabels(true);
                    atualizarBotoes();
                }
            }
            if (e.KeyCode.ToString() == "F4")
            {
                if (btnCancelar.Enabled) 
                {
                    limparCaixas();
                    mostrarLabels(false);
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
                    remover();
                }
            }
            if (e.KeyCode.ToString() == "F7")
            {
            }
            if (e.KeyCode == Keys.Escape)
            {
                confirmarFechamento();
            }
            if (e.Alt && e.KeyCode == Keys.I)
            {
                this.ActiveControl = btnCarregarImagem;
                e.SuppressKeyPress = true;
            }
            if (e.Alt && e.KeyCode == Keys.C) 
            {
                gravarDependente();
            }
            if (e.Alt && e.KeyCode == Keys.M)
            {
                modificarDependente();
            }
            if (e.Alt && e.KeyCode == Keys.C)
            {
                limparCaixasDependente();
            }
            if (e.Alt && e.KeyCode == Keys.E)
            {
                eliminarDependente();
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mostrarLabels(true);
            atualizarBotoes();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            remover();
            impedirBotoes();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
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

        private void atualizarBotoes()
        {
            if (lblMod1.Visible == true)
            {
                btnAdicionar.Enabled = false;
                btnImprimir.Enabled = false;
                btnMostrar.Enabled = false;
                btnEliminar.Enabled = false;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnMostrar.FlatStyle = FlatStyle.Flat;
                btnImprimir.FlatStyle = FlatStyle.Flat;
                btnAdicionar.FlatStyle = FlatStyle.Flat;
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Default;
                btnImprimir.Cursor = System.Windows.Forms.Cursors.Default;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                btnMostrar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                btnMostrar.Enabled = true;
                btnImprimir.Enabled = true;
                btnEliminar.Enabled = true;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnImprimir.FlatStyle = FlatStyle.Standard;
                btnMostrar.FlatStyle = FlatStyle.Standard;
                btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }
        private void f_funcionarios_Load(object sender, EventArgs e)
        {
            //porFoco();
            impedirBotoes();
            refrescarDependentes();
            foreach (DataGridViewColumn col in dataDependentes.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            mudarLarguraCelulas();
        }

        /// <summary>Muda Largura das DataGridView Cells.</summary>
        private void mudarLarguraCelulas() 
        {
            dataDependentes.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataDependentes.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataDependentes.Columns["Data Nasc."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataDependentes.Columns["Grau Parent."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataDependentes.Columns["ID"].Width = 70;
            dataDependentes.Columns["Nome"].Width = 370;
            dataDependentes.Columns["Data Nasc."].Width = 105;
            dataDependentes.Columns["Grau Parent."].Width = 163;
        }
        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Control ctrl;
        /// <summary>Permite navegar no Form usando setas e o ENTER.</summary>
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

        private void txtBi_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);

        }

  

        private void txtMorada_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMorada_KeyDown(object sender, KeyEventArgs e)
        {

            mexerTeclado(sender, e);
        }

        private void txtBairro_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtCodPostal_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtLocalidade_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtCell_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtCellSec_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void dtNascimento_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbSexo_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbEstadoCivil_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtConjugue_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void dtNascimento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtBi_KeyDown_1(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtNrBenificiario_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtNrFiscal_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtNrFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtBanco_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtAlimentacao_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtNib_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtSubTransporte_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtNrConta_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrar();
            impedirBotoes();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProImages\";
            opFile.Title = "Selecione uma imagem";
            opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = opFile.SafeFileName;
                    linkImagem = opFile.FileName;
                    File.Copy(linkImagem, appPath + iName);
                    pbFoto.Image = new Bitmap(opFile.OpenFile());
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Não foi possível carregar a imagem " + exp.Message);
                }
            }
            else
            {
                opFile.Dispose();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            impedirBotoes();
        }

        private void cbDeficiencia_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbContrato_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void dtDataAdmissao_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void dtDataDemissao_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbProfissao_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbLocalTrabalho_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbRegime_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbHabilitacoes_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbDependentes_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtHoraSemana_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void btnCarregarImagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                mexerTeclado(sender, e);
            }
        }

        private void txtHoraSemana_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbDependentes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNrBenificiario_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtLink_KeyDown(object sender, KeyEventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProImages\";
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(appPath) == false)
                {
                    Directory.CreateDirectory(appPath);
                }
                if (System.IO.File.Exists(txtLink.Text))
                {
                    pbFoto.ImageLocation = txtLink.Text;
                    linkImagem = txtLink.Text;
                    string iName = Path.GetExtension(linkImagem);
                    File.Copy(linkImagem, appPath + iName);
                    txtLink.Text = "";
                }
                else {
                    MessageBox.Show("Link de imagem inválido!");
                }
                e.SuppressKeyPress = true;
            }
        }

        private void txtLink_MouseClick(object sender, MouseEventArgs e)
        {
            txtLink.Text = "";
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            confirmarFechamento();
        }

        private void txtNrFiscal_TextChanged_1(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtNome_TextChanged_1(object sender, EventArgs e)
        {
            impedirBotoes();
            atualizarBotoes();
        }

        private void txtHoraSemana_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void txtNrConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void txtNib_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void txtAlimentacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void txtSubTransporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void cbDependentes_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void txtCodPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void txtImpostoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            aceitarApenasNumeros(e);
        }

        private void txtNacionalidade_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender,e);
        }

        private void txtSeguro_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtUltimo_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtSeguranca_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbCentrocusto_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbTurno_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtImpostoM_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
            txtSeguro.Text = "";
        }

        private void btnImprimir_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir(); 
        }

        private void txtLink_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ModeloSeguro seg in listaSeguros)
            {
                if (cbSeguro.Text == seg.getSeguro())
                    txtSeguro.Text = seg.getPercentagem() + "";
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionarDep_Click(object sender, EventArgs e)
        {
            gravarDependente();
        }

        private void btnModificarDep_Click(object sender, EventArgs e)
        {
            modificarDependente();
        }

        private void limparCaixasDependente() 
        {
            txtNomeDep.Text = "";
            cbParentescoDep.Text = "";
            dtNascimentoDep.Value = DateTime.Now;
        }

        private void eliminarDependente() 
        {
            ControllerDependente.remover(codigoCelSelecionada);
            refrescarDependentes();
        }
        private void btnCancelarDep_Click(object sender, EventArgs e)
        {
            limparCaixasDependente();
        }

        private void btnEliminarDep_Click(object sender, EventArgs e)
        {
            eliminarDependente();
        }

        private void dataDependentes_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataDependentes.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaDependentes = ControllerDependente.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloDependente func in listaDependentes)
            {
                txtNomeDep.Text = func.getNome();
                dtNascimentoDep.Value = Convert.ToDateTime(func.getDataNascimento());
                cbParentescoDep.Text = func.getGrauParentesco();
            }
        }

        private void txtNomeDep_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void dtNascimentoDep_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbParentescoDep_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtMorada_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCodPostal_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtLocalidade_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCell_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCellSec_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void dtNascimento_ValueChanged_1(object sender, EventArgs e)
        {
        }

        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtConjugue_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNrDependentes_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbDeficiencia_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtNacionalidade_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dtDataAdmissao_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
