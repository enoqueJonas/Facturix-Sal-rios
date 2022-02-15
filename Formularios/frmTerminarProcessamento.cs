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
    public partial class frmTerminarProcessamento : Form
    {
        public frmTerminarProcessamento()
        {
            InitializeComponent();
        }

        public List<String> lista = new List<string>();
        private void frmTerminarProcessamento_Load(object sender, EventArgs e)
        {
            int i;
            rtxtFuncProcessados.Text = lista[0];
            for (i = 1; i < lista.Count; i++) 
            {
                rtxtFuncProcessados.Text += Environment.NewLine + lista[i];
            }
            rtxtFuncProcessados.Text += Environment.NewLine;
            rtxtFuncProcessados.Text += Environment.NewLine + "-----------------------------------------------";
            rtxtFuncProcessados.Text += Environment.NewLine + " Processados "+ i + "  funcionários";
            rtxtFuncProcessados.Text += Environment.NewLine + "-----------------------------------------------";

        }

        private void btnRegressar_Click(object sender, EventArgs e)
        {
            this.Close();
            lista.Clear();
        }

        private void frmTerminarProcessamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            lista.Clear();
        }

        private void frmTerminarProcessamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void frmTerminarProcessamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
