using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloUtilizador
    {
        private int id;
        private String apelido, password, email, nome, contacto, nivel, nomeUtilizador, dataNascimento;

        public ModeloUtilizador(int id, String nome, String apelido, String password, String email, String contacto, String nivel, String nomeUtilizador, String dataNascimento)
        {
            this.id = id;
            this.nome = nome;
            this.apelido = apelido;
            this.password = password;
            this.email = email;
            this.contacto = contacto;
            this.nivel = nivel;
            this.nomeUtilizador = nomeUtilizador;
            this.dataNascimento = dataNascimento;
        }

        public int getId() { return id; }
        public String getNome() { return nome; }

        public String getApelido() { return apelido; }

        public String getPassword() { return password; }

        public String getEmail() { return email; }

        public String getContacto() { return contacto; }

        public String getNivel() { return nivel; }

        public String getNomeUtilizador() { return nomeUtilizador; }

        public String getDataNascimento() { return dataNascimento; }
    }
}
