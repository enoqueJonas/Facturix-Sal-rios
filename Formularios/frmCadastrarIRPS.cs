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
using System.Text.RegularExpressions;

namespace Facturix_Salários.Formularios.Cadastros
{
    public partial class frmCadastrarIRPS : Form
    {
        public frmCadastrarIRPS()
        {
            InitializeComponent();
        }
        private void gravar() 
        {
            ArrayList listaIRPS = ControllerIRPS.recuperar();
            int id = int.Parse(txtNrRegisto.Text);
            double salarioMin = 0;
            double salarioMax;
            int dependentes = 0;
            float valor = 0;
            float coeficiente = 0;
            Boolean existe = false;
            if (txtSalarioMax.Text == "")
            {
                salarioMax = 0;
            }
            else 
            {
                salarioMax = float.Parse(txtSalarioMax.Text);
            }
            if (txtSalarioMin.Text == "")
            {
                MessageBox.Show("Salário mínimo inválido!");
            }
            else 
            {
                salarioMin = float.Parse(txtSalarioMin.Text); 
            }
            if (txtValor.Text == "")
            {
                MessageBox.Show("Valor inválido!");
            }
            else 
            {
                valor = float.Parse(txtValor.Text);
            }if (txtCoeficiente.Text == "")
            {
                MessageBox.Show("Coeficiente inválido!");
            }
            else 
            {
                coeficiente = float.Parse(txtCoeficiente.Text);
            }
            if (txtDependentes.Text == "")
            {
                MessageBox.Show("Número de dependentes inválido!");
            }
            else 
            {
                dependentes = int.Parse(txtDependentes.Text);
            }
            foreach (ModeloIRPS ir in listaIRPS) 
            {
                if (ir.getSalarioMax() == salarioMax && ir.getSalarioMin() == salarioMin && ir.getNrDependentes() == dependentes) 
                {
                    existe = true;
                }
            }
            if (existe == false)
            {
                ControllerIRPS.gravar(id, salarioMin, salarioMax, valor, dependentes, coeficiente);
                //adicionar();
            }
            else 
            {
                ControllerIRPS.atualizar(id, salarioMin, salarioMax, valor, dependentes, coeficiente);
                limparCaixas();
            }
        }

        private void adicionar() 
        {
            //limparCaixas();
            setCod();
        }
        private void limparCaixas() 
        {
            txtNrRegisto.Text = "";
            txtSalarioMax.Text = "";
            txtSalarioMin.Text = "";
            txtValor.Text = "";
            txtDependentes.Text = "";
            txtCoeficiente.Text = "";
        }

        private void setCod() 
        {
            txtNrRegisto.Text = getCod() + 1 + "";
        }
        private int getCod() 
        {
            int cod = 0;
            ArrayList listaIRPS = ControllerIRPS.recuperar();
            foreach (ModeloIRPS f in listaIRPS)
            {
                if (f.getId() != 0)
                {
                    cod = f.getId();
                }
            }
            return cod;
        }
        private void montarCaixasDeTexto(ArrayList listaIRPS) 
        {

        }
        private void frmCadastrarIRPS_Load(object sender, EventArgs e)
        {
            dtViewIRPS.ColumnHeadersHeight = dtViewIRPS.ColumnHeadersHeight * 2;
            dtViewIRPS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dtViewIRPS.CellPainting += new DataGridViewCellPaintingEventHandler(dtViewIRPS_CellPainting);
            dtViewIRPS.Paint += new PaintEventHandler(dtViewIRPS_Paint);
            dtViewIRPS.Scroll += new ScrollEventHandler(dtViewIRPS_scroll);
            dtViewIRPS.ColumnWidthChanged += new DataGridViewColumnEventHandler(dtViewIRPS_ColumnWidthChanged);
            refrescar();
            mudarLarguraCelulas();
            dtViewIRPS.AutoResizeColumnHeadersHeight();
            foreach (DataGridViewColumn col in dtViewIRPS.Columns)
            {
                if (col.HeaderText == "1" || col.HeaderText == "2" || col.HeaderText == "3" || col.HeaderText == "4 ou mais" || col.HeaderText == "0")
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                }
                else 
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            setCod();
            impedirBotoes();
        }

        private void mudarLarguraCelulas()
        {
            //dtViewIRPS.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtViewIRPS.Columns["Limites dos Intervalos de Salário bruto mensal (MTS)"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtViewIRPS.Columns["0"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtViewIRPS.Columns["1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtViewIRPS.Columns["2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtViewIRPS.Columns["3"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtViewIRPS.Columns["4 ou mais"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtViewIRPS.Columns["Coeficiente aplicável à cada unidade adicional do limite inferior do salário bruto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //dtViewIRPS.Columns["ID"].Width = -5;
            dtViewIRPS.Columns["Limites dos Intervalos de Salário bruto mensal (MTS)"].Width = 195;
            dtViewIRPS.Columns["0"].Width = 90;
            dtViewIRPS.Columns["1"].Width = 90;
            dtViewIRPS.Columns["2"].Width = 90;
            dtViewIRPS.Columns["3"].Width = 90;
            dtViewIRPS.Columns["4 ou mais"].Width = 90;
            dtViewIRPS.Columns["Coeficiente aplicável à cada unidade adicional do limite inferior do salário bruto"].Width = 160;
        }

        Control ctrl;
        private void mexerTeclado(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (ctrl is TextBox)
            {
                if (e.KeyCode == Keys.Enter || e.Alt && e.KeyCode == Keys.Down || e.Alt && e.KeyCode == Keys.Right)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.Alt && e.KeyCode == Keys.Up || e.Alt && e.KeyCode == Keys.Left)
                {
                    this.SelectNextControl(ctrl, false, true, true, true);
                }
                else
                    return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.KeyCode == Keys.Up && e.Control)
                {
                    this.SelectNextControl(ctrl, false, true, true, true);
                }
                else
                    return;
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void refrescar()
        {
            ArrayList listaIRPS = ControllerIRPS.recuperar();
            ArrayList listaIrpsSalMin;
            double salarioMin, valor;
            DataTable dt = new DataTable();
            //dt.Columns.Add("ID");
            dt.Columns.Add("Limites dos Intervalos de Salário bruto mensal (MTS)");
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            dt.Columns.Add("3");
            dt.Columns.Add("4 ou mais");
            dt.Columns.Add("Coeficiente aplicável à cada unidade adicional do limite inferior do salário bruto");
            foreach (ModeloIRPS ir in listaIRPS)
            {
                DataRow dRow = dt.NewRow();
                salarioMin = ir.getSalarioMin();
                listaIrpsSalMin = ControllerIRPS.recuperarComSalMin(salarioMin);
                if (ir.getSalarioMin() < 20250)
                {
                    dRow["Limites dos Intervalos de Salário bruto mensal (MTS)"] = "Até " + Math.Round(ir.getSalarioMin(), 2, MidpointRounding.AwayFromZero) + "";
                }
                else if (ir.getSalarioMin() >= 144750)
                {
                    dRow["Limites dos Intervalos de Salário bruto mensal (MTS)"] = "De  " + Math.Round(ir.getSalarioMin(), 2, MidpointRounding.AwayFromZero) + " em diante";
                }
                else 
                {
                    dRow["Limites dos Intervalos de Salário bruto mensal (MTS)"] = "De  " + Math.Round(ir.getSalarioMin(), 2) + " até " + Math.Round(ir.getSalarioMax(), 2, MidpointRounding.AwayFromZero);
                }                
                foreach (ModeloIRPS f in listaIrpsSalMin) 
                {
                    if (f.getNrDependentes() == 0) 
                    {
                        valor = Math.Round(f.getValor(), 2, MidpointRounding.AwayFromZero);
                        dRow["0"] = valor;
                    }else
                    if (f.getNrDependentes() == 1) 
                    {
                        valor = Math.Round(f.getValor(), 2, MidpointRounding.AwayFromZero);
                        dRow["1"] = valor;
                    }else
                    if (f.getNrDependentes() == 2) 
                    {
                        valor = Math.Round(f.getValor(), 2, MidpointRounding.AwayFromZero);
                        dRow["2"] = valor;
                    }else
                    if (f.getNrDependentes() == 3) 
                    {
                        valor = Math.Round(f.getValor(), 2, MidpointRounding.AwayFromZero);
                        dRow["3"] = valor;
                    }else
                    if (f.getNrDependentes() >= 4) 
                    {
                        valor = Math.Round(f.getValor(), 2, MidpointRounding.AwayFromZero);
                        dRow["4 ou mais"] = valor;
                    }
                }
                dRow["Coeficiente aplicável à cada unidade adicional do limite inferior do salário bruto"] = Math.Round(ir.getCoeficiente(), 2) + "";
                dt.Rows.Add(dRow);
            }
            DataView dtView = new DataView(dt);
            DataTable dtTable = dtView.ToTable(true, "Limites dos Intervalos de Salário bruto mensal (MTS)", "0", "1", "2", "3", "4 ou mais", "Coeficiente aplicável à cada unidade adicional do limite inferior do salário bruto");
            dtViewIRPS.DataSource = dtTable;
            dtViewIRPS.Refresh();
            dtViewIRPS.AllowUserToAddRows = false;
            dtViewIRPS.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dtViewIRPS.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private void mudarVisibilidadeLabels(Boolean estado)
        {
            lbl1.Visible = estado;
            lbl2.Visible = estado;
            lbl3.Visible = estado;
            lbl4.Visible = estado;
            lbl5.Visible = estado;
        }

        private void atualizarBotoes()
        {
            if (lbl1.Visible == true)
            {
                btnAdicionar.Enabled = false;
                btnEliminar.Enabled = false;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnAdicionar.FlatStyle = FlatStyle.Flat;
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Default;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                btnAdicionar.Enabled = true;
                btnEliminar.Enabled = true;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
                btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void impedirBotoes()
        {
            if (txtSalarioMin.Text == "" || txtValor.Text == "")
            {
                btnAdicionar.Enabled = true;
                btnCancelar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnAdicionar.FlatStyle = FlatStyle.Standard;
                btnAtualizar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnConfirmar.FlatStyle = FlatStyle.Flat;
                btnCancelar.FlatStyle = FlatStyle.Flat;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Default;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                btnAtualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnConfirmar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAtualizar.FlatStyle = FlatStyle.Standard;
                btnEliminar.FlatStyle = FlatStyle.Standard;
                btnConfirmar.FlatStyle = FlatStyle.Standard;
                btnCancelar.FlatStyle = FlatStyle.Standard;
                btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void eliminar() 
        {
            int id = int.Parse(txtNrRegisto.Text);
            ControllerIRPS.removerComCod(id);
            limparCaixas();
        }
        private void dtViewIRPS_Paint(Object sender, PaintEventArgs e) 
        {
            Rectangle r1 = dtViewIRPS.GetCellDisplayRectangle(1, -1, true);
            int w2 = dtViewIRPS.GetCellDisplayRectangle(2, -1, true).Width;
            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + 273 + w2 -2;
            r1.Height = r1.Height / 2 - 2;
            e.Graphics.FillRectangle(new SolidBrush(Color.GhostWhite), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString("Valor do IRPS a reter relativo ao limite inferior do intervalo do salário bruto, por número de dependentes(MTs)", dtViewIRPS.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dtViewIRPS.DefaultCellStyle.ForeColor), r1, format);
        }
        private void dtViewIRPS_ColumnWidthChanged(Object sender, DataGridViewColumnEventArgs e) 
        {
            Rectangle rtHeader = dtViewIRPS.DisplayRectangle;
            rtHeader.Height = dtViewIRPS.ColumnHeadersHeight / 2;
            dtViewIRPS.Invalidate(rtHeader);
        }

        private void dtViewIRPS_scroll(Object sender, ScrollEventArgs e) 
        {
            Rectangle rtHeader = dtViewIRPS.DisplayRectangle;
            rtHeader.Height = dtViewIRPS.ColumnHeadersHeight / 2;
            dtViewIRPS.Invalidate(rtHeader);
        }

        private void dtViewIRPS_CellPainting(Object sender, DataGridViewCellPaintingEventArgs e) 
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1) 
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height += e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        private void dtViewIRPS_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dtViewIRPS.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
            refrescar();
            impedirBotoes();
            mudarVisibilidadeLabels(false);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionar();
            impedirBotoes();
        }

        private void dtViewIRPS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNrRegisto.Text = "";
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dtViewIRPS.Rows[rowIndex];
            string primeiraCel = row.Cells[0].Value.ToString();
            String subPrimeiraCel = Regex.Match(primeiraCel, @"\d+").Value;
            float salMin = float.Parse(subPrimeiraCel);
            ArrayList listaIRPS = ControllerIRPS.recuperarComSalMin(salMin);
            foreach (ModeloIRPS ir in listaIRPS)
            {
                txtSalarioMin.Text = ir.getSalarioMin()+"";
                txtSalarioMax.Text = ir.getSalarioMax() + "";
                txtCoeficiente.Text = ir.getCoeficiente() + "";
            }
            impedirBotoes();
        }

        private void frmCadastrarIRPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1" && btnAdicionar.Enabled)
            {
                adicionar();
            }
            if (e.KeyCode.ToString() == "F3" && btnAtualizar.Enabled)
            {
                mudarVisibilidadeLabels(true);
                atualizarBotoes();
            }
            if (e.KeyCode.ToString() == "F4" && btnCancelar.Enabled)
            {
                limparCaixas();
                impedirBotoes();
                mudarVisibilidadeLabels(false);
            }
            if (e.KeyCode.ToString() == "F5" && btnConfirmar.Enabled)
            {
                gravar();
                impedirBotoes();
                mudarVisibilidadeLabels(false);
            }
            if (e.KeyCode.ToString() == "F6" && btnEliminar.Enabled)
            {
                eliminar();
                limparCaixas();
            }
            if (e.KeyCode.ToString() == "F7")
            {
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtSalarioMin_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtSalarioMax_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void cbDependentes_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void txtCoeficiente_KeyDown(object sender, KeyEventArgs e)
        {
            mexerTeclado(sender, e);
        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastrarIRPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (MessageBox.Show("Pretende fechar o formulário Cadastro de IRPS?", "Atenção!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void cbDependentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDependentes_TextChanged(object sender, EventArgs e)
        {
            txtValor.Text = "";
            float salMin = 0;
            int dependentes = -1;
            ArrayList listaIRPS = ControllerIRPS.recuperar();
            if (txtSalarioMin.Text != "")
            {
                salMin = float.Parse(txtSalarioMin.Text);
            }
            if (txtDependentes.Text != "") 
            {
                dependentes = int.Parse(txtDependentes.Text);
            }
            foreach (ModeloIRPS f in listaIRPS)
            {
                if (salMin == f.getSalarioMin() && dependentes == f.getNrDependentes())
                {
                    txtValor.Text = f.getValor() + "";
                    txtNrRegisto.Text = f.getId() + "";
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(true);
            atualizarBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mudarVisibilidadeLabels(false);
            limparCaixas();
            impedirBotoes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            limparCaixas();
            impedirBotoes();
        }

        private void txtSalarioMin_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtNrRegisto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalarioMax_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }

        private void txtCoeficiente_TextChanged(object sender, EventArgs e)
        {
            impedirBotoes();
        }
    }
}
