using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public abstract class Dato
    {
        public virtual double calcularDouble()
        {
            if (this.calcularString() == String.Empty)
                return 0;
            else
                return Convert.ToDouble(this.calcularString());
        }

        public abstract string calcularString();
    }
}
