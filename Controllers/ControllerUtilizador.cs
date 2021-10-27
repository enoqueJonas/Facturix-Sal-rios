using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Controllers
{
    class ControllerUtilizador
    {
        public static void Guardar(int codigo, String nome, String apelido, String password, String email, String contacto, String nivel, String nomeUtilizador, String dataNascimento)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into utilizador (id, nome, apelido, password, email, contacto, nivel, nomeUtilizador, dataNascimento) values(?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", codigo);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("apelido", apelido);
                comando.Parameters.AddWithValue("password", password);
                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("contacto", contacto);
                comando.Parameters.AddWithValue("nivel", nivel);
                comando.Parameters.AddWithValue("nomeUtilizador", nomeUtilizador);
                comando.Parameters.AddWithValue("dataNascimento", dataNascimento);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel cadastrar o utilizador!");
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
            ArrayList listaUtilizadores = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelectMorada = "SELECT * from utilizador";
                MySqlCommand comando = new MySqlCommand(sqlSelectMorada, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    String apelido = leitor.GetString(2);
                    String password = leitor.GetString(3);
                    String email = leitor.GetString(4);
                    String contacto = leitor.GetString(5);
                    String nivel = leitor.GetString(6);
                    String nomeUtilizador = leitor.GetString(7);
                    String dataNascimento = leitor.GetString(8);
                    listaUtilizadores.Add(new ModeloUtilizador(id, nome, apelido, password, email, contacto, nivel, nomeUtilizador, dataNascimento));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar utilizadores!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaUtilizadores;
        }

        public static ArrayList recuperarComCodigo(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaUtilizadores = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSlect = "SELECT * from utilizador WHERE id=" + codigo + "";
                MySqlCommand comando = new MySqlCommand(sqlSlect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    String apelido = leitor.GetString(2);
                    String password = leitor.GetString(3);
                    String email = leitor.GetString(4);
                    String contacto = leitor.GetString(5);
                    String nivel = leitor.GetString(6);
                    String nomeUtilizador = leitor.GetString(7);
                    String dataNascimento = leitor.GetString(8);
                    listaUtilizadores.Add(new ModeloUtilizador(id, nome, apelido, password, email, contacto, nivel, nomeUtilizador, dataNascimento));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar utilizadores!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaUtilizadores;
        }

        public static void atualizar(int id, String nome, String apelido, String password, String email, String contacto, String nivel, String nomeUtilizador, String dataNascimento)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE utilizador SET nome=?, apelido=?, password=?, email=?, contacto=?, nivel=?, nomeUtilizador=?, dataNascimento=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("apelido", apelido);
                comando.Parameters.AddWithValue("password", password);
                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("contacto", contacto);
                comando.Parameters.AddWithValue("nivel", nivel);
                comando.Parameters.AddWithValue("nomeUtilizador", nomeUtilizador);
                comando.Parameters.AddWithValue("dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("id", id);
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
                String SqlDelete = "DELETE from utilizador WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("codigo", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel remover o utilizador!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
