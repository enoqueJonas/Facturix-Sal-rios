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
    public partial class frmLoadingScreen : Form
    {
        public Action Worker { get; set; }
        public frmLoadingScreen(Action worker)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;
        }

        private void frmLoadingScreen_Load(object sender, EventArgs e)
        {
            //ProgressBar pBar = new ProgressBar
            //{
            //    Location = new System.Drawing.Point(25, 125),
            //    Name = "progressBar1",
            //    Width = 350,
            //    Height = 30,
            //    Minimum = 0,
            //    Maximum = 100,
            //    Value = 30
            //};
            //pBar.Dock = DockStyle.Bottom;
            //Controls.Add(pBar);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
