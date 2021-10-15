using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;

namespace Facturix_Salários
{
    public partial class frmCadastrarFuncionarios : Form
    {
        String linkImagem = "";
        public frmCadastrarFuncionarios()
        {
            InitializeComponent();
            setCod();
            impedirBotoes();
            lerItems();
        }

        private void lerItems() 
        {
            ArrayList listaFunc = ControllerFuncionario.recuperar();
            foreach (ModeloFuncionario func in listaFunc) 
            {
                cbCategoria.Items.Add(func.getCategoria());
                cbContrato.Items.Add(func.getTipoContrato());
                cbProfissao.Items.Add(func.getProfissao());
                cbSeguro.Items.Add(func.getSeguro());
                cbLocalTrabalho.Items.Add(func.getLocalTrabalho());
                cbRegime.Items.Add(func.getRegime());
                cbHabilitacoes.Items.Add(func.getHabilitacoes());
            }
        }

        private void porFoco() 
        {
            this.ActiveControl = txtNome;
        }

        private void aceitarApenasNumeros(KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
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
        public void impedirBotoes()
        {
                if (txtNome.Text == "" || txtNrFiscal.Text == "")
                {
                    btnAtualizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnConfirmar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnAtualizar.FlatStyle = FlatStyle.Flat;
                    btnCancelar.FlatStyle = FlatStyle.Flat;
                    btnConfirmar.FlatStyle = FlatStyle.Flat;
                    btnEliminar.FlatStyle = FlatStyle.Flat;
                    btnImprimir.FlatStyle = FlatStyle.Flat;
                }
            else
                if (txtNome.Text != "" && txtNrFiscal.Text != "" )
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
                }
        }
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
                codPostal = 0;
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
            String dataNasc = dtNascimento.Text;
            String tipoContrato = cbContrato.Text;
            String dataAdmissao = dtDataAdmissao.Text;
            String dataDemissao = dtDataDemissao.Text;
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
            if (txtVencimento.Text == "" || txtAlimentacao.Text == "" || txtSubTransporte.Text == "" || txtHoraSemana.Text == "" || txtImpostoM.Text == "")
            {
                MessageBox.Show("Prencha os dados do salarios do funcionario!");
            }
            else { 
                vencimento = double.Parse(txtVencimento.Text);
                subAlimentacao = double.Parse(txtAlimentacao.Text);
                subTransporte = double.Parse(txtSubTransporte.Text);
                horas = float.Parse(txtHoraSemana.Text);
                impostoMunicipal = float.Parse(txtImpostoM.Text);
            }
            int dependentes;
            if (cbDependentes.Text == "")
            {
                dependentes = 0;
            }
            else {
                dependentes = int.Parse(cbDependentes.Text);
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
            if (getCod() == codigo)
            {
                MessageBox.Show("Funcionario ja esta registado! Clique no botao adicionar para poder adicionar novo funcionario!");
            }
            else if (linkImagem == "")
            {
                MessageBox.Show("Adcione a foto do funcionario!");
            }
            else 
            {
                ControllerFuncionario.Guardar(codigo, nome, cell, cellSec, telefone, email, estadoCivil, def, conj, sexo, dataNasc, linkImagem, codPostal, bairro, localidade, morada, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal,centroDeCusto, segurancaSocial);
                ControllerConta.Guardar(codigo, banco, nib, conta);
                adicionar();
                setCod();
            }
        }

        public void mostrar()
        {
            frmNumeroRegisto f = new frmNumeroRegisto();
            f.ShowDialog();
            int cod = f.enterdCod;
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(cod);
            ArrayList listaContas = ControllerConta.recuperarComCod(cod);
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
                pbFoto.Image = Image.FromFile(func.getLinkImagem());
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
                txtNrFiscal.Text = func.getNumeroFiscal()+"";
                txtVencimento.Text = func.getVencimento()+"";
                txtAlimentacao.Text = func.getSubAlimentacao()+"";
                txtSubTransporte.Text = func.getSubTransporte() + "";
                txtHoraSemana.Text = func.getHoras()+"";
                cbDependentes.Text = func.getDependentes()+"";
                txtNacionalidade.Text = func.getNacionalidade();
                txtUltimo.Text = func.getUltimoEmprego();
                cbTurno.Text = func.getTurno();
                txtImpostoM.Text = func.getImpostoMunicipal() + "";
                cbCentrocusto.Text = func.getCentroDeCusto();
                txtSeguranca.Text = func.getSegurancaSocial();
                foreach (ModeloConta conta in listaContas) {
                    if (cod == conta.idFuncionario) {
                        txtNrConta.Text = conta.conta;
                        txtNib.Text = conta.nib;
                        txtBanco.Text = conta.banco;
                    }
                }
            }
        }

        private void procurar(int cod)
        {
            //Procura na lista de funcionarios
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(cod);
            ArrayList listaContas = ControllerConta.recuperarComCod(cod);
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
                pbFoto.Image = Image.FromFile(func.getLinkImagem());
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
                cbDependentes.Text = func.getDependentes()+"";
                cbHabilitacoes.Text = func.getHabilitacoes();
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

        private void visualizar()
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            ArrayList listaContas = ControllerConta.recuperar();
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
                pbFoto.Image = Image.FromFile(func.getLinkImagem());
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
                int dependentes = int.Parse(cbDependentes.Text);
                txtNacionalidade.Text = func.getNacionalidade();
                txtUltimo.Text = func.getUltimoEmprego();
                cbTurno.Text = func.getTurno();
                txtImpostoM.Text = func.getImpostoMunicipal()+"";
                cbCentrocusto.Text = func.getCentroDeCusto();
                txtSeguranca.Text = func.getSegurancaSocial();
                foreach (ModeloConta conta in listaContas)
                {
                    if (func.getCodigo() == conta.idFuncionario)
                    {
                        txtNrConta.Text = conta.conta;
                        txtNib.Text = conta.nib;
                        txtBanco.Text = conta.banco;
                    }
                }
            }
        }

        private void modificar()
        {
            int codigo = int.Parse(txtCodigo.Text);
            String nome = txtNome.Text;
            String cell = txtCell.Text;
            String cellSec = txtCellSec.Text;
            String telefone = txtTel.Text;
            String email = txtEmail.Text;
            String estadoCivil = cbEstadoCivil.Text;
            String deficiencia = cbDeficiencia.Text;
            String conjugue = txtConjugue.Text;
            String sexo = cbSexo.Text;
            String moradaGen = txtMorada.Text;
            String bairro = txtBairro.Text;
            String localidade = txtLocalidade.Text;
            int codigoPostal = int.Parse(txtCodPostal.Text);
            String dataNasc = dtNascimento.Text;
            String tipoContrato = cbContrato.Text;
            String dataAdmissao = dtDataAdmissao.Text;
            String dataDemissao = dtDataDemissao.Text;
            String profissao = cbProfissao.Text;
            String categoria = cbCategoria.Text;
            String seguro = cbSeguro.Text;
            String localTrabalho = cbLocalTrabalho.Text;
            String regime = cbRegime.Text;
            String bi = txtBi.Text;
            String numeroBenificiario = txtNrBenificiario.Text;
            String numeroFiscal = txtNrFiscal.Text;
            double vencimento = double.Parse(txtVencimento.Text);
            double subAlimentacao = double.Parse(txtAlimentacao.Text);
            double subTransporte = double.Parse(txtSubTransporte.Text);
            float horas = float.Parse(txtHoraSemana.Text);
            int dependentes = int.Parse(cbDependentes.Text);
            String habilitacoes = cbHabilitacoes.Text;
            String banco = txtBanco.Text;
            String nib = txtNib.Text;
            String conta = txtNrConta.Text;
            String nacionalidade = txtNacionalidade.Text;
            String ultimoEmprego = txtUltimo.Text;
            String turno = cbTurno.Text;
            String centroDeCusto = cbCentrocusto.Text;
            String segurancaSocial = txtSeguranca.Text;
            float impostoMunicipal = float.Parse(txtImpostoM.Text);
            ControllerFuncionario.atualizar(codigo, nome, cell, cellSec, telefone, email, estadoCivil, deficiencia, conjugue, sexo, dataNasc, linkImagem, codigoPostal, bairro, localidade, moradaGen, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto, segurancaSocial);
            ControllerConta.atualizar(codigo, banco, nib, conta);
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
                    reportFuncionario rep = new reportFuncionario();
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
                MessageBox.Show("Nenhum funcionário com esse numero de registo existe na base de dados! Selecione um funcionário válido!");
            }
        }
        private void adicionar()
        {
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
            cbDependentes.Text = "";
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
            setCod();
            porFoco();
        }

        private void cancelar()
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
            cbDependentes.Text = "";
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
            porFoco();
        }
        private void remover()
        {
            
            int codigo = int.Parse(txtCodigo.Text);
            ControllerConta.remover(codigo);
            ControllerFuncionario.remover(codigo);
            cancelar();
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
        }

        private void txtNovo_Click(object sender, EventArgs e)
        {
            cancelar();
            impedirBotoes();
        }

        private void frmFuncionarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                adicionar();
            }
            if (e.KeyCode.ToString() == "F2")
            {
                mostrar();
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
                remover();
            }
            if (e.KeyCode.ToString() == "F7")
            {
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.Alt && e.KeyCode == Keys.I)
            {
                this.ActiveControl = btnCarregarImagem;
                e.SuppressKeyPress = true;
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            modificar();
            visualizar();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            remover(); 
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void f_funcionarios_Load(object sender, EventArgs e)
        {
            porFoco();
            impedirBotoes();
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProImages\";
            opFile.Title = "Select a Image";
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
                    MessageBox.Show("Nao foi possivel carregar a imagem " + exp.Message);
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
                    txtLink.Text = "";
                }
                else {
                    MessageBox.Show("Link de imagem invalido!");
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
            this.Close();
        }

        private void txtNrFiscal_TextChanged_1(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtNome_TextChanged_1(object sender, EventArgs e)
        {
            impedirBotoes();
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
    }
}
