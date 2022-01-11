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
    class ControllerProcessamentoDeSalario
    {
        public static void Guardar(int id, int idFuncionario, String nomeTrabalhador, int diasDeTrabalho, double salarioBrutoMensal, double subsidioAlimentacao,double ajudaDeCusto, double ajudaDeDeslocacao, double pagamentoFerias, double diversosSubsidios, double totalRetribuicao, double emprestimoMedico, double irps, double ipa, double inss, double totalADescontar, double adiantamentos, double importanciaAPagar, String operacao, String dataProcessamento, String tipo)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into processamento_salario (id, idFuncionario, nomeTrabalhador, diasDeTrabalho, salarioBrutoMensal, subsidioAlimentacao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, tipo) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.Parameters.AddWithValue("nomeTrabalhador", nomeTrabalhador);
                comando.Parameters.AddWithValue("diasDeTrabalho", diasDeTrabalho);
                comando.Parameters.AddWithValue("salarioBrutoMensal", salarioBrutoMensal);
                comando.Parameters.AddWithValue("subsidioAlimentacao", subsidioAlimentacao);
                comando.Parameters.AddWithValue("ajudaDeCusto", ajudaDeCusto);
                comando.Parameters.AddWithValue("ajudaDeDeslocacao", ajudaDeDeslocacao);
                comando.Parameters.AddWithValue("pagamentoFerias", pagamentoFerias);
                comando.Parameters.AddWithValue("diversosSubsidios", diversosSubsidios);
                comando.Parameters.AddWithValue("totalRetribuicao", totalRetribuicao);
                comando.Parameters.AddWithValue("emprestimoMedico", emprestimoMedico);
                comando.Parameters.AddWithValue("irps", irps);
                comando.Parameters.AddWithValue("ipa", ipa);
                comando.Parameters.AddWithValue("inss", inss);
                comando.Parameters.AddWithValue("totalADescontar", totalADescontar);
                comando.Parameters.AddWithValue("adiantamentos", adiantamentos);
                comando.Parameters.AddWithValue("importanciaAPagar", importanciaAPagar);
                comando.Parameters.AddWithValue("operacao", operacao);
                comando.Parameters.AddWithValue("dataProcessamento", dataProcessamento);
                comando.Parameters.AddWithValue("tipo", tipo);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Salário/os processado/os com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar processamento! Contacte o técnico!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizar(int id, int idFuncionario, String nomeTrabalhador, int diasDeTrabalho, double salarioBrutoMensal, double subsidioAlimentacao, double ajudaDeCusto, double ajudaDeDeslocacao, double pagamentoFerias, double diversosSubsidios, double totalRetribuicao, double emprestimoMedico, double irps, double ipa, double inss, double totalADescontar, double adiantamentos, double importanciaAPagar, String operacao, String dataProcessamento, String tipo)
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "UPDATE processamento_salario SET nomeTrabalhador=?, diasDeTrabalho=?, salarioBrutoMensal=?, subsidioAlimentacao=?, ajudaDeCusto=?, ajudaDeDeslocacao=?, pagamentoFerias=?, diversosSubsidios=?, totalRetribuicao=?, emprestimoMedico=?, irps=?, ipa=?, inss=?, totalADescontar=?, adiantamentos=?, importanciaAPagar=?, operacao=?, dataProcessamento=?, tipo=? WHERE idFuncionario=? AND id=?";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("nomeTrabalhador", nomeTrabalhador);
                comando.Parameters.AddWithValue("diasDeTrabalho", diasDeTrabalho);
                comando.Parameters.AddWithValue("salarioBrutoMensal", salarioBrutoMensal);
                comando.Parameters.AddWithValue("subsidioAlimentacao", subsidioAlimentacao);
                comando.Parameters.AddWithValue("ajudaDeCusto", ajudaDeCusto);
                comando.Parameters.AddWithValue("ajudaDeDeslocacao", ajudaDeDeslocacao);
                comando.Parameters.AddWithValue("pagamentoFerias", pagamentoFerias);
                comando.Parameters.AddWithValue("diversosSubsidios", diversosSubsidios);
                comando.Parameters.AddWithValue("totalRetribuicao", totalRetribuicao);
                comando.Parameters.AddWithValue("emprestimoMedico", emprestimoMedico);
                comando.Parameters.AddWithValue("irps", irps);
                comando.Parameters.AddWithValue("ipa", ipa);
                comando.Parameters.AddWithValue("inss", inss);
                comando.Parameters.AddWithValue("totalADescontar", totalADescontar);
                comando.Parameters.AddWithValue("adiantamentos", adiantamentos);
                comando.Parameters.AddWithValue("importanciaAPagar", importanciaAPagar);
                comando.Parameters.AddWithValue("operacao", operacao);
                comando.Parameters.AddWithValue("dataProcessamento", dataProcessamento);
                comando.Parameters.AddWithValue("tipo", tipo);
                comando.Parameters.AddWithValue("idFuncionario", idFuncionario);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar processamento! Contacte o técnico!");
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
            ArrayList listaProcessamento = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from processamento_salario";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    String nomeTrabalhador = leitor.GetString(2);
                    int diasDeTrabalho = leitor.GetInt16(3);
                    double salarioBrutosMensal = leitor.GetDouble(4);
                    double subAlimentacao = leitor.GetDouble(5);
                    double ajudaDeCusto = leitor.GetDouble(6);
                    double ajudaDeDeslocacao = leitor.GetDouble(7);
                    double pagamentoFerias = leitor.GetDouble(8);
                    double diversosSubsidios = leitor.GetDouble(9);
                    double totalRetribuicao = leitor.GetDouble(10);
                    double emprestimoMedico = leitor.GetDouble(11);
                    double irps = leitor.GetDouble(12);  
                    double ipa = leitor.GetDouble(13);  
                    double inss = leitor.GetDouble(14);  
                    double totalADescontar = leitor.GetDouble(15);  
                    double adiantamentos = leitor.GetDouble(16);  
                    double importanciaAPagar = leitor.GetDouble(17);  
                    String operacao = leitor.GetString(18);
                    String dataProcessamento = leitor.GetString(19);
                    String tipo = leitor.GetString(20);
                    listaProcessamento.Add(new ModeloProcessamentoDeSalario(id, idFuncionario, nomeTrabalhador, diasDeTrabalho, salarioBrutosMensal, subAlimentacao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, tipo));
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
            return listaProcessamento;
        }

        public static ArrayList recuperarComCod(int idFunc)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaProcessamento = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from processamento_salario WHERE idFuncionario=" + idFunc + "";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int id = leitor.GetInt16(0);
                    int idFuncionario = leitor.GetInt16(1);
                    String nomeTrabalhador = leitor.GetString(2);
                    int diasDeTrabalho = leitor.GetInt16(3);
                    double salarioBrutosMensal = leitor.GetDouble(4);
                    double subAlimentacao = leitor.GetDouble(5);
                    double ajudaDeCusto = leitor.GetDouble(6);
                    double ajudaDeDeslocacao = leitor.GetDouble(7);
                    double pagamentoFerias = leitor.GetDouble(8);
                    double diversosSubsidios = leitor.GetDouble(9);
                    double totalRetribuicao = leitor.GetDouble(10);
                    double emprestimoMedico = leitor.GetDouble(11);
                    double irps = leitor.GetDouble(12);
                    double ipa = leitor.GetDouble(13);
                    double inss = leitor.GetDouble(14);
                    double totalADescontar = leitor.GetDouble(15);
                    double adiantamentos = leitor.GetDouble(16);
                    double importanciaAPagar = leitor.GetDouble(17);
                    String operacao = leitor.GetString(18);
                    String dataProcessamento = leitor.GetString(19);
                    String tipo = leitor.GetString(20);
                    listaProcessamento.Add(new ModeloProcessamentoDeSalario(id, idFuncionario, nomeTrabalhador, diasDeTrabalho, salarioBrutosMensal, subAlimentacao, ajudaDeCusto, ajudaDeDeslocacao, pagamentoFerias, diversosSubsidios, totalRetribuicao, emprestimoMedico, irps, ipa, inss, totalADescontar, adiantamentos, importanciaAPagar, operacao, dataProcessamento, tipo));
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
            return listaProcessamento;
        }

        public static void remover(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from processamento_salario WHERE id=?";
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
