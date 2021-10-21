using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Controllers
{
    class ControllerDependente
    {
        public static void Guardar(int idFuncionario, String nome, String dataNascimneto, String grauParentesco)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into dependente (idFuncionario, nome, dataNascimento, grauParentesco) values(?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("dataNascimento", dataNascimneto);
                comando.Parameters.AddWithValue("grauParentesco", grauParentesco);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar o dependente! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int idFuncionario, String nome, String dataNascimneto, String grauParentesco)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE dependente SET nome=?, dataNascimento=?, grauParentesco=? WHERE idFuncionario=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("dataNascimento", dataNascimneto);
                comando.Parameters.AddWithValue("grauParentesco", grauParentesco);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o dependente! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from dependente";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    String nome = leitor.GetString(2);
                    String dataNascimento = leitor.GetString(3);
                    String dt = dataNascimento.Substring(0, 10);
                    String grauParentesco = leitor.GetString(4);
                    listaContas.Add(new ModeloDependente(id, idFuncionario, nome, dt, grauParentesco));
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
            return listaContas;
        }

        public static ArrayList recuperarComCod(int idFunc)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaContas = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from dependente WHERE id=" + idFunc + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    String nome = leitor.GetString(2);
                    String dataNascimento = leitor.GetString(3);
                    String dt = dataNascimento.Substring(0, 10);
                    String grauParentesco = leitor.GetString(4);
                    listaContas.Add(new ModeloDependente(id, idFuncionario, nome, dt, grauParentesco));
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
            return listaContas;
        }

        public static void remover(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from dependente WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o dependente! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
