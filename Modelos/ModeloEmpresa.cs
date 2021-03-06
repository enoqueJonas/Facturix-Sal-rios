using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloEmpresa
    {
        private int id;
        private String nome, nomeAbreviado, imagem, nuit;
        private Boolean logo;

        public ModeloEmpresa(int id, String nome, String nomeAbreviado, Boolean logo, String imagem, String nuit) 
        {
            this.id = id;
            this.nome = nome;
            this.nomeAbreviado = nomeAbreviado;
            this.logo = logo;
            this.imagem = imagem;
            this.nuit = nuit;
        }
        
        public int getId() { return id; }
        public String getNome() { return nome; }
        public String getNomeAbreviado() { return nomeAbreviado; }
        public String getImagem() { return imagem; }
        public Boolean getLogo() { return logo; }
        public String getNuit() { return nuit; }
    }
}
