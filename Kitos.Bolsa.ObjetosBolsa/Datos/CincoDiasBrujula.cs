using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class CincoDiasBrujula : DatoWeb
    {   
        /*
        const string palabraClave = "barra estirar";
        const string strAntes = "tivo\">";
        const string strDespues = "</p>";
        */
        const string palabraClave = "Tendencia de las recomendaciones";
        const string strAntes = "%\">";
        const string strDespues = "*</span>";


        public CincoDiasBrujula(String Entrada) : base(Entrada, palabraClave, strAntes, strDespues) { }

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
