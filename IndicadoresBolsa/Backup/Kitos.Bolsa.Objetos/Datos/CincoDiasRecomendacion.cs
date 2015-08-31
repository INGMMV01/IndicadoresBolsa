using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class CincoDiasRecomendacion : DatoWeb
    {
        const string palabraClave = "de consenso:";
        //const string strAntes = "class=\"accion\">";
        //const string strDespues = "</span>";
        const string strAntes = "</strong>";
        const string strDespues = " - <span class=";        

        public CincoDiasRecomendacion(string entrada)
            : base(entrada,palabraClave,strAntes, strDespues)
        {
        }

        public override double calcularDouble()
        {
            return obtenerDatoDouble();            
        }

        public override string calcularString()
        {
            //return obtenerDatoString(); ;
            throw new NotImplementedException();
        }

    }
}
