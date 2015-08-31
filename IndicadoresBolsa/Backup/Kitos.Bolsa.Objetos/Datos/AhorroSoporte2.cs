using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class AhorroSoporte2: DatoWeb
    {
        const string palabraClave = "Soportes</td>";
        const string strAntes = "class=\"contextm \">";//"id=\"ext-gen7\">";
        const string strDespues = "</td>";

        public AhorroSoporte2(string entrada)
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