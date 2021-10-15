using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturix_Salários
{
    public partial class frmCadastrarContrato : Form
    {
        public frmCadastrarContrato()
        {
            InitializeComponent();
        }

        public void gravar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerContrato.gravar(id, regime);
        }

        public void eliminar()
        {
            int id = int.Parse(txtCodigo.Text);
            ControllerContrato.remover(id);
        }

        public void atualizar()
        {
            int id = int.Parse(txtCodigo.Text);
            String regime = txtNome.Text;
            ControllerContrato.atualizar(id, regime);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gravar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            atualizar();
        }
    }
}
