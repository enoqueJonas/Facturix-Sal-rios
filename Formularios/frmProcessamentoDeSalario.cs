using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturix_Salários.Formularios
{
    public partial class frmProcessamentoDeSalario : Form
    {
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
            Rectangle r1 = dataProcessamentoSalario.GetCellDisplayRectangle(1, -1, true);
            int w2 = dataProcessamentoSalario.GetCellDisplayRectangle(2, -1, true).Width;
            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + 273 + w2 - 2;
            r1.Height = r1.Height / 2 - 2;
            e.Graphics.FillRectangle(new SolidBrush(Color.GhostWhite), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString("Valor do IRPS a reter relativo ao limite inferior do intervalo do salário bruto, por número de dependentes(MTs)", dataProcessamentoSalario.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dataProcessamentoSalario.DefaultCellStyle.ForeColor), r1, format);
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
            dataProcessamentoSalario.ColumnHeadersHeight = dataProcessamentoSalario.ColumnHeadersHeight * 2;
            dataProcessamentoSalario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataProcessamentoSalario.CellPainting += new DataGridViewCellPaintingEventHandler(dtViewIRPS_CellPainting);
            dataProcessamentoSalario.Paint += new PaintEventHandler(dtViewIRPS_Paint);
            dataProcessamentoSalario.Scroll += new ScrollEventHandler(dtViewIRPS_scroll);
            dataProcessamentoSalario.ColumnWidthChanged += new DataGridViewColumnEventHandler(dtViewIRPS_ColumnWidthChanged);
        }
    }
}
