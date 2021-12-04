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
    public partial class frmTempoDeServico : Form
    {
        private int codigoItemSelecionado;
        public frmTempoDeServico()
        {
            InitializeComponent();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            frmFinalDeSemana f = new frmFinalDeSemana();
            f.Show();
            this.Close();
        }

        private void btnSeguinte_Click(object sender, EventArgs e)
        {
            frmDepartamentos f = new frmDepartamentos();
            f.Show();
            this.Close();
        }

        private void frmTempoDeServico_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cbServico;
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
        private void impedirBotoes()
        {
            if (cbServico.Text == "" || nrTempoServicoH.Value == 0 || nrForaDeServicoH.Value == 0)
            {
                btnAdicionarHora.Enabled = true;
                btnCancelarHora.Enabled = false;
                btnEditarHora.Enabled = false;
                btnRemoverHora.Enabled = false;
                btnConfirmarHora.Enabled = false;
                btnAdicionarHora.FlatStyle = FlatStyle.Popup;
                btnEditarHora.FlatStyle = FlatStyle.Flat;
                btnRemoverHora.FlatStyle = FlatStyle.Flat;
                btnConfirmarHora.FlatStyle = FlatStyle.Flat;
                btnCancelarHora.FlatStyle = FlatStyle.Flat;
                btnCancelarHora.Cursor = System.Windows.Forms.Cursors.Default;
                btnEditarHora.Cursor = System.Windows.Forms.Cursors.Default;
                btnRemoverHora.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmarHora.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else if (cbServico.Text != "" || nrTempoServicoH.Value != 0 || nrForaDeServicoH.Value != 0)
            {
                btnEditarHora.Enabled = true;
                btnRemoverHora.Enabled = true;
                btnConfirmarHora.Enabled = true;
                btnCancelarHora.Enabled = true;
                btnEditarHora.FlatStyle = FlatStyle.Popup;
                btnRemoverHora.FlatStyle = FlatStyle.Popup;
                btnConfirmarHora.FlatStyle = FlatStyle.Popup;
                btnCancelarHora.FlatStyle = FlatStyle.Popup;
                btnEditarHora.Cursor = System.Windows.Forms.Cursors.Hand;
                btnRemoverHora.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfirmarHora.Cursor = System.Windows.Forms.Cursors.Hand;
                btnCancelarHora.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void frmTempoDeServico_Load_1(object sender, EventArgs e)
        {
            this.ActiveControl = cbServico;
            impedirBotoes();
            adicionarItemsCb();
        }

        private void adicionarItemsCb() 
        {
            cbServico.Items.Clear();
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            foreach (ModeloHorarios f in listaHorarios) 
            {
                cbServico.Items.Add(f.getTempoServico());
            }
        }

        private void mudarEstadoChBoxes(Boolean estado) 
        {
            nrTempoServicoH.Enabled = estado;
            nrTempoDeServicoM.Enabled = estado;
            nrForaDeServicoH.Enabled = estado;
            nrForaDeServicoM.Enabled = estado;
            chbDeveBaterPonto.Enabled = estado;
            chbDeveCalcularAtraso.Enabled = estado;
            chbDeveCalcularAusencia.Enabled = estado;
            chbDeveCalcularSaidaAdiantada.Enabled = estado;
            chbDeveMarcarPonto.Enabled = estado;
        }
        private void mudarEstadoLabels(Boolean estado) 
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
            lbl10.Visible = estado;
        }
        private void gravar() 
        {
            String servico = cbServico.Text;
            decimal emTempoH = nrTempoServicoH.Value;
            decimal emTempoM = nrTempoDeServicoM.Value;
            decimal foraDoTempoH = nrForaDeServicoH.Value;
            decimal foraDoTempoM = nrForaDeServicoM.Value;
            Boolean deveMarcar = false, deveBaterPonto = false, atraso = false, ausencia = false, saidaAdiantada = false, existe = false;
            if (chbDeveMarcarPonto.Checked) 
            {
                deveMarcar = true;
            }
            if (chbDeveBaterPonto.Checked) 
            {
                deveBaterPonto = true;
            }
            if (chbDeveCalcularAtraso.Checked) 
            {
                atraso = true;
            }
            if (chbDeveCalcularAusencia.Checked) 
            {
                ausencia = true;
            }
            if (chbDeveCalcularSaidaAdiantada.Checked) 
            {
                saidaAdiantada = true;
            }
            int cod = 0;
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            foreach (ModeloHorarios f in listaHorarios) 
            {
                if (f.getTempoServico().ToLower().Equals(servico.ToLower())) 
                {
                    existe = true;
                    cod = f.getId();
                }
            }

            if (existe)
            {
                ControllerHorarios.atualizar(cod, servico, emTempoH, emTempoM, foraDoTempoH, foraDoTempoM, deveMarcar, deveBaterPonto, saidaAdiantada, atraso, ausencia);
            }
            else 
            {
                cod = getCod() + 1;
                ControllerHorarios.Guardar(cod, servico, emTempoH, emTempoM, foraDoTempoH, foraDoTempoM, deveMarcar, deveBaterPonto, saidaAdiantada, atraso, ausencia);
            }
        }

        private int getCod() 
        {
            int cod = 0;
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            foreach (ModeloHorarios f in listaHorarios)
            {
                if (f.getId()!=0)
                {
                    cod = f.getId();
                }
            }
            return cod;
        }

        private void limpar() 
        {
            cbServico.Text = "";
            nrForaDeServicoH.Value = 0;
            nrForaDeServicoM.Value = 0;
            nrTempoDeServicoM.Value = 0;
            nrTempoServicoH.Value = 0;
            chbDeveBaterPonto.Checked = false;
            chbDeveCalcularAtraso.Checked = false;
            chbDeveCalcularAusencia.Checked = false;
            chbDeveCalcularSaidaAdiantada.Checked = false;
            chbDeveMarcarPonto.Checked = false;
        }

        private void btnConfirmarHora_Click(object sender, EventArgs e)
        {
            gravar();
            limpar();
            impedirBotoes();
            adicionarItemsCb();
        }

        private void btnCancelarHora_Click(object sender, EventArgs e)
        {
            limpar();
            impedirBotoes();
            mudarEstadoLabels(false);
        }

        private void btnEditarHora_Click(object sender, EventArgs e)
        {
            mudarEstadoLabels(true); 
            mudarEstadoChBoxes(true);
        }

        private void btnAdicionarHora_Click(object sender, EventArgs e)
        {
            limpar();
            this.ActiveControl = cbServico;
            mudarEstadoChBoxes(true);
            impedirBotoes();
        }

        private void cbServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            impedirBotoes();
            String servico = cbServico.Text;
            ArrayList listaHorarios = ControllerHorarios.recuperar();
            foreach (ModeloHorarios f in listaHorarios)
            {
                if (f.getTempoServico().ToLower().Equals(servico.ToLower()))
                {
                    codigoItemSelecionado = f.getId();
                    nrTempoServicoH.Value = f.getEmTempoH();
                    nrTempoDeServicoM.Value = f.getEmTempoM();
                    nrForaDeServicoH.Value = f.getForaDoTempo();
                    nrForaDeServicoM.Value = f.getForaDoTempoM();
                    if (f.getAusencia())
                    {
                        chbDeveCalcularAusencia.Checked = true;
                    }
                    else 
                    {
                        chbDeveCalcularAusencia.Checked = true;
                    }

                    if (f.getSaidaAdiantada())
                    {
                        chbDeveCalcularSaidaAdiantada.Checked = true;
                    }
                    else 
                    {
                        chbDeveCalcularSaidaAdiantada.Checked = false;
                    }

                    if (f.getAtraso())
                    {
                        chbDeveCalcularAtraso.Checked = true;
                    }
                    else 
                    {
                        chbDeveCalcularAtraso.Checked = false;
                    }

                    if (f.getBaterPonto())
                    {
                        chbDeveBaterPonto.Checked = true;
                    }
                    else 
                    {
                        chbDeveBaterPonto.Checked = false;
                    }

                    if (f.getMarcarPonto())
                    {
                        chbDeveMarcarPonto.Checked = true;
                    }
                    else 
                    {
                        chbDeveMarcarPonto.Checked = false;
                    }
                }
            }
            mudarEstadoChBoxes(false);
        }

        private void cbServico_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void nrTempoServicoH_ValueChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void nrForaDeServicoH_ValueChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void btnRemoverHora_Click(object sender, EventArgs e)
        {
            ControllerHorarios.remover(codigoItemSelecionado);
            adicionarItemsCb();
            limpar();
            impedirBotoes();
        }

        /*
        private void atualizarBotoes()
        {
            if (lbl1.Visible == true)
            {
                btnAdicionarHora.Enabled = false;
                btnRemoverHora.Enabled = false;
                btnRemoverHora.FlatStyle = FlatStyle.Flat;
                btnAdicionarHora.FlatStyle = FlatStyle.Flat;
                btnAdicionarHora.Cursor = System.Windows.Forms.Cursors.Default;
                btnRemoverHora.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                btnAdicionarHora.Enabled = true;
                btnRemoverHora.Enabled = true;
                btnRemoverHora.FlatStyle = FlatStyle.Popup;
                btnAdicionarHora.FlatStyle = FlatStyle.Popup;
                btnAdicionarHora.Cursor = System.Windows.Forms.Cursors.Hand;
                btnRemoverHora.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }
        */
    }
}
