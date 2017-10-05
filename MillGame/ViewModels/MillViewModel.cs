using MillGame.Models;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MillGame.ViewModels
{
    public class MillViewModel : INotifyPropertyChanged
    {
        public int Test { get; set; }
        public Dictionary<int, FieldViewModel> FieldViewModels { get; private set; }

        private Mill _model;

        public MillViewModel()
        {
            _model = new Mill();
            FieldViewModels = new Dictionary<int, FieldViewModel>();
            foreach (var kvp in _model.Fields)
            {
                FieldViewModels.Add(kvp.Key, new FieldViewModel(kvp.Value));
            }
            
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged
    }
}
