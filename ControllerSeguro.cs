using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Facturix_Salários
{
    class ControllerSeguro
    {
        public static void gravar(int id, String seguro) 
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into seguro(id, seguro) values(?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("seguro", seguro);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel cadastrar seguro");
            }
            finally 
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id,  String seguro)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE seguro SET tipoSeguro=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue(" tipoSeguro", seguro);
                comando.Parameters.AddWithValue("ido", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel atualizar o seguro!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static ArrayList recuperar()
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaSeguros = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from conta";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    String banco = leitor.GetString(2);
                    String nib = leitor.GetString(3);
                    String conta = leitor.GetString(4);
                    listaSeguros.Add(new ModeloConta(id, idFuncionario, banco, nib, conta));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel recuperar contas!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaSeguros;
        }
    }
}
