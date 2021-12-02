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
    public partial class frmTempoDeServico : Form
    {
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
