using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenR_OCME.Model
{
    public class FrecuenciaCar
    {
        public double CalcularFrecuencia(int[] Latidos)
        {
            if (Latidos == null || Latidos.Length == 0)
                throw new ArgumentException("No se han ingresado latidos.");

            
            int totalLatidos = Latidos.Sum();
           
            return (totalLatidos / 15.0) * 60.0;
        }

        public string ClasificarLatidos(double Cantidad)
        {
            if (Cantidad < 60)
                return "Baja";
            else if (Cantidad > 100)
                return "Alta";
            else
                return "Normal";
        }
    }
}