using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Controllers
{
    class ControllerEmpresa
    {
        public static void Guardar(int id, String nome, String nomeAbreviado, Boolean logo, String imagem)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into informacao_da_empresa (id, nome, nomeAbreviado, logo, imagem) values(?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("nomeAbreviado", nomeAbreviado);
                comando.Parameters.AddWithValue("logo", logo);
                comando.Parameters.AddWithValue("imagem", imagem);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar a empresa! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, String nome, String nomeAbreviado, Boolean logo, String imagem)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE informacao_da_empresa SET nome=?, nomeAbreviado=?, logo=?, imagem=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("nomeAbreviado", nomeAbreviado);
                comando.Parameters.AddWithValue("logo", logo);
                comando.Parameters.AddWithValue("imagem", imagem);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a empresa! Contacte o técnico!");
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
            ArrayList listaHorarios = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from informacao_da_empresa";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    String nomeAbreviado = leitor.GetString(2);
                    Boolean logo = leitor.GetBoolean(3);
                    String imagem = leitor.GetString(4);
                    listaHorarios.Add(new ModeloEmpresa(id, nome, nomeAbreviado, logo, imagem));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar dependentes!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaHorarios;
        }

        public static ArrayList recuperarComCod(int idFunc)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaHorarios = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from informacao_da_empresa WHERE id=" + idFunc + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    String nomeAbreviado = leitor.GetString(2);
                    Boolean logo = leitor.GetBoolean(3);
                    String imagem = leitor.GetString(4);
                    listaHorarios.Add(new ModeloEmpresa(id, nome, nomeAbreviado, logo, imagem));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar dependentes!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaHorarios;
        }

        public static void remover(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from informacao_da_empresa WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover empresa! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
