using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturix_Salários.Modelos;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Facturix_Salários.Controllers
{
    class ControllerRegrasDePonto
    {
        public static void Guardar(int id, decimal diaDeTrabalho, decimal intervaloEntreBatidas, decimal atraso, decimal ausencia, decimal saidaAdiantada, String entradaNaoRegistada, String saidaNaoRegistada, decimal horasExtra, decimal tempoAlmoco)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into regras_do_relogio (id, diaDeTrabalho, intervaloEntreBatidas, atraso, ausencia, saidaAdiantada, entradaNaoRegistada, saidaNaoRegistada, horasExtra, tempoAlmoco) values(?,?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("diaDeTrabalho", diaDeTrabalho);
                comando.Parameters.AddWithValue("intervaloEntreBatidas", intervaloEntreBatidas);
                comando.Parameters.AddWithValue("atraso", atraso);
                comando.Parameters.AddWithValue("ausencia", ausencia);
                comando.Parameters.AddWithValue("saidaAdiantada", saidaAdiantada);
                comando.Parameters.AddWithValue("entradaNaoRegistada", entradaNaoRegistada);
                comando.Parameters.AddWithValue("saidaNaoRegistada", saidaNaoRegistada);
                comando.Parameters.AddWithValue("horasExtra", horasExtra);
                comando.Parameters.AddWithValue("tempoAlmoco", tempoAlmoco);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar regras de ponto! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, decimal diaDeTrabalho, decimal intervaloEntreBatidas, decimal atraso, decimal ausencia, decimal saidaAdiantada, String entradaNaoRegistada, String saidaNaoRegistada, decimal horasExtra, decimal tempoAlmoco)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE regras_do_relogio SET diaDeTrabalho=?, intervaloEntreBatidas=?, atraso=?, ausencia=?, saidaAdiantada=?, entradaNaoRegistada=?, saidaNaoRegistada=?, horasExtra=?, tempoAlmoco=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("diaDeTrabalho", diaDeTrabalho);
                comando.Parameters.AddWithValue("intervaloEntreBatidas", intervaloEntreBatidas);
                comando.Parameters.AddWithValue("atraso", atraso);
                comando.Parameters.AddWithValue("ausencia", ausencia);
                comando.Parameters.AddWithValue("saidaAdiantada", saidaAdiantada);
                comando.Parameters.AddWithValue("entradaNaoRegistada", entradaNaoRegistada);
                comando.Parameters.AddWithValue("saidaNaoRegistada", saidaNaoRegistada);
                comando.Parameters.AddWithValue("horasExtra", horasExtra);
                comando.Parameters.AddWithValue("tempoAlmoco", tempoAlmoco);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar regraDeRelogioDePonto! Contacte o técnico!");
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
            ArrayList listaHorarios = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from regras_do_relogio";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    decimal diaDeTrabalho = leitor.GetDecimal(1);
                    decimal intervaloEntreBatidas = leitor.GetDecimal(2);
                    decimal atraso = leitor.GetDecimal(3);
                    decimal ausencia = leitor.GetDecimal(4);
                    decimal saidaAdiantada = leitor.GetDecimal(5);
                    String entradaNaoRegistada = leitor.GetString(6);
                    String saidaNaoRegistada = leitor.GetString(7);
                    decimal horasExtra = leitor.GetDecimal(8);
                    decimal tempoAlmoco = leitor.GetDecimal(9);
                    listaHorarios.Add(new ModeloRegrasDePonto(id, diaDeTrabalho, intervaloEntreBatidas, atraso, ausencia, saidaAdiantada, entradaNaoRegistada, saidaNaoRegistada, horasExtra, tempoAlmoco));
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
            return listaHorarios;
        }

        public static ArrayList recuperarComCod(int idFunc)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaHorarios = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from regras_do_relogio WHERE id=" + idFunc + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    decimal diaDeTrabalho = leitor.GetDecimal(1);
                    decimal intervaloEntreBatidas = leitor.GetDecimal(2);
                    decimal atraso = leitor.GetDecimal(3);
                    decimal ausencia = leitor.GetDecimal(4);
                    decimal saidaAdiantada = leitor.GetDecimal(5);
                    String entradaNaoRegistada = leitor.GetString(6);
                    String saidaNaoRegistada = leitor.GetString(7);
                    decimal horasExtra = leitor.GetDecimal(8);
                    decimal tempoAlmoco = leitor.GetDecimal(9);
                    listaHorarios.Add(new ModeloRegrasDePonto(id, diaDeTrabalho, intervaloEntreBatidas, atraso, ausencia, saidaAdiantada, entradaNaoRegistada, saidaNaoRegistada, horasExtra, tempoAlmoco));
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
            return listaHorarios;
        }

        public static void remover(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from regras_do_relogio WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover a regra de ponto! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
