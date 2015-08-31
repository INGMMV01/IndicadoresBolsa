using System;
using System.Collections.Generic;

using System.Text;
using System.Resources;
using System.Reflection;

using System.IO;

namespace Kitos.Bolsa.Informes
{
    public abstract class Informe
    {
        protected const string SEPARADOR = ";";
        private string[] _valores;

        //protected string[] valoresIBEX = { "ABE", "ANA", "ACS", "AMS", "MTS", "SAB", "POP", "BKIA", "BKT", "BBVA", "BME", "CABK", "DIA", "ENG", "FCC", "FER", "GAS", "GRF", "IAG", "IBE", "ITX", "IDR", "JAZ", "MAP", "TL5", "OHL", "REE", "REP", "SCYR", "SAN", "TRE", "TEF", "VIS", "ACX" };
        protected string[] valoresIBEX = { "ABE", "ANA", "ACS", "AMS", "MTS", "SAB", "POP", "BKIA", "BKT", "BBVA", "BME", "CABK", "DIA", "ENG", "FCC", "FER", "GAS", "GRF", "IAG", "IBE", "ITX", "IDR", "JAZ", "MAP", "TL5", "OHL", "REE", "REP", "SCYR", "SAN", "TRE", "TEF", "ACX" };

        public void Generar()
        {
            string nombreFich = DateTime.Now.ToString("yyyy-MM-dd") + NombreFichero;

            FileInfo fi = new FileInfo(nombreFich);

            if (fi.Exists)
                fi.Delete();

            StreamWriter sw = new StreamWriter(nombreFich);            
            StringBuilder sb = new StringBuilder();

            sw.WriteLine(Cabecera);
            foreach (string valor in valores)
            {
                Console.WriteLine("Valor: " + valor + "...");
                sw.WriteLine(datosFila(valor));
            }
            
            sw.Close();
        }

        protected virtual string NombreFichero { get { throw new NotImplementedException(); } }        
        protected virtual string Cabecera { get { throw new NotImplementedException(); } }        

        public abstract string datosFila(string valor);

        protected string[] valores
        {
            get { return _valores; }
            set { _valores = value; }
        }

        //kitos protected static string datoRecurso(string key)
        public static string datoRecurso(string key)
        {
            string assemblyName = "Kitos.Bolsa.Informes";
            Assembly assembly = Assembly.Load(assemblyName);
            Type type = assembly.GetType(string.Format("{0}.RUTAS", assemblyName));
            ResourceManager resMan = new ResourceManager(type);

            return resMan.GetString(key);            
        }

        //protected void ToFile(string nombreFich, string contenido)
        //{
        //    FileInfo fi = new FileInfo(nombreFich);

        //    if (fi.Exists)
        //        fi.Delete();
                        
        //    StreamWriter sw = new StreamWriter(nombreFich);
        //    sw.Write(contenido);
        //    sw.Close();
        //}

    }
}
