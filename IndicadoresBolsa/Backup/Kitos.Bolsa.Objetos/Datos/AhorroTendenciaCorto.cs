using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class AhorroTendenciaCorto: DatoWeb
    {
        const string palabraClave = "";
        const string strAntes = "Tendencia corto plazo&nbsp;&nbsp;<span class=\"";
        const string strDespues = "\"></span>";

        public AhorroTendenciaCorto(string entrada)
            : base(entrada,palabraClave,strAntes, strDespues)
        {
        }
        
        public override double calcularDouble()
        {
            if (this.calcularString() == "icoSube")
                return 1;
            else
                return 0;
        }

        public override string calcularString()
        {
            return obtenerDatoString();;
        }

    }
}