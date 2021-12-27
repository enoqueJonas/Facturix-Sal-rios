using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Facturix_Salários
{
    class ControllerFuncionario
    {
        public static void Guardar
            (
                int codigo,
                int idIRPS,
                String nome, 
                String cell, 
                String cellSec, 
                String telefone, 
                String email, 
                String estadoCivil, 
                String deficiencia, 
                String conjugue, 
                String sexo, 
                String dataNascimento, 
                String linkImagem, 
                int codigoPostal, 
                String bairro, 
                String localidade, 
                String moradaGen,
                String tipoContrato,
                String dataAdmissao,
                String dataDemissao,
                String profissao,
                String categoria,
                String seguro,
                String localTrabalho,
                String regime,
                String bi,
                String numeroBenificiario,
                String numeroFiscal,
                double vencimento,
                double subAlimentacao,
                double subTransporte,
                float horas,
                int dependentes,
                String habilitacoes,
                String nacionalidade,
                String ultimoEmprego,
                String turno,
                float impostoMunicipal,
                String centroDeCusto,
                String segurancaSocial,
                String sindicato,
                double subComunicacao
            )
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into funcionario ( id, idIRPS, nome, cell, cellSec, telefone, email, estadoCivil, deficiencia, conjugue, sexo, dataNascimento, linkImagem, codigoPostal, bairro, localidade, moradaGen, tipoContrato,dataAdmissao, dataDemissao, profissao, categoria, seguro, localDeTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao , subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto, segurancaSocial, sindicato, subComunicacao) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", codigo);
                comando.Parameters.AddWithValue("idIRPS", idIRPS);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("cell", cell);
                comando.Parameters.AddWithValue("cellSec", cellSec);
                comando.Parameters.AddWithValue("telefone", telefone);
                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("estadoCivil", estadoCivil);
                comando.Parameters.AddWithValue("deficiencia", deficiencia);
                comando.Parameters.AddWithValue("conjugue", conjugue);
                comando.Parameters.AddWithValue("sexo", sexo);
                comando.Parameters.AddWithValue("dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("linkImagem", linkImagem);
                comando.Parameters.AddWithValue("codigoPostal", codigoPostal);
                comando.Parameters.AddWithValue("bairro", bairro);
                comando.Parameters.AddWithValue("localidade", localidade);
                comando.Parameters.AddWithValue("moradaGen", moradaGen);
                comando.Parameters.AddWithValue("tipoContrato", tipoContrato);
                comando.Parameters.AddWithValue("dataAdmissao", dataAdmissao);
                comando.Parameters.AddWithValue("dataDemissao", dataDemissao);
                comando.Parameters.AddWithValue("profissao", profissao);
                comando.Parameters.AddWithValue("categoria", categoria);
                comando.Parameters.AddWithValue("seguro", seguro);
                comando.Parameters.AddWithValue("localDeTrabalho", localTrabalho);
                comando.Parameters.AddWithValue("regime", regime);
                comando.Parameters.AddWithValue("bi", bi);
                comando.Parameters.AddWithValue("numeroBenificiario", numeroBenificiario);
                comando.Parameters.AddWithValue("numeroFiscal", numeroFiscal);
                comando.Parameters.AddWithValue("vencimento", vencimento);
                comando.Parameters.AddWithValue("subAlimentacao", subAlimentacao);
                comando.Parameters.AddWithValue("subTransporte", subTransporte);
                comando.Parameters.AddWithValue("horas", horas);
                comando.Parameters.AddWithValue("dependentes", dependentes);
                comando.Parameters.AddWithValue("habilitacoes", habilitacoes);
                comando.Parameters.AddWithValue("nacionalidade", nacionalidade);
                comando.Parameters.AddWithValue("ultimoEmprego", ultimoEmprego);
                comando.Parameters.AddWithValue("turno", turno);
                comando.Parameters.AddWithValue("impostoMunicipal", impostoMunicipal);
                comando.Parameters.AddWithValue("centroDeCusto", centroDeCusto);
                comando.Parameters.AddWithValue("segurancaSocial", segurancaSocial);
                comando.Parameters.AddWithValue("sindicato", sindicato);
                comando.Parameters.AddWithValue("subComunicacao", subComunicacao);
                comando.ExecuteNonQuery();
                MessageBox.Show("Funcionário cadastrado com sucesso!");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível cadastrar o  Funcionário! Contacte o técnico!");
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
            ArrayList listaFuncionarios = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from funcionario";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int codigo = leitor.GetInt16(0);
                    int idIRPS = leitor.GetInt16(1);
                    String nome = leitor.GetString(2) + "";
                    int codPostal = leitor.GetInt16(3);
                    String cell = leitor.GetString(4) + "";
                    String cellSec = leitor.GetString(5) + "";
                    String tel = leitor.GetString(6) + "";
                    String email = leitor.GetString(7) + "";
                    String estadoCivil = leitor.GetString(8) + "";
                    String def = leitor.GetString(9) + "";
                    String conjugue = leitor.GetString(10) + "";
                    String sexo = leitor.GetString(11) + "";
                    String dataNascimento = leitor.GetString(12) + "";
                    String linkImagem = leitor.GetString(13) + "";
                    String bairro = leitor.GetString(14) + "";
                    String localidade = leitor.GetString(15) + "";
                    String moradaGen = leitor.GetString(16) + "";
                    String tipoContrato = leitor.GetString(17) + "";
                    String dataAdmissao = leitor.GetString(18) + "";
                    String dataDemissao = leitor.GetString(19) + "";
                    String profissao = leitor.GetString(20) + "";
                    String categoria = leitor.GetString(21) + "";
                    String seguro = leitor.GetString(22) + "";
                    String localTrabalho = leitor.GetString(23) + "";
                    String regime = leitor.GetString(24) + "";
                    String bi = leitor.GetString(25) + "";
                    String numeroBenificiario = leitor.GetString(26) + "";
                    String numeroFiscal = leitor.GetString(27)+"";
                    double vencimento = leitor.GetDouble(28);
                    double subAlimentacao = leitor.GetDouble(29);
                    double subTransporte = leitor.GetDouble(30);
                    float horas = leitor.GetFloat(31);
                    int dependentes = leitor.GetInt16(32);
                    String habilitacoes = leitor.GetString(33);
                    String nacionalidade = leitor.GetString(34);
                    String ultimoEmprego = leitor.GetString(35);
                    String turno = leitor.GetString(36);
                    float impostoMunicipal = leitor.GetFloat(37);
                    String centroDeCusto = leitor.GetString(38);
                    String segurancaSocial = leitor.GetString(39);
                    String sindicato = leitor.GetString(40);
                    double subComunicacao = leitor.GetDouble(41);
                    listaFuncionarios.Add(new ModeloFuncionario(codigo, idIRPS, nome, cell, cellSec, tel, email, estadoCivil, def, conjugue, sexo, dataNascimento, linkImagem, codPostal, bairro, localidade, moradaGen, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto,segurancaSocial, sindicato, subComunicacao));
                }
            } catch (Exception)
            {
               
            }
            finally{
                if (conexao != null)
                    conexao.Close();
            }
            return listaFuncionarios;
        }

        public static ArrayList recuperarComCodigo(int cod)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaFuncionarios = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from funcionario WHERE id="+cod+"";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int codigo = leitor.GetInt16(0);
                    int idIRPS = leitor.GetInt16(1);
                    String nome = leitor.GetString(2) + "";
                    int codPostal = leitor.GetInt16(3);
                    String cell = leitor.GetString(4) + "";
                    String cellSec = leitor.GetString(5) + "";
                    String tel = leitor.GetString(6) + "";
                    String email = leitor.GetString(7) + "";
                    String estadoCivil = leitor.GetString(8) + "";
                    String def = leitor.GetString(9) + "";
                    String conjugue = leitor.GetString(10) + "";
                    String sexo = leitor.GetString(11) + "";
                    String dataNascimento = leitor.GetString(12) + "";
                    String linkImagem = leitor.GetString(13) + "";
                    String bairro = leitor.GetString(14) + "";
                    String localidade = leitor.GetString(15) + "";
                    String moradaGen = leitor.GetString(16) + "";
                    String tipoContrato = leitor.GetString(17) + "";
                    String dataAdmissao = leitor.GetString(18) + "";
                    String dataDemissao = leitor.GetString(19) + "";
                    String profissao = leitor.GetString(20) + "";
                    String categoria = leitor.GetString(21) + "";
                    String seguro = leitor.GetString(22) + "";
                    String localTrabalho = leitor.GetString(23) + "";
                    String regime = leitor.GetString(24) + "";
                    String bi = leitor.GetString(25) + "";
                    String numeroBenificiario = leitor.GetString(26) + "";
                    String numeroFiscal = leitor.GetString(27) + "";
                    double vencimento = leitor.GetDouble(28);
                    double subAlimentacao = leitor.GetDouble(29);
                    double subTransporte = leitor.GetDouble(30);
                    float horas = leitor.GetFloat(31);
                    int dependentes = leitor.GetInt16(32);
                    String habilitacoes = leitor.GetString(33);
                    String nacionalidade = leitor.GetString(34);
                    String ultimoEmprego = leitor.GetString(35);
                    String turno = leitor.GetString(36);
                    float impostoMunicipal = leitor.GetFloat(37);
                    String centroDeCusto = leitor.GetString(38);
                    String segurancaSocial = leitor.GetString(39);
                    String sindicato = leitor.GetString(40);
                    double subComunicacao = leitor.GetDouble(41);
                    listaFuncionarios.Add(new ModeloFuncionario(codigo, idIRPS, nome, cell, cellSec, tel, email, estadoCivil, def, conjugue, sexo, dataNascimento, linkImagem, codPostal, bairro, localidade, moradaGen, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto, segurancaSocial, sindicato, subComunicacao));
                }
            }
            catch (Exception)
            {
                
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaFuncionarios;
        }
         
        public static ArrayList recuperarComString(String procura)
        {
            MySqlConnection conexao = Conexao.conectar();
            ArrayList listaFuncionarios = new ArrayList();
            try
            {
                conexao.Open();
                String sqlSelect = "SELECT * from funcionario WHERE nome like'%"+procura+"%'";
                MySqlCommand comando = new MySqlCommand(sqlSelect, conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    int codigo = leitor.GetInt16(0);
                    int idIRPS = leitor.GetInt16(1);
                    String nome = leitor.GetString(2) + "";
                    int codPostal = leitor.GetInt16(3);
                    String cell = leitor.GetString(4) + "";
                    String cellSec = leitor.GetString(5) + "";
                    String tel = leitor.GetString(6) + "";
                    String email = leitor.GetString(7) + "";
                    String estadoCivil = leitor.GetString(8) + "";
                    String def = leitor.GetString(9) + "";
                    String conjugue = leitor.GetString(10) + "";
                    String sexo = leitor.GetString(11) + "";
                    String dataNascimento = leitor.GetString(12) + "";
                    String linkImagem = leitor.GetString(13) + "";
                    String bairro = leitor.GetString(14) + "";
                    String localidade = leitor.GetString(15) + "";
                    String moradaGen = leitor.GetString(16) + "";
                    String tipoContrato = leitor.GetString(17) + "";
                    String dataAdmissao = leitor.GetString(18) + "";
                    String dataDemissao = leitor.GetString(19) + "";
                    String profissao = leitor.GetString(20) + "";
                    String categoria = leitor.GetString(21) + "";
                    String seguro = leitor.GetString(22) + "";
                    String localTrabalho = leitor.GetString(23) + "";
                    String regime = leitor.GetString(24) + "";
                    String bi = leitor.GetString(25) + "";
                    String numeroBenificiario = leitor.GetString(26) + "";
                    String numeroFiscal = leitor.GetString(27) + "";
                    double vencimento = leitor.GetDouble(28);
                    double subAlimentacao = leitor.GetDouble(29);
                    double subTransporte = leitor.GetDouble(30);
                    float horas = leitor.GetFloat(31);
                    int dependentes = leitor.GetInt16(32);
                    String habilitacoes = leitor.GetString(33);
                    String nacionalidade = leitor.GetString(34);
                    String ultimoEmprego = leitor.GetString(35);
                    String turno = leitor.GetString(36);
                    float impostoMunicipal = leitor.GetFloat(37);
                    String centroDeCusto = leitor.GetString(38);
                    String segurancaSocial = leitor.GetString(39);
                    String sindicato = leitor.GetString(40);
                    double subComunicacao = leitor.GetDouble(41);
                    listaFuncionarios.Add(new ModeloFuncionario(codigo, idIRPS, nome, cell, cellSec, tel, email, estadoCivil, def, conjugue, sexo, dataNascimento, linkImagem, codPostal, bairro, localidade, moradaGen, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto, segurancaSocial, sindicato, subComunicacao));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message, "Nao foi possival carregar lista de funcionarios!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return listaFuncionarios;
        }

        public static void atualizar
            (
                int codigo,
                int idIRPS,
                String nome, 
                String cell, 
                String cellSec, 
                String telefone, 
                String email, 
                String estadoCivil, 
                String deficiencia, 
                String conjugue, 
                String sexo, 
                String dataNascimento, 
                String linkImagem, 
                int codigoPostal, 
                String bairro, 
                String localidade, 
                String moradaGen,
                String tipoContrato,
                String dataAdmissao,
                String dataDemissao,
                String profissao,
                String categoria,
                String seguro,
                String localTrabalho,
                String regime,
                String bi,
                String numeroBenificiario,
                String numeroFiscal,
                double vencimento,
                double subAlimentacao,
                double subTransporte,
                float horas,
                int dependentes,
                String habilitacoes,
                String nacionalidade,
                String ultimoEmprego,
                String turno,
                float impostoMunicipal,
                String centroDeCusto,
                String segurancaSocial,
                String sindicato,
                double subComunicacao
            )
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlUpdate = "UPDATE funcionario " +
                                    "SET idIRPS=?, nome=?, " +
                                    "cell=?, " +
                                    "cellSec=?, " +
                                    "telefone=?, " +
                                    "email=?, " +
                                    "estadoCivil=?, " +
                                    "deficiencia=?, " +
                                    "conjugue=?, " +
                                    "sexo=?, " +
                                    "dataNascimento=?, " +
                                    "linkImagem=?, " +
                                    "codigoPostal=?, " +
                                    "bairro=?, " +
                                    "localidade=?, " +
                                    "moradaGen=?, " +
                                    "tipoContrato=?, " +
                                    "dataAdmissao=?, " +
                                    "dataDemissao=?, " +
                                    "profissao=?, " +
                                    "categoria=?, " +
                                    "seguro=?, " +
                                    "localDeTrabalho=?, " +
                                    "regime=?, " +
                                    "bi=?, " +
                                    "numeroBenificiario=?, " +
                                    "numeroFiscal=?, " +
                                    "vencimento=?, " +
                                    "subAlimentacao=?, " +
                                    "subTransporte=?, " +
                                    "horas=?, " +
                                    "dependentes=?, " +
                                    "habilitacoes=?, nacionalidade=?, ultimoEmprego=?, turno=?, impostoMunicipal=?, centroDeCusto=?, segurancaSocial=?, sindicato=?, subComunicacao=? WHERE id=?; ";
                MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);
                comando.Parameters.AddWithValue("idIRPS", idIRPS);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("cell", cell);
                comando.Parameters.AddWithValue("cellSec", cellSec);
                comando.Parameters.AddWithValue("telefone", telefone);
                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("estadoCivil", estadoCivil);
                comando.Parameters.AddWithValue("deficiencia", deficiencia);
                comando.Parameters.AddWithValue("conjugue", conjugue);
                comando.Parameters.AddWithValue("sexo", sexo);
                comando.Parameters.AddWithValue("dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("linkImagem", linkImagem);
                comando.Parameters.AddWithValue("codigoPostal", codigoPostal);
                comando.Parameters.AddWithValue("bairro", bairro);
                comando.Parameters.AddWithValue("localidade", localidade);
                comando.Parameters.AddWithValue("moradaGen", moradaGen);
                comando.Parameters.AddWithValue("tipoContrato", tipoContrato);
                comando.Parameters.AddWithValue("dataAdmissao", dataAdmissao);
                comando.Parameters.AddWithValue("dataDemissao", dataDemissao);
                comando.Parameters.AddWithValue("profissao", profissao);
                comando.Parameters.AddWithValue("categoria", categoria);
                comando.Parameters.AddWithValue("seguro", seguro);
                comando.Parameters.AddWithValue("localDeTrabalho", localTrabalho);
                comando.Parameters.AddWithValue("regime", regime);
                comando.Parameters.AddWithValue("bi", bi);
                comando.Parameters.AddWithValue("numeroBenificiario", numeroBenificiario);
                comando.Parameters.AddWithValue("numeroFiscal", numeroFiscal);
                comando.Parameters.AddWithValue("vencimento", vencimento);
                comando.Parameters.AddWithValue("subAlimentacao", subAlimentacao);
                comando.Parameters.AddWithValue("subTransporte", subTransporte);
                comando.Parameters.AddWithValue("horas", horas);
                comando.Parameters.AddWithValue("dependentes", dependentes);
                comando.Parameters.AddWithValue("habilitacoes", habilitacoes);
                comando.Parameters.AddWithValue("nacionalidade", nacionalidade);
                comando.Parameters.AddWithValue("ultimoEmprego", ultimoEmprego);
                comando.Parameters.AddWithValue("turno",turno);
                comando.Parameters.AddWithValue("impostoMunicipal", impostoMunicipal);
                comando.Parameters.AddWithValue("centroDeCusto", centroDeCusto);
                comando.Parameters.AddWithValue("segurancaSocial", segurancaSocial);
                comando.Parameters.AddWithValue("sindicato", sindicato);
                comando.Parameters.AddWithValue("subComunicacao", subComunicacao);
                comando.Parameters.AddWithValue("id", codigo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Funcionário atualizado com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o  Funcionário! Contacte o técnico!!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void atualizarVenc
           (
               int codigo,
               double vencimento,
               double subAlimentacao,
               double ipa
           )
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlUpdate = "UPDATE funcionario SET vencimento=?, subAlimentacao=?, impostoMunicipal=? WHERE id=?; ";
                MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);
                comando.Parameters.AddWithValue("vencimento", vencimento);
                comando.Parameters.AddWithValue("subAlimentacao", subAlimentacao);
                comando.Parameters.AddWithValue("impostoMunicipal", ipa);
                comando.Parameters.AddWithValue("id", codigo);
                comando.ExecuteNonQuery();
                //MessageBox.Show("Vencimento de funcionário atualizado com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível atualizar o vencimento do funcionário! Contacte o técnico!!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        public static void remover(int codigo)
        {
            MySqlConnection conexao = Conexao.conectar();
            try
            {
                conexao.Open();
                String SqlDelete = "DELETE from funcionario WHERE id=?";
                MySqlCommand comando = new MySqlCommand(SqlDelete, conexao);
                comando.Parameters.Add(new MySqlParameter("id", codigo));
                comando.ExecuteNonQuery();
                MessageBox.Show("Funcionário removido!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Não foi possível remover o  Funcionário! Contacte o técnico!!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
