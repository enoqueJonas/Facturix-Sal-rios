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
    public partial class frmTabelaDeRemuneracoes : Form
    {
        private int codigoCelSelecionada;
        private int nrSub = 0;
        public frmTabelaDeRemuneracoes()
        {
            InitializeComponent();
        }

        private void frmTabelaDeRemuneracoes_Load(object sender, EventArgs e)
        {
            refrescar();
            dataRemuneracoes.Focus();
            dataRemuneracoes.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;
            dataRemuneracoes.RowsDefaultCellStyle.SelectionForeColor = Color.White;
        }

        public void refrescar()
        {
            ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
            preencherDtView(listaRemuneracoes);
        }

        private void preencherDtView(ArrayList lista) 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Registo n°");
            dt.Columns.Add("Natureza");
            dt.Columns.Add("Grupo");
            foreach (ModeloRemuneracoes r in lista)
            {
                DataRow dRow = dt.NewRow();
                dRow["Registo n°"] = r.getId();
                dRow["Natureza"] = r.getNatureza();
                dRow["Grupo"] = r.getGrupo();
                dt.Rows.Add(dRow);
                nrSub++;
            }
            dataRemuneracoes.DataSource = dt;
            dataRemuneracoes.AllowUserToAddRows = false;
            dataRemuneracoes.Refresh();
            dataRemuneracoes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataRemuneracoes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            txtNumeroDeRemuneracoes.Text = nrSub + "";
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmRemuneracoes f = new frmRemuneracoes();
            f.Show();
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmNumeroRegisto f = new frmNumeroRegisto();
            f.Show();
            int cod = f.enterdCod;
            ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperarComCod(cod);
            preencherDtView(listaRemuneracoes);
        }

        private void dataRemuneracoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataRemuneracoes.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            ArrayList listaremuneracoes = ControllerRemuneracoes.recuperarComCod(codigoCelSelecionada);
            frmRemuneracoes frm = new frmRemuneracoes();
            frm.Show();
            foreach (ModeloRemuneracoes r in listaremuneracoes)
            {
                frm.txtPercentagem.Text = r.getPercentagem()+"";
                frm.txtRegistoNr.Text = r.getId() + "";
                frm.cbValorUnit.Text = r.getValorUnitario() + "";

                if (r.getSegurancaSocial() == true)
                {
                    frm.chbSegurancaSocial.Checked = true;
                }
                else {
                    frm.chbSegurancaSocial.Checked = false;
                }

                if (r.getSeguro() == true)
                {
                    frm.chbSeguro.Checked = true;
                }
                else
                {
                    frm.chbSeguro.Checked = false;
                }

                if (r.getIrps() == true)
                {
                    frm.chbIrps.Checked = true;
                }
                else
                {
                    frm.chbIrps.Checked = false;
                }

                frm.cbGrupo.Text = r.getGrupo();
                frm.cbNatureza.Text = r.getNatureza();
                frm.cbQuantidade.Text = r.getQuantidade();
                frm.cbInsento.Text = r.getIsento();
                frm.txtValor.Text = r.getValor()+"";
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        private void frmTabelaDeRemuneracoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (MessageBox.Show("Pretende Voltar ao menu principal?", "Atenção!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void frmTabelaDeRemuneracoes_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        int rowSelected;
        private void dataRemuneracoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ArrayList listaremuneracoes = ControllerRemuneracoes.recuperarComCod(codigoCelSelecionada);
                frmRemuneracoes frm = new frmRemuneracoes();
                frm.Show();
                foreach (ModeloRemuneracoes r in listaremuneracoes)
                {
                    frm.txtPercentagem.Text = r.getPercentagem() + "";
                    frm.txtRegistoNr.Text = r.getId() + "";
                    frm.cbValorUnit.Text = r.getValorUnitario() + "";

                    if (r.getSegurancaSocial() == true)
                    {
                        frm.chbSegurancaSocial.Checked = true;
                    }
                    else
                    {
                        frm.chbSegurancaSocial.Checked = false;
                    }

                    if (r.getSeguro() == true)
                    {
                        frm.chbSeguro.Checked = true;
                    }
                    else
                    {
                        frm.chbSeguro.Checked = false;
                    }

                    if (r.getIrps() == true)
                    {
                        frm.chbIrps.Checked = true;
                    }
                    else
                    {
                        frm.chbIrps.Checked = false;
                    }

                    frm.cbGrupo.Text = r.getGrupo();
                    frm.cbNatureza.Text = r.getNatureza();
                    frm.cbQuantidade.Text = r.getQuantidade();
                    frm.cbInsento.Text = r.getIsento();
                    frm.txtValor.Text = r.getValor() + "";
                }
                e.Handled = true;
            }
        }

        private void dataRemuneracoes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataRemuneracoes.Rows[rowIndex];
            codigoCelSelecionada = int.Parse(row.Cells[0].Value.ToString());
            rowSelected = rowIndex;
        }
    }
}
