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
    class ControllerIntervalo
    {
        public static void gravar(int idUsuario, float salarioBrutoMin, float salarioBrutoMax)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into intervalo(id, salarioBrutoMin, salarioBrutoMax) values(?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", idUsuario);
                comando.Parameters.AddWithValue("salarioBrutoMin", salarioBrutoMin);
                comando.Parameters.AddWithValue("salarioBrutoMax", salarioBrutoMax);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Tabela cadastrada com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar Intervalo! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, float salarioMin, float salarioMax)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE intervalo SET salarioBrutoMin=?, salarioBrutoMax=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("salarioBrutoMin", salarioMin);
                comando.Parameters.AddWithValue("salarioBrutoMax", salarioMax);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a Intervalo! Contacte o técnico");
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
                String sqlSelect = "SELECT * from intervalo";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    float salarioMin = leitor.GetFloat(1);
                    float salarioMax = leitor.GetFloat(2);
                    listaIRPS.Add(new ModeloIntervalo(id, salarioMin, salarioMax));
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

        public static void removerComCod(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from intervalo WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover Intervalo! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from irps WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    float salarioMin = leitor.GetFloat(1);
                    float salarioMax = leitor.GetFloat(2);
                    listaIRPS.Add(new ModeloIntervalo(id, salarioMin, salarioMax));
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
