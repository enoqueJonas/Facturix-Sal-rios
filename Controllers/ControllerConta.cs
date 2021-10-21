using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace Facturix_Salários
{
    class ControllerConta
    {
        public static void Guardar(int idFuncionario, String banco, String nib, String conta)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into conta (idFuncionario, banco, nib, conta) values(?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.Parameters.AddWithValue(" banco", banco);
                comando.Parameters.AddWithValue("nib", nib);
                comando.Parameters.AddWithValue("conta", conta);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar a conta! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int idFuncionario, String banco, String nib, String conta)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE conta SET banco=?, nib=?, conta=? WHERE idFuncionario=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue(" banco", banco);
                comando.Parameters.AddWithValue("nib", nib);
                comando.Parameters.AddWithValue("conta", conta);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a conta! Contacte o técnico!");
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
            ArrayList listaContas = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from conta";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    String banco = leitor.GetString(2);
                    String nib = leitor.GetString(3);
                    String conta = leitor.GetString(4);
                    listaContas.Add(new ModeloConta(id, idFuncionario, banco, nib, conta));
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
            return listaContas;
        }

        public static ArrayList recuperarComCod(int idFunc)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaContas = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from conta WHERE idFuncionario="+idFunc+"";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    String banco = leitor.GetString(2);
                    String nib = leitor.GetString(3);
                    String conta = leitor.GetString(4);
                    listaContas.Add(new ModeloConta(id, idFuncionario, banco, nib, conta));
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
            return listaContas;
        }

        public static void remover(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from conta WHERE idFuncionario=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("idFuncionario", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover a conta! Contacte o técnico!!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
