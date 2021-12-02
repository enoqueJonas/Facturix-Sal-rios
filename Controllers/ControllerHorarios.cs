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
    class ControllerHorarios
    {
        public static void Guardar(int id, decimal tempoServico, decimal emTempoH, decimal emTempoM, decimal foraDoTempoH, decimal foraDotempoM, Boolean marcarPonto, Boolean baterPonto, Boolean saidaAdiantada, Boolean atraso, Boolean ausencia)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into horario (id, tempoServico, emTempoH, emTempoM, foraDoTempoH, foraDotempoM, marcarPonto, baterPonto, saidaAdiantada, atraso, ausencia) values(?,?,?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("tempoServico", tempoServico);
                comando.Parameters.AddWithValue("emTempoH", emTempoH);
                comando.Parameters.AddWithValue("emTempoM", emTempoM);
                comando.Parameters.AddWithValue("foraDoTempoH", foraDoTempoH);
                comando.Parameters.AddWithValue("foraDotempoM", foraDotempoM);
                comando.Parameters.AddWithValue("marcarPonto", marcarPonto);
                comando.Parameters.AddWithValue("baterPonto", baterPonto);
                comando.Parameters.AddWithValue("saidaAdiantada", saidaAdiantada);
                comando.Parameters.AddWithValue("atraso", atraso);
                comando.Parameters.AddWithValue("ausencia", ausencia);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar oHorarios! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, decimal tempoServico, decimal emTempoH, decimal emTempoM, decimal foraDoTempoH, decimal foraDotempoM, Boolean marcarPonto, Boolean baterPonto, Boolean saidaAdiantada, Boolean atraso, Boolean ausencia)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE horario SET tempoServico=?, emTempoH=?, emTempoM=?, foraDoTempoH=?, foraDotempoM=?, marcarPonto=?, baterPonto=?, saidaAdiantada=?, atraso=?, ausencia=?WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("tempoServico", tempoServico);
                comando.Parameters.AddWithValue("emTempoH", emTempoH);
                comando.Parameters.AddWithValue("emTempoM", emTempoM);
                comando.Parameters.AddWithValue("foraDoTempoH", foraDoTempoH);
                comando.Parameters.AddWithValue("foraDotempoM", foraDotempoM);
                comando.Parameters.AddWithValue("marcarPonto", marcarPonto);
                comando.Parameters.AddWithValue("baterPonto", baterPonto);
                comando.Parameters.AddWithValue("saidaAdiantada", saidaAdiantada);
                comando.Parameters.AddWithValue("atraso", atraso);
                comando.Parameters.AddWithValue("ausencia", ausencia);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o horario! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from horario";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    decimal tempoServico = leitor.GetDecimal(1);
                    decimal emTempoH = leitor.GetDecimal(2);
                    decimal emTempoM = leitor.GetDecimal(3);
                    decimal foraDoTempoH = leitor.GetDecimal(4);
                    decimal foraDoTempoM = leitor.GetDecimal(5);
                    Boolean marcarPonto = leitor.GetBoolean(6);
                    Boolean baterPonto = leitor.GetBoolean(7);
                    Boolean saidaAdiantada = leitor.GetBoolean(8);
                    Boolean atraso = leitor.GetBoolean(9);
                    Boolean ausencia = leitor.GetBoolean(10);
                    listaHorarios.Add(new ModeloHorarios(id, tempoServico, emTempoH, emTempoM, foraDoTempoH, foraDoTempoM, marcarPonto, baterPonto, saidaAdiantada, atraso, ausencia));
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
                String sqlSelect = "SELECT * from horario WHERE id=" + idFunc + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    decimal tempoServico = leitor.GetDecimal(1);
                    decimal emTempoH = leitor.GetDecimal(2);
                    decimal emTempoM = leitor.GetDecimal(3);
                    decimal foraDoTempoH = leitor.GetDecimal(4);
                    decimal foraDoTempoM = leitor.GetDecimal(5);
                    Boolean marcarPonto = leitor.GetBoolean(6);
                    Boolean baterPonto = leitor.GetBoolean(7);
                    Boolean saidaAdiantada = leitor.GetBoolean(8);
                    Boolean atraso = leitor.GetBoolean(9);
                    Boolean ausencia = leitor.GetBoolean(10);
                    listaHorarios.Add(new ModeloHorarios(id, tempoServico, emTempoH, emTempoM, foraDoTempoH, foraDoTempoM, marcarPonto, baterPonto, saidaAdiantada, atraso, ausencia));
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
                String SqlDelete = "DELETE from horario WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover o horario! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
