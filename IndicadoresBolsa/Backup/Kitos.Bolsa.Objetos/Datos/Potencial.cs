using System;
using System.Collections.Generic;

using System.Text;

namespace Kitos.Bolsa.Objetos.Datos
{
    public class Potencial : Dato
    {
        double _actual;
        double _objetivo;

        public Potencial(double actual, double objetivo)
        {
            _actual = actual;
            _objetivo = objetivo;
        }

        public override double calcularDouble()
        {
            double perCent = (_objetivo-_actual) * 100 / _actual;
            return perCent;
        }

        public override string calcularString()
        {
            throw new NotImplementedException();
        }        
    }
}
