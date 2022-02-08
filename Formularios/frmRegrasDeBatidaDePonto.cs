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
    public partial class frmRegrasDeBatidaDePonto : Form
    {
        public frmRegrasDeBatidaDePonto()
        {
            InitializeComponent();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmRegrasDeBatidaDePonto_Load(object sender, EventArgs e)
        {
            this.ActiveControl = nrHorasTrabalho;
            ArrayList listaRegras = ControllerRegrasDePonto.recuperar();
            foreach (ModeloRegrasDePonto f in listaRegras) 
            {
                nrHorasTrabalho.Value = f.getDiaDeTrabalho();
                nrIntervaloMinimoBatida.Value = f.getIntervaloEntreBatidas();
                nrEntradaAtraso.Value = f.getAtraso();
                nrFalta.Value = f.getAusencia();
                cbEntrada.Text = f.getEntradaNaoRegistada();
                cbSaida.Text = f.getSaidaNaoRegistada();
                nrHorasExtra.Value = f.getHorasExtra();
                nrAlmoco.Value = f.getTempoAlmoco();
                if (nrHorasTrabalho.Value!=0) 
                {
                    cbDiaDeTrabalho.Checked = true;
                }
                if (nrIntervaloMinimoBatida.Value!=0) 
                {
                    cbIntervaloMinimo.Checked = true;
                }
                if (nrEntradaAtraso.Value!=0) 
                {
                    cbAtraso.Checked = true;
                }
                if (nrFalta.Value!=0) 
                {
                    chbFalta.Checked = true;
                }
                if (nrHorasExtra.Value!=0) 
                {
                    chbHorasExtra.Checked = true;
                }
                if (nrAlmoco.Value!=0) 
                {
                    chbAlmoco.Checked = true;
                }
                if (cbEntrada.Text!="") 
                {
                    chbEntrada.Checked = true;
                }
                if (cbSaida.Text!="") 
                {
                    chbSaida.Checked = true;
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Close();
            frmNomeDaEmpresa f = new frmNomeDaEmpresa();
            f.ShowDialog();
        }

        private void gravar() 
        {
            decimal diaTrabalho = 0;
            decimal intervaloMinimo = 0;
            decimal atraso = 0;
            decimal falta = 0;
            decimal saidaAdiantada = 0;
            decimal horasExtra = 0;
            decimal almoco = 0;
            String entradaNaoRegistada = "";
            String saidaNaoRegistada = "";

            if (cbDiaDeTrabalho.Checked) 
            {
                diaTrabalho = nrHorasTrabalho.Value;
            }
            if (cbIntervaloMinimo.Checked) 
            {
                intervaloMinimo = nrIntervaloMinimoBatida.Value;
            }
            if (cbAtraso.Checked) 
            {
                atraso = nrEntradaAtraso.Value;
            }
            if (chbFalta.Checked) 
            {
                falta = nrFalta.Value;
            }
            if (chbSaidaAdiantada.Checked) 
            {
                saidaAdiantada = nrSaidaAdiantada.Value;
            }
            if (chbEntrada.Checked) 
            {
                entradaNaoRegistada = cbEntrada.Text;
            }
            if (chbSaida.Checked) 
            {
                saidaNaoRegistada = cbSaida.Text;
            }
            if (chbHorasExtra.Checked) 
            {
                horasExtra = nrHorasExtra.Value;
            }
            if (chbAlmoco.Checked) 
            {
                almoco = nrAlmoco.Value;
            }
            if (getCod() == 0)
            {
                int id = getCod() + 1;
                ControllerRegrasDePonto.Guardar(id, diaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, entradaNaoRegistada, saidaNaoRegistada, horasExtra, almoco);
            }
            else 
            {
                int id = getCod();
                ControllerRegrasDePonto.atualizar(id, diaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, entradaNaoRegistada, saidaNaoRegistada, horasExtra, almoco);
            }
        }

        private int getCod() 
        {
            int cod = 0;
            ArrayList listaHorario = ControllerRegrasDePonto.recuperar();
            foreach (ModeloRegrasDePonto f in listaHorario) 
            {
                if (f.getId()!=0) 
                {
                    cod = f.getId();
                }
            }
            return cod;
        }

        private void btnSeguinte_Click(object sender, EventArgs e)
        {
            gravar();
            this.Close();
            frmFeriados f = new frmFeriados();
            f.ShowDialog();
        }
    }
}
