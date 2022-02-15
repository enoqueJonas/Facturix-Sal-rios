using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Facturix_Salários.Modelos;
using System.Windows.Forms;

namespace Facturix_Salários.Controllers
{
    class ControllerDiasDeTrabalho
    {
        public static void gravar(int id, int diasDeTrabalho, String data)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into dias_de_trabalho (idFunc, diasDeTrabalho, data) values(?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("idFunc", id);
                comando.Parameters.AddWithValue("diasDeTrabalho", diasDeTrabalho);
                comando.Parameters.AddWithValue("data", data);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Dias cadastrados com sucesso!");
            }
            catch (Exception err)
            {
                String mess = err.Message;
                //MessageBox.Show(err.Message, "Não foi possível cadastrar categoria! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, int diasDeTrabalho, String data)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE dias_de_trabalho SET diasDeTrabalho=? WHERE idFunc=? AND data=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("diasDeTrabalho", diasDeTrabalho);
                comando.Parameters.AddWithValue("idFunc", id);
                comando.Parameters.AddWithValue("data", data);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                String mess = err.Message;
                //MessageBox.Show(err.Message, "Não foi possível atualizar a categoria! Contacte o técnico");
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
            ArrayList lista = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from dias_de_trabalho";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int categoria = leitor.GetInt16(1);
                    DateTime data = leitor.GetDateTime(2);
                    String dt = data.ToString();
                    lista.Add(new ModeloDiasDeTrabalho(id, categoria, dt));
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
            return lista;
        }

        public static void remover()
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from dias_de_trabalho";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                String mess = err.Message;
                //MessageBox.Show(err.Message, "Não foi possível remover a categoria! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        //public static ArrayList recuperarComCod(int codigo)
        //{
        //    MySqlConnection conexao = Conexao.conectar();
        //    ArrayList listaCategorias = new ArrayList();
        //    try
        //    {
        //        conexao.Open();
        //        String sqlSelect = "SELECT * from categoria WHERE id=" + codigo;
        //        MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
        //        MySqlDataReader leitor = comando.ExecuteReader();
        //        while (leitor.Read())
        //        {
        //            int id = leitor.GetInt16(0);
        //            String categoria = leitor.GetString(1);
        //            listaCategorias.Add(new ModeloCategoria(id, categoria));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show(err.Message, "Nao foi possivel recuperar categorias!");
        //    }
        //    finally
        //    {
        //        if (conexao != null)
        //            conexao.Close();
        //    }
        //    return listaCategorias;
        //}
    }
}
