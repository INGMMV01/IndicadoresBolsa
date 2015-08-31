using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class AhorroMinAnho: DatoWeb
    {    
        const string palabraClave = "";
        const string strAntes = "rango año:&nbsp;&nbsp;</td><td class=\"txt11v4b\" style=\"text-align:right\">";
        const string strDespues = "</td><td class=\"txt11V1\"";

        public AhorroMinAnho(string entrada)
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