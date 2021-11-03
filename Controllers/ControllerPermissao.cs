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
    class ControllerPermissao
    {
        public static void gravar(int idUsuario, String tabela, Boolean activo, String cabecalho)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into permissao(idUsuario, tabela, activo, cabecalhoTabela) values(?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("idUsuario", idUsuario);
                comando.Parameters.AddWithValue("tabela", tabela);
                comando.Parameters.AddWithValue("activo", activo);
                comando.Parameters.AddWithValue("cabecalhoTabela", cabecalho);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Tabela cadastrada com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar permissao! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, int idUsuario, String tabela, Boolean activo)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE permissao SET tabela=?, activo=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("tabela", tabela);
                comando.Parameters.AddWithValue("activo", activo);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar a permissao! Contacte o técnico");
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
            ArrayList listaPermissoes = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from permissao";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idUsuario = leitor.GetInt16(1);
                    String tabela = leitor.GetString(2);
                    Boolean activo = leitor.GetBoolean(3);
                    String cabecalho = leitor.GetString(4);
                    listaPermissoes.Add(new ModeloPermissao(id, idUsuario, tabela, activo, cabecalho));
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
            return listaPermissoes;
        }

        public static void removerComCod(int id)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from permissao WHERE idUsuario=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover a permissao! Contacte o técnico!");
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
            ArrayList listaPermissoes = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from permissao WHERE id=" + codigo;
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idUsuario = leitor.GetInt16(1);
                    String tabela = leitor.GetString(2);
                    Boolean activo = leitor.GetBoolean(3);
                    String cabecalho = leitor.GetString(4);
                    listaPermissoes.Add(new ModeloPermissao(id, idUsuario, tabela, activo, cabecalho));
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
            return listaPermissoes;
        }
    }
}
