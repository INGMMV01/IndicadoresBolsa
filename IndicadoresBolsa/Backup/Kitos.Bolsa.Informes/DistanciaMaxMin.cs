using System;
using System.Collections.Generic;
using System.Text;

using Kitos.Bolsa.Objetos.Datos;
using Kitos.Bolsa.Objetos.Util;

namespace Kitos.Bolsa.Informes
{
    public class DistanciaMaxMin : Informe 
    {
        //kitos string[] valoresIBEX = { "ABG", "ABE", "ANA", "ACX", "ACS", "AMS", "MTS", "POP", "SAB", "BKT", "BBVA", "BME", "CRI", "DIA", "ENG", "ELE", "FCC", "FER", "GAS", "GRF", "IAG", "IBE", "ITX", "IDR", "MAP", "TL5", "OHL", "REE", "REP", "SYV", "SAN", "TRE", "TEF", "VIS" };

        public DistanciaMaxMin()
        {
            this.valores = valoresIBEX;
        }

        protected override string NombreFichero
        {
            get
            {
                return " DistanciaMaxMin.csv";
            }
        }

        protected override string Cabecera
        {
            get
            {
                return "Valor" + SEPARADOR + "Actual" + SEPARADOR + "Minimo Año"+ SEPARADOR + "%Min-Actual"+ SEPARADOR + "Max Año"+ SEPARADOR + "%Actual-Max";
            }
        }

        public override string datosFila(string valor)
        {
            //A
            StringBuilder sb = new StringBuilder(Informe.datoRecurso(valor) + SEPARADOR);
            int Caducidad = 1000;

            string fuente = CacheFichero.GetText(Informe.datoRecurso(valor + "_AHORRO"), Caducidad);

            AhorroMinAnho minAno;
            minAno = new AhorroMinAnho(fuente);
            string strMinAnho = minAno.calcularString();

/*
            AhorroTendenciaCorto tendCorto;
            tendCorto = new AhorroTendenciaCorto(fuente);
            double dblTendCorto = tendCorto.calcularDouble();
            sb.Append(dblTendCorto + SEPARADOR);

            AhorroTendenciaLargo tendLargo;
            tendLargo = new AhorroTendenciaLargo(fuente);
            double dblTendLargo = tendLargo.calcularDouble();
            sb.Append(dblTendLargo + SEPARADOR);
*/
            return sb.ToString();
        }
   
        //kitos

    }
}
