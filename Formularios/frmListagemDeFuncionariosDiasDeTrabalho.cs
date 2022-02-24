using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Formularios
{
    public partial class frmListagemDeFuncionariosDiasDeTrabalho : Form
    {
        public frmListagemDeFuncionariosDiasDeTrabalho()
        {
            InitializeComponent();
        }

        private void frmListagemDeFuncionariosDiasDeTrabalho_Load(object sender, EventArgs e)
        {
            refrescar();
            lblEstado.Visible = estaVazio();
            dataFuncionarios.MultiSelect = false;
            if (dataFuncionarios.Rows.Count > 0)
                dataFuncionarios.Rows[0].Selected = true;
            dataFuncionarios.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;
            dataFuncionarios.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dataFuncionarios.Focus();
        }

        private void refrescar()
        {
            ArrayList listaFuncionarios = ControllerFuncionario.recuperar();
            montarDataGridView(listaFuncionarios);
        }

        public Boolean estaVazio()
        {
            if (dataFuncionarios.Rows.Count == 0)
                return true;

            return false;
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

        int codigoCelSelecionada;
        public List<int> getFuncionarios()
        {
            List<int> listaFuncionarios = new List<int>();
            foreach (DataGridViewRow row in dataFuncionarios.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value != null)
                {
                    listaFuncionarios.Add(int.Parse(row.Cells[1].Value.ToString()));
                    codigoCelSelecionada = int.Parse(row.Cells[1].Value.ToString());
                }
            }
            return listaFuncionarios;
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
            int idFuncionario = 0;
            String nomeDoTrabalhador;
            frmConsultarContualidade frm = new frmConsultarContualidade();
            //List<int> listagemFuncionario = listf.getFuncionarios();
            ArrayList listaFuncionario = ControllerFuncionario.recuperar();
            ArrayList listaRegras = ControllerRegrasDePonto.recuperar();
            List<int> funcionariosValidos = getFuncionarios();
            int tempoAlmoco = 0, SN = 0, nrDoDispositivo = 0;
            String estado ="", obs = "", data = "";
            DateTime dataRelogio;
            DataTable dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("Nr. do Dispositivo");
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Nome do funcionário");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Obs.");
            dt.Columns.Add("Data");
            foreach (ModeloFuncionario f in listaFuncionario)
            {
                for (int i = 0; i < funcionariosValidos.Count; i++)
                {
                    if (f.getCodigo() == funcionariosValidos[i])
                    {
                        idFuncionario = f.getCodigo();
                        ArrayList listaRelogio = ControllerRelogioDePonto.recuperarComCod(idFuncionario);
                        foreach (ModeloRegrasDePonto reg in listaRegras)
                        {
                            tempoAlmoco = Convert.ToInt16(reg.getTempoAlmoco());
                        }
                        foreach (ModeloRelogioDePonto rel in listaRelogio)
                        {
                            data = rel.getData();
                            dataRelogio = Convert.ToDateTime(data);
                            if (dataRelogio.Month == DateTime.Now.Month)
                            {
                                DataRow dRow = dt.NewRow();
                                SN = rel.getSn();
                                nrDoDispositivo = rel.getNrDispositivo();
                                estado = rel.getEstado();
                                if (dataRelogio.Hour >= 12 && dataRelogio.Hour <= 14)
                                {
                                    obs = "Almoço";
                                }
                                else
                                {
                                    obs = "Entrada/Saída";
                                }
                                nomeDoTrabalhador = f.getNome();
                                dRow["SN"] = SN;
                                dRow["Nr. do Dispositivo"] = nrDoDispositivo;
                                dRow["Registo n°"] = idFuncionario;
                                dRow["Nome do funcionário"] = nomeDoTrabalhador;
                                dRow["Estado"] = estado;
                                dRow["Obs."] = obs;
                                dRow["Data"] = data;
                                dt.Rows.Add(dRow);
                            }
                        }
                    }
                }
            }
            frm.dataFuncionarios.DataSource = dt;
            frm.dataFuncionarios.AllowUserToAddRows = false;
            frm.dataFuncionarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            frm.dataFuncionarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            //if (frm.estaVazio() == true)
            //{
            //    frm.lblEstado.Visible = true;
            //}
            //if (InvokeRequired)
            //{
            //    // after we've done all the processing, 
            //    this.Invoke(new MethodInvoker(delegate
            //    {
            // load the control with the appropriate data
            frm.codCelSelecionada = idFuncionario;
                    frm.Show();
                    this.Close();
                //}));
                //return;
            //}
        }
    }
}
