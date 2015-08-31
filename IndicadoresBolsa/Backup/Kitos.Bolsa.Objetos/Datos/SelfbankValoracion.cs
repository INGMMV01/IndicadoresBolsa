using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class SelfbankValoracion : DatoWeb
    {
        const string palabraClave = "<div class=\"body news\" style=\"height:110px\">";
        const string strAntes = "<p class=\"txt04\">";
        const string strDespues = "</p>";

        public SelfbankValoracion(String Entrada) : base(Entrada, palabraClave, strAntes, strDespues) { }

        public override double calcularDouble()
        {
            return obtenerDatoDouble();
        }

        public override string calcularString()
        {
            throw new NotImplementedException();
        }

    }
}
