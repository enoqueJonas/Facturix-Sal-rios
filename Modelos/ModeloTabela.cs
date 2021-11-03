using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloTabela
    {
        private int id;
        private String nome, label;

        public ModeloTabela(int id, String nome, String label)
        {
            this.id = id;
            this.nome = nome;
            this.label = label;
        }

        public int getId()
        {
            return id;
        }

        public String getLabel()
        {
            return label;
        }
        
        public String getCNome()
        {
            return nome;
        }
    }
}
