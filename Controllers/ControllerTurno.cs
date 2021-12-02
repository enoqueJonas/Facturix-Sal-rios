using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturix_Salários.Modelos;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Facturix_Salários.Controllers
{
    class ControllerTurno
    {
        public static void Guardar(int id, String nome, Boolean manha, Boolean tarde, Boolean noite, Boolean normal)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into turno (id, nome, manha, tarde, noite, normal) values(?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("manha", manha);
                comando.Parameters.AddWithValue("tarde", tarde);
                comando.Parameters.AddWithValue("noite", noite);
                comando.Parameters.AddWithValue("normal", normal);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar o Turno! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, String nome, Boolean manha, Boolean tarde, Boolean noite, Boolean normal)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE turno SET nome=?, manha=?, tarde=?, noite=?, normal=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("manha", manha);
                comando.Parameters.AddWithValue("tarde", tarde);
                comando.Parameters.AddWithValue("noite", noite);
                comando.Parameters.AddWithValue("normal", normal);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o turno! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from turno";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    Boolean manha = leitor.GetBoolean(2);
                    Boolean tarde = leitor.GetBoolean(3);
                    Boolean noite = leitor.GetBoolean(4);
                    Boolean normal = leitor.GetBoolean(5);
                    listaHorarios.Add(new ModeloTurno(id, nome, manha, tarde, noite, normal));
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
                String sqlSelect = "SELECT * from turno WHERE id=" + idFunc + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    Boolean manha = leitor.GetBoolean(2);
                    Boolean tarde = leitor.GetBoolean(3);
                    Boolean noite = leitor.GetBoolean(4);
                    Boolean normal = leitor.GetBoolean(5);
                    listaHorarios.Add(new ModeloTurno(id, nome, manha, tarde, noite, normal));
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
                String SqlDelete = "DELETE from turno WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover o turno! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
