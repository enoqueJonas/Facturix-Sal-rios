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
    class ControllerRelogioDePonto
    {
        public static void Guardar(int sn, ulong idUsuario, String estado, int nrDispositivo, String accao, String data)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into relogioDePonto (sn, idUsuario, estado, nrDispositivo, accao, data) values(?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("sn", sn);
                comando.Parameters.AddWithValue("idUsuario", idUsuario);
                comando.Parameters.AddWithValue("estado", estado);
                comando.Parameters.AddWithValue("nrDispositivo", nrDispositivo);
                comando.Parameters.AddWithValue("accao", accao);
                comando.Parameters.AddWithValue("data", data);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar relatorio de relogio! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int sn, int idUsuario, String estado, int nrDispositivo, String accao, String data)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE relogioDePonto SET estado=?, nrDispositivo=?, accao=?, data=? WHERE sn=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("estado", estado);
                comando.Parameters.AddWithValue("nrDispositivo", nrDispositivo);
                comando.Parameters.AddWithValue("accao", accao);
                comando.Parameters.AddWithValue("data", data);
                comando.Parameters.AddWithValue("sn", sn);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o relatorio de relogio! Contacte o técnico!");
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
            ArrayList listaRelogioDePonto = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from relogioDePonto";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int sn = leitor.GetInt16(0);
                    int idUsuario = leitor.GetInt16(1);
                    String estado = leitor.GetString(2);
                    int nrDispositivo = leitor.GetInt16(3);
                    String accao = leitor.GetString(4);
                    String data = leitor.GetString(5);
                    listaRelogioDePonto.Add(new ModeloRelogioDePonto(sn, idUsuario, estado, nrDispositivo, accao, data));
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
            return listaRelogioDePonto;
        }

        public static ArrayList recuperarComCod(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaRelogioDePonto = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from relogioDePonto WHERE sn=" + id + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int sn = leitor.GetInt16(0);
                    int idUsuario = leitor.GetInt16(1);
                    String estado = leitor.GetString(2);
                    int nrDispositivo = leitor.GetInt16(3);
                    String accao = leitor.GetString(4);
                    String data = leitor.GetString(5);
                    listaRelogioDePonto.Add(new ModeloRelogioDePonto(sn, idUsuario, estado, nrDispositivo, accao, data));
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
            return listaRelogioDePonto;
        }

        public static void remover()
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from relogioDePonto";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover o relogio de ponto! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
