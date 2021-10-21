using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Facturix_Salários
{
    class ControllerContrato
    {
        public static void gravar(int id, String contrato)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into contrato(id, tipoContrato) values(?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("tipoContrato", contrato);
                comando.ExecuteNonQuery();
                MessageBox.Show("Contrato cadastrado com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar o contrato! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, String contrato)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE contrato SET tipoContrato=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue(" tipoContrato", contrato);
                comando.Parameters.AddWithValue("ido", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o contrato! Contacte o técnico!!");
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
            ArrayList listaContratos = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from contrato";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String contrato = leitor.GetString(1);
                    listaContratos.Add(new ModeloContrato(id, contrato));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar contratos!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaContratos;
        }

        public static void remover(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from contrato WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover o contrato! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from contrato WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String contrato = leitor.GetString(1);
                    listaSeguros.Add(new ModeloContrato(id, contrato));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possivel recuperar contratos!");
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
