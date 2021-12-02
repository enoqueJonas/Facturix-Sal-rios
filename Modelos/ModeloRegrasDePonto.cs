using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloRegrasDePonto
    {
        private int id;
        private decimal diaDeTrabalho, intervaloEntreBatidas, atraso, ausencia, saidaAdiantada, horasExtra, tempoAlmoco;
        private String entradaNaoRegistada, saidaNaoRegistada;

        public ModeloRegrasDePonto(int id, decimal diaDeTrabalho, decimal intervaloEntreBatidas, decimal atraso, decimal ausencia, decimal saidaAdiantada, String entradaNaoRegistada, String saidaNaoRegistada, decimal horasExtra, decimal tempoAlmoco) 
        {
            this.id = id;
            this.diaDeTrabalho = diaDeTrabalho;
            this.intervaloEntreBatidas = intervaloEntreBatidas;
            this.atraso = atraso;
            this.ausencia = ausencia;
            this.saidaAdiantada = saidaAdiantada;
            this.entradaNaoRegistada = entradaNaoRegistada;
            this.saidaNaoRegistada = saidaNaoRegistada;
            this.horasExtra = horasExtra;
            this.tempoAlmoco = tempoAlmoco;
        }

        public int getId() { return id; }
        public decimal getDiaDeTrabalho() { return diaDeTrabalho; }
        public decimal getIntervaloEntreBatidas() { return intervaloEntreBatidas; }
        public decimal getAtraso() { return atraso; }
        public decimal getAusencia() { return ausencia; }
        public decimal getSaidaAdiantada() { return saidaAdiantada; }
        public decimal getHorasExtra() { return horasExtra; }
        public decimal getTempoAlmoco() { return tempoAlmoco; }
        public String getEntradaNaoRegistada() { return entradaNaoRegistada; }
        public String getSaidaNaoRegistada() { return saidaNaoRegistada; }
    }
}
