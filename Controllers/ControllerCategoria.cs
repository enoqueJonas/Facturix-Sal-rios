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
    class ControllerCategoria
    {
        public static void gravar(int id, String categoria)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into categoria(id, tipoCategoria) values(?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("tipoCategoria", categoria);
                comando.ExecuteNonQuery();
                MessageBox.Show("Categoria cadastrada com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar categoria! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, String categoria)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE categoria SET tipoCategoria=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue(" tipoRegime", categoria);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a categoria! Contacte o técnico");
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
                String sqlSelect = "SELECT * from categoria";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String categoria = leitor.GetString(1);
                    listaCategorias.Add(new ModeloCategoria(id, categoria));
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

        public static void remover(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from categoria WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover a categoria! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from categoria WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String categoria = leitor.GetString(1);
                    listaCategorias.Add(new ModeloCategoria(id, categoria));
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
