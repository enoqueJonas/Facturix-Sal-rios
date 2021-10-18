using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturix_Salários
{
    class ModeloMorada
    {
        private int codigoPostal, codigo;
        private String bairro, localidade, moradaGen;

        public ModeloMorada(int codigo, int codigoPostal, String bairro, String localidade, String moradaGen)
        {
            this.codigo = codigo;
            this.codigoPostal = codigoPostal;
            this.bairro = bairro;
            this.localidade = localidade;
            this.moradaGen = moradaGen;
        }

        public int getCodigo() { return codigo; }
        public int getCodigoPostal() { return codigoPostal; }

        public String getBairro() { return bairro; }

        public String getLocalidade() { return localidade; }

        public String getMoradaGen() { return moradaGen; }
    }
}
