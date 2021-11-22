using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloRelogioDePonto
    {
        private int sn, nrDispositivo, idUsuario;
        private String estado, accao;
        private String data;

        public ModeloRelogioDePonto(int sn, int idUsuario, String estado, int nrDispositivo, String accao, String data) 
        {
            this.sn = sn;
            this.idUsuario = idUsuario;
            this.estado = estado;
            this.nrDispositivo = nrDispositivo;
            this.accao = accao;
            this.data = data;
        }

        public int getSn() { return sn; }

        public int getIdUsuario() { return idUsuario; }

        public int getNrDispositivo() { return nrDispositivo; }

        public String getEstado() { return estado; }

        public String getAccao() { return accao; }

        public String getData() { return data; }
    }
}
