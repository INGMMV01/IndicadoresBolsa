using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using Kitos.Bolsa.Informes;

namespace IndicadoresBolsa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("kitos inicio: " + DateTime.Now.ToString());
            
            General gen = new General();
            gen.Generar();

            Tendencia ten = new Tendencia();
            ten.Generar();

            DistanciaMaxMin dist = new DistanciaMaxMin();
            dist.Generar();
            
            SoportesResistencias sopRes = new SoportesResistencias();
            sopRes.Generar();
            
            Console.WriteLine("kitos fin: " + DateTime.Now.ToString());
            Console.ReadLine();
        }       
      
    }
}
