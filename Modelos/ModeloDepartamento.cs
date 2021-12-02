using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloDepartamento
    {
        private int id;
        private String nome;

        public ModeloDepartamento(int id, String nome) 
        {
            this.id = id;
            this.nome = nome;
        }

        public int getId() { return id; }
        public String getNome() { return nome; }
    }
}
