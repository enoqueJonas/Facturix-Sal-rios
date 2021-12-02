using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloHorarios
    {
        private int id;
        private decimal tempoServico, emTempoH, emTempoM, foraDoTempoH, foraDotempoM;
        private Boolean marcarPonto, baterPonto, saidaAdiantada, ausencia, atraso;

        public ModeloHorarios(int id, decimal tempoServico, decimal emTempoH, decimal emTempoM, decimal foraDoTempoH, decimal foraDotempoM, Boolean marcarPonto, Boolean baterPonto, Boolean saidaAdiantada, Boolean atraso, Boolean ausencia) 
        {
            this.id = id;
            this.tempoServico = tempoServico;
            this.emTempoH = emTempoH;
            this.emTempoM = emTempoM;
            this.foraDoTempoH = foraDoTempoH;
            this.foraDotempoM = foraDotempoM;
            this.marcarPonto = marcarPonto;
            this.baterPonto = baterPonto;
            this.saidaAdiantada = saidaAdiantada;
            this.ausencia = ausencia;
            this.atraso = atraso;
        }

        public int getId() { return id; }
        public decimal getTempoServico() { return tempoServico; }
        public decimal getEmTempoH() { return emTempoH; }
        public decimal getEmTempoM() { return emTempoM; }
        public decimal getForaDoTempo() { return foraDoTempoH; }
        public decimal getForaDoTempoM() { return foraDotempoM; }
        public Boolean getMarcarPonto() { return marcarPonto; }
        public Boolean getBaterPonto() { return baterPonto; }
        public Boolean getSaidaAdiantada() { return saidaAdiantada; }
        public Boolean getAusencia() { return ausencia; }
        public Boolean getSaidaH() { return atraso; }
    }
}
