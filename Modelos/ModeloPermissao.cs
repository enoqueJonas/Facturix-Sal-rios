using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloPermissao
    {
        private int id, idUsuario;
        private String tabela, cabecalho;
        private Boolean activo;
        public ModeloPermissao(int id, int idUsuario, String tabela, Boolean activo, String cabecalho)
        {
            this.id = id;
            this.tabela = tabela;
            this.idUsuario = idUsuario;
            this.activo = activo;
            this.cabecalho = cabecalho;
        }

        public int getId()
        {
            return id;
        }

        public int getIdUsuario()
        {
            return idUsuario;
        }

        public String getTabela()
        {
            return tabela;
        }
        
        public Boolean getActivo()
        {
            return activo;
        }
        
        public String getCabecalho()
        {
            return cabecalho;
        }
    }
}
