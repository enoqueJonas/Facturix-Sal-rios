using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloConta
    {
        public int id { get; set; }
        public int idFuncionario{ get; set; }
        public string banco { get; set; }
        public string nib { get; set; }
        public string conta { get; set; }

        public ModeloConta(int id, int idFuncionario, String banco, String nib, String conta) 
        {
            this.id = id;
            this.idFuncionario = idFuncionario;
            this.banco = banco;
            this.nib = nib;
            this.conta = conta;
        }
    }
}
