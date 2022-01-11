using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Controllers
{
    class ControllerFuncionarioRemuneracoes
    {
        public static void gravar(int id, int idFuncionario, int idRemuneracao, double valor, int quantidade)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into funcionario_remuneracoes(id, idFuncionario, idRemuneracao, valorUnitario, quantidade) values(?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.Parameters.AddWithValue("idRemuneracao", idRemuneracao);
                comando.Parameters.AddWithValue("valorUnitario", valor);
                comando.Parameters.AddWithValue("quantidade", quantidade);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Funcionario_Remuneracao cadastrado com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar o funcionario_remuneracao! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, int idFuncionario, int idRemuneracao, double valor, int quantidade)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE funcionario_remuneracoes SET idFuncionario=?, idRemuneracao=?, valorUnitario=?, quantidade=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.Parameters.AddWithValue("idRemuneracao", idRemuneracao);
                comando.Parameters.AddWithValue("valorUnitario", valor);
                comando.Parameters.AddWithValue("quantidade", quantidade);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar Funcionario_Remuneracoes! Contacte o técnico!!");
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
            ArrayList listafunionarioRemuneracoes = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from funcionario_remuneracoes";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    int idRemuneracao = leitor.GetInt16(2);
                    double valor = leitor.GetDouble(3);
                    int qtd = leitor.GetInt16(4);
                    listafunionarioRemuneracoes.Add(new ModeloFuncionarioRemuneracoes(id, idFuncionario, idRemuneracao, valor, qtd));
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
            return listafunionarioRemuneracoes;
        }

        public static void remover(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from funcionario_remuneracoes WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                String mess =  err.Message;
                //MessageBox.Show(err.Message, "Não foi possível remover o feriado! Contacte o técnico!");
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
            ArrayList listafunionarioRemuneracoes = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from funcionario_remuneracoes WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    int idRemuneracao = leitor.GetInt16(2);
                    double valor = leitor.GetDouble(3);
                    int qtd = leitor.GetInt16(4);
                    listafunionarioRemuneracoes.Add(new ModeloFuncionarioRemuneracoes(id, idFuncionario, idRemuneracao, valor, qtd));
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
            return listafunionarioRemuneracoes;
        }
    }
}
