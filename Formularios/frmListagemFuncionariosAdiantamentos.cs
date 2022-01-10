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
using Facturix_Salários.Modelos;
using Facturix_Salários.Controllers;

namespace Facturix_Salários.Formularios
{
    public partial class frmListagemFuncionariosAdiantamentos : Form
    {
        public frmListagemFuncionariosAdiantamentos()
        {
            InitializeComponent();
        }

        private void montarDataGridView(ArrayList listaRecebida)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Telefone");
            foreach (ModeloFuncionario func in listaRecebida)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = func.getCodigo();
                dRow["Nome"] = func.getNome();
                dRow["Telefone"] = func.getTel();
                dt.Rows.Add(dRow);
            }
            dataFuncionarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataFuncionarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataFuncionarios.AllowUserToAddRows = false;
            dataFuncionarios.DataSource = dt;
            dataFuncionarios.Refresh();
        }

        private void refrescar()
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            montarDataGridView(listaFuncionarios);
        }
        private int getDiasDeTrabalho(int codFunc)
        {
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
            int ano = DateTime.Now.Year, idFunc = 0;
            int nrMes = DateTime.Now.Month;
            DateTime dataRelogio;
            int dias = 0;
            foreach (ModeloRelogioDePonto f in listaRelogioDePonto)
            {
                dataRelogio = Convert.ToDateTime(f.getData());
                if (codFunc == f.getIdUsuario() && f.getEstado().Equals("Check in") && dataRelogio.Year == ano && dataRelogio.Month == nrMes)
                {
                    idFunc = f.getIdUsuario();
                    dias = dias + 1;
                }
            }
            if (dias % 2 != 0)
            {
                dias = dias - 1;
            }
            if (idFunc != 0)
            {
                ControllerDiasDeTrabalho.gravar(idFunc, dias / 2);
            }
            return dias / 2;
        }

        private void frmListagemFuncionariosAdiantamentos_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        private void txtLocalizar_TextChanged(object sender, EventArgs e)
        {
            String procura = txtLocalizar.Text;
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComString(procura);
            montarDataGridView(listaFuncionarios);
        }

        int rowSelected, codigoCelSelecionada;

        private void txtLocalizar_KeyDown(object sender, KeyEventArgs e)
        {
            foreach(DataGridViewRow row in dataFuncionarios.Rows)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dataFuncionarios.MultiSelect = false;
                    dataFuncionarios.Rows[0].Selected = true;
                    dataFuncionarios.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;
                    dataFuncionarios.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                    dataFuncionarios.Focus();
                }
            }
        }

        private void dataFuncionarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int rowIndex = rowSelected;
                DataGridViewRow row = dataFuncionarios.Rows[rowIndex];
                codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
                frmAdiantamentos f = new frmAdiantamentos();
                ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(codigoCelSelecionada);
                int diasDeTrabalho = getDiasDeTrabalho(codigoCelSelecionada);
                foreach (ModeloFuncionario func in listaFuncionarios)
                {
                    f.nrRegisto.Value = func.getCodigo();
                    f.txtNome.Text = func.getNome();
                    f.txtSalarioBruto.Text = string.Format("{0:#,##0.00}", func.getVencimento());
                    f.txtDiasDeTrabalho.Text = diasDeTrabalho + "";
                }
                e.Handled = true;
                f.Show();
            }
        }

        private void dataFuncionarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            rowSelected = rowIndex;
        }

        private void dataFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            rowSelected = rowIndex;
            DataGridViewRow row = dataFuncionarios.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            frmAdiantamentos f = new frmAdiantamentos();
            ArrayList listaFuncionarios = ControllerFuncionario.recuperarComCodigo(codigoCelSelecionada);
            int diasDeTrabalho = getDiasDeTrabalho(codigoCelSelecionada);
            foreach (ModeloFuncionario func in listaFuncionarios)
            {
                f.nrRegisto.Value = func.getCodigo();
                f.txtNome.Text = func.getNome();
                f.txtSalarioBruto.Text = string.Format("{0:#,##0.00}", func.getVencimento());
                f.txtDiasDeTrabalho.Text = diasDeTrabalho + "";
            }
            f.Show();
        }
    }
}
