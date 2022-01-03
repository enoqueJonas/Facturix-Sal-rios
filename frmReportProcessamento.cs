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

                String Query1 = "SELECT categoria, numeroBenificiario, numeroFiscal from funcionario";

                MySqlDataAdapter adapter = new MySqlDataAdapter(Query1, conexao);

                DataSet Ds = new DtSetProcessamento();
                DataTable dt0 = new DataTable("processamento_salario");
                adapter.Fill(dt0);
                Ds.Tables.Clear();
                Ds.Tables.Add(dt0);
                var s = dt0.Copy();
                s.TableName = "dtTableProcessamento";
                Ds.Tables.Add(s);
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
