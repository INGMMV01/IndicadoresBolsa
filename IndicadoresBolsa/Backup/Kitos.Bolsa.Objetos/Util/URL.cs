using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Net;

namespace Kitos.Bolsa.Objetos.Util
{
    public class URL 
    {
        string _ruta;
        int _caducidad;
        string _path = "";
        const int CADUCIDAD = 30;

        public URL(string ruta)
        {
            _ruta = ruta;
            _caducidad = CADUCIDAD;
        }

        public URL(string ruta, int caducidad)
        {
            _ruta = ruta;
            _caducidad = caducidad;
        }
     
        private string ToPath()
        {
            if (_path == "")
            {
                string path = _ruta;

                //path = path.Replace("http://", @"c:\Temp\IndicadoresBolsa\");
                path = path.Replace("http://", "");
                path = path.Replace("www.", "");
                path = path.Replace("/", "_");
                path = path.Replace(".", "_");
                path = path.Replace("?", "_");
                path = path.Replace("&", "_");
                path += ".txt";

                _path = path;
            }
            
            return _path;
        }
        
        public string ToCode()
        {
            try
            {
                FileInfo fi = new FileInfo(this.ToPath());

                if (fi.Exists)
                {
                    if (fi.LastWriteTime.AddMinutes(_caducidad) < DateTime.Now)
                        recargarFichero(_ruta, this.ToPath());
                }
                else
                {
                    recargarFichero(_ruta, ToPath());
                }

                StreamReader sr = fi.OpenText();
                return sr.ReadToEnd();
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        private static void recargarFichero(string url, string pathFichero)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Proxy.Credentials = CredentialCache.DefaultCredentials;
                wc.DownloadFile(url, pathFichero);
            }
            catch (Exception e)
            {
                int j = 0;
            }
        }    

    }
}
