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
    class ControllerEstabelecimento
    {
        public static void gravar(int id, String estabelecimento)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into estabelecimento(id, estabelecimento) values(?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("estabelecimento", estabelecimento);
                comando.ExecuteNonQuery();
                MessageBox.Show("Estabelecimento cadastrada com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel cadastrar estabelecimento");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, String estabelecimento)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE estabelecimento SET estabelecimento=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("estabelecimento", estabelecimento);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel atualizar o estabelecimento!");
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
            ArrayList listaEstabelecimentos = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from estabelecimento";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String estabelecimento = leitor.GetString(1);
                    listaEstabelecimentos.Add(new ModeloEstabelecimento(id, estabelecimento));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar estabelecimento!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaEstabelecimentos;
        }

        public static void remover(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from estabelecimento WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel remover o estabelecimento!");
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
            ArrayList listaEstabelecimentos = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from estabelecimento WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String estabelecimento = leitor.GetString(1);
                    listaEstabelecimentos.Add(new ModeloEstabelecimento(id, estabelecimento));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar estabelecimentos!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaEstabelecimentos;
        }
    }
}
