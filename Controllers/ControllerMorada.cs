using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Facturix_Salários
{
    class ControllerMorada
    {
        public static void Guardar(int codigo, int codigoPostal, String bairro, String localidade, String moradaGen)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into morada (codigo, codigoPostal, bairro, localidade, moradaGen) values(?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.Parameters.AddWithValue("codigoPostal", codigoPostal);
                comando.Parameters.AddWithValue("bairro", bairro);
                comando.Parameters.AddWithValue("localidade", localidade);
                comando.Parameters.AddWithValue("moradaGen", moradaGen);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel cadastrar o funcionario!");
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
            ArrayList listaMoradas = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelectMorada = "SELECT * from morada";
                MySqlCommand comando = new MySqlCommand(sqlSelectMorada, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int cod = leitor.GetInt16(0);
                    int codigoPostal = leitor.GetInt16(1);
                    String bairro = leitor.GetString(2);
                    String localidade = leitor.GetString(3);
                    String moradaGen = leitor.GetString(4);
                    listaMoradas.Add(new ModeloMorada(cod, codigoPostal, bairro, localidade, moradaGen));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel recuperar moradas!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaMoradas;
        }

        public static ArrayList recuperarComCodigo(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaMoradas = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelectMorada = "SELECT * from morada WHERE codigo="+codigo+"";
                MySqlCommand comando = new MySqlCommand(sqlSelectMorada, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int cod = leitor.GetInt16(0);
                    int codigoPostal = leitor.GetInt16(1);
                    String bairro = leitor.GetString(2);
                    String localidade = leitor.GetString(3);
                    String moradaGen = leitor.GetString(4);
                    listaMoradas.Add(new ModeloMorada(cod, codigoPostal, bairro, localidade, moradaGen));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel recuperar moradas!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaMoradas;
        }

        public static void atualizar(int codigo, int codigoPostal, String bairro, String localidade, String moradaGen)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE morada SET codigoPostal=?, bairro=?, localidade=?, moradaGen=? WHERE codigo=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("codigoPostal", codigoPostal);
                comando.Parameters.AddWithValue("bairro", bairro);
                comando.Parameters.AddWithValue("localidade", localidade);
                comando.Parameters.AddWithValue("moradaGen", moradaGen);
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void remover(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from morada WHERE codigo=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("codigo", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel remover o funcionario!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
