using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenR_OCME.Model
{
    public class FrecuenciaCar
    {
        public double CalcularFrecuencia(int latidos)
        {
            if (latidos <= 0)
                throw new ArgumentException("Los latidos deben ser un número positivo.");

            return latidos * 4; // Frecuencia por minuto
        }

        public string ClasificarFrecuencia(double frecuencia)
        {
            if (frecuencia < 60)
                return "Baja";
            else if (frecuencia > 100)
                return "Alta";
            else
                return "Normal";
        }
    }
}
