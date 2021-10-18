using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Facturix_Salários;

namespace Facturix_Salários
{
    class ControllerFuncionario
    {
        public static void Guardar
            (
                int codigo, 
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
                String segurancaSocial
            )
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlInsert = "INSERT into funcionario ( id, nome, cell, cellSec, telefone, email, estadoCivil, deficiencia, conjugue, sexo, dataNascimento, linkImagem, codigoPostal, bairro, localidade, moradaGen, tipoContrato,dataAdmissao, dataDemissao, profissao, categoria, seguro, localDeTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao , subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto, segurancaSocial) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
                comando.Parameters.AddWithValue("id", codigo);
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
                comando.ExecuteNonQuery();
                MessageBox.Show("Funcionario cadastrado com sucesso!");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel fazer o cadastro do funcionario!");
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
                    String nome = leitor.GetString(1) + "";
                    int codPostal = leitor.GetInt16(2);
                    String cell = leitor.GetString(3) + "";
                    String cellSec = leitor.GetString(4) + "";
                    String tel = leitor.GetString(5) + "";
                    String email = leitor.GetString(6) + "";
                    String estadoCivil = leitor.GetString(7) + "";
                    String def = leitor.GetString(8) + "";
                    String conjugue = leitor.GetString(9) + "";
                    String sexo = leitor.GetString(10) + "";
                    String dataNascimento = leitor.GetString(11) + "";
                    String linkImagem = leitor.GetString(12) + "";
                    String bairro = leitor.GetString(13) + "";
                    String localidade = leitor.GetString(14) + "";
                    String moradaGen = leitor.GetString(15) + "";
                    String tipoContrato = leitor.GetString(16) + "";
                    String dataAdmissao = leitor.GetString(17) + "";
                    String dataDemissao = leitor.GetString(18) + "";
                    String profissao = leitor.GetString(19) + "";
                    String categoria = leitor.GetString(20) + "";
                    String seguro = leitor.GetString(21) + "";
                    String localTrabalho = leitor.GetString(22) + "";
                    String regime = leitor.GetString(23) + "";
                    String bi = leitor.GetString(24) + "";
                    String numeroBenificiario = leitor.GetString(25) + "";
                    String numeroFiscal = leitor.GetString(26)+"";
                    double vencimento = leitor.GetDouble(27);
                    double subAlimentacao = leitor.GetDouble(28);
                    double subTransporte = leitor.GetDouble(29);
                    float horas = leitor.GetFloat(30);
                    int dependentes = leitor.GetInt16(31);
                    String habilitacoes = leitor.GetString(32);
                    String nacionalidade = leitor.GetString(33);
                    String ultimoEmprego = leitor.GetString(34);
                    String turno = leitor.GetString(35);
                    float impostoMunicipal = leitor.GetFloat(36);
                    String centroDeCusto = leitor.GetString(37);
                    String segurancaSocial = leitor.GetString(38);
                    listaFuncionarios.Add(new ModeloFuncionario(codigo, nome, cell, cellSec, tel, email, estadoCivil, def, conjugue, sexo, dataNascimento, linkImagem, codPostal, bairro, localidade, moradaGen, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto,segurancaSocial));
                }
            } catch (Exception err)
            {
                MessageBox.Show("Nao foi possival carregar lista de funcionarios! Contacte o tecnico!");
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
                    String nome = leitor.GetString(1) + "";
                    int codPostal = leitor.GetInt16(2);
                    String cell = leitor.GetString(3) + "";
                    String cellSec = leitor.GetString(4) + "";
                    String tel = leitor.GetString(5) + "";
                    String email = leitor.GetString(6) + "";
                    String estadoCivil = leitor.GetString(7) + "";
                    String def = leitor.GetString(8) + "";
                    String conjugue = leitor.GetString(9) + "";
                    String sexo = leitor.GetString(10) + "";
                    String dataNascimento = leitor.GetString(11) + "";
                    String linkImagem = leitor.GetString(12) + "";
                    String bairro = leitor.GetString(13) + "";
                    String localidade = leitor.GetString(14) + "";
                    String moradaGen = leitor.GetString(15) + "";
                    String tipoContrato = leitor.GetString(16) + "";
                    String dataAdmissao = leitor.GetString(17) + "";
                    String dataDemissao = leitor.GetString(18) + "";
                    String profissao = leitor.GetString(19) + "";
                    String categoria = leitor.GetString(20) + "";
                    String seguro = leitor.GetString(21) + "";
                    String localTrabalho = leitor.GetString(22) + "";
                    String regime = leitor.GetString(23) + "";
                    String bi = leitor.GetString(24) + "";
                    String numeroBenificiario = leitor.GetString(25) + "";
                    String numeroFiscal = leitor.GetString(26) + "";
                    double vencimento = leitor.GetDouble(27);
                    double subAlimentacao = leitor.GetDouble(28);
                    double subTransporte = leitor.GetDouble(29);
                    float horas = leitor.GetFloat(30);
                    int dependentes = leitor.GetInt16(31);
                    String habilitacoes = leitor.GetString(32);
                    String nacionalidade = leitor.GetString(33);
                    String ultimoEmprego = leitor.GetString(34);
                    String turno = leitor.GetString(35);
                    float impostoMunicipal = leitor.GetFloat(36);
                    String centroDeCusto = leitor.GetString(37);
                    String segurancaSocial = leitor.GetString(38);
                    listaFuncionarios.Add(new ModeloFuncionario(codigo,nome,cell,cellSec,tel,email,estadoCivil,def,conjugue,sexo,dataNascimento,linkImagem,codPostal,bairro,localidade,moradaGen,tipoContrato,dataAdmissao,dataDemissao,profissao,categoria,seguro,localTrabalho,regime,bi,numeroBenificiario,numeroFiscal,vencimento,subAlimentacao,subTransporte,horas,dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto, segurancaSocial));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Nao foi possival carregar lista de funcionarios!");
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
                    String nome = leitor.GetString(1) + "";
                    int codPostal = leitor.GetInt16(2);
                    String cell = leitor.GetString(3) + "";
                    String cellSec = leitor.GetString(4) + "";
                    String tel = leitor.GetString(5) + "";
                    String email = leitor.GetString(6) + "";
                    String estadoCivil = leitor.GetString(7) + "";
                    String def = leitor.GetString(8) + "";
                    String conjugue = leitor.GetString(9) + "";
                    String sexo = leitor.GetString(10) + "";
                    String dataNascimento = leitor.GetString(11) + "";
                    String linkImagem = leitor.GetString(12) + "";
                    String bairro = leitor.GetString(13) + "";
                    String localidade = leitor.GetString(14) + "";
                    String moradaGen = leitor.GetString(15) + "";
                    String tipoContrato = leitor.GetString(16) + "";
                    String dataAdmissao = leitor.GetString(17) + "";
                    String dataDemissao = leitor.GetString(18) + "";
                    String profissao = leitor.GetString(19) + "";
                    String categoria = leitor.GetString(20) + "";
                    String seguro = leitor.GetString(21) + "";
                    String localTrabalho = leitor.GetString(22) + "";
                    String regime = leitor.GetString(23) + "";
                    String bi = leitor.GetString(24) + "";
                    String numeroBenificiario = leitor.GetString(25) + "";
                    String numeroFiscal = leitor.GetString(26) + "";
                    double vencimento = leitor.GetDouble(27);
                    double subAlimentacao = leitor.GetDouble(28);
                    double subTransporte = leitor.GetDouble(29);
                    float horas = leitor.GetFloat(30);
                    int dependentes = leitor.GetInt16(31);
                    String habilitacoes = leitor.GetString(32);
                    String nacionalidade = leitor.GetString(33);
                    String ultimoEmprego = leitor.GetString(34);
                    String turno = leitor.GetString(35);
                    float impostoMunicipal = leitor.GetFloat(36);
                    String centroDeCusto = leitor.GetString(37);
                    String segurancaSocial = leitor.GetString(38);
                    listaFuncionarios.Add(new ModeloFuncionario(codigo, nome, cell, cellSec, tel, email, estadoCivil, def, conjugue, sexo, dataNascimento, linkImagem, codPostal, bairro, localidade, moradaGen, tipoContrato, dataAdmissao, dataDemissao, profissao, categoria, seguro, localTrabalho, regime, bi, numeroBenificiario, numeroFiscal, vencimento, subAlimentacao, subTransporte, horas, dependentes, habilitacoes, nacionalidade, ultimoEmprego, turno, impostoMunicipal, centroDeCusto, segurancaSocial));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possival carregar lista de funcionarios!");
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
                String segurancaSocial
            )
        {
            MySqlConnection conexao = Conexao.conectar();

            try
            {
                conexao.Open();
                String sqlUpdate = "UPDATE funcionario " +
                                    "SET nome=?, " +
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
                                    "habilitacoes=?, nacionalidade=?, ultimoEmprego=?, turno=?, impostoMunicipal=?, centroDeCusto=?, segurancaSocial=? WHERE id=?; ";
                MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);
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
                comando.Parameters.AddWithValue("id", codigo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Funcionario atualizado com sucesso!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel actualizar o funcionario!");
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
                MessageBox.Show("Funcionaro removido!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Nao foi possivel remover o funcionario!");
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }
    }
}
