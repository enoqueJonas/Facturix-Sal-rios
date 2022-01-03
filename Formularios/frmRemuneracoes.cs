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
using Facturix_Salários.Controllers;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Formularios
{
	public partial class frmRemuneracoes : Form
	{
		public frmRemuneracoes()
		{
			InitializeComponent();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void frmRemuneracoes_Load(object sender, EventArgs e)
		{
			txtRegistoNr.Text = getCod() + 1 + "";
			txtValor.LostFocus += new EventHandler(txtValor_LostFocus);
		}

		private void txtValor_LostFocus(object sender, EventArgs e)
		{
			if (txtValor.Text!= "") 
			{
				txtValor.Text = string.Format("{0:#,##0.00}", double.Parse(txtValor.Text));
			}
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
				else if (e.KeyCode == Keys.Up && e.Alt)
				{
					this.SelectNextControl(ctrl, false, true, true, true);
				}
				else
					return;
			}
			e.Handled = true;
			e.SuppressKeyPress = true;
		}

		private int getCod() 
		{
			ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
			int cod = 0;
			foreach (ModeloRemuneracoes r in listaRemuneracoes)
			{
				if (r.getId() != 0)
				{
					cod = r.getId();
				}
			}
			return cod;
		}
		private void gravar() 
		{
			float percentagem = float.Parse(txtPercentagem.Text);
			String grupo = cbGrupo.Text;
			String natureza = cbNatureza.Text;
			String qtd = cbQuantidade.Text;
			String valorUnit = cbValorUnit.Text;
			String isento = cbInsento.Text;
			double valor = 0;
			if(txtValor.Text!="" && txtValor.Text!="MZN")
				valor = double.Parse(txtValor.Text);
			Boolean segurancaSocial = false, irps = false, seguro = false, existe = false;
			int cod = int.Parse(txtRegistoNr.Text);
			if (chbSegurancaSocial.Checked)
				segurancaSocial = true;

			if (chbIrps.Checked)
				irps = true;

			if (chbSeguro.Checked)
				seguro = true;

			ArrayList listaRemuneracoes = ControllerRemuneracoes.recuperar();
			foreach (ModeloRemuneracoes r in listaRemuneracoes) 
			{
				if (cod == r.getId()) 
				{
					existe = true;
				}
			}

			if (existe)
			{
				ControllerRemuneracoes.atualizar(cod, percentagem, grupo, natureza, qtd, valorUnit, segurancaSocial, irps, seguro, isento, valor);
			}
			else {
				ControllerRemuneracoes.Guardar(cod, percentagem, grupo, natureza, qtd, valorUnit, segurancaSocial, irps, seguro, isento, valor);
			}
		}

		private void limpar() 
		{
			txtRegistoNr.Text = "";
			txtPercentagem.Text = "";
			cbValorUnit.Text = "";
			cbGrupo.Text = "";
			cbNatureza.Text = "";
			cbQuantidade.Text = "";
			chbIrps.Checked = false;
			chbSegurancaSocial.Checked = false;
			chbSeguro.Checked = false;
			cbInsento.Text = "";
			txtValor.Text = "";
		}

		private void mudarVisibilidadeLabels(Boolean estado) 
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

		private void btnConfirmar_Click(object sender, EventArgs e)
		{
			gravar();
			limpar();
			mudarVisibilidadeLabels(false);
			txtRegistoNr.Text = getCod() + 1 +"";
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			limpar();
			mudarVisibilidadeLabels(false);
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			int cod = int.Parse(txtRegistoNr.Text);
			ControllerRemuneracoes.remover(cod);
		}

		private void btnRegressar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			limpar();
			txtRegistoNr.Text = getCod() + 1 + "";
		}

		private void txtValor_Click(object sender, EventArgs e)
		{
			if (txtValor.Text.Equals("MZN"))
				txtValor.Text = "";
		}

		private void txtValor_TextChanged(object sender, EventArgs e)
		{
			if (txtValor.Text.Equals("MZN"))
				txtValor.Text = "";
		}

		private void txtPercentagem_KeyDown(object sender, KeyEventArgs e)
		{
			mexerTeclado(sender, e);
		}

		private void cbGrupo_KeyDown(object sender, KeyEventArgs e)
		{
			mexerTeclado(sender, e);
		}

		private void cbNatureza_KeyDown(object sender, KeyEventArgs e)
		{
			mexerTeclado(sender, e);
		}

		private void cbQuantidade_KeyDown(object sender, KeyEventArgs e)
		{
			mexerTeclado(sender, e);
		}

		private void cbValorUnit_KeyDown(object sender, KeyEventArgs e)
		{
			mexerTeclado(sender, e);
		}

		private void cbInsento_KeyDown(object sender, KeyEventArgs e)
		{
			mexerTeclado(sender, e);
		}

		private void txtValor_KeyDown(object sender, KeyEventArgs e)
		{
			mexerTeclado(sender, e);
		}

		private void frmRemuneracoes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.ToString() == "F1")
			{
				limpar();
				txtRegistoNr.Text = getCod() + 1 + "";
			}
			if (e.KeyCode.ToString() == "F4")
			{
				limpar();
				mudarVisibilidadeLabels(false);
			}
			if (e.KeyCode.ToString() == "F5")
			{
				gravar();
				limpar();
				mudarVisibilidadeLabels(false);
				txtRegistoNr.Text = getCod() + 1 + "";
			}
			if (e.KeyCode.ToString() == "F6")
			{
				int cod = int.Parse(txtRegistoNr.Text);
				ControllerRemuneracoes.remover(cod);
			}
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void txtRegistoNr_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
