using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;
using Facturix_Salários.Reports;
using MySql.Data.MySqlClient;

namespace Facturix_Salários.Formularios
{
    public partial class frmProcessamentoEmLote : Form
    {
        private int nrMes, diasDeTrabalho, codigoCelSelecionada;
        private void dataProcessamentoSalario_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {         
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                                                                            
            }
        }

        private void dataProcessamentoSalario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        public int diasDeTrabalhoRecebidos;

        private void dataProcessamentoSalario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = dataProcessamentoSalario.Rows[rowIndex];
                codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
                if (cbMes.Text == "")
                {
                    MessageBox.Show("Selecione um mês válido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(codigoCelSelecionada);
                    ArrayList listaIrps = ControllerIRPS.recuperar();
                    //ArrayList listaDependentes = ControllerDependente.recuperarComCodFuncionario(codigoCelSelecionada);
                    String nome = "", estado = "";
                    frmProcessamentoIndividual f = new frmProcessamentoIndividual();
                    int codIrps = 0;
                    double valorIrps = 0, emprestimo = 0, ipa = 0, adiantamentos = 0, vencimento = 0, outroSub = 0, subAlimentacao = 0;
                    diasDeTrabalho = getDiasDeTrabalho(codigoCelSelecionada);
                    Boolean existe = existeProcessamento(codigoCelSelecionada);
                    if (existe == false)
                    {
                        foreach (ModeloFuncionario func in listaFuncionarios)
                        {
                            nome = func.getNome();
                            emprestimo = 0;
                            ipa = func.getImpostoMunicipal();
                            adiantamentos = 0;
                            codIrps = func.getIdIRPS();
                            vencimento = Math.Round(func.getVencimento(), 2, MidpointRounding.AwayFromZero);
                            subAlimentacao = func.getSubAlimentacao();
                        }

                        foreach (ModeloIRPS conta in listaIrps)
                        {
                            if (codIrps == conta.getId())
                            {
                                valorIrps = conta.getValor();
                            }
                        }
                        ArrayList listaRemenuracoes = ControllerRemuneracoes.recuperar();
                        ArrayList listaFuncRemuneracao = ControllerFuncionarioRemuneracoes.recuperar();
                        foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracao)
                        {
                            if (codigoCelSelecionada == fr.getIdFuncionario())
                            {
                                foreach (ModeloRemuneracoes r in listaRemenuracoes)
                                {
                                    outroSub = (fr.getValor() * fr.getQtd()) + outroSub;
                                }
                            }

                        }
                        if (diasDeTrabalho != 0 && diasDeTrabalho != diasDeTrabalhoRecebidos && diasDeTrabalhoRecebidos != 0)
                        {
                            diasDeTrabalho = diasDeTrabalhoRecebidos;
                        }
                        else
                        {
                            diasDeTrabalho = getDiasDeTrabalho(codigoCelSelecionada);
                        }
                        estado = "Não processado";
                    }
                    else
                    {
                        ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperarComCod(codigoCelSelecionada);
                        foreach (ModeloProcessamentoDeSalario p in listaProcessamento)
                        {
                            adiantamentos = p.getAdiantamentos();
                            emprestimo = p.getEmprestimoMedico();
                            valorIrps = p.getIrps();
                            subAlimentacao = p.getSubAlimentacao();
                            vencimento = p.getSalarioBrutoMensal();
                            ipa = p.getIpa();
                            outroSub = p.getDiversosSubsidios();
                            diasDeTrabalho = p.getIdDiasDeTrabalho();
                            estado = "Processado";
                        }
                    }
                    f.nrAno.Value = nrAno.Value;
                    f.cbMes.Text = cbMes.Text;
                    f.txtNome.Text = nome;
                    f.nrRegistonr.Value = codigoCelSelecionada;
                    f.txtIrps.Text = string.Format("{0:#,##0.00}", valorIrps);
                    f.txtIpa.Text = string.Format("{0:#,##0.00}", ipa);
                    f.txtVencimento.Text = string.Format("{0:#,##0.00}", vencimento);
                    f.txtSubAlimentacao.Text = string.Format("{0:#,##0.00}", subAlimentacao);
                    f.txtadiantamentos.Text = string.Format("{0:#,##0.00}", adiantamentos);
                    f.txtemprestimoMedico.Text = string.Format("{0:#,##0.00}", emprestimo);
                    f.nrDias.Value = diasDeTrabalho;
                    f.txtOutrasRemuneracoes.Text = string.Format("{0:#,##0.00}", outroSub);
                    f.txtTotalDescontar.Text = string.Format("{0:#,##0.00}", valorIrps + emprestimo + ipa + adiantamentos);
                    f.txtTotalRemuneracoes.Text = string.Format("{0:#,##0.00}", subAlimentacao + vencimento + outroSub);
                    f.txtEstado.Text = estado;
                    f.ShowDialog();
                    diasDeTrabalhoRecebidos = f.diasDeTrabalho;
                }
            }
            catch 
            {
                MessageBox.Show("Clique uma linha válida!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //diasDeTrabalho = f.diasDeTrabalho;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbOperacao.Text = "";
            chbVencimento.Checked = false;
            chbSubFerias.Checked = false;
            chbExtraordinario.Checked = false;
            cbMes.Text = "";
            dtProcessamento.Value = DateTime.Now;
            dtFaltasHorasExtra.Value = DateTime.Now;
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReportProcessamento f = new frmReportProcessamento();
            f.ShowDialog();
        }

        private void cbOperacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refrescar();
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                gravar();
                MessageBox.Show("Salário/os processado/os com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err) 
            {
                MessageBox.Show( err.Message,"Falha ao processar Salário/os", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

        }

        public frmProcessamentoEmLote()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmProcessamentoEmLote_Load(object sender, EventArgs e)
        {
            //refrescar();
        }

        private Boolean existeProcessamento(int idFunc) 
        {
            Boolean existe = false;
            ArrayList lista = ControllerProcessamentoDeSalario.recuperar();
            //ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            int ano = Convert.ToInt32(nrAno.Value);
            String mes = cbMes.Text;
            int nrMes = getMes(mes), anoProcess, mesProcess;
            DateTime dataProcess;
            foreach (ModeloProcessamentoDeSalario p in lista) 
            {
                dataProcess = Convert.ToDateTime(p.getDataProcessamento());
                anoProcess = dataProcess.Year;
                mesProcess = dataProcess.Month;
                if (idFunc == p.getIdFuncionario() && anoProcess == ano && mesProcess == nrMes) 
                {
                    existe = true;    
                }
            }
            return existe;
        }

        public void refrescar()
        {
            //frmListagemFuncionarios listf = new frmListagemFuncionarios();
            //List<int> listagemFuncionario = listf.getFuncionarios();
            ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            List<int> funcionariosValidos = getFuncionariosValidos();
            ArrayList listaIrps = ControllerIRPS.recuperar();
            DataTable dt = new DataTable();
            Program prog = new Program();
            double valorIrps = 0;
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Nome do funcionário");
            dt.Columns.Add("Dias de trab.");
            dt.Columns.Add("Mensal");
            dt.Columns.Add("SUB. ALIM.");
            dt.Columns.Add("AJUD. CUST.");
            dt.Columns.Add("AJUD. DESL.");
            dt.Columns.Add("PAG. FÉRIAS");
            dt.Columns.Add("DIVERSOS SUB EFIC.");
            dt.Columns.Add("TOTAL");
            dt.Columns.Add("EMPRÉSTIMO ASSIST. MÉDICA");
            dt.Columns.Add("IRPS");
            dt.Columns.Add("IPA");
            dt.Columns.Add("INSS");
            dt.Columns.Add("Total a descontar");
            dt.Columns.Add("Adiantamento");
            dt.Columns.Add("Importância a pagar");
            foreach (ModeloFuncionario f in listaFuncionario)
            {
                int idFuncionario;
                String nomeDoTrabalhador;
                double salarioBrutoMensal = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0, irps = 0, ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;
                ArrayList listaDias = ControllerDiasDeTrabalho.recuperar();
                ArrayList listaFuncRemuneracoes = ControllerFuncionarioRemuneracoes.recuperar();
                int diasBaseDados = 0;
                for (int i = 0; i < funcionariosValidos.Count; i++) 
                {
                    
                    if (f.getCodigo() == funcionariosValidos[i])
                    {
                        DataRow dRow = dt.NewRow();
                        idFuncionario = f.getCodigo();
                        nomeDoTrabalhador = f.getNome();
                        Boolean existe = existeProcessamento(idFuncionario);
                        if (existe == false)
                        {
                            foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracoes)
                            {
                                if (idFuncionario == fr.getIdFuncionario())
                                {
                                    diversosSubsidios = (fr.getValor() * fr.getQtd()) + diversosSubsidios;
                                }
                            }
                            foreach (ModeloDiasDeTrabalho d in listaDias)
                            {
                                if (d.getIdFunc() == f.getCodigo())
                                {
                                    diasBaseDados = d.getDiasDeTrabalho();
                                }
                            }
                            if (diasDeTrabalho !=0 && diasDeTrabalho!=diasDeTrabalhoRecebidos && diasDeTrabalhoRecebidos != 0) 
                            {
                                diasDeTrabalho = diasDeTrabalhoRecebidos;
                            }
                            else
                            {
                                diasDeTrabalho = getDiasDeTrabalho(idFuncionario);
                            }
                            salarioBrutoMensal = Math.Round((f.getVencimento() / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
                            subAlimentacao = f.getSubAlimentacao();
                            ajudaDeCusto = 0;
                            ajudaDeslocacao = 0;
                            pagamentoFerias = 0;
                            totalRetribuicao = salarioBrutoMensal + subAlimentacao + diversosSubsidios + ajudaDeslocacao + ajudaDeCusto + pagamentoFerias;
                            emprestimoMedico = 0;
                            foreach (ModeloIRPS ir in listaIrps)
                            {
                                if (f.getIdIRPS() == ir.getId())
                                    valorIrps = ir.getValor();
                            }
                            ipa = f.getImpostoMunicipal();
                            inss = salarioBrutoMensal * 0.07;
                            adiantamentos = 0;
                            totalDescontar = valorIrps + emprestimoMedico + ipa + inss + adiantamentos;
                            importanciaAPagar = totalRetribuicao - totalDescontar;
                        }
                        else 
                        {
                            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperarComCod(idFuncionario);
                            foreach (ModeloProcessamentoDeSalario p in listaProcessamento) 
                            {
                                salarioBrutoMensal = p.getSalarioBrutoMensal();
                                subAlimentacao = p.getSubAlimentacao();
                                ajudaDeCusto = p.getAjudaDeCusto();
                                ajudaDeslocacao = p.getAjudaDeslocacao();
                                pagamentoFerias = p.getPagamentoFerias();
                                totalRetribuicao = p.getTotalRetribuicao();
                                emprestimoMedico = p.getEmprestimoMedico();
                                diasDeTrabalho = p.getIdDiasDeTrabalho();
                                diversosSubsidios = p.getDiversosSubsidios();
                                ipa = p.getIpa();
                                inss = p.getInss();
                                adiantamentos = 0;
                                totalDescontar = p.getTotalADescontar();
                                importanciaAPagar = p.getImportanciaApagar();
                            }
                        }
                        dRow["Registo n°"] = idFuncionario;
                        dRow["Nome do funcionário"] = nomeDoTrabalhador;
                        dRow["Dias de trab."] = diasDeTrabalho;
                        dRow["Mensal"] = string.Format("{0:#,##0.00}", salarioBrutoMensal);
                        dRow["SUB. ALIM."] = string.Format("{0:#,##0.00}", subAlimentacao);
                        dRow["AJUD. CUST."] = string.Format("{0:#,##0.00}", ajudaDeCusto);
                        dRow["AJUD. DESL."] = string.Format("{0:#,##0.00}", ajudaDeslocacao);
                        dRow["PAG. FÉRIAS"] = string.Format("{0:#,##0.00}", pagamentoFerias);
                        dRow["DIVERSOS SUB EFIC."] = string.Format("{0:#,##0.00}", diversosSubsidios);
                        dRow["TOTAL"] = string.Format("{0:#,##0.00}", totalRetribuicao);
                        dRow["EMPRÉSTIMO ASSIST. MÉDICA"] = emprestimoMedico;
                        dRow["IRPS"] = string.Format("{0:#,##0.00}", valorIrps);
                        dRow["IPA"] = string.Format("{0:#,##0.00}", ipa);
                        dRow["INSS"] = string.Format("{0:#,##0.00}", inss);
                        dRow["Total a descontar"] = string.Format("{0:#,##0.00}", totalDescontar);
                        dRow["Adiantamento"] = string.Format("{0:#,##0.00}", adiantamentos);
                        dRow["Importância a pagar"] = string.Format("{0:#,##0.00}", importanciaAPagar);
                        dt.Rows.Add(dRow);
                    }
                }
            }
            dataProcessamentoSalario.DataSource = dt;
            dataProcessamentoSalario.Refresh();
            dataProcessamentoSalario.AllowUserToAddRows = false;
            dataProcessamentoSalario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataProcessamentoSalario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        //private void gravarProcessamento()
        //{
        //    int id = 0;
        //    int idFunc = Convert.ToInt16(nrRegistonr.Value);
        //    String nome = txtNome.Text;
        //    String operacao = cbTipoProcessamento.Text;
        //    String dataProcessamnto = dtDataProcessamento.Value.ToString("yyyy-MM-dd");
        //    int mesRecebido = dtDataProcessamento.Value.Month;
        //    int anoRecebido = dtDataProcessamento.Value.Year;
        //    int anoProcessado, mesProcessado;
        //    DateTime dtProcessado;
        //    int diasDeTrabalho = Convert.ToInt16(nrDias.Value);
        //    double emprestimoMedico = double.Parse(txtemprestimoMedico.Text);
        //    double irps = double.Parse(txtIrps.Text);
        //    double ipa = double.Parse(txtIpa.Text);
        //    double adiantamentos = double.Parse(txtadiantamentos.Text);
        //    double salarioBruto = double.Parse(txtVencimento.Text);
        //    double subAlimentcao = double.Parse(txtSubAlimentacao.Text);
        //    double diversosSubsidios = double.Parse(txtOutrasRemuneracoes.Text);
        //    double ajudaDeCusto = 0, ajudaDeDeslocacao = 0, pagamentoFerias = 0, inss, totalADescontar, totalRetribuicoes, importanciaAPagar, salarioLiquido;
        //    salarioLiquido = Math.Round((salarioBruto / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
        //    inss = Math.Round((salarioLiquido * 0.07), 2, MidpointRounding.AwayFromZero); ;
        //    totalADescontar = emprestimoMedico + adiantamentos + irps + ipa + inss;
        //    totalRetribuicoes = subAlimentcao + salarioLiquido + diversosSubsidios + ajudaDeCusto + ajudaDeDeslocacao + pagamentoFerias;
        //    importanciaAPagar = totalRetribuicoes - totalADescontar;
        //    Boolean existe = false;
        //    ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
        //    foreach (ModeloProcessamentoDeSalario f in listaProcessamento)
        //    {
        //        dtProcessado = Convert.ToDateTime(f.getDataProcessamento());
        //        anoProcessado = dtProcessado.Year;
        //        mesProcessado = dtProcessado.Month;
        //        if (f.getIdFuncionario() == idFunc && anoProcessado == anoRecebido && mesProcessado == mesRecebido)
        //        {
        //            existe = true;
        //            id = f.getId();
        //        }
        //    }

        //    if (existe)
        //    {
        //        ControllerProcessamentoDeSalario.atualizar(id, idFunc, nome, diasDeTrabalho, salarioLiquido, subAlimentcao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamnto, operacao);
        //    }
        //    else
        //    {
        //        id = getCodProcessamento() + 1;
        //        ControllerProcessamentoDeSalario.Guardar(id, idFunc, nome, diasDeTrabalho, salarioLiquido, subAlimentcao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicoes, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamnto, operacao);
        //    }
        //}

        private void gravar() 
        {
            int idFuncionario;
            String nomeDoTrabalhador, operacao, dataProcessamento;
            double salarioLiquido = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0, idIrps = 0, ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;

            int id = 0, i = 0;
            operacao = cbOperacao.Text;
            dataProcessamento = dtProcessamento.Value.Date.ToString("yyyy-MM-dd");
            double valorIrps = 0;
            List<int> lista = getFuncionariosValidos();
            List<int> codigoFuncionarioDtView = new List<int>();
            int mesRecebido = dtProcessamento.Value.Month;
            int anoRecebido = dtProcessamento.Value.Year;
            int anoProcessado, mesProcessado;
            DateTime dtProcessado;
            Boolean existe = false;
            ArrayList listaDias = ControllerDiasDeTrabalho.recuperar();
            ArrayList listaFuncs = ControllerFuncionario.recuperar();
            ArrayList listaFuncRemuneracoes = ControllerFuncionarioRemuneracoes.recuperar();
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            ArrayList listaIrps = ControllerIRPS.recuperar();

            foreach (DataGridViewRow row in dataProcessamentoSalario.Rows)
            {
                codigoFuncionarioDtView.Add(int.Parse(row.Cells[0].Value.ToString()));
            }

            foreach (ModeloFuncionario f in listaFuncs) 
            {
                idFuncionario = f.getCodigo();
                nomeDoTrabalhador = f.getNome();
                ajudaDeCusto = 0;
                ajudaDeslocacao = 0;
                pagamentoFerias = 0;
                emprestimoMedico = 0;
                subAlimentacao = f.getSubAlimentacao();
                foreach (ModeloIRPS ir in listaIrps)
                {
                    if (f.getIdIRPS() == ir.getId())
                        valorIrps = ir.getValor();
                }
                ipa = f.getImpostoMunicipal();
                foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracoes)
                {
                    if (idFuncionario == fr.getIdFuncionario())
                    {
                        diversosSubsidios = (fr.getValor() * fr.getQtd()) + diversosSubsidios;
                    }

                }

                foreach (ModeloProcessamentoDeSalario pro in listaProcessamento)
                {
                    dtProcessado = Convert.ToDateTime(pro.getDataProcessamento());
                    anoProcessado = dtProcessado.Year;
                    mesProcessado = dtProcessado.Month;
                    for (int j = 0; j< codigoFuncionarioDtView.Count; j++)
                    {
                        if (pro.getIdFuncionario() == codigoFuncionarioDtView[j] && anoProcessado == anoRecebido && mesProcessado == mesRecebido)
                        {
                            existe = true;
                            id = pro.getId();
                        }
                    }
                }

                foreach (ModeloDiasDeTrabalho d in listaDias)
                {
                    if (d.getIdFunc() == idFuncionario)
                    {
                        diasDeTrabalho = d.getDiasDeTrabalho();
                    }
                }

                salarioLiquido = Math.Round((f.getVencimento() / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
                inss = Math.Round((salarioLiquido * 0.07), 2, MidpointRounding.AwayFromZero); 
                totalDescontar = emprestimoMedico + adiantamentos + valorIrps + ipa + inss;
                totalRetribuicao = Math.Round(subAlimentacao + salarioLiquido + diversosSubsidios + ajudaDeCusto + ajudaDeslocacao + pagamentoFerias, 2, MidpointRounding.AwayFromZero);
                importanciaAPagar = Math.Round(totalRetribuicao - totalDescontar, 2, MidpointRounding.AwayFromZero);

                if (codigoFuncionarioDtView != null)
                {
                    for (int j = 0; j < codigoFuncionarioDtView.Count; j++)
                    {
                        if (codigoFuncionarioDtView[j] == f.getCodigo())
                        {
                            if (existe)
                            {
                                ControllerProcessamentoDeSalario.atualizar(id, idFuncionario, nomeDoTrabalhador, diasDeTrabalho, salarioLiquido, subAlimentacao, ajudaDeCusto, ajudaDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, valorIrps, ipa, inss, totalDescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, operacao);
                            }
                            else
                            {
                                id = getCodProcessamento() + 1;
                                ControllerProcessamentoDeSalario.Guardar(id, idFuncionario, nomeDoTrabalhador, diasDeTrabalho, salarioLiquido, subAlimentacao, ajudaDeCusto, ajudaDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, valorIrps, ipa, inss, totalDescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, operacao);
                                break;
                            }
                        }                        
                    }
                }
                else
                {
                    MessageBox.Show("Lista de funcionários vazia", "Não foi possível processar salário/os!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private int getCodProcessamento() 
        {
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            int cod = 0;
            foreach (ModeloProcessamentoDeSalario f in listaProcessamento) 
            {
                if (f.getId() != 0) 
                {
                    cod = f.getId();
                }
            }
            return cod;
        }

        private int getMes(String mes) 
        {
            int nr = 0;
            if (mes.ToLower().Equals("janeiro")) 
            {
                nr = 1;
            }
            if (mes.ToLower().Equals("fevereiro"))
            {
                nr = 2;
            }
            if (mes.ToLower().Equals("marco"))
            {
                nr = 3;
            }
            if (mes.ToLower().Equals("abril"))
            {
                nr = 4;
            }
            if (mes.ToLower().Equals("maio"))
            {
                nr = 5;
            }
            if (mes.ToLower().Equals("junho"))
            {
                nr = 6;
            }
            if (mes.ToLower().Equals("julho"))
            {
                nr = 7;
            }
            if (mes.ToLower().Equals("agosto"))
            {
                nr = 8;
            }
            if (mes.ToLower().Equals("setembro"))
            {
                nr = 9;
            }
            if (mes.ToLower().Equals("outubro"))
            {
                nr = 10;
            }
            if (mes.ToLower().Equals("novembro"))
            {
                nr = 11;
            }
            if (mes.ToLower().Equals("dezembro"))
            {
                nr = 12;
            }
            return nr;
        }

        ArrayList listaCadastroFuncionarios = new ArrayList();
        private List<int>getFuncionariosValidos() 
        {
            List<int> funcionario = new List<int>();
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperar();
            ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperar();
            decimal ano = nrAno.Value;           
            String mes = cbMes.Text;
            int nrMes = getMes(mes), nrMesRelogio;
            DateTime dataAdimissao, dataRelogio/*, dataProcessamento*/;
            foreach (ModeloFuncionario f in listaFuncionarios) 
            {
                dataAdimissao = Convert.ToDateTime(f.getDataAdmissao());
                foreach (ModeloRelogioDePonto r in listaRelogioDePonto) 
                {
                    dataRelogio = Convert.ToDateTime(r.getData());
                    nrMesRelogio = dataRelogio.Month;
                    diasDeTrabalho = getDiasDeTrabalho(r.getIdUsuario());
                    if (dataAdimissao.Year <= ano && f.getCodigo() == r.getIdUsuario() && nrMes == nrMesRelogio && dataRelogio.Year ==ano && diasDeTrabalho > 0)
                    {
                        funcionario.Add(f.getCodigo());
                        listaCadastroFuncionarios.Add(new ModeloFuncionario(f.getCodigo(), f.getIdIRPS(), f.getNome(), f.getCell(), f.getCellSec(), f.getTel(), f.getEmail(), f.getEstadoCivil(), f.getDeficiencia(), f.getConjugue(), f.getSexo(), f.getDataNascimento(), f.getLinkImagem(), f.getCodigoPostal(), f.getBairro(), f.getLocalidade(), f.getMoradaGen(), f.getTipoContrato(), f.getDataAdmissao(), f.getDataDemissao(), f.getProfissao(), f.getCategoria(), f.getSeguro(), f.getLocalTrabalho(), f.getRegime(), f.getBi(), f.getNumeroBenificiario(), f.getNumeroFiscal(), f.getVencimento(), f.getSubAlimentacao(), f.getSubTransporte(), f.getHoras(), f.getDependentes(), f.getHabilitacoes(), f.getNacionalidade(), f.getUltimoEmprego(), f.getTurno(), f.getImpostoMunicipal(), f.getCentroDeCusto(), f.getSegurancaSocial(), f.getSindicato(), f.getSubComunicacao()));
                        break;
                    } 
                }
            }
            return funcionario;
        }
        
        private int getDiasDeTrabalho(int codFunc)
        {
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
            int ano = Convert.ToInt32(nrAno.Value);
            String mes = cbMes.Text;
            int nrMes = getMes(mes), anoProcess, mesProcess;
            DateTime dataRelogio;
            int dias = 0;
            foreach (ModeloRelogioDePonto f in listaRelogioDePonto)
            {
                dataRelogio = Convert.ToDateTime(f.getData());
                if (codFunc == f.getIdUsuario() && f.getEstado().Equals("Check in") && dataRelogio.Year == ano && dataRelogio.Month == nrMes) 
                {
                    dias = dias + 1;
                }
            }
            if (dias % 2 != 0)
            {
                dias = dias - 1;
            }
            return dias/2;
        }

        private void frmProcessamentoEmLote_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControllerDiasDeTrabalho.remover();
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (MessageBox.Show("Pretende Voltar ao menu principal?", "Atenção!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void frmProcessamentoEmLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F5")
            {
                try
                {
                    gravar();
                    MessageBox.Show("Salário/os processado/os com sucesso!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Erro");
                }
            }

            if(e.KeyCode.ToString() == "F7")
            {
                frmReportProcessamento f = new frmReportProcessamento();
                f.Show();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String mes = cbMes.Text;
            nrMes = getMes(mes);
            refrescar();
        }

        private void nrAno_ValueChanged(object sender, EventArgs e)
        {
            refrescar();
        }
    }
}
