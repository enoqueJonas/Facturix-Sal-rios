using System;
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
using System.Collections;

namespace Facturix_Salários.Formularios
{
    public partial class frmConsultarContualidade : Form
    {
        public frmConsultarContualidade()
        {
            InitializeComponent();
        }

        private void frmConsultarContualidade_Load(object sender, EventArgs e)
        {
            refrescar();
            dataFuncionarios.Columns["Cor"].Width = 0;
            txtDiasTrabalhados.Text = getDiasDeTrabalho(codCelSelecionada) + "";
            nrRegistonr.Value = codCelSelecionada;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public int codCelSelecionada;
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

        int horasTrabalhadas = 0;
        List<int> listaDiasValidos = new List<int>();
        private int getDiasDeTrabalho(int codFunc)
        {
            ArrayList listaRelogioDePonto = ControllerRelogioDePonto.recuperarComCod(codFunc);
            ArrayList listaRegrasDeponto = ControllerRegrasDePonto.recuperar();
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            List<int> listaDeDias = new List<int>();
            int ano = Convert.ToInt16(nrAno.Value), idFunc = 0;
            String mes = cbMes.Text;
            int nrMes = getMes(mes), horaEntrada = 0, minutoEntrada = 0, horaSaida = 0, minutoSaida = 0, diaAtual = 0;
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

            List<int> listaTemp = new List<int>();
            foreach (ModeloRelogioDePonto r in listaRelogioDePonto)
            {
                dataRelogio = Convert.ToDateTime(r.getData());
                if (codFunc == r.getIdUsuario() && r.getEstado().Equals("Check in") && nrMes == dataRelogio.Month && ano == dataRelogio.Year)
                {
                    diaAtual = dataRelogio.Day;
                    listaDeDias.Add(diaAtual);
                }

            }

            int i = 0, cont, entrada = 0, saida = 0;

            for (int j = 0; j < listaDeDias.Count; j++)
            {
                for (int k = 1; k <= listaDeDias.Count - 1; k++)
                {
                    int a;
                    a = j;
                    if (listaDeDias[j] == listaDeDias[k] && listaDeDias[j] == diaAtual)
                    {
                        listaTemp.Add(listaDeDias[j]);
                        if (listaDeDias.Count > 4)
                        {
                            if(listaDeDias[j] == listaDeDias[k + 2] && listaDeDias[j] == diaAtual)
                                listaTemp.Add(listaDeDias[j]);
                        }
                        break;
                    }
                }
            }

            listaDiasValidos = listaTemp.Distinct().ToList();

            foreach (ModeloRelogioDePonto f in listaRelogioDePonto)
            {
                dataRelogio = Convert.ToDateTime(f.getData());
                diaAtual = dataRelogio.Day;
                cont = listaRelogioDePonto.Count;
                if (codFunc == f.getIdUsuario() && f.getEstado().Equals("Check in") && dataRelogio.Year == ano && dataRelogio.Month == nrMes)
                {
                    if (i % 2 == 0 && dataRelogio.Hour <= horaEntrada)
                    {
                        dias = dias + 1;
                        entrada = dataRelogio.Hour;
                    }

                    if (i % 2 != 0 && dataRelogio.Hour >= horaSaida)
                    {
                        dias = dias + 1;
                        saida = dataRelogio.Hour;
                    }
                    idFunc = f.getIdUsuario();
                    if (entrada != 0 && saida != 0)
                        horasTrabalhadas = horasTrabalhadas + (saida - entrada);
                }
                i++;
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

        private void refrescar()
        {
            int idFuncionario = 0;
            String nomeDoTrabalhador;
            //List<int> listagemFuncionario = listf.getFuncionarios();
            ArrayList listaFuncionario = ControllerFuncionario.recuperarComCodigo(codCelSelecionada);
            ArrayList listaRegras = ControllerRegrasDePonto.recuperar();
            //List<int> funcionariosValidos = getFuncionarios();
            int tempoAlmoco = 0, SN = 0, nrDoDispositivo = 0, mes = getMes(cbMes.Text);
            String estado = "", obs = "", data = "";
            DateTime dataRelogio;
            DataTable dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("Nr. do Dispositivo");
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Nome do funcionário");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Obs.");
            dt.Columns.Add("Data");
            dt.Columns.Add("Cor");
            int ano = Convert.ToInt16(nrAno.Value);
            foreach (ModeloFuncionario f in listaFuncionario)
            {
                //for (int i = 0; i < funcionariosValidos.Count; i++)
                //{
                    if (f.getCodigo() == codCelSelecionada)
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
                            if (dataRelogio.Month == mes && dataRelogio.Year == ano && rel.getEstado().Equals("Check in"))
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
                            for (int i=0; i< listaDiasValidos.Count; i++)
                            {
                                if (listaDiasValidos[i] == dataRelogio.Day)
                                {
                                    dRow["Cor"] = "t";
                                }
                                else
                                {
                                    dRow["Cor"] = "f";
                                }
                                    
                            }
                                dt.Rows.Add(dRow);
                            }
                        }
                    }
                }
            //}
            dataFuncionarios.DataSource = dt;
            foreach (DataGridViewRow row in dataFuncionarios.Rows)
                if (row.Cells[7].Value.ToString() == "t")
                {
                    row.Cells["Data"].Style.BackColor = Color.Green;
                }
                else
                {
                    row.Cells["Data"].Style.BackColor = Color.Red;
                }
            dataFuncionarios.AllowUserToAddRows = false;
            dataFuncionarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataFuncionarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            codCelSelecionada = idFuncionario;
            //}));
            //return;
            //}
        }

        private int getDiasFds()
        {
            ArrayList listaFds = ControllerFinalDeSemana.recuperar();
            int diasFds = 0;
            foreach (ModeloFinalDeSemana f in listaFds)
            {
                if (f.getAtivo() == true)
                {
                    if (f.getSabadoM() == true)
                    {
                        diasFds = 4;
                    }
                    else if(f.getSabadoM() == false)
                    {
                        diasFds = 8;
                    }
                }
            }
            return diasFds;
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            codCelSelecionada = Convert.ToInt16(nrRegistonr.Value);
            int diasDeTrabalho = getDiasDeTrabalho(codCelSelecionada), diasFds = getDiasFds(), diasAusencias = 0;
            float horasPorDia = 0;
            txtDiasTrabalhados.Text = diasDeTrabalho + "";
            refrescar();
            txtHorasNoMes.Text = horasTrabalhadas + "";
            if (diasDeTrabalho != 0)
            {
                horasPorDia = horasTrabalhadas / diasDeTrabalho;
            }
            txtHorasPorSemana.Text = horasPorDia + "";
            horasTrabalhadas = 0;

            if (cbMes.Text != "")
            {
                int nrMes = getMes(cbMes.Text);
                int diasDoMes = DateTime.DaysInMonth(DateTime.Now.Year, nrMes);
                diasAusencias = (diasDoMes - diasFds) - diasDeTrabalho;
                txtAusencias.Text = diasAusencias + "";
            }
        }

        private void nrAno_ValueChanged(object sender, EventArgs e)
        {
            refrescar();
            txtDiasTrabalhados.Text = getDiasDeTrabalho(codCelSelecionada) + "";
        }

        private void nrRegistonr_ValueChanged(object sender, EventArgs e)
        {
            codCelSelecionada = Convert.ToInt16(nrRegistonr.Value);
            int diasDeTrabalho = getDiasDeTrabalho(codCelSelecionada), diasFds = getDiasFds(), diasAusencias = 0;
            float horasPorDia = 0;
            txtDiasTrabalhados.Text = diasDeTrabalho + "";
            refrescar();
            txtHorasNoMes.Text = horasTrabalhadas + "";
            if (diasDeTrabalho != 0)
            {
                horasPorDia = horasTrabalhadas / diasDeTrabalho;
            }
            txtHorasPorSemana.Text = horasPorDia + "";
            horasTrabalhadas = 0;

            if (cbMes.Text != "")
            {
                int nrMes = getMes(cbMes.Text);
                int diasDoMes = DateTime.DaysInMonth(DateTime.Now.Year, nrMes);
                diasAusencias = (diasDoMes - diasFds) - diasDeTrabalho;
                txtAusencias.Text = diasAusencias + "";
            }
        }

        private void nrAno_ValueChanged_1(object sender, EventArgs e)
        {
            codCelSelecionada = Convert.ToInt16(nrRegistonr.Value);
            int diasDeTrabalho = getDiasDeTrabalho(codCelSelecionada), diasFds = getDiasFds(), diasAusencias = 0;
            float horasPorDia = 0;
            txtDiasTrabalhados.Text = diasDeTrabalho + "";
            refrescar();
            txtHorasNoMes.Text = horasTrabalhadas + "";
            if (diasDeTrabalho != 0)
            {
                horasPorDia = horasTrabalhadas / diasDeTrabalho;
            }
            txtHorasPorSemana.Text = horasPorDia + "";
            horasTrabalhadas = 0;

            if (cbMes.Text != "")
            {
                int nrMes = getMes(cbMes.Text);
                int diasDoMes = DateTime.DaysInMonth(DateTime.Now.Year, nrMes);
                diasAusencias = (diasDoMes - diasFds) - diasDeTrabalho;
                txtAusencias.Text = diasAusencias + "";
            }
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
