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
    class ControllerTabela
    {
        public static void gravar(int id, String nome, String label)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into tabela(id, nome, label) values(?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("label", label);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Tabela cadastrada com sucesso!");
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Não foi possível cadastrar tabela! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, String nome, String label)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE tabela SET nome=?, label=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("label", label);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a tabela! Contacte o técnico");
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
            ArrayList listaCategorias = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from tabela";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    String label = leitor.GetString(2);
                    listaCategorias.Add(new ModeloTabela(id, nome, label));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar categorias!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaCategorias;
        }

        public static void removerComCod(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from tabela WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Não foi possível remover a tabela! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }public static void remover()
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from tabela";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Não foi possível remover a tabela! Contacte o técnico!");
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
            ArrayList listaCategorias = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from tabela WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String nome = leitor.GetString(1);
                    String label = leitor.GetString(2);
                    listaCategorias.Add(new ModeloTabela(id, nome, label));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar categorias!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaCategorias;
        }
    }
}
