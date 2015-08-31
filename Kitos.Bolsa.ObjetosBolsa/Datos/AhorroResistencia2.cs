using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class AhorroResistencia2: DatoWeb
    {
        const string palabraClave = "Resistencias</td>";
        const string strAntes = "class=\"contextm \">";//"id=\"ext-gen9\">";
        const string strDespues = "</td>";

        public AhorroResistencia2(string entrada)
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