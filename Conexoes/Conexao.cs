using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Facturix_Salários
{
    class Conexao
    {
        public static String host;
        public static String database;
        public static String user;
        public static String passwd;

        public static MySqlConnection conectar()
        {
            MySqlConnection conexao = null;
            try
            {
                host = "localhost";
                user = "root";
                passwd = "";
                database = "facturixsalario";
                String connection = "Server=" + host + ";Uid=" + user + ";Pwd=" + passwd + ";Database=" + database + "";
                conexao = new MySqlConnection(connection);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível conectar a base de dados! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return conexao;
        }

    }
}
