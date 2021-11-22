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

namespace Facturix_Salários
{
    public partial class frmNumeroRegisto : Form
    {
        public frmNumeroRegisto()
        {
            InitializeComponent();
        }

        public int enterdCod;

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            enterdCod = int.Parse(txtNrRegisto.Text);
            this.Close();
        }

        private void frmNumeroRegisto_Load(object sender, EventArgs e)
        {

        }

        private void frmNumeroRegisto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                enterdCod = int.Parse(txtNrRegisto.Text);
                this.Close();
            }
        }
    }
}
