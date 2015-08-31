using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class AhorroUltimo : DatoWeb 
    {
        const string palabraClave = "nameval\">";
        const string strAntes = "<span id=\"value\">";
        const string strDespues = "</span>";

        public AhorroUltimo(String Entrada, String valor) : base(Entrada, palabraClave+ valor, strAntes, strDespues) { }

        public override double calcularDouble()
        {
            return obtenerDatoDouble();
        }

        public override string calcularString()
        {
            return this.obtenerDatoDouble().ToString();
        }

    }
}
