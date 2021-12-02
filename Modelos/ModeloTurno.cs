using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloTurno
    {
        private int id;
        private String nome;
        private Boolean manha, tarde, noite, normal;
        public ModeloTurno(int id, String nome, Boolean manha, Boolean tarde, Boolean noite, Boolean normal) 
        {
            this.id = id;
            this.nome = nome;
            this.manha = manha;
            this.tarde = tarde;
            this.noite = noite;
            this.normal = normal;
        }

        public int getId() { return id; }
        public String getNome() { return nome; }
        public Boolean getManha() { return manha; }
        public Boolean getTarde() { return tarde; }
        public Boolean getNoite() { return noite; }
        public Boolean getNormal() { return normal; }
    }
}
