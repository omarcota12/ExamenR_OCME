using ExamenR_OCME.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ExamenR_OCME.VModel
{
    public class VMFrecuenciaCar : FrecuenciaCar
    {
        private string _statusMessage;
        private string _inputText;
        private FrecuenciaCar _heartRateModel;

        public VMFrecuenciaCar()
        {
            _heartRateModel = new FrecuenciaCar();
            CalculateCommand = new RelayCommand(OnCalculateHeartRate, CanCalculateHeartRate);
        }

        public string InputText
        {
            get { return _inputText; }
            set
            {
                if (_inputText != value)
                {
                    _inputText = value;
                    OnPropertyChanged(nameof(InputText));
                }
            }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged(nameof(StatusMessage));
                }
            }
        }

        public ICommand CalculateCommand { get; }

        private bool CanCalculateHeartRate(object parameter)
        {
            
            return !string.IsNullOrWhiteSpace(InputText);
        }

        private void OnCalculateHeartRate(object parameter)
        {
            try
            {
              
                var beats = InputText.Split(',')
                                     .Select(b => int.TryParse(b.Trim(), out int result) ? result : -1)
                                     .Where(b => b >= 0) 
                                     .ToArray();

                if (beats.Length == 0)
                {
                    StatusMessage = "Por favor ingrese latidos válidos.";
                    return;
                }

                
                double heartRate = _heartRateModel.CalcularFrecuencia(beats);
                
                StatusMessage = $"{heartRate:F2} BPM - {_heartRateModel.ClasificarLatidos(heartRate)}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
