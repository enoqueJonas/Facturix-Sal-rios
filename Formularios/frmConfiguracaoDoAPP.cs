using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace Facturix_Salários.Formularios
{
    public partial class frmConfiguracaoDoAPP : Form
    {
        public frmConfiguracaoDoAPP()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmConfiguracaoDoAPP_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            decimal umDiaTrabalho = nrHorasTrabalho.Value;
            decimal intervaloMinimo = nrIntervaloMinimoBatida.Value;
            decimal atraso = nrEntradaAtraso.Value;
            decimal falta = nrFalta.Value;
            decimal saidaAdiantada = nrSaidaAdiantada.Value;
            decimal horasExtra = nrHorasExtra.Value;
            decimal almoco = nrAlmoco.Value;
            decimal entradaH = nrEntradaH.Value;
            decimal entradaM = nrEntradaM.Value;
            decimal saidaH = nrSaidaH.Value;
            decimal saidaM = nrSaidaM.Value;
            if (getCod() == 0) 
            {
                int id = getCod() + 1;
                ControllerHorarios.Guardar(id, umDiaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, horasExtra, almoco, entradaH, entradaM, saidaH, saidaM);
            }
            else 
            {
                int id = getCod();
                ControllerHorarios.atualizar(id, umDiaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, horasExtra, almoco, entradaH, entradaM, saidaH, saidaM);
            }
            refrescar();
        }

        private void refrescar()
        {
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Um Dia de Trab.");
            dt.Columns.Add("Intervalo Min. entre Bat.");
            dt.Columns.Add("Atraso");
            dt.Columns.Add("Falta");
            dt.Columns.Add("Saida Adiantada");
            dt.Columns.Add("Horas Extra");
            dt.Columns.Add("Almoço");
            dt.Columns.Add("Hora de Entrada");
            dt.Columns.Add("Hora de Saída");
            foreach (ModeloHorarios func in listaHorarios)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = func.getId() + " min";
                dRow["Um Dia de Trab."] = func.getUmdiaTrabalho() + " min";
                dRow["Intervalo Min. entre Bat."] = func.getIntervaloMinimo() + " min";
                dRow["Atraso"] = func.getAtraso() + " min";
                dRow["Falta"] = func.getFalta() + " min";
                dRow["Saida Adiantada"] = func.getSaidaAdiantada() + " min";
                dRow["Horas Extra"] = func.getHorasExtra() + " min";
                dRow["Almoço"] = func.getAlmoco() + " min";
                dRow["Hora de Entrada"] = func.getEntradaH()+" h " + func.getEntradaM()+" min";
                dRow["Hora de Saída"] = func.getSaidaH() + " h " + func.getSaidaM() + " min";
                dt.Rows.Add(dRow);
            }
            dtHorarios.DataSource = dt;
            dtHorarios.AllowUserToAddRows = false;
            dtHorarios.Refresh();
            dtHorarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dtHorarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private int getCod()
        {
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            int cod = 0;
            foreach (ModeloHorarios cat in listaHorarios)
            {
                if (cat.getId() != 0)
                {
                    cod = cat.getId();
                }
                else
                {
                    cod = 0;
                }
            }
            return cod;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            mostrarLabels(true);
            montarCaixasDeTexto(listaHorarios);
        }
        private void mostrarLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
            lbl2.Visible = estado;
            lbl3.Visible = estado;
            lbl4.Visible = estado;
            lbl5.Visible = estado;
            lbl6.Visible = estado;
            lbl7.Visible = estado;
            lbl8.Visible = estado;
            lbl9.Visible = estado;
        }
        private void mostrarLabelsFeriado(Boolean estado) 
        {
            lbl1Feriado.Visible = estado;
            lbl2Feriado.Visible = estado;
            lbl3Feriado.Visible = estado;
        }

        private void limpar() 
        {
            nrAlmoco.Value = 0;
            nrEntradaAtraso.Value = 0;
            nrEntradaH.Value = 0;
            nrEntradaM.Value = 0;
            nrFalta.Value = 0;
            nrHorasExtra.Value = 0;
            nrHorasTrabalho.Value = 0;
            nrIntervaloMinimoBatida.Value = 0;
            nrSaidaAdiantada.Value = 0;
        }

        private void montarCaixasDeTexto(ArrayList listaHorarios) 
        {
            foreach (ModeloHorarios f in listaHorarios) 
            {
                nrAlmoco.Value = f.getAlmoco();
                nrEntradaAtraso.Value = f.getAtraso();
                nrEntradaH.Value = f.getEntradaH();
                nrEntradaM.Value = f.getEntradaM();
                nrFalta.Value = f.getFalta();
                nrHorasExtra.Value = f.getHorasExtra();
                nrHorasTrabalho.Value = f.getUmdiaTrabalho();
                nrIntervaloMinimoBatida.Value = f.getIntervaloMinimo();
                nrSaidaAdiantada.Value = f.getSaidaAdiantada();
                nrSaidaH.Value = f.getSaidaH();
                nrSaidaM.Value = f.getSaidaM();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpar();
            mostrarLabels(false);
        }

        private void dtHorarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            montarCaixasDeTexto(listaHorarios);
        }

        private void btnGravarFeriado_Click(object sender, EventArgs e)
        {
            int id = getCodFeriado() + 1;
            String nome = txtNome.Text;
            String dataInicio = dateTimeInicio.Value.ToString("yyyy-MM-dd");
            String dataFim = dateTimeFim.Value.ToString("yyyy-MM-dd");
            if (lbl1Feriado.Visible == false)
            {
                ControllerFeriado.gravar(id, nome, dataInicio, dataFim);
                limparCaixasFeriado();
            }
            else 
            {
                ControllerFeriado.atualizar(id, nome, dataInicio, dataFim);
                limparCaixasFeriado();
                mostrarLabels(false);
            }
        }

        private int getCodFeriado()
        {
            int cod = 0;
            ArrayList listaFeriados = ControllerFeriado.recuperar();
            foreach (ModeloFeriado f in listaFeriados)
            {
                if (f.getId() != 0)
                {
                    cod = f.getId();
                }
            }
            return cod;
        }

        private void limparCaixasFeriado() 
        {
            txtNome.Text = "";
            dateTimeInicio.Value = DateTime.Now;
            dateTimeFim.Value = DateTime.Now;
        }
        private void btnModifcarFeriado_Click(object sender, EventArgs e)
        {
            mostrarLabels(true); ;
        }

        private void btnCancelarFeriado_Click(object sender, EventArgs e)
        {
            mostrarLabels(false);
            limparCaixasFeriado();
        }
    }
}
