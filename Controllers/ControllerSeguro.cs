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
        public static void gravar(int id, String seguro, float percentagem) 
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into seguro(id, tipoSeguro, percentagem) values(?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("seguro", seguro);
                comando.Parameters.AddWithValue("percentagem", percentagem);
                comando.ExecuteNonQuery();
                MessageBox.Show("Seguro cadastrado com sucesso!");
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

        public static void atualizar(int id,  String seguro, float percentagem)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE seguro SET tipoSeguro=?, percentagem=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("tipoSeguro", seguro);
                comando.Parameters.AddWithValue("percentagem", percentagem);
                comando.Parameters.AddWithValue("id", id);
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
                String sqlSelect = "SELECT * from seguro";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String seguro = leitor.GetString(1);
                    float percentagem = leitor.GetFloat(2);
                    listaSeguros.Add(new ModeloSeguro(id, seguro, percentagem));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar contas!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaSeguros;
        }

        public static void remover(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from seguro WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel remover o seguro!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static ArrayList recuperarComCod(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaSeguros = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from seguro WHERE id="+codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String seguro = leitor.GetString(1);
                    float percentagem = leitor.GetFloat(2);
                    listaSeguros.Add(new ModeloSeguro(id, seguro, percentagem));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar seguros!");
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
