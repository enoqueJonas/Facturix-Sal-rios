using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturix_Salários
{
    class Program
    {
        public int diasDeTrabalhoGeral =0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBoxManager.Yes = "Sim";
            MessageBoxManager.No = "Não";
            MessageBoxManager.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu());
        }
    }
}
