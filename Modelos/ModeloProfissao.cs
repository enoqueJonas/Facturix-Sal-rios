using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloProfissao
    {
        private int id;
        private String profissao;

        public ModeloProfissao(int id, String profissao) 
        {
            this.id = id;
            this.profissao = profissao;
        }

        public int getId() 
        {
            return id;
        }

        public String getProfissao() 
        {
            return profissao;
        }
    }
}
