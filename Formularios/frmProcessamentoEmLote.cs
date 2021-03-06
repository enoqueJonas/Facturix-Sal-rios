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
        private int nrMes, codigoCelSelecionada;
        private void dataProcessamentoSalario_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        { 
        }

        private void dataProcessamentoSalario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        private void dataProcessamentoSalario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int diasDeTrabalhoRecebidos = 0;
            int diasDeTrabalho;
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = dataProcessamentoSalario.Rows[rowIndex];
                codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
                if (cbMes.Text == "")
                {
                    MessageBox.Show("Selecione o mês que pretende processar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ActiveControl = cbMes;
                }
                else
                {
                    ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(codigoCelSelecionada);
                    ArrayList listaIrps = ControllerIRPS.recuperar();
                    ArrayList listaAdiantamentos = ControllerAdiantamento.recuperar();
                    ArrayList listaDias = ControllerDiasDeTrabalho.recuperar();
                    String nome = "", estado = "";
                    frmProcessamentoIndividual f = new frmProcessamentoIndividual();
                    int codIrps = 0;
                    int mesRecebido = dtProcessamento.Value.Month;
                    int anoRecebido = dtProcessamento.Value.Year;
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
                            foreach (ModeloAdiantamento a in listaAdiantamentos)
                            {
                                if (a.getIdFuncionario() == func.getCodigo())
                                {
                                    adiantamentos = a.getDiantamento();
                                }
                            }
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
                        foreach (ModeloDiasDeTrabalho d in listaDias)
                        {
                            if (d.getIdFunc() == codigoCelSelecionada)
                            {
                                diasDeTrabalhoRecebidos = d.getDiasDeTrabalho();
                            }
                        }
                        if (diasDeTrabalhoRecebidos == 0)
                        {
                            diasDeTrabalho = getDiasDeTrabalho(codigoCelSelecionada);
                        }
                        else
                        {
                            diasDeTrabalho = diasDeTrabalhoRecebidos;
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

                    foreach (ModeloAdiantamento ad in listaAdiantamentos)
                    {
                        DateTime dataAdiantamentos = Convert.ToDateTime(ad.getData());
                        int mesAdiant = dataAdiantamentos.Month;
                        int anoAdiant = dataAdiantamentos.Year;
                        if (ad.getIdFuncionario() == codigoCelSelecionada && mesAdiant == mesRecebido && anoAdiant == anoRecebido)
                        {
                            adiantamentos = Math.Round(ad.getDiantamento(), 2, MidpointRounding.AwayFromZero);
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
                    this.TopMost = false;
                    f.ShowDialog();
                    f.TopMost = true;
                }
            }
            catch 
            {
                MessageBox.Show("Clique uma linha válida!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void impedirBotoes() 
        {
            if (dataProcessamentoSalario.Rows.Count != 0 && nrAno.Value != 0 && cbMes.Text != "")
            {
                btnEliminar.Enabled = true;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnConfirmar.Enabled = true;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
            }
            else 
            {
                btnEliminar.Enabled = false;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnConfirmar.Enabled = false;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbOperacao.Text = "";
            cbMes.Text = "";
            dtProcessamento.Value = DateTime.Now;
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

        private void confirmar() 
        {
            try
            {
                if (cbMes.Text == "")
                {
                    MessageBox.Show("Selecione um mês válido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    gravar();
                    frmTerminarProcessamento f = new frmTerminarProcessamento();
                    f.lista = listaDeNomes;
                    f.ShowDialog();
                    //MessageBox.Show("Salário/os processado/os com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Falha ao processar Salário/os", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            confirmar();
        }

        public frmProcessamentoEmLote()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private int contador = 0;
        private void frmProcessamentoEmLote_Load(object sender, EventArgs e)
        {
            contador = 1;
            impedirBotoes();
            this.ActiveControl = cbOperacao;
            if (estaVazio() == true) 
            {
                lblEstado.Visible = true;
            } 
            ControllerDiasDeTrabalho.remover();
        }

        public Boolean estaVazio() 
        {
            if (dataProcessamentoSalario.Rows.Count == 0) 
            {
                return true;
            }
            return false;
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
            ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            List<int> funcionariosValidos = getFuncionariosValidos();
            ArrayList listaIrps = ControllerIRPS.recuperar();
            DataTable dt = new DataTable();
            Program prog = new Program();
            List<int> codigosFuncDtView = new List<int>();
            int mesRecebido = getMes(cbMes.Text);
            int anoRecebido = Convert.ToInt16(nrAno.Value);
            if (dataProcessamentoSalario.Rows.Count > 0)
            {
                for (int i = 0; i < dataProcessamentoSalario.Rows.Count; i++)
                {
                    codigosFuncDtView.Add(int.Parse(dataProcessamentoSalario.Rows[i].Cells[0].Value.ToString()));
                }
            }

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
            dt.Columns.Add("ASSIST. MÉDICA");
            dt.Columns.Add("IRPS");
            dt.Columns.Add("IPA");
            dt.Columns.Add("INSS");
            dt.Columns.Add("Total a descontar");
            dt.Columns.Add("Adiantamento");
            dt.Columns.Add("Importância a pagar");
            foreach (ModeloFuncionario f in listaFuncionario)
            {
                int idFuncionario;
                int diasDeTrabalho = 0;
                int diasDeTrabalhoRecebidos;
                String nomeDoTrabalhador;
                double salarioBrutoMensal = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0, ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;
                ArrayList listaDias = ControllerDiasDeTrabalho.recuperar();
                ArrayList listaFuncRemuneracoes = ControllerFuncionarioRemuneracoes.recuperar();
                ArrayList listaAdiantamentos = ControllerAdiantamento.recuperar();
                ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
                ArrayList listaSeguros = ControllerSeguro.recuperar();
                //int diasBaseDados = 0;
                ajudaDeslocacao = 0;
                for (int i = 0; i < codigosFuncDtView.Count; i++)
                {
                    diasDeTrabalhoRecebidos = 0;
                    if (f.getCodigo() == codigosFuncDtView[i])
                    {
                        DataRow dRow = dt.NewRow();
                        idFuncionario = f.getCodigo();
                        nomeDoTrabalhador = f.getNome();
                        Boolean existe = existeProcessamento(idFuncionario);
                        if (existe == false)
                        {
                            foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracoes)
                            {
                                foreach (ModeloRemuneracoes r in listaRemuneracoes)
                                {
                                    if (idFuncionario == fr.getIdFuncionario() && fr.getIdRemuneracao() == r.getId())
                                    {
                                        if (r.getNatureza().Equals("A- Ajudas De Custo e Transportes"))
                                        {
                                            ajudaDeslocacao = fr.getValor() * fr.getQtd();
                                        }
                                        else
                                        {
                                            diversosSubsidios = (fr.getValor() * fr.getQtd()) + diversosSubsidios;
                                        }
                                    }
                                }
                            }
                            foreach (ModeloSeguro seg in listaSeguros)
                            {
                                if (seg.getSeguro().Equals(f.getSeguro()))
                                {
                                    emprestimoMedico = f.getVencimento() * (seg.getPercentagem() / 100);
                                }
                            }

                            foreach (ModeloDiasDeTrabalho d in listaDias)
                            {
                                if (d.getIdFunc() == idFuncionario)
                                {
                                    diasDeTrabalhoRecebidos = d.getDiasDeTrabalho();
                                }
                            }
                            if (diasDeTrabalhoRecebidos == 0)
                            {
                                diasDeTrabalho = getDiasDeTrabalho(idFuncionario);
                            }
                            else {
                                diasDeTrabalho = diasDeTrabalhoRecebidos;
                            }
                            salarioBrutoMensal = Math.Round((f.getVencimento() / 26) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
                            subAlimentacao = f.getSubAlimentacao();
                            ajudaDeCusto = 0;
                            pagamentoFerias = 0;
                            totalRetribuicao = salarioBrutoMensal + subAlimentacao + diversosSubsidios + ajudaDeslocacao + ajudaDeCusto + pagamentoFerias;
                            foreach (ModeloIRPS ir in listaIrps)
                            {
                                if(f.getIdIRPS() == ir.getId())
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
                            DateTime dataProcessamento ;
                            foreach (ModeloProcessamentoDeSalario p in listaProcessamento) 
                            {
                                dataProcessamento = Convert.ToDateTime(p.getDataProcessamento());
                                if (idFuncionario == p.getIdFuncionario() && dataProcessamento.Year == anoRecebido && dataProcessamento.Month == mesRecebido) 
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
                                dtProcessamento.Value = dataProcessamento;
                            }
                        }

                        foreach (ModeloAdiantamento ad in listaAdiantamentos)
                        {
                            DateTime dataAdiantamentos = Convert.ToDateTime(ad.getData());
                            int mesAdiant = dataAdiantamentos.Month;
                            int anoAdiant = dataAdiantamentos.Year;
                            if (ad.getIdFuncionario() == idFuncionario && mesAdiant == mesRecebido && anoAdiant == anoRecebido)
                            {
                                adiantamentos = Math.Round(ad.getDiantamento(), 2, MidpointRounding.AwayFromZero);
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
                        dRow["ASSIST. MÉDICA"] = string.Format("{0:#,##0.00}", emprestimoMedico);
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
            dataProcessamentoSalario.AllowUserToAddRows = false;
            dataProcessamentoSalario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataProcessamentoSalario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        public List<String> listaDeNomes = new List<string>();
        private void gravar() 
        {
            int diasDeTrabalho;
            int idFuncionario, diasDeTrabalhoRecebidos = 0;
            String nomeDoTrabalhador, operacao, dataProcessamento;
            double salarioLiquido = 0, subAlimentacao = 0, ajudaDeCusto = 0, ajudaDeslocacao = 0, pagamentoFerias = 0, diversosSubsidios = 0, totalRetribuicao = 0, emprestimoMedico = 0,  ipa = 0, inss = 0, totalDescontar = 0, adiantamentos = 0, importanciaAPagar = 0;

            int id = 0;
            operacao = cbOperacao.Text;
            dataProcessamento = dtProcessamento.Value.Date.ToString("yyyy-MM-dd");
            double valorIrps = 0;
            List<int> codigoFuncionarioDtView = new List<int>();
            int mesRecebido = dtProcessamento.Value.Month;
            int anoRecebido = dtProcessamento.Value.Year;
            int anoProcessado, mesProcessado;
            DateTime dtProcessado;
            Boolean existe = false;
            ArrayList listaDias = ControllerDiasDeTrabalho.recuperar();
            ArrayList listaFuncs = ControllerFuncionario.recuperar();
            ArrayList listaFuncRemuneracoes = ControllerFuncionarioRemuneracoes.recuperar();
            ArrayList listaIrps = ControllerIRPS.recuperar();
            ArrayList listaSeguros = ControllerSeguro.recuperar();
            ArrayList listaAdiantamentos = ControllerAdiantamento.recuperar();

            foreach (DataGridViewRow row in dataProcessamentoSalario.Rows)
            {
                codigoFuncionarioDtView.Add(int.Parse(row.Cells[0].Value.ToString()));
            }

            foreach (ModeloFuncionario f in listaFuncs) 
            {
                diasDeTrabalho = 0;
                idFuncionario = f.getCodigo();
                nomeDoTrabalhador = f.getNome();
                ajudaDeCusto = 0;
                ajudaDeslocacao = 0;
                pagamentoFerias = 0;
                emprestimoMedico = 0;
                subAlimentacao = f.getSubAlimentacao();
                ArrayList listaProcessamento = ControllerProcessamentoDeSalario.recuperarComCod(idFuncionario);
                foreach (ModeloIRPS ir in listaIrps)
                {
                    if (f.getIdIRPS() == ir.getId())
                        valorIrps = ir.getValor();
                }
                foreach (ModeloSeguro seg in listaSeguros)
                {
                    if (seg.getSeguro().Equals(f.getSeguro()))
                    {
                        emprestimoMedico = f.getVencimento() * (seg.getPercentagem() / 100);
                    }
                }

                ipa = f.getImpostoMunicipal();
                foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracoes)
                {
                    if (idFuncionario == fr.getIdFuncionario())
                    {
                        diversosSubsidios = (fr.getValor() * fr.getQtd()) + diversosSubsidios;
                    }
                }              

                foreach (ModeloDiasDeTrabalho d in listaDias)
                {
                    if (d.getIdFunc() == idFuncionario)
                    {
                        diasDeTrabalhoRecebidos = d.getDiasDeTrabalho();
                    }
                }
                if (diasDeTrabalhoRecebidos == 0)
                {
                    diasDeTrabalho = getDiasDeTrabalho(idFuncionario);
                }
                else
                {
                    diasDeTrabalho = diasDeTrabalhoRecebidos;
                }

                foreach (ModeloProcessamentoDeSalario pro in listaProcessamento)
                {
                    dtProcessado = Convert.ToDateTime(pro.getDataProcessamento());
                    anoProcessado = dtProcessado.Year;
                    mesProcessado = dtProcessado.Month;
                    for (int j = 0; j < codigoFuncionarioDtView.Count; j++)
                    {
                        if (pro.getIdFuncionario() == codigoFuncionarioDtView[j] && anoProcessado == anoRecebido && mesProcessado == mesRecebido)
                        {
                            existe = true;
                            id = pro.getId();
                            if (diasDeTrabalho == 0) 
                            {
                                diasDeTrabalho = pro.getIdDiasDeTrabalho();
                            }
                        }
                    }
                }

                foreach (ModeloAdiantamento ad in listaAdiantamentos) 
                {
                    DateTime dataAdiantamentos = Convert.ToDateTime(ad.getData());
                    int mesAdiant = dataAdiantamentos.Month;
                    int anoAdiant = dataAdiantamentos.Year;
                    if (ad.getIdFuncionario() == idFuncionario && mesAdiant == mesRecebido && anoAdiant == anoRecebido) 
                    {
                        adiantamentos = Math.Round(ad.getDiantamento(), 2, MidpointRounding.AwayFromZero);
                    }
                }

                salarioLiquido = Math.Round((f.getVencimento() / 30) * diasDeTrabalho, 2, MidpointRounding.AwayFromZero);
                inss = Math.Round((salarioLiquido * 0.03), 2, MidpointRounding.AwayFromZero); 
                totalDescontar = Math.Round( emprestimoMedico + adiantamentos + valorIrps + ipa + inss, 2, MidpointRounding.AwayFromZero);
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
                                listaDeNomes.Add(nomeDoTrabalhador);
                            }
                            else
                            {
                                id = getCodProcessamento() + 1;
                                ControllerProcessamentoDeSalario.Guardar(id, idFuncionario, nomeDoTrabalhador, diasDeTrabalho, salarioLiquido, subAlimentacao, ajudaDeCusto, ajudaDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, valorIrps, ipa, inss, totalDescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, operacao);
                                listaDeNomes.Add(nomeDoTrabalhador);
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
            if (mes.ToLower().Equals("março"))
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
            int diasDeTrabalho;
            List<int> funcionario = new List<int>();
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperar();
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

        //private int getDiasDeTrabalho(int codFunc)
        //{
        //    ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
        //    int ano = Convert.ToInt32(nrAno.Value);
        //    String mes = cbMes.Text;
        //    int nrMes = getMes(mes);
        //    DateTime dataRelogio;
        //    int dias = 0;
        //    foreach (ModeloRelogioDePonto f in listaRelogioDePonto)
        //    {
        //        dataRelogio = Convert.ToDateTime(f.getData());
        //        if (codFunc == f.getIdUsuario() && f.getEstado().Equals("Check in") && dataRelogio.Year == ano && dataRelogio.Month == nrMes)
        //        {
        //            dias = dias + 1;
        //        }
        //    }
        //    if (dias % 2 != 0)
        //    {
        //        dias = dias - 1;
        //    }
        //    return dias / 2;
        //}

    private int getDiasDeTrabalho(int codFunc)
    {
        ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
        ArrayList listaRegrasDeponto = ControllerRegrasDePonto.recuperar();
        ArrayList listaHorarios = ControllerHorarios.recuperar();
        int ano = Convert.ToInt32(nrAno.Value), idFunc = 0;
        String mes = cbMes.Text;
        int nrMes = getMes(mes), horaEntrada = 0, minutoEntrada = 0, horaSaida = 0, minutoSaida = 0;
        DateTime dataRelogio;
        int dias = 0;
        String entradaNaoBatida = "", saidaNaoBatida = "";

        foreach (ModeloRegrasDePonto r in listaRegrasDeponto)
        {
            entradaNaoBatida = r.getEntradaNaoRegistada();
            saidaNaoBatida = r.getSaidaNaoRegistada();
        }

        foreach (ModeloHorarios h in listaHorarios)
        {
            if (h.getAtivo())
            {
                horaEntrada = Convert.ToInt16(h.getEmTempoH());
                minutoEntrada = Convert.ToInt16(h.getEmTempoM());
                horaSaida = Convert.ToInt16(h.getForaDoTempo());
                minutoSaida = Convert.ToInt16(h.getForaDoTempoM());
            }
        }

        foreach (ModeloRelogioDePonto f in listaRelogioDePonto)
        {
            dataRelogio = Convert.ToDateTime(f.getData());
            if (codFunc == f.getIdUsuario() && f.getEstado().Equals("Check in") && dataRelogio.Year == ano && dataRelogio.Month == nrMes)
            {
                if(f.getSn() % 2 != 0 && entradaNaoBatida.Equals("Dia Trabalhado") && dataRelogio.Hour <= horaEntrada)
                {
                    dias = dias + 1;
                }

                if (f.getSn() % 2 == 0 && saidaNaoBatida.Equals("Dia Trabalhado") && dataRelogio.Hour >= horaSaida)
                {
                    dias = dias + 1;
                }
                idFunc = f.getIdUsuario();
            }
        }
        if (dias % 2 != 0)
        {
            dias = dias - 1;
        }

        //if (idFunc != 0)
        //{
        //    ControllerDiasDeTrabalho.gravar(idFunc, dias / 2);
        //}
            return dias / 2;
    }

    private void frmProcessamentoEmLote_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ControllerDiasDeTrabalho.remover();
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
            ControllerDiasDeTrabalho.remover();
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
            
            if (e.KeyCode.ToString() == "F6" && btnEliminar.Enabled)
            {
                String data = dtProcessamento.Value.ToString("yyyy-MM-dd");
                MySqlConnection conexao = Conexao.conectar();
                try
                {
                    conexao.Open();
                    if (dtProcessamento.Value.Date < DateTime.Now.Date)
                    {
                        if (MessageBox.Show("Os processamentos já foram submetidos à segurança social! Eliminar os mesmos virá com Repercussões. Deseja Continuar?", "Atenção!",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            String SqlDelete = "DELETE from processamento_salario WHERE dataProcessamento=?";
                            MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                            comando.Parameters.Add(new MySqlParameter("dataProcessamento", data));
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Processamentos removidos com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        String SqlDelete = "DELETE from processamento_salario WHERE dataProcessamento=?";
                        MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                        comando.Parameters.Add(new MySqlParameter("dataProcessamento", data));
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Processamentos removidos com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Não foi possível remover os processamentos! Contacte o técnico!");
                }
                finally
                {
                    if (conexao != null)
                        conexao.Close();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String data = dtProcessamento.Value.ToString("yyyy-MM-dd");
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                if (dtProcessamento.Value.Date < DateTime.Now.Date)
                {
                    if (MessageBox.Show("Os processamentos já foram submetidos à segurança social! Eliminar os mesmos virá com Repercussões. Deseja Continuar?", "Atenção!",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        String SqlDelete = "DELETE from processamento_salario WHERE dataProcessamento=?";
                        MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                        comando.Parameters.Add(new MySqlParameter("dataProcessamento", data));
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Processamentos removidos com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (MessageBox.Show("Tem certeza que deseja eliminar os processamentos de "+ data +"?", "Atenção!",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        String SqlDelete = "DELETE from processamento_salario WHERE dataProcessamento=?";
                        MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                        comando.Parameters.Add(new MySqlParameter("dataProcessamento", data));
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Processamentos removidos com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover os processamentos! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }

        }

        private void cbOperacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter) 
            {
                nrAno.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Down) 
            {
                dtProcessamento.Focus();
                e.Handled = true;
            }
        }

        private void nrAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                cbMes.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                cbOperacao.Focus();
                e.Handled = true;
            }
        }

        private void cbMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                dtProcessamento.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                nrAno.Focus();
                e.Handled = true;
            }
        }

        private void dtProcessamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                cbOperacao.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                cbMes.Focus();
                e.Handled = true;
            }
        }

        private void chbVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                btnConfirmar.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Down)
            {
                btnConfirmar.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                dtProcessamento.Focus();
                e.Handled = true;
            }
            if (e.Alt && e.KeyCode == Keys.Up)
            {
                cbMes.Focus();
                e.Handled = true;
            }
        }

        private void dtProcessamento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String mes = cbMes.Text;
            nrMes = getMes(mes);
            refrescar();
            impedirBotoes();
            lblEstado.Visible = estaVazio();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nrAno_ValueChanged(object sender, EventArgs e)
        {
            refrescar();
            impedirBotoes();
            lblEstado.Visible = estaVazio();
        }
    }
}
