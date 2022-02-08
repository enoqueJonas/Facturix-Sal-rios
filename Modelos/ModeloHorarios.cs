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
        private String tempoServico;
        private decimal emTempoH, emTempoM, foraDoTempoH, foraDotempoM;
        private Boolean marcarPonto, baterPonto, saidaAdiantada, ausencia, atraso;
        private Boolean ativo;
        public ModeloHorarios(int id, String tempoServico, decimal emTempoH, decimal emTempoM, decimal foraDoTempoH, decimal foraDotempoM, Boolean marcarPonto, Boolean baterPonto, Boolean saidaAdiantada, Boolean atraso, Boolean ausencia, Boolean ativo) 
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
            this.ativo = ativo;
        }

        public int getId() { return id; }
        public String getTempoServico() { return tempoServico; }
        public decimal getEmTempoH() { return emTempoH; }
        public decimal getEmTempoM() { return emTempoM; }
        public decimal getForaDoTempo() { return foraDoTempoH; }
        public decimal getForaDoTempoM() { return foraDotempoM; }
        public Boolean getMarcarPonto() { return marcarPonto; }
        public Boolean getBaterPonto() { return baterPonto; }
        public Boolean getSaidaAdiantada() { return saidaAdiantada; }
        public Boolean getAusencia() { return ausencia; }
        public Boolean getAtraso() { return atraso; }
        public Boolean getAtivo() { return ativo; }
    }
}
