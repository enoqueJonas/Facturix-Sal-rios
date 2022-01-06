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
    public partial class frmConsultarProcessamento : Form
    {
        public frmConsultarProcessamento()
        {
            InitializeComponent();
        }

        public int mesSelecionado;
        private void frmConsultarProcessamento_Load(object sender, EventArgs e)
        {

        }

        private void frmConsultarProcessamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mesSelecionado = int.Parse(txtMes.Text);
                this.Close();
            }
        }

        private void frmConsultarProcessamento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
