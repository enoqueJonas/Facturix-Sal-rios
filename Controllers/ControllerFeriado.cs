using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Windows.Forms;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Controllers
{
    class ControllerFeriado
    {
        public static void gravar(int id, String nome, String dataInicio, String dataFim)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into feriado(id, nome, dataInicio, dataFim) values(?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("dataInicio", dataInicio);
                comando.Parameters.AddWithValue("dataFim", dataFim);
                comando.ExecuteNonQuery();
                MessageBox.Show("Feriado cadastrado com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar o feriado! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, String nome, String dataInicio, String dataFim)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE seguro SET nome=?, dataInicio=?, dataFim=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("dataInicio", dataInicio);
                comando.Parameters.AddWithValue("dataFim", dataFim);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o feriado! Contacte o técnico!!");
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
            ArrayList listaFeriados = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from feriado";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    String dataInicio = leitor.GetString(2);
                    String dataFim = leitor.GetString(3); 
                    String dtInicio = dataInicio.Substring(0, 5);
                    String dtFim = dataFim.Substring(0, 5);
                    listaFeriados.Add(new ModeloFeriado(id, nome, dtInicio, dtFim));
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
            return listaFeriados;
        }

        public static void remover(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from feriado WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover o feriado! Contacte o técnico!");
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
            ArrayList listaFeriados = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from feriado WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    String dataInicio = leitor.GetString(2);
                    String dataFim = leitor.GetString(3);
                    listaFeriados.Add(new ModeloFeriado(id, nome, dataInicio, dataFim));
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
            return listaFeriados;
        }
    }
}
