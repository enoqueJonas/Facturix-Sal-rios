using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Facturix_Salários.Reports;
using MySql.Data.MySqlClient;
using Facturix_Salários.Conexoes;
using Facturix_Salários.DataSets;

namespace Facturix_Salários.Formularios
{
    public partial class frmReportProcessamento : Form
    {
        public frmReportProcessamento()
        {
            InitializeComponent();
        }

        private void frmReportProcessamento_Load(object sender, EventArgs e)
        {
            reportProcessamento objRpt = new reportProcessamento();
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();

                //String Query1 = "SELECT categoria, numeroBenificiario, numeroFiscal, vencimento from funcionario WHERE exists (select nomeTrabalhador from processamento_salario)";
                String Query2 = "SELECT nomeTrabalhador, diasDeTrabalho, salarioBrutoMensal, subsidioAlimentacao, importanciaAPagar, totalADescontar, totalRetribuicao, dataProcessamento, ajudaDeDeslocacao, ajudaDeCusto, categoria, numeroBenificiario, numeroFiscal, vencimento, irps, adiantamentos from processamento_salario, funcionario WHERE processamento_salario.nomeTrabalhador = funcionario.nome;";

                MySqlDataAdapter adapter = new MySqlDataAdapter(Query2, conexao);

                DataSet Ds = new DtSetProcessamento();

                adapter.Fill(Ds, "dtTableProcessamento");

                //adapter = new MySqlDataAdapter(Query2, conexao);
                //adapter.Fill(Ds, "dtTableProcessamento");

                if (Ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No data Found", "CrystalReportWithOracle");
                    return;
                }

                //Setting data source of our report object
                objRpt.SetDataSource(Ds);

                //CrystalDecisions.CrystalReports.Engine.TextObject root;
                //root = (CrystalDecisions.CrystalReports.Engine.TextObject);
                //objRpt.ReportDefinition.ReportObjects["txt_header"];
                //root.Text = "Sample Report By Using Data Table!!";

                //Binding the crystalReportViewer with our report object. 
                crystalReportViewer1.ReportSource = objRpt;
            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message, "Não foi possível preencher o report!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
