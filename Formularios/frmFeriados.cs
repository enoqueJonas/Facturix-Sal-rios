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
    public partial class frmFeriados : Form
    {
        private int codigoCelSelecionada;
        public frmFeriados()
        {
            InitializeComponent();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Close();
            frmRegrasDeBatidaDePonto F = new frmRegrasDeBatidaDePonto();
            F.ShowDialog();
        }

        private void frmFeriados_Load(object sender, EventArgs e)
        {
            impedirBotoes();
            refrescar();
            this.ActiveControl = txtNome;
        }

        private int getCod() 
        {
            ArrayList listaFeriados = ControllerFeriado.recuperar();
            int cod = 0;
            foreach (ModeloFeriado f in listaFeriados)
            {
                if (f.getId()!=0)
                {
                    cod = f.getId();
                }
            }
            return cod;
        }
        private void gravar() 
        {
            String nome = txtNome.Text;
            String dataInicio = dateTimeInicio.Value.ToString("yyyy-MM-dd");
            String dataFim = dateTimeFim.Value.ToString("yyyy-MM-dd");
            Boolean existe = false;
            int id = 0;
            ArrayList listaFeriados = ControllerFeriado.recuperar();
            foreach (ModeloFeriado f in listaFeriados) 
            {
                if (nome.ToLower().Equals(f.getNome().ToLower())) 
                {
                    existe = true;
                    id = f.getId();
                }
            }
            if (existe == false) 
            {
                id = getCod() + 1;
                ControllerFeriado.gravar(id, nome, dataInicio, dataFim);
            }
            else{
                ControllerFeriado.gravar(id, nome, dataInicio, dataFim);
            }
        }
        private void refrescar()
        {
            ArrayList listaFeriados = ControllerFeriado.recuperar();
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Designação");
            dt.Columns.Add("Início");
            dt.Columns.Add("Fim");
            foreach (ModeloFeriado func in listaFeriados)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = func.getId();
                dRow["Designação"] = func.getNome();
                dRow["Início"] = func.getDataInicio();
                dRow["Fim"] = func.getDataFim();
                dt.Rows.Add(dRow);
            }
            dtFeriados.DataSource = dt;
            dtFeriados.AllowUserToAddRows = false;
            dtFeriados.Refresh();
            dtFeriados.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dtFeriados.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private void impedirBotoes()
        {
            if (txtNome.Text == "")
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
            else
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
            if (lbl1.Visible == true)
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
        private void mudarVisibilidadeLabels(Boolean estado) 
        {
            lbl1.Visible = estado;
            lbl2.Visible = estado;
            lbl3.Visible = estado;
        }
        private void limpar() 
        {
            txtNome.Text = "";
            dateTimeInicio.Value = DateTime.Now;
            dateTimeFim.Value = DateTime.Now;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            this.ActiveControl= txtNome;
            limpar();
            btnEditar.Enabled = false;
            btnRemover.Enabled = false;
        }

        private void btnAdicionar_MouseEnter(object sender, EventArgs e)
        {
            if (btnAdicionar.Enabled == true)
            {
                lblAdicionar.Visible = true;
            }
            else 
            {
                lblAdicionar.Visible = true;
            }
        }

        private void btnAdicionar_MouseLeave(object sender, EventArgs e)
        {
            lblAdicionar.Visible = false;
        }

        private void btnEditar_MouseEnter(object sender, EventArgs e)
        {
            if (btnEditar.Enabled == false)
            {
                lblEditar.Visible = true;
            }
            else
            {
                lblEditar.Visible = true;
            }
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
            atualizarBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(false);
            limpar();
            impedirBotoes();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            refrescar();
            impedirBotoes();
            limpar();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            ControllerFeriado.remover(codigoCelSelecionada);
        }

        private void dtFeriados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dtFeriados.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaFeriados = ControllerFeriado.recuperarComCod(codigoCelSelecionada);
            foreach (ModeloFeriado func in listaFeriados)
            {
                txtNome.Text = func.getNome();
                dateTimeInicio.Value = Convert.ToDateTime(func.getDataInicio());
                dateTimeFim.Value = Convert.ToDateTime(func.getDataFim());
            }
        }

        private void btnSeguinte_Click(object sender, EventArgs e)
        {
            frmFinalDeSemana f = new frmFinalDeSemana();
            f.ShowDialog();
            this.Close();
        }
    }
}
