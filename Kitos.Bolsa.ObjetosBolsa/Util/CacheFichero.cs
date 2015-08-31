using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Net;

namespace Kitos.Bolsa.Objetos.Util
{
    public static class CacheFichero
    {
        public static string GetText(string url)
        {
            return GetText(url, 30);
        }

        public static string GetText(string url,int caducidad)
        {
            URL _url = new URL(url,caducidad);

            return _url.ToCode();
        }
    }
}
