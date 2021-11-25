using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloHorarios
    {
        private int id, umDiaTrabalho, intervaloMinimo, atraso, falta, saidaAdiantada, horasExtra, almoco, entradaH, entradaM, saidaH, saidaM;

        public ModeloHorarios(int id, int umDiaTrabalho, int intervaloMinimo, int atraso, int falta, int saidaAdiantada, int horasExtra, int almoco, int entradaH, int entradaM, int saidaH, int saidaM) 
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
        public int getUmdiaTrabalho() { return umDiaTrabalho; }
        public int getIntervaloMinimo() { return intervaloMinimo; }
        public int getAtraso() { return atraso; }
        public int getFalta() { return falta; }
        public int getSaidaAdiantada() { return saidaAdiantada; }
        public int getHorasExtra() { return horasExtra; }
        public int getAlmoco() { return almoco; }
        public int getEntradaH() { return entradaH; }
        public int getEntradaM() { return entradaM; }
        public int getSaidaH() { return saidaH; }
        public int getSaidaM() { return saidaM; }
    }
}
