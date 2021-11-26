using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloFeriado
    {
        private int id;
        private String nome, dataInicio, dataFim;

        public ModeloFeriado(int id, String nome, String dataInicio, String dataFim) 
        {
            this.id = id;
            this.nome = nome;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
        }

        public int getId() { return id; }
        public String getNome() { return nome; }
        public String getDataInicio() { return dataInicio; }
        public String getDataFim() { return dataFim; }
    }
}
