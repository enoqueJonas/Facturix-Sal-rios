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
using Facturix_Salários.Modelos;
using Facturix_Salários.Controllers;

namespace Facturix_Salários.Formularios
{
    public partial class frmListagemFuncionarios : Form
    {
        public frmListagemFuncionarios()
        {
            InitializeComponent();
        }

        private void frmListagemFuncionarios_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        private void refrescar()
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            montarDataGridView(listaFuncionarios);
        }

        private void montarDataGridView(ArrayList listaRecebida)
        {
            DataTable dt = new DataTable();
            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Telefone");
            foreach (ModeloFuncionario func in listaRecebida)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = func.getCodigo();
                dRow["Nome"] = func.getNome();
                dRow["Telefone"] = func.getTel();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "Chk";
                dgvCmb.HeaderText = "Selecionar";
                dgvCmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvCmb.Width = 60;
                dt.Rows.Add(dRow);
            }
            dataFuncionarios.Columns.Add(dgvCmb);
            dataFuncionarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataFuncionarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataFuncionarios.AllowUserToAddRows = false;
            dataFuncionarios.DataSource = dt;
            dataFuncionarios.Refresh();
        }

        private void btnSelecionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataFuncionarios.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            getFuncionarios();
            if (getFuncionarios().Count > 1 && getFuncionarios().Count != 0)
            {
                frmProcessamentoEmLote f = new frmProcessamentoEmLote();
                f.Show();
                this.Hide();
            } else if (getFuncionarios().Count == 1 && getFuncionarios().Count != 0) 
            {
                frmProcessamentoIndividual f = new frmProcessamentoIndividual();
                f.Show();
                this.Hide();
            }
        }

        public List<int> getFuncionarios() 
        {
            List<int> listaFuncionarios = new List<int>();
            foreach (DataGridViewRow row in dataFuncionarios.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value != null)
                {
                    listaFuncionarios.Add(int.Parse(row.Cells[1].Value.ToString()));
                }
            }
            return listaFuncionarios;
        }
    }
}
