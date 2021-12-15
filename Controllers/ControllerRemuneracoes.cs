using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Facturix_Salários.Modelos;
using Facturix_Salários.Controllers;

namespace Facturix_Salários.Controllers
{
    class ControllerRemuneracoes
    {
        public static void Guardar(int id, float percentagem, String grupo, String natureza, String quantidade, String valorUnitario, Boolean segurancaSocial, Boolean irps, Boolean seguro, String isento, double valor)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into remuneracoes (id, percentagem, grupo, natureza, quantidade, valorUnitario, segurancaSocial, irps, seguro, isento, valor) values(?,?,?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("percentagem", percentagem);
                comando.Parameters.AddWithValue("grupo", grupo);
                comando.Parameters.AddWithValue("natureza", natureza);
                comando.Parameters.AddWithValue("quantidade", quantidade);
                comando.Parameters.AddWithValue("valorUnitario", valorUnitario);
                comando.Parameters.AddWithValue("segurancaSocial", segurancaSocial);
                comando.Parameters.AddWithValue("irps", irps);
                comando.Parameters.AddWithValue("seguro", seguro);
                comando.Parameters.AddWithValue("isento", isento);
                comando.Parameters.AddWithValue("valor", valor);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar a remuneração! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, float percentagem, String grupo, String natureza, String quantidade, String valorUnitario, Boolean segurancaSocial, Boolean irps, Boolean seguro, String isento, double valor)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE remuneracoes SET percentagem=?, grupo=?, natureza=?, quantidade=?, valorUnitario=?, segurancaSocial=?, irps=?, seguro=?, isento=?, valor=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("percentagem", percentagem);
                comando.Parameters.AddWithValue("grupo", grupo);
                comando.Parameters.AddWithValue("natureza", natureza);
                comando.Parameters.AddWithValue("quantidade", quantidade);
                comando.Parameters.AddWithValue("valorUnitario", valorUnitario);
                comando.Parameters.AddWithValue("segurancaSocial", segurancaSocial);
                comando.Parameters.AddWithValue("irps", irps);
                comando.Parameters.AddWithValue("seguro", seguro);
                comando.Parameters.AddWithValue("isento", isento);
                comando.Parameters.AddWithValue("valor", valor);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a remuneração! Contacte o técnico!");
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
            ArrayList listaRemuneracoes = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from remuneracoes";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    float percentagem = leitor.GetFloat(1);
                    String grupo = leitor.GetString(2);
                    String natureza = leitor.GetString(3);
                    String quantidade = leitor.GetString(4);
                    String valorUnitario = leitor.GetString(5);
                    Boolean segurancaSocial = leitor.GetBoolean(6);
                    Boolean irps = leitor.GetBoolean(7);
                    Boolean seguro = leitor.GetBoolean(8);
                    String isento = leitor.GetString(9);
                    double valor = leitor.GetDouble(10);
                    listaRemuneracoes.Add(new ModeloRemuneracoes(id, percentagem, grupo, natureza, quantidade, valorUnitario, segurancaSocial, irps, seguro, isento, valor));
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
            return listaRemuneracoes;
        }

        public static ArrayList recuperarComCod(int idFunc)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaRemuneracoes = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from remuneracoes WHERE id=" + idFunc + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    float percentagem = leitor.GetFloat(1);
                    String grupo = leitor.GetString(2);
                    String natureza = leitor.GetString(3);
                    String quantidade = leitor.GetString(4);
                    String valorUnitario = leitor.GetString(5);
                    Boolean segurancaSocial = leitor.GetBoolean(6);
                    Boolean irps = leitor.GetBoolean(7);
                    Boolean seguro = leitor.GetBoolean(8);
                    String isento = leitor.GetString(9);
                    double valor = leitor.GetDouble(10);
                    listaRemuneracoes.Add(new ModeloRemuneracoes(id, percentagem, grupo, natureza, quantidade, valorUnitario, segurancaSocial, irps, seguro, isento, valor));
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
            return listaRemuneracoes;
        }

        public static void remover(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from remuneracoes id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover a remuneração! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
