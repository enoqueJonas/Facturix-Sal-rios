using System;
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
    public partial class frmProcessamentoDeSalario : Form
    {
        private int jan, fev, mar, abr, mai, jun, jul, ago, set, outu, nov, dez, codigoCelSelecionada;

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            getMonths(codigoCelSelecionada);
        }

        private void dataProcessamentoSalario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataProcessamentoSalario.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
        }

        public frmProcessamentoDeSalario()
        {
            InitializeComponent();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataProcessamentoSalario_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void dtViewIRPS_Paint(Object sender, PaintEventArgs e)
        {
            Rectangle r1 = dataProcessamentoSalario.GetCellDisplayRectangle(2, -1, true);
            Rectangle r2 = dataProcessamentoSalario.GetCellDisplayRectangle(10, -1, true);
            int w1 = dataProcessamentoSalario.GetCellDisplayRectangle(3, -1, true).Width;
            int w2 = dataProcessamentoSalario.GetCellDisplayRectangle(9, -1, true).Width;
            r1.X += 2;
            r1.Y += 2;
            r1.Width = r1.Width + 273 + w1 - 3;
            r1.Height = r1.Height / 2 - 2;
            r2.X += 2;
            r2.Y += 2;
            r2.Width = r2.Width + 2 + w2 - 6;
            r2.Height = r2.Height / 2 - 2;
            e.Graphics.FillRectangle(new SolidBrush(Color.GhostWhite), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString("RETRIBUIÇÃO", dataProcessamentoSalario.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dataProcessamentoSalario.DefaultCellStyle.ForeColor), r1, format);
            e.Graphics.FillRectangle(new SolidBrush(Color.GhostWhite), r2);
            e.Graphics.DrawString("DESCONTOS", dataProcessamentoSalario.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dataProcessamentoSalario.DefaultCellStyle.ForeColor), r2, format);
        }
        private void dtViewIRPS_ColumnWidthChanged(Object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = dataProcessamentoSalario.DisplayRectangle;
            rtHeader.Height = dataProcessamentoSalario.ColumnHeadersHeight / 2;
            dataProcessamentoSalario.Invalidate(rtHeader);
        }

        private void dtViewIRPS_scroll(Object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = dataProcessamentoSalario.DisplayRectangle;
            rtHeader.Height = dataProcessamentoSalario.ColumnHeadersHeight / 2;
            dataProcessamentoSalario.Invalidate(rtHeader);
        }

        private void dtViewIRPS_CellPainting(Object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height += e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        private void dtViewIRPS_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataProcessamentoSalario.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void frmProcessamentoDeSalario_Load(object sender, EventArgs e)
        {
            /*
            dataProcessamentoSalario.ColumnHeadersHeight = dataProcessamentoSalario.ColumnHeadersHeight * 2;
            dataProcessamentoSalario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataProcessamentoSalario.CellPainting += new DataGridViewCellPaintingEventHandler(dtViewIRPS_CellPainting);
            dataProcessamentoSalario.Paint += new PaintEventHandler(dtViewIRPS_Paint);
            dataProcessamentoSalario.Scroll += new ScrollEventHandler(dtViewIRPS_scroll);
            dataProcessamentoSalario.ColumnWidthChanged += new DataGridViewColumnEventHandler(dtViewIRPS_ColumnWidthChanged);
            */
            refrescar();
            dataProcessamentoSalario.Columns["Nome do funcionário"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataProcessamentoSalario.Columns["Nome do funcionário"].Width = 250;
            dataProcessamentoSalario.Columns["Dias de trab."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataProcessamentoSalario.Columns["Dias de trab."].Width = 50;
            dataProcessamentoSalario.Columns["TOTAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataProcessamentoSalario.Columns["TOTAL"].Width = 150;
            dataProcessamentoSalario.Columns["Importância a pagar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataProcessamentoSalario.Columns["Importância a pagar"].Width = 150;
            foreach (DataGridViewColumn col in dataProcessamentoSalario.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void refrescar() 
        {
            ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            ArrayList listaIrps = ControllerIRPS.recuperar();
            DataTable dt = new DataTable();
            double valorIrps = 0;
            //dt.Columns.Add("ID");
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
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = f.getCodigo();
                dRow["Nome do funcionário"] = f.getNome();
                dRow["Dias de trab."] = f.getHoras()/4;
                dRow["Mensal"] = f.getVencimento();
                dRow["SUB. ALIM."] = f.getSubAlimentacao();
                dRow["AJUD. CUST."] = 0;
                dRow["AJUD. DESL."] = f.getSubTransporte();
                dRow["PAG. FÉRIAS"] = 0;
                dRow["DIVERSOS SUB EFIC."] = f.getSubComunicacao();
                dRow["TOTAL"] = f.getVencimento() + f.getSubAlimentacao() + f.getSubTransporte() + f.getSubComunicacao();
                dRow["EMPRÉSTIMO ASSIST. MÉDICA"] = 0;
                foreach (ModeloIRPS i in listaIrps) 
                {
                    if (f.getIdIRPS() == i.getId())
                        valorIrps = i.getValor();
                }
                dRow["IRPS"] = valorIrps;
                dRow["IPA"] = f.getImpostoMunicipal();
                dRow["INSS"] = f.getVencimento() * 0.03;
                dRow["Total a descontar"] = valorIrps + f.getImpostoMunicipal();
                dRow["Adiantamento"] = 0;
                dRow["Importância a pagar"] = (f.getVencimento() + f.getSubAlimentacao() + f.getSubTransporte() + f.getSubComunicacao()) - (valorIrps + f.getImpostoMunicipal());
                dt.Rows.Add(dRow);
            }
            dataProcessamentoSalario.DataSource = dt;
            dataProcessamentoSalario.Refresh();
            dataProcessamentoSalario.AllowUserToAddRows = false;
            dataProcessamentoSalario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataProcessamentoSalario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private void getMonths(int codFunc) 
        {
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
            DateTime data;
            foreach (ModeloRelogioDePonto f in listaRelogioDePonto) 
            {
                data = Convert.ToDateTime(f.getData());
                if (data.Month == 1) 
                {
                    jan += 1;
                }
                if (data.Month == 2)
                {
                    fev += 1;
                }
                if (data.Month == 3)
                {
                    mar += 1;
                }
                if (data.Month == 4)
                {
                    abr += 1;
                }
                if (data.Month == 5)
                {
                    mai += 1;
                }
                if (data.Month == 6)
                {
                    jun += 1;
                }
                if (data.Month == 7)
                {
                    jul += 1;
                }
                if (data.Month == 8)
                {
                    ago += 1;
                }
                if (data.Month == 9)
                {
                    set += 1;
                }
                if (data.Month == 10)
                {
                    outu += 1;
                }
                if (data.Month == 11)
                {
                    nov += 1;
                }
                if (data.Month == 12)
                {
                    dez += 1;
                }
            }
        }
    }
}
