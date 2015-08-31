using System;
using System.Collections.Generic;

using System.Text;

using Kitos.Bolsa.Objetos.Datos;
using Kitos.Bolsa.Objetos.Util;

namespace Kitos.Bolsa.Informes
{
    public class General: Informe 
    {
        //kitos string[] valoresIBEX = { "ABG","ABE","ANA","ACX","ACS","AMS","MTS","POP","SAB","BKT","BBVA","BME","CRI","DIA","ENG","ELE","FCC","FER","GAS","GRF","IAG","IBE","ITX","IDR","MAP","TL5","OHL","REE","REP","SYV","SAN","TRE","TEF","VIS" };        

        public General()
        {
            base.valores = valoresIBEX;
        }

        protected override string NombreFichero
        {
            get
            {
                return " General.csv";
            }
        }

        protected override string Cabecera
        {
            get 
            {
                return "Valor" + SEPARADOR + "AH Ultimo" + SEPARADOR + /*"AH objetivo" +*/ SEPARADOR + /*"AH Potencial" + */SEPARADOR + 
                    "CD Brujula" + SEPARADOR + "CD Objetivo" + SEPARADOR + "CD Potencial" + SEPARADOR +
                    "SF Objetivo" + SEPARADOR + "SF Potencial" + SEPARADOR + "SF Valoracion" + SEPARADOR + SEPARADOR +
                    "L = D + G + I" + SEPARADOR + "M = E + J" + SEPARADOR + SEPARADOR + "O = L / M"; 
            }
        }


        public override string datosFila(string valor)
        {
            //A
            StringBuilder sb = new StringBuilder(Informe.datoRecurso(valor) + SEPARADOR);
            int Caducidad = 1000;

            //B
            AhorroUltimo ultimo;
            //kitos string fuente = CacheFichero.GetText(Informe.datoRecurso("AHORRO_" + valor), Caducidad);
            string fuente = CacheFichero.GetText(Informe.datoRecurso(valor + "_AHORRO"), Caducidad);
            ultimo = new AhorroUltimo(fuente, valor);
            double dblUltimo = ultimo.calcularDouble();
            sb.Append(dblUltimo + SEPARADOR);
           
            //C
/*
            AhorroObjetivo objetivo;
            objetivo = new AhorroObjetivo(fuente);
            double dblAhObjetivo = objetivo.calcularDouble();
            sb.Append(dblAhObjetivo + SEPARADOR);
*/ 
            sb.Append(SEPARADOR);

            //D
/*
            Potencial ahPotencial;
            ahPotencial = new Potencial(dblUltimo, dblAhObjetivo);
            double dblAhPotencial = ahPotencial.calcularDouble();
            sb.Append(dblAhPotencial + SEPARADOR);
*/ 
            sb.Append(SEPARADOR);

            //AhorroTendenciaCorto tendCorto;
            //tendCorto = new AhorroTendenciaCorto(fuente);
            //double dblTendCorto = tendCorto.calcularDouble();
            //sb.Append(dblTendCorto + SEPARADOR);

            //AhorroTendenciaLargo tendLargo;            
            //tendLargo = new AhorroTendenciaLargo(fuente);
            //double dblTendLargo = tendLargo.calcularDouble();
            //sb.Append(dblTendLargo + SEPARADOR);
            
            //E
            CincoDiasBrujula cdBrujula;
            //kitos fuente = CacheFichero.GetText(Informe.datoRecurso("CINCO_DIAS_" + valor), Caducidad);
            fuente = CacheFichero.GetText(Informe.datoRecurso(valor + "_CINCO_DIAS"), Caducidad);
            cdBrujula = new CincoDiasBrujula(fuente);
            double dblBrujula = cdBrujula.calcularDouble();
            sb.Append(dblBrujula + SEPARADOR);
            
            //F
            CincoDiasObjetivo cdObjetivo;            
            cdObjetivo = new CincoDiasObjetivo(fuente);
            double dblCdObjetivo = cdObjetivo.calcularDouble();
            sb.Append(dblCdObjetivo + SEPARADOR);

            //CincoDiasRecomendacion cdRecomendacion;            
            //cdRecomendacion = new CincoDiasRecomendacion(fuente);            
            //double dblCdRecomendacion = cdRecomendacion.calcularDouble();
            //sb.Append(dblCdRecomendacion + SEPARADOR); 

            //G
            Potencial cdPotencial;
            cdPotencial = new Potencial(dblUltimo, dblCdObjetivo);
            double dblCdPotencial = cdPotencial.calcularDouble();
            sb.Append(dblCdPotencial + SEPARADOR);

            //double valoracion = dblTendCorto + dblTendLargo + 1 / dblBrujula + 1 / dblCdRecomendacion;
            //sb.Append(valoracion + SEPARADOR);

            //double valoracionAH = valoracion * dblAhPotencial;
            //sb.Append(valoracionAH + SEPARADOR);

            //double valoracionCD = valoracion * dblCdPotencial;
            //sb.Append(valoracionCD + SEPARADOR);

            //sb.Append(valoracionAH + valoracionCD);

            //H
            //kitos fuente = CacheFichero.GetText(Informe.datoRecurso("SELFBANK_" + valor), Caducidad);
            fuente = CacheFichero.GetText(Informe.datoRecurso(valor + "_SELFBANK"), Caducidad);
            SelfBankObjetivo sbObjetivo = new SelfBankObjetivo(fuente);
            double dblSbObjetivo = sbObjetivo.calcularDouble();
            sb.Append(dblSbObjetivo + SEPARADOR);

            //I
            Potencial sbPotencial;
            sbPotencial = new Potencial(dblUltimo, dblSbObjetivo);
            double dblSbPotencial = sbPotencial.calcularDouble();
            sb.Append(dblSbPotencial + SEPARADOR);

            //J
            SelfbankValoracion sbValoracion;
            sbValoracion = new SelfbankValoracion(fuente);
            double dblSbValoracion = sbValoracion.calcularDouble();
            sb.Append(dblSbValoracion + SEPARADOR);

            sb.Append(SEPARADOR);

            //L = D + G + I
            double sumaPotencial = /*dblAhPotencial + */dblCdPotencial + dblSbPotencial;
            sb.Append(sumaPotencial + SEPARADOR);

            //M = E + J
            double sumaValoracion = dblBrujula + dblSbValoracion;
            sb.Append(sumaValoracion + SEPARADOR);

            sb.Append(SEPARADOR);

            //O
            double producto = sumaPotencial * 1/sumaValoracion;
            sb.Append(producto + SEPARADOR);
            
            return sb.ToString();
        }

        private double Media(double primero, double segundo)
        {
            return (primero + segundo) / 2;
        }

    }
}
