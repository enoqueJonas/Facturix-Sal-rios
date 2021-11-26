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
        public static void Guardar(int id, decimal umDiaTrabalho, decimal intervaloMinimo, decimal atraso, decimal falta, decimal saidaAdiantada, decimal horasExtra, decimal almoco, decimal entradaH, decimal entradaM, decimal saidaH, decimal saidaM)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into horario (id, umDiaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, horasExtra, almoco, entradaH, entradaM, saidaH, saidaM) values(?,?,?,?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("umDiaTrabalho", umDiaTrabalho);
                comando.Parameters.AddWithValue("intervaloMinimo", intervaloMinimo);
                comando.Parameters.AddWithValue("atraso", atraso);
                comando.Parameters.AddWithValue("falta", falta);
                comando.Parameters.AddWithValue("saidaAdiantada", saidaAdiantada);
                comando.Parameters.AddWithValue("horasExtra", horasExtra);
                comando.Parameters.AddWithValue("almoco", almoco);
                comando.Parameters.AddWithValue("entradaH", entradaH);
                comando.Parameters.AddWithValue("entradaM", entradaM);
                comando.Parameters.AddWithValue("saidaH", saidaH);
                comando.Parameters.AddWithValue("saidaM", saidaM);
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

        public static void atualizar(int id, decimal umDiaTrabalho, decimal intervaloMinimo, decimal atraso, decimal falta, decimal saidaAdiantada, decimal horasExtra, decimal almoco, decimal entradaH, decimal entradaM, decimal saidaH, decimal saidaM)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE horario SET umDiaTrabalho=?, intervaloMinimo=?, atraso=?, falta=?, saidaAdiantada=?, horasExtra=?, almoco=?, entradaH=?, entradaM=?, saidaH=?, saidaM=? WHERE id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("umDiaTrabalho", umDiaTrabalho);
                comando.Parameters.AddWithValue("intervaloMinimo", intervaloMinimo);
                comando.Parameters.AddWithValue("atraso", atraso);
                comando.Parameters.AddWithValue("falta", falta);
                comando.Parameters.AddWithValue("saidaAdiantada", saidaAdiantada);
                comando.Parameters.AddWithValue("horasExtra", horasExtra);
                comando.Parameters.AddWithValue("almoco", almoco);
                comando.Parameters.AddWithValue("entradaH", entradaH);
                comando.Parameters.AddWithValue("entradaM", entradaM);
                comando.Parameters.AddWithValue("saidaH", saidaH);
                comando.Parameters.AddWithValue("saidaM", saidaM);
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
                    decimal umDiaTrabalho = leitor.GetDecimal(1);
                    decimal intervaloMinimo = leitor.GetDecimal(2);
                    decimal atraso = leitor.GetDecimal(3);
                    decimal falta = leitor.GetDecimal(4);
                    decimal saidaAdiantada = leitor.GetDecimal(5);
                    decimal horasExtra = leitor.GetDecimal(6);
                    decimal almoco = leitor.GetDecimal(7);
                    decimal entradaH = leitor.GetDecimal(8);
                    decimal entradaM = leitor.GetDecimal(9);
                    decimal saidaH = leitor.GetDecimal(10);
                    decimal saidaM = leitor.GetDecimal(11);
                    listaHorarios.Add(new ModeloHorarios(id, umDiaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, horasExtra, almoco, entradaH, entradaM, saidaH, saidaM));
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
                    decimal umDiaTrabalho = leitor.GetDecimal(1);
                    decimal intervaloMinimo = leitor.GetDecimal(2);
                    decimal atraso = leitor.GetDecimal(3);
                    decimal falta = leitor.GetDecimal(4);
                    decimal saidaAdiantada = leitor.GetDecimal(5);
                    decimal horasExtra = leitor.GetDecimal(6);
                    decimal almoco = leitor.GetDecimal(7);
                    decimal entradaH = leitor.GetDecimal(8);
                    decimal entradaM = leitor.GetDecimal(9);
                    decimal saidaH = leitor.GetDecimal(10);
                    decimal saidaM = leitor.GetDecimal(11);
                    listaHorarios.Add(new ModeloHorarios(id, umDiaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, horasExtra, almoco, entradaH, entradaM, saidaH, saidaM));
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
