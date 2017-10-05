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

        public ICommand FieldPressedCommand { get; private set; }

        private Mill _model;

        public MillViewModel()
        {
            _model = new Mill();
            FieldViewModels = new Dictionary<int, FieldViewModel>();
            for (int i = 0; i < 24; i++)
            {
                FieldViewModels.Add(i, new FieldViewModel());
            }
            SetupNeighborhoods();

            FieldPressedCommand = new Command(FieldPressed);
        }

        private void SetupNeighborhoods()
        {
            FieldViewModels[0].AddNeighbor(FieldViewModels[1]);
            FieldViewModels[0].AddNeighbor(FieldViewModels[9]);
            FieldViewModels[1].AddNeighbor(FieldViewModels[2]);
            FieldViewModels[1].AddNeighbor(FieldViewModels[4]);
            FieldViewModels[2].AddNeighbor(FieldViewModels[14]);
            FieldViewModels[4].AddNeighbor(FieldViewModels[3]);
            FieldViewModels[4].AddNeighbor(FieldViewModels[7]);
            FieldViewModels[4].AddNeighbor(FieldViewModels[5]);
            FieldViewModels[3].AddNeighbor(FieldViewModels[10]);
            FieldViewModels[5].AddNeighbor(FieldViewModels[13]);
            FieldViewModels[9].AddNeighbor(FieldViewModels[10]);
            FieldViewModels[9].AddNeighbor(FieldViewModels[21]);
            FieldViewModels[10].AddNeighbor(FieldViewModels[11]);
            FieldViewModels[10].AddNeighbor(FieldViewModels[18]);
            FieldViewModels[11].AddNeighbor(FieldViewModels[6]);
            FieldViewModels[11].AddNeighbor(FieldViewModels[15]);
            FieldViewModels[6].AddNeighbor(FieldViewModels[7]);
            FieldViewModels[7].AddNeighbor(FieldViewModels[8]);
            FieldViewModels[8].AddNeighbor(FieldViewModels[12]);
            FieldViewModels[12].AddNeighbor(FieldViewModels[13]);
            FieldViewModels[12].AddNeighbor(FieldViewModels[17]);
            FieldViewModels[13].AddNeighbor(FieldViewModels[14]);
            FieldViewModels[13].AddNeighbor(FieldViewModels[20]);
            FieldViewModels[14].AddNeighbor(FieldViewModels[23]);
            FieldViewModels[15].AddNeighbor(FieldViewModels[16]);
            FieldViewModels[16].AddNeighbor(FieldViewModels[17]);
            FieldViewModels[16].AddNeighbor(FieldViewModels[19]);
            FieldViewModels[18].AddNeighbor(FieldViewModels[19]);
            FieldViewModels[19].AddNeighbor(FieldViewModels[20]);
            FieldViewModels[19].AddNeighbor(FieldViewModels[22]);
            FieldViewModels[21].AddNeighbor(FieldViewModels[22]);
            FieldViewModels[22].AddNeighbor(FieldViewModels[23]);
        }

        private void FieldPressed(object parameter)
        {
            int key = -1;

            if (int.TryParse(parameter.ToString(), out key))
            {
                throw new ArgumentException("Parameter is not a Integer");
            }

            var fieldViewModel = FieldViewModels[key];
            //...
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
