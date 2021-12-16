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
using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Formularios
{
    public partial class frmProcessamentoIndividual : Form
    {
        public frmProcessamentoIndividual()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReportProcessamento f = new frmReportProcessamento();
            f.Show();
        }

        private void frmProcessamentoIndividual_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNome;
            refrescarVencimento();
        }

        private void refrescarVencimento()
        {
            decimal idFunc = nrRegistonr.Value;
            ArrayList listaRemenuracoes = ControllerRemuneracoes.recuperar();
            ArrayList listaFuncRemuneracao = ControllerFuncionarioRemuneracoes.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Natureza");
            dt.Columns.Add("Valor Unit.");
            dt.Columns.Add("Quantidade");
            dt.Columns.Add("Total");
            foreach (ModeloFuncionarioRemuneracoes fr in listaFuncRemuneracao)
            {
                DataRow dRow = dt.NewRow();
                if (idFunc == fr.getIdFuncionario())
                {
                    dRow["Registo n°"] = fr.getId();
                    foreach (ModeloRemuneracoes r in listaRemenuracoes)
                    {
                        if (fr.getIdRemuneracao() == r.getId())
                        {
                            dRow["Natureza"] = r.getNatureza();
                        }
                    }
                    dRow["Valor Unit."] = fr.getValor();
                    dRow["Quantidade"] = fr.getQtd();
                    dRow["Total"] = fr.getValor() * fr.getQtd() + "";
                }
                dt.Rows.Add(dRow);
            }
            DataView dtView = new DataView(dt);
            DataTable dtTable = dtView.ToTable(true, "Registo n°", "Natureza", "Valor Unit.", "Quantidade", "Total");
            dataProcessamentoSalario.DataSource = dtTable;
            dataProcessamentoSalario.Refresh();
            dataProcessamentoSalario.AllowUserToAddRows = false;
            dataProcessamentoSalario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataProcessamentoSalario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            frmListagemFuncionarios f = new frmListagemFuncionarios();
            MessageBox.Show(f.getFuncionarios().Count+"");
        }
    }
}
