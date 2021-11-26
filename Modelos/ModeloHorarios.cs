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
        private decimal umDiaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, horasExtra, almoco, entradaH, entradaM, saidaH, saidaM;

        public ModeloHorarios(int id, decimal umDiaTrabalho, decimal intervaloMinimo, decimal atraso, decimal falta, decimal saidaAdiantada, decimal horasExtra, decimal almoco, decimal entradaH, decimal entradaM, decimal saidaH, decimal saidaM) 
        {
            this.id = id;
            this.umDiaTrabalho = umDiaTrabalho;
            this.intervaloMinimo = intervaloMinimo;
            this.atraso = atraso;
            this.falta = falta;
            this.saidaAdiantada = saidaAdiantada;
            this.horasExtra = horasExtra;
            this.almoco = almoco;
            this.entradaH = entradaH;
            this.entradaM = entradaM;
            this.saidaH = saidaH;
            this.saidaM = saidaM;
        }

        public int getId() { return id; }
        public decimal getUmdiaTrabalho() { return umDiaTrabalho; }
        public decimal getIntervaloMinimo() { return intervaloMinimo; }
        public decimal getAtraso() { return atraso; }
        public decimal getFalta() { return falta; }
        public decimal getSaidaAdiantada() { return saidaAdiantada; }
        public decimal getHorasExtra() { return horasExtra; }
        public decimal getAlmoco() { return almoco; }
        public decimal getEntradaH() { return entradaH; }
        public decimal getEntradaM() { return entradaM; }
        public decimal getSaidaH() { return saidaH; }
        public decimal getSaidaM() { return saidaM; }
    }
}
