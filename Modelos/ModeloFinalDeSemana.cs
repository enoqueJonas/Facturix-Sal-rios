using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários.Modelos
{
    class ModeloFinalDeSemana
    {
        private int id;
        private Boolean segundaManha, segundaTarde, tercaManha, tercaTarde, quartaManha, quartaTarde, quintaManha, quintaTarde, sextaManha, sextaTarde, sabadoManha, sabadoTarde, domingoManha, domingoTarde;
        private String fds;

        public ModeloFinalDeSemana(int id,String fds, Boolean segundaManha, Boolean segundaTarde, Boolean tercaManha, Boolean tercaTarde, Boolean quartaManha, Boolean quartaTarde, Boolean quintaManha, Boolean quintaTarde, Boolean sextaManha, Boolean sextaTarde, Boolean sabadoManha, Boolean sabadoTarde, Boolean domingoManha, Boolean domingoTarde) 
        {
            this.id = id;
            this.fds = fds;
            this.segundaManha = segundaManha;
            this.segundaTarde = segundaTarde;
            this.tercaManha = tercaManha;
            this.tercaTarde = tercaTarde;
            this.quartaManha = quartaManha;
            this.quartaTarde = quartaTarde;
            this.quintaManha = quintaManha;
            this.quintaTarde = quintaTarde;
            this.sextaManha = sextaManha;
            this.sextaTarde = sextaTarde;
            this.sabadoManha = sabadoManha;
            this.sabadoTarde = sabadoTarde;
            this.domingoManha = domingoManha;
            this.domingoTarde = domingoTarde;
        }

        public int getId() { return id; }
        public String getFds() { return fds; }
        public Boolean getSegundaM() { return segundaManha; }
        public Boolean getSegundaT() { return segundaTarde; }
        public Boolean getTercaM() { return tercaManha; }
        public Boolean getTercaT() { return tercaTarde; }
        public Boolean getQuartaM() { return quartaManha; }
        public Boolean getQuartaT() { return quartaTarde; }
        public Boolean getQuintaM() { return quintaManha; }
        public Boolean getQuintaT() { return quintaTarde; }
        public Boolean getSextaM() { return sextaManha; }
        public Boolean getSextaT() { return sextaTarde; }
        public Boolean getSabadoM() { return sabadoManha; }
        public Boolean getSabadoT() { return sabadoTarde; }
        public Boolean getDomingoM() { return domingoManha; }
        public Boolean getDomingoT() { return domingoTarde; }
    }
}
