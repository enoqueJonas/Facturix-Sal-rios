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
    class ControllerAdiantamento
    {
        public static void Guardar(int id, int idFuncionario, double salarioBruto, int diasDeTrabalho, float percentagem, double adiantamento, String data)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into adiantamento (id, idFuncionario, salarioBruto, diasDeTrabalho, percentagem, adiantamento, data) values(?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.Parameters.AddWithValue("salarioBruto", salarioBruto);
                comando.Parameters.AddWithValue("diasDeTrabalho", diasDeTrabalho);
                comando.Parameters.AddWithValue("percentagem", percentagem);
                comando.Parameters.AddWithValue("adiantamento", adiantamento);
                comando.Parameters.AddWithValue("data", data);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar o adiantamento! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, int idFuncionario, double salarioBruto, int diasDeTrabalho, float percentagem, double adiantamento, String data)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE adiantamento SET salarioBruto=?, diasDeTrabalho=?, percentagem=?, adiantamento=?, data=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("salarioBruto", salarioBruto);
                comando.Parameters.AddWithValue("diasDeTrabalho", diasDeTrabalho);
                comando.Parameters.AddWithValue("percentagem", percentagem);
                comando.Parameters.AddWithValue("adiantamento", adiantamento);
                comando.Parameters.AddWithValue("data", data);
                //comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o adiantamento! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from adiantamento";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    double salarioBruto = leitor.GetDouble(2);
                    int diasDeTrabalho = leitor.GetInt16(3);
                    float percentagem = leitor.GetFloat(4);
                    double adiantamento = leitor.GetDouble(5);
                    String data = leitor.GetString(6);
                    listaContas.Add(new ModeloAdiantamento(id, idFuncionario, salarioBruto, diasDeTrabalho, percentagem, adiantamento, data));
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

        public static ArrayList recuperarComCod(int idAdi)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaContas = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from adiantamento WHERE id=" + idAdi + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    double salarioBruto = leitor.GetDouble(2);
                    int diasDeTrabalho = leitor.GetInt16(3);
                    float percentagem = leitor.GetFloat(4);
                    double adiantamento = leitor.GetDouble(5);
                    String data = leitor.GetString(6);
                    listaContas.Add(new ModeloAdiantamento(id, idFuncionario, salarioBruto, diasDeTrabalho, percentagem, adiantamento, data));
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

        //public static ArrayList recuperarComCodFuncionario(int idFunc)
        //{
        //    MySqlConnection conexao = Conexao.conectar();
        //    ArrayList listaContas = new ArrayList();
        //    try
        //    {
        //        conexao.Open();
        //        String sqlSelect = "SELECT * from dependente WHERE idFuncionario=" + idFunc + "";
        //        MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
        //        MySqlDataReader leitor = comando.ExecuteReader();
        //        while (leitor.Read())
        //        {
        //            int id = leitor.GetInt16(0);
        //            int idFuncionario = leitor.GetInt16(1);
        //            String nome = leitor.GetString(2);
        //            String dataNascimento = leitor.GetString(3);
        //            String dt = dataNascimento.Substring(0, 10);
        //            String grauParentesco = leitor.GetString(4);
        //            listaContas.Add(new ModeloDependente(id, idFuncionario, nome, dt, grauParentesco));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show(err.Message, "Nao foi possivel recuperar dependentes!");
        //    }
        //    finally
        //    {
        //        if (conexao != null)
        //            conexao.Close();
        //    }
        //    return listaContas;
        //}

        public static void remover(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from adiantamento WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover o adiantamento! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }

}
