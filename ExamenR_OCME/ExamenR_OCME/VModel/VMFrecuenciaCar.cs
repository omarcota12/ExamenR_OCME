using ExamenR_OCME.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExamenR_OCME.VModel
{
    public class VMFrecuenciaCar : INotifyPropertyChanged
    {
        private string _inputLatidos;
        private string _resultado;
        private readonly FrecuenciaCar _frecuenciaModel;

        public VMFrecuenciaCar()
        {
            _frecuenciaModel = new FrecuenciaCar();
            CalcularCommand = new Command(OnCalcularFrecuencia, CanCalcularFrecuencia);
        }

        public string InputLatidos
        {
            get => _inputLatidos;
            set
            {
                _inputLatidos = value;
                OnPropertyChanged(nameof(InputLatidos));
                ((Command)CalcularCommand).ChangeCanExecute(); // Actualiza el estado del botón
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }

        public ICommand CalcularCommand { get; }

        private bool CanCalcularFrecuencia()
        {
            return !string.IsNullOrWhiteSpace(InputLatidos) && int.TryParse(InputLatidos, out _);
        }

        private void OnCalcularFrecuencia()
        {
            try
            {
                int latidos = int.Parse(InputLatidos);
                double frecuencia = _frecuenciaModel.CalcularFrecuencia(latidos);
                string clasificacion = _frecuenciaModel.ClasificarFrecuencia(frecuencia);

                Resultado = $"Frecuencia: {frecuencia} BPM - Clasificación: {clasificacion}";
            }
            catch (Exception ex)
            {
                Resultado = $"Error: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
