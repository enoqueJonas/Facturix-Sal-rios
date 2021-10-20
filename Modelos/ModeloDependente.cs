using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloDependente
    {

        private int id, idFuncionario;
        private String nome, dataNascimento, grauParentesco;

        public ModeloDependente(int id, int idFuncionario, String nome, String dataNascimento, String grauParentesco)
        {
            this.id = id;
            this.idFuncionario = idFuncionario;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.grauParentesco = grauParentesco;
        }

        public int getId()
        {
            return id;
        }

        public int getIdFuncionario()
        {
            return idFuncionario;
        }

        public String getNome()
        {
            return nome;
        }

        public String getDataNascimento()
        {
            return dataNascimento;
        }

        public String getGrauParentesco()
        {
            return grauParentesco;
        }
    }
}
