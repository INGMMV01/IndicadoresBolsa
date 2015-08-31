using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

using Kitos.Bolsa.Objetos;
using Kitos.Bolsa.Informes;
using Kitos.Bolsa.Objetos.Datos;
using Kitos.Bolsa.Objetos.Util;

namespace IndicadoresBolsaWS
{
    /// <summary>
    /// Descripción breve de IndicadoresBolsaFacade
    /// </summary>
    public class IndicadoresBolsaFacade : System.Web.Services.WebService
    {

        [WebMethod]
        public string ObtenerDato(string dato, string valor)
        {
            int caducidad = 30;

            string fuente = CacheFichero.GetText(Informe.datoRecurso(valor + "_AHORRO"), caducidad);
            AhorroUltimo ultimo = new AhorroUltimo(fuente, valor);

            return ultimo.calcularString();

        }

        
    }
}
