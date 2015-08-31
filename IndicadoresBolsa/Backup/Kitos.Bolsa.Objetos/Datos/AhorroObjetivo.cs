using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class AhorroObjetivo : DatoWeb
    {
        const string palabraClave = "Precio objetivo";
        const string strAntes = "contextm\">";
        const string strDespues = "</span>";

        public AhorroObjetivo(string entrada)
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
