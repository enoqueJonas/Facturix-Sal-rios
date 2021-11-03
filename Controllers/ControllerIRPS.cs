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
    class ControllerIRPS
    {
        public static void gravar(int idUsuario, double salMin, double salMax, float valor, int dependentes, float coeficiente)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into irps(id, salMin, salMax, valor, nrDependentes, coeficiente) values(?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", idUsuario);
                comando.Parameters.AddWithValue("salMin", salMin);
                comando.Parameters.AddWithValue("salMax", salMax);
                comando.Parameters.AddWithValue("valor", valor);
                comando.Parameters.AddWithValue("nrDependentes", dependentes);
                comando.Parameters.AddWithValue("coeficiente", coeficiente);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Tabela cadastrada com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar irps! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int idUsuario, double salMin, double salMax, float valor, int dependentes, float coeficiente)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE irps SET salMin=?, salMax=?, valor=?, nrDependentes=?, coeficiente=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("salMin", salMin);
                comando.Parameters.AddWithValue("salMax", salMax);
                comando.Parameters.AddWithValue("valor", valor);
                comando.Parameters.AddWithValue("nrDependentes", dependentes);
                comando.Parameters.AddWithValue("coeficiente", coeficiente);
                comando.Parameters.AddWithValue("id", idUsuario);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a irps! Contacte o técnico");
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
                String sqlSelect = "SELECT * from irps";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    double salMin = leitor.GetFloat(1);
                    double salMax = leitor.GetFloat(2);
                    float valor = leitor.GetFloat(3);
                    int nrDependentes = leitor.GetInt16(4);
                    float coeficiente = leitor.GetInt16(5);
                    listaIRPS.Add(new ModeloIRPS(id, salMin, salMax, valor, nrDependentes, coeficiente));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel recuperar irps!");
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
                String SqlDelete = "DELETE from irps WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover irps! Contacte o técnico!");
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
                    double salMin = leitor.GetFloat(1);
                    double salMax = leitor.GetFloat(2);
                    float valor = leitor.GetFloat(3);
                    Convert.ToDecimal(valor);
                    int nrDependentes = leitor.GetInt16(4);
                    float coeficiente = leitor.GetInt16(5);
                    listaIRPS.Add(new ModeloIRPS(id, salMin, salMax, valor, nrDependentes, coeficiente));
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
        
        public static ArrayList recuperarComSalMin(double salMinimo)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaIRPS = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from irps WHERE salMin=" + salMinimo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    double salMin = leitor.GetFloat(1);
                    double salMax = leitor.GetFloat(2);
                    float valor = leitor.GetFloat(3);
                    int nrDependentes = leitor.GetInt16(4);
                    float coeficiente = leitor.GetInt16(5);
                    listaIRPS.Add(new ModeloIRPS(id, salMin, salMax, valor, nrDependentes, coeficiente));
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
