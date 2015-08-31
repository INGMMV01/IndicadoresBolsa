using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class CincoDiasObjetivo : DatoWeb
    {
        /*
        const string palabraClave = "precio objetivo:";
        const string strAntes = "</strong>";
        const string strDespues = "\r\n</li>";
        */
        const string palabraClave = "Precio objetivo</th>";
        const string strAntes = "<td>";
        const string strDespues = "</td>";

        public CincoDiasObjetivo(string entrada)
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
