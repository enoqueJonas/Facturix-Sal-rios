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
    class ControllerFinalDeSemana
    {
        public static void Guardar(int id,String fds, Boolean segundaManha, Boolean segundaTarde, Boolean tercaManha, Boolean tercaTarde, Boolean quartaManha, Boolean quartaTarde, Boolean quintaManha, Boolean quintaTarde, Boolean sextaManha, Boolean sextaTarde, Boolean sabadoManha, Boolean sabadoTarde, Boolean domingoManha, Boolean domingoTarde, Boolean ativo)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into fim_de_semana (id, finalDeSemana, segundaManha, segundaTarde, tercaManha, tercaTarde, quartaManha, quartaTarde, quintaManha, quintaTarde, sextaManha, sextaTarde, sabadoManha, sabadoTarde, domingoManha, domingoTarde, ativo) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("finalDeSemana", fds);
                comando.Parameters.AddWithValue("segundaManha", segundaManha);
                comando.Parameters.AddWithValue("segundaTarde", segundaTarde);
                comando.Parameters.AddWithValue("tercaManha", tercaManha);
                comando.Parameters.AddWithValue("tercaTarde", tercaTarde);
                comando.Parameters.AddWithValue("quartaManha", quartaManha);
                comando.Parameters.AddWithValue("quartaTarde", quartaTarde);
                comando.Parameters.AddWithValue("quintaManha", quintaManha);
                comando.Parameters.AddWithValue("quintaTarde", quintaTarde);
                comando.Parameters.AddWithValue("sextaManha", sextaManha);
                comando.Parameters.AddWithValue("sextaTarde", sextaTarde);
                comando.Parameters.AddWithValue("sabadoManha", sabadoManha);
                comando.Parameters.AddWithValue("sabadoTarde", sabadoTarde);
                comando.Parameters.AddWithValue("domingoManha", domingoManha);
                comando.Parameters.AddWithValue("domingoTarde", domingoTarde);
                comando.Parameters.AddWithValue("ativo", ativo);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar fim de semana! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id,String fds, Boolean segundaManha, Boolean segundaTarde, Boolean tercaManha, Boolean tercaTarde, Boolean quartaManha, Boolean quartaTarde, Boolean quintaManha, Boolean quintaTarde, Boolean sextaManha, Boolean sextaTarde, Boolean sabadoManha, Boolean sabadoTarde, Boolean domingoManha, Boolean domingoTarde, Boolean ativo)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE fim_de_semana SET finalDeSemana=?, segundaManha=?, segundaTarde=?, tercaManha=?, tercaTarde=?, quartaManha=?, quartaTarde=?, quintaManha=?, quintaTarde=?, sextaManha=?, sextaTarde=?, sabadoManha=?, sabadoTarde=?, domingoManha=?, domingoTarde=?, ativo=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("finalDeSemana", fds);
                comando.Parameters.AddWithValue("segundaManha", segundaManha);
                comando.Parameters.AddWithValue("segundaTarde", segundaTarde);
                comando.Parameters.AddWithValue("tercaManha", tercaManha);
                comando.Parameters.AddWithValue("tercaTarde", tercaTarde);
                comando.Parameters.AddWithValue("quartaManha", quartaManha);
                comando.Parameters.AddWithValue("quartaTarde", quartaTarde);
                comando.Parameters.AddWithValue("quintaManha", quintaManha);
                comando.Parameters.AddWithValue("quintaTarde", quintaTarde);
                comando.Parameters.AddWithValue("sextaManha", sextaManha);
                comando.Parameters.AddWithValue("sextaTarde", sextaTarde);
                comando.Parameters.AddWithValue("sabadoManha", sabadoManha);
                comando.Parameters.AddWithValue("sabadoTarde", sabadoTarde);
                comando.Parameters.AddWithValue("domingoManha", domingoManha);
                comando.Parameters.AddWithValue("domingoTarde", domingoTarde);
                comando.Parameters.AddWithValue("ativo", ativo);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o Fim de semana! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizarAtivo(int id, Boolean ativo)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE fim_de_semana SET ativo=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("ativo", ativo);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o Fim de semana ativo! Contacte o técnico!");
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
                String sqlSelect = "SELECT * from fim_de_semana";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String fds = leitor.GetString(1);
                    Boolean sm = leitor.GetBoolean(2);
                    Boolean st = leitor.GetBoolean(3);
                    Boolean tm = leitor.GetBoolean(4);
                    Boolean tt = leitor.GetBoolean(5);
                    Boolean qm = leitor.GetBoolean(6);
                    Boolean qt = leitor.GetBoolean(7);
                    Boolean qnm = leitor.GetBoolean(8);
                    Boolean qnt = leitor.GetBoolean(9);
                    Boolean sxm = leitor.GetBoolean(10);
                    Boolean sxt = leitor.GetBoolean(11);
                    Boolean sam = leitor.GetBoolean(12);
                    Boolean sat = leitor.GetBoolean(13);
                    Boolean dm = leitor.GetBoolean(14);
                    Boolean dt = leitor.GetBoolean(15);
                    Boolean ativo = leitor.GetBoolean(16);
                    listaHorarios.Add(new ModeloFinalDeSemana(id,fds, sm, st, tm, tt, qm, qt, qnm, qnt, sxm, sxt, sam, sat, dm, dt, ativo));
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
                String sqlSelect = "SELECT * from fim_de_semana WHERE id=" + idFunc + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    String fds = leitor.GetString(1);
                    Boolean sm = leitor.GetBoolean(2);
                    Boolean st = leitor.GetBoolean(3);
                    Boolean tm = leitor.GetBoolean(4);
                    Boolean tt = leitor.GetBoolean(5);
                    Boolean qm = leitor.GetBoolean(6);
                    Boolean qt = leitor.GetBoolean(7);
                    Boolean qnm = leitor.GetBoolean(8);
                    Boolean qnt = leitor.GetBoolean(9);
                    Boolean sxm = leitor.GetBoolean(10);
                    Boolean sxt = leitor.GetBoolean(11);
                    Boolean sam = leitor.GetBoolean(12);
                    Boolean sat = leitor.GetBoolean(13);
                    Boolean dm = leitor.GetBoolean(14);
                    Boolean dt = leitor.GetBoolean(15);
                    Boolean ativo = leitor.GetBoolean(16);
                    listaHorarios.Add(new ModeloFinalDeSemana(id, fds, sm, st, tm, tt, qm, qt, qnm, qnt, sxm, sxt, sam, sat, dm, dt, ativo));
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
                String SqlDelete = "DELETE from fim_de_semana WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", codigo));
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover o fim de semana! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
