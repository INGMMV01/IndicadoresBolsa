using System;
using System.Collections.Generic;
using System.Text;

using Kitos.Bolsa.Objetos.Datos;
using Kitos.Bolsa.Objetos.Util;

namespace Kitos.Bolsa.Informes
{
    public class SoportesResistencias : Informe 
    {
        //kitos string[] valoresIBEX = { "ABG", "ABE", "ANA", "ACX", "ACS", "AMS", "MTS", "POP", "SAB", "BKT", "BBVA", "BME", "CRI", "DIA", "ENG", "ELE", "FCC", "FER", "GAS", "GRF", "IAG", "IBE", "ITX", "IDR", "MAP", "TL5", "OHL", "REE", "REP", "SYV", "SAN", "TRE", "TEF", "VIS" };

        public SoportesResistencias()
        {
            this.valores = valoresIBEX;
        }

        protected override string NombreFichero
        {
            get
            {
                return " SoportesResistencias.csv";
            }
        }

        protected override string Cabecera
        {
            get
            {
                return "Valor" + SEPARADOR + "Actual" + SEPARADOR + "Soporte 2"+ SEPARADOR + "Soporte 1"+ SEPARADOR + "Resistencia 1"+ SEPARADOR + "Resistencia 2" + SEPARADOR + SEPARADOR + "Promedio Soportes" + SEPARADOR + "Promedio Resistencias" + SEPARADOR + SEPARADOR + "Distancia a soportes" + SEPARADOR + "Distancia a resistencias";
            }
        }

        public override string datosFila(string valor)
        {
            //A
            StringBuilder sb = new StringBuilder(Informe.datoRecurso(valor) + SEPARADOR);
            int Caducidad = 1000;

            double mediaSoporte;
            double mediaResistencia;

            double distanciaSoporte;
            double distanciaResistencia;

            string fuente = CacheFichero.GetText(Informe.datoRecurso(valor + "_AHORRO"), Caducidad);

            //B
            AhorroUltimo ultimo;
            ultimo = new AhorroUltimo(fuente, valor);
            double dblUltimo = ultimo.calcularDouble();
            sb.Append(dblUltimo + SEPARADOR);

            //C
            AhorroSoporte2 sop2;
            sop2 = new AhorroSoporte2(fuente);
            string strSop2 = sop2.calcularString();
            sb.Append(strSop2 + SEPARADOR);

            //D
            AhorroSoporte1 sop1;
            sop1 = new AhorroSoporte1(fuente);
            string strSop1 = sop1.calcularString();
            sb.Append(strSop1 + SEPARADOR);

            //E
            AhorroResistencia2 res1;
            res1 = new AhorroResistencia2(fuente);
            string strRes1 = res1.calcularString();
            sb.Append(strRes1 + SEPARADOR);

            //F
            AhorroResistencia2 res2;
            res2 = new AhorroResistencia2(fuente);
            string strRes2 = res2.calcularString();
            sb.Append(strRes2 + SEPARADOR);

            //G
            sb.Append(SEPARADOR);

            //H
            mediaSoporte = (sop1.calcularDouble() + sop2.calcularDouble()) / 2;
            sb.Append(mediaSoporte + SEPARADOR);

            //I
            mediaResistencia = (res1.calcularDouble() + res2.calcularDouble()) / 2;
            sb.Append(mediaResistencia + SEPARADOR);

            //J
            sb.Append(SEPARADOR);

            //K
            distanciaSoporte = (dblUltimo - mediaSoporte) * 100 / dblUltimo;
            sb.Append(distanciaSoporte + SEPARADOR); 

            //L
            distanciaResistencia = (mediaResistencia - dblUltimo) * 100 / dblUltimo;
            sb.Append(distanciaResistencia + SEPARADOR); 
            
            return sb.ToString();
        }
   
    }
}
