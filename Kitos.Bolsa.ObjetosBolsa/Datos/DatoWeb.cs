using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public abstract class DatoWeb : Dato
    {
        string _source;
        string _palabraClave;
        string _strAntes;
        string _strDespues;        

        public DatoWeb(string source, string palabraClave, string antes, string despues)
        {
            _source = source;
            _palabraClave =  palabraClave;
            _strAntes = antes;
            _strDespues = despues;
        }

        protected string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        protected string PalabraClave
        {
            get { return _palabraClave; }
            set { _palabraClave = value; }
        }

        protected string StrAntes
        {
            get { return _strAntes; }
            set { _strAntes = value; }
        }

        protected string StrDespues
        {
            get { return _strDespues; }
            set { _strDespues = value; }
        }

        protected string obtenerDatoString()
        {
            string strResult = String.Empty;

            try
            {
                int posIni = 0;
                int posFin = 0;

                posIni = Source.IndexOf(PalabraClave);
                if (posIni == -1)
                {
                    return "";
                }

                posIni = Source.IndexOf(StrAntes, posIni + 1);
                posIni = posIni + StrAntes.Length;

                posFin = Source.IndexOf(StrDespues, posIni);

                strResult = Source.Substring(posIni, posFin - posIni);                
            }
            catch (Exception e)
            {
                throw e;
            }

            return strResult;
        }

        protected double obtenerDatoDouble()
        {
            string strResult;
            double dblResult;            
            int posIni = 0;
            int posFin = 0;

            try
            {
                posIni = Source.IndexOf(PalabraClave);
                posIni = Source.IndexOf(StrAntes, posIni + 1);
                posIni = posIni + StrAntes.Length;

                posFin = Source.IndexOf(StrDespues, posIni);

                strResult = Source.Substring(posIni, posFin - posIni);                
                dblResult = Convert.ToDouble(strResult);
            }
            catch
            {
                try
                {
                    strResult = Source.Substring(posIni, 5);
                    dblResult = Convert.ToDouble(strResult);
                }
                catch
                {
                    try
                    {
                        strResult = Source.Substring(posIni, 4);
                        dblResult = Convert.ToDouble(strResult);
                    }
                    catch
                    {
                        dblResult = 0;
                    }                    
                }
            }

            return dblResult;
        }

    }
}
