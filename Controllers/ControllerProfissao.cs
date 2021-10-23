using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Facturix_Salários
{
    class ControllerProfissao
    {
        public static void gravar(int id, String profissao)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into profissao(id, tipoProfissao) values(?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("profissao", profissao);
                comando.ExecuteNonQuery();
                MessageBox.Show("Profissao cadastrada com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar a profissão! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, String profissao)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE profissao SET tipoProfissao=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue(" tipoProfissao", profissao);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a profissão! Contacte o técnico!");
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
            ArrayList listaProfissoes = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from profissao";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String profissao = leitor.GetString(1);
                    listaProfissoes.Add(new ModeloProfissao(id, profissao));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar profissoes!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaProfissoes;
        }

        public static void remover(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from profissao WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover a profissão! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from profissao WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String seguro = leitor.GetString(1);
                    listaSeguros.Add(new ModeloProfissao(id, seguro));
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
    }
}
