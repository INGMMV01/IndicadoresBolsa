using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class AhorroSoporte1: DatoWeb
    {
        const string palabraClave = "Soportes</td>";
        const string strAntes = "class=\"contextm \">";//"id=\"ext-gen6\">";
        const string strDespues = "</td>";

        public AhorroSoporte1(string entrada)
            : base(entrada,palabraClave,strAntes, strDespues)
        {
        }      

        public override string calcularString()
        {
            string cadena = obtenerDatoString();

            return cadena;
        }

    }
}