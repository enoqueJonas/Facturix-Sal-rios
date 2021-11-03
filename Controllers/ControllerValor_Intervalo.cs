using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Windows.Forms;
using Facturix_Salários.Modelos;

namespace Facturix_Salários.Controllers
{
    class ControllerValor_Intervalo
    {
        public static void gravar(int idUsuario, int idIntervalo, int dependentes, float valor)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into valor_intervalo(id, idIntervalo, nrDependentes, valor) values(?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", idUsuario);
                comando.Parameters.AddWithValue("idIntervalo", idIntervalo);
                comando.Parameters.AddWithValue("nrDependentes", dependentes);
                comando.Parameters.AddWithValue("valor", valor);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Tabela cadastrada com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar Valor_Intervalo! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, int dependentes, float valor)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE valor_intervalo SET nrDependentes=?, valor=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("nrDependentes", dependentes);
                comando.Parameters.AddWithValue("valor", valor);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a Valor_Intervalo! Contacte o técnico");
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
            ArrayList listaIRPS = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from valor_intervalo";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idIntervalo = leitor.GetInt16(1);
                    int dependentes = leitor.GetInt16(2);
                    float valor = leitor.GetFloat(3);
                    listaIRPS.Add(new ModeloValor_Intervalo(id, idIntervalo, dependentes, valor));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel recuperar categorias!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaIRPS;
        }

        public static void removerComCod(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from valor_intervalo WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover Valor_Intervalo! Contacte o técnico!");
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
            ArrayList listaIRPS = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from valor_intervalo WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idIntervalo = leitor.GetInt16(1);
                    int dependentes = leitor.GetInt16(2);
                    float valor = leitor.GetFloat(3);
                    listaIRPS.Add(new ModeloValor_Intervalo(id, idIntervalo, dependentes, valor));
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
            return listaIRPS;
        }
    }
}
