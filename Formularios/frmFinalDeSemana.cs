using System;
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
    public partial class frmFinalDeSemana : Form
    {
        public frmFinalDeSemana()
        {
            InitializeComponent();
        }

        private void frmFinalDeSemana_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cbFinalDeSemana;
            impedirBotoes();
            adicionarItemsCB();
        }

        private void adicionarItemsCB() 
        {
            ArrayList listaFinalDeSemana = ControllerFinalDeSemana.recuperar();
            cbFinalDeSemana.Items.Clear();
            foreach (ModeloFinalDeSemana f in listaFinalDeSemana)
            {
                cbFinalDeSemana.Items.Add(f.getFds());
            }
        }
        private void impedirBotoes()
        {
            if (cbFinalDeSemana.Text == "" && chbSegundaM.Checked == false && chbSegundaT.Checked == false && chbTercaM.Checked == false && chbTercaT.Checked == false && chbQuartaM.Checked == false && chbQuartaT.Checked == false && chbQuintaM.Checked == false && chbQuintaT.Checked == false && chbSextaM.Checked == false && chbSextaT.Checked == false && chbSabadoM.Checked == false && chbDomingoM.Checked == false && chbDomingoT.Checked == false)
            {
                btnAdicionar.Enabled = true;
                btnCancelar.Enabled = false;
                btnEditar.Enabled = false;
                btnRemover.Enabled = false;
                btnConfirmar.Enabled = false;
                btnAdicionar.FlatStyle = FlatStyle.Popup;
                btnEditar.FlatStyle = FlatStyle.Flat;
                btnRemover.FlatStyle = FlatStyle.Flat;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
                btnCancelar.FlatStyle = FlatStyle.Flat;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
                btnEditar.Cursor = System.Windows.Forms.Cursors.Default;
                btnRemover.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else if(cbFinalDeSemana.Text != "" && chbSegundaM.Checked == true || chbSegundaT.Checked == true || chbTercaM.Checked == true || chbTercaT.Checked == true || chbQuartaM.Checked == true || chbQuartaT.Checked == true || chbQuintaM.Checked == true || chbQuintaT.Checked == true || chbSextaM.Checked == true || chbSextaT.Checked == true || chbSabadoM.Checked == true || chbDomingoM.Checked == true || chbDomingoT.Checked == true)
            {
                btnEditar.Enabled = true;
                btnRemover.Enabled = true;
                btnConfirmar.Enabled = true;
                btnCancelar.Enabled = true;
                btnEditar.FlatStyle = FlatStyle.Popup;
                btnRemover.FlatStyle = FlatStyle.Popup;
                btnConfirmar.FlatStyle = FlatStyle.Popup;
                btnCancelar.FlatStyle = FlatStyle.Popup;
                btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnRemover.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void atualizarBotoes()
        {
            if (chbSegunda.Enabled == true)
            {
                btnAdicionar.Enabled = false;
                btnRemover.Enabled = false;
                btnRemover.FlatStyle = FlatStyle.Flat;
                btnAdicionar.FlatStyle = FlatStyle.Flat;
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Default;
                btnRemover.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                btnAdicionar.Enabled = true;
                btnRemover.Enabled = true;
                btnRemover.FlatStyle = FlatStyle.Popup;
                btnAdicionar.FlatStyle = FlatStyle.Popup;
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnRemover.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void mudarEstadoCHB (Boolean estado)
        {
            chbSegunda.Enabled = estado;
            chbSegundaM.Enabled = estado;
            chbSegundaT.Enabled = estado;
            chbTerca.Enabled = estado;
            chbTercaM.Enabled = estado;
            chbTercaT.Enabled = estado;
            chbQuarta.Enabled = estado;
            chbQuartaM.Enabled = estado;
            chbQuartaT.Enabled = estado;
            chbQuinta.Enabled = estado;
            chbQuintaM.Enabled = estado;
            chbQuintaT.Enabled = estado;
            chbSexta.Enabled = estado;
            chbSextaM.Enabled = estado;
            chbSextaT.Enabled = estado;
            chbSabado.Enabled = estado;
            chbSabadoM.Enabled = estado;
            chbSabadoT.Enabled = estado;
            chbDomingo.Enabled = estado;
            chbDomingoM.Enabled = estado;
            chbDomingoT.Enabled = estado;
        }

        private void limpar() 
        {
            cbFinalDeSemana.Text = "";
            chbSegunda.Checked = false;
            chbSegundaM.Checked = false;
            chbSegundaT.Checked = false;
            chbTerca.Checked = false;
            chbTercaM.Checked = false;
            chbTercaT.Checked = false;
            chbQuarta.Checked = false;
            chbQuartaM.Checked = false;
            chbQuartaT.Checked = false;
            chbQuinta.Checked = false;
            chbQuintaM.Checked = false;
            chbQuintaT.Checked = false;
            chbSexta.Checked = false;
            chbSextaM.Checked = false;
            chbSextaT.Checked = false;
            chbSabado.Checked = false; 
            chbSabadoM.Checked = false;
            chbSabadoT.Checked = false;
            chbDomingo.Checked = false;
            chbDomingoM.Checked = false;
            chbDomingoT.Checked = false;
        }
        private void gravar()
        {
            Boolean existe = false, segundaM = false, segundaT = false, tercaM = false, tercaT = false, quartaM = false, quartaT = false, quintaM = false, quintaT = false, sextaM = false, sextaT = false, sabadoM = false, sabadoT = false, domingoM = false, domingoT = false;
            String fds = cbFinalDeSemana.Text;
            if (chbSegundaM.Checked) 
            {
                segundaM = true;
            }
            if (chbSegundaT.Checked) 
            {
                segundaT = true;
            }
            if (chbTercaM.Checked) 
            {
                tercaM = true;
            }
            if (chbTercaT.Checked) 
            {
                tercaT = true;
            }
            if (chbQuartaM.Checked) 
            {
                quartaM = true;
            }
            if (chbQuartaT.Checked) 
            {
                quartaT = true;
            }
            if (chbQuintaM.Checked) 
            {
                quintaM = true;
            }
            if (chbQuintaT.Checked) 
            {
                quintaT = true;
            }
            if (chbSextaM.Checked) 
            {
                sextaM = true;
            }
            if (chbSextaT.Checked) 
            {
                sextaT = true;
            }
            if (chbSabadoM.Checked) 
            {
                sabadoM = true;
            }
            if (chbSabadoT.Checked) 
            {
                sabadoT = true;
            }
            if (chbDomingoM.Checked) 
            {
               domingoM = true;
            }
            if (chbDomingoT.Checked) 
            {
               domingoT = true;
            }
            int id = 0;
            ArrayList listaFeriados = ControllerFinalDeSemana.recuperar();
            foreach (ModeloFinalDeSemana f in listaFeriados) 
            {
                if (f.getFds().ToLower().Equals(fds.ToLower())) 
                {
                    existe = true;
                    id = f.getId();
                }
            }
            if (existe == false)
            {
                id = getCod() + 1;
                ControllerFinalDeSemana.Guardar(id, fds, segundaM, segundaT, tercaM, tercaT, quartaM, quartaT, quintaM, quintaT, sextaM, sextaT, sabadoM, sabadoT, domingoM, domingoT);
            }
            else 
            {
                ControllerFinalDeSemana.atualizar(id, fds, segundaM, segundaT, tercaM, tercaT, quartaM, quartaT, quintaM, quintaT, sextaM, sextaT, sabadoM, sabadoT, domingoM, domingoT);
            }
        }

        private int getCod() 
        {
            int cod = 0;
            ArrayList listaFinalDeSemana = ControllerFinalDeSemana.recuperar();
            foreach (ModeloFinalDeSemana f in listaFinalDeSemana) 
            {
                if (f.getId()!=0) 
                {
                    cod = f.getId();
                }
            }
            return cod;
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            frmFeriados f = new frmFeriados();
            f.Show();
            this.Close();
        }

        private void btnAdicionar_MouseEnter(object sender, EventArgs e)
        {
            lblAdicionar.Visible = true;
        }

        private void btnAdicionar_MouseLeave(object sender, EventArgs e)
        {
            lblAdicionar.Visible = false;
        }

        private void btnEditar_MouseEnter(object sender, EventArgs e)
        {
            lblEditar.Visible = true;
        }

        private void btnEditar_MouseLeave(object sender, EventArgs e)
        {
            lblEditar.Visible = false;
        }

        private void btnRemover_MouseEnter(object sender, EventArgs e)
        {
            lblRemover.Visible = true;
        }

        private void btnRemover_MouseLeave(object sender, EventArgs e)
        {
            lblRemover.Visible = false;
        }

        private void btnConfirmar_MouseEnter(object sender, EventArgs e)
        {
            lblConfirmar.Visible = true;
        }

        private void btnConfirmar_MouseLeave(object sender, EventArgs e)
        {
            lblConfirmar.Visible = false;
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            lblCancelar.Visible = true;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            lblCancelar.Visible = false;
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            mudarEstadoCHB(true);
            this.ActiveControl = cbFinalDeSemana;
            impedirBotoes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            atualizarBotoes();
            mudarEstadoCHB(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            impedirBotoes();
            mudarEstadoCHB(false);
            limpar();
        }

        private void cbFinalDeSemana_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void cbFinalDeSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            impedirBotoes();
            String fds = cbFinalDeSemana.Text;
            ArrayList listaFinalDeSemana = ControllerFinalDeSemana.recuperar();
            Boolean segundaM = false, segundaT = false, tercaM = false, tercaT = false, quartaM = false, quartaT = false, quintaM = false, quintaT = false, sextaM = false, sextaT = false, sabadoM = false, sabadoT = false, domingoM = false, domingoT = false;
            foreach (ModeloFinalDeSemana f in listaFinalDeSemana)
            {
                if (f.getFds().ToLower().Equals(fds.ToLower()))
                {
                    segundaM = f.getSegundaM();
                    segundaT = f.getSegundaT();
                    tercaM = f.getTercaM();
                    tercaT = f.getTercaT();
                    quartaM = f.getQuartaM();
                    quartaT = f.getQuartaT();
                    quintaM = f.getQuintaM();
                    quintaT = f.getQuintaT();
                    sextaM = f.getSextaM();
                    sextaT = f.getSextaT();
                    sabadoM = f.getSabadoM();
                    sabadoT = f.getSabadoT();
                    domingoM = f.getDomingoM();
                    domingoT = f.getDomingoT();
                }
            }


            if (segundaM == true)
            {
                chbSegundaM.Checked = true;
                chbSegunda.Checked = true;
            }
            else 
            {
                chbSegundaM.Checked = false;
                chbSegunda.Checked = false;
            }


            if (segundaT == true)
            {
                chbSegundaT.Checked = true;
                chbSegunda.Checked = true;
            }
            else 
            {
                chbSegundaT.Checked = false;
                chbSegunda.Checked = false;
            }


            if (tercaM == true)
            {
                chbTercaM.Checked = true;
                chbTerca.Checked = true;
            }
            else 
            {
                chbTercaM.Checked = false;
                chbTerca.Checked = false;
            }


            if (tercaT == true)
            {
                chbTercaT.Checked = true;
                chbTerca.Checked = true;
            }
            else 
            {
                chbTercaT.Checked = false;
                chbTerca.Checked = false;
            }


            if (quartaM == true)
            {
                chbQuartaM.Checked = true;
                chbQuarta.Checked = true;
            }
            else 
            {
                chbQuartaM.Checked = false;
                chbQuarta.Checked = false;
            }


            if (quartaT == true)
            {
                chbQuartaT.Checked = true;
                chbQuarta.Checked = true;
            }
            else 
            {
                chbQuartaT.Checked = false;
                chbQuarta.Checked = false;
            }


            if (quintaM == true)
            {
                chbQuintaT.Checked = true;
                chbQuinta.Checked = true;
            }
            else 
            {
                chbQuintaT.Checked = false;
                chbQuinta.Checked = false;
            }


            if (quintaT == true)
            {
                chbQuintaT.Checked = true;
                chbQuinta.Checked = true;
            }
            else 
            {
                chbQuintaT.Checked = false;
                chbQuinta.Checked = false;
            }


            if (sextaM == true)
            {
                chbSextaM.Checked = true;
                chbSexta.Checked = true;
            }
            else 
            {
                chbSextaM.Checked = false;
                chbSexta.Checked = false;
            }


            if (sextaT == true)
            {
                chbSextaT.Checked = true;
                chbSexta.Checked = true;
            }
            else 
            {
                chbSextaT.Checked = false;
                chbSexta.Checked = false;
            }


            if (sabadoM == true)
            {
                chbSabado.Checked = true;
                chbSabadoM.Checked = true;
            }
            else 
            {
                chbSabado.Checked = false;
                chbSabadoM.Checked = false;
            }


            if (sabadoT == true)
            {
                chbSabadoT.Checked = true;
                chbSabado.Checked = true;
            }
            else 
            {
                chbSabadoT.Checked = false;
                chbSabado.Checked = false;
            }


            if (domingoM == true)
            {
                chbDomingoM.Checked = true;
                chbDomingo.Checked = true;
            }
            else 
            {
                chbDomingoM.Checked = false;
                chbDomingo.Checked = false;
            }


            if (domingoT == true)
            {
                chbDomingoT.Checked = true;
                chbDomingo.Checked = true;
            }
            else 
            {
                chbDomingoT.Checked = false;
                chbDomingo.Checked = false;
            }
        }

        private void chbSegundaM_CheckStateChanged(object sender, EventArgs e)
        {
            //impedirBotoes();
        }

        private void chbSegundaM_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbSegundaT_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbTercaM_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbTercaT_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbQuartaM_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbQuartaT_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbQuintaM_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbQuintaT_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbSextaM_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbSextaT_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbSabadoM_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbSabadoT_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbDomingoM_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void chbDomingoT_CheckedChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            limpar();
            mudarEstadoCHB(false);
            impedirBotoes();
            adicionarItemsCB();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            ArrayList listaFinalDeSemana = ControllerFinalDeSemana.recuperar();
            int cod = 0;
            foreach (ModeloFinalDeSemana f in listaFinalDeSemana) 
            {
                if (f.getFds().ToLower().Equals(cbFinalDeSemana.Text.ToLower()))
                {
                    cod = f.getId();
                }
            }
            if (cod != 0) 
            {
                ControllerFinalDeSemana.remover(cod);
            }
        }

        private void btnSeguinte_Click(object sender, EventArgs e)
        {
            frmTempoDeServico f = new frmTempoDeServico();
            f.Show();
            this.Close();
        }
    }
}
