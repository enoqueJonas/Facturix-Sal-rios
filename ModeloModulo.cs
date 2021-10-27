using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloModulo
    {
        private int id;
        private Boolean activo;
        private String nome;

        public ModeloModulo(int id, Boolean activo, String nome)
        {
            this.id = id;
            this.activo = activo;
            this.nome = nome;
        }

        public int getId()
        {
            return id;
        }
        
        public Boolean getActivo()
        {
            return activo;
        }

        public String getNome()
        {
            return nome;
        }
    }
}
