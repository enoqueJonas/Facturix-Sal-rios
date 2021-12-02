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
using System.IO;


namespace Facturix_Salários.Formularios
{
    public partial class frmNomeDaEmpresa : Form
    {
        String linkImagem = "";
        public frmNomeDaEmpresa()
        {
            InitializeComponent();
        }

        private void frmNomeDaEmpresa_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNomeDaEmpresa;
            ArrayList listaEmpresa = ControllerEmpresa.recuperar();
            foreach (ModeloEmpresa f in listaEmpresa) 
            {
                txtNomeAbreviado.Text = f.getNomeAbreviado();
                txtNomeDaEmpresa.Text = f.getNome();
                if (System.IO.File.Exists(f.getImagem()))
                {
                    pbLogo.Image = Image.FromFile(f.getImagem());
                }
                else
                {
                    pbLogo.Image = null;
                }
                if (f.getLogo() == true && System.IO.File.Exists(f.getImagem())) 
                {
                    cbLogo.Checked = true;
                }
            }
        }

        private void gravar() 
        {
            String nome = txtNomeDaEmpresa.Text;
            String nomeAbreviado = txtNomeAbreviado.Text;
            Boolean logo = false;

            if (cbLogo.Checked && pbLogo.Image!=null) 
            {
                logo = true;
            }

            if (getCod() == 0)
            {
                int id = getCod() + 1;
                ControllerEmpresa.Guardar(id, nome, nomeAbreviado, logo, linkImagem);
            }
            else 
            {
                int id = getCod();
                ControllerEmpresa.atualizar(id, nome, nomeAbreviado, logo, linkImagem);
            }
        }
        private int getCod() 
        {
            int cod = 0;
            ArrayList listaEmpresa = ControllerEmpresa.recuperar();
            foreach (ModeloEmpresa f in listaEmpresa) 
            {
                if (f.getId()!=0) 
                {
                    cod = f.getId();
                }
            }
            return cod;
        }

        private void btnAdicionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProImages\";
            opFile.Title = "Selecione uma imagem";
            opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = opFile.SafeFileName;
                    linkImagem = opFile.FileName;
                    File.Copy(linkImagem, appPath + iName);
                    pbLogo.Image = new Bitmap(opFile.OpenFile());
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Não foi possível carregar a imagem " + exp.Message);
                }
            }
            else
            {
                opFile.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gravar();
            this.Close();
            frmRegrasDeBatidaDePonto f = new frmRegrasDeBatidaDePonto();
            f.Show();
        }
    }
}
