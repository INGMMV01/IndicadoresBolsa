using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class SelfBankObjetivo : DatoWeb
    {
        const string palabraClave = "id=\"consensus_analysts_objective_0";
        const string strAntes = "<p class=\"txt04 gras\">";
        const string strDespues = " EUR";

        public SelfBankObjetivo(string entrada)
            : base(entrada,palabraClave,strAntes, strDespues)
        {
        }

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
