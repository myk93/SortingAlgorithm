using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Sorting_algorithm;

namespace SortAlgorithm_UI
{
    class ViewModel : INotifyPropertyChanged
    {
        // properties
        private ObservableCollection<int> _elementsList;
        public ObservableCollection<int> ElementsList {
            get { return _elementsList; }
            set { _elementsList = value; OnPropertyChanged(); }

        }
        
        private int _elementListSize;

        public int ElementListSize
        {
            get => _elementListSize;
            set
            {
                _elementListSize = value; 
                ElementsList = new ObservableCollection<int>(Enumerable.Range(0, ElementListSize));
                OnPropertyChanged();
            }
        }

        private BaseSort _sorter;

        public BaseSort Sorter
        {
            get => _sorter;
            set { _sorter = value; OnPropertyChanged(); }
        }


        //Commands
        public ICommand ShuffleCommand { get; set; }

        public void Shuffle(object param)
        {
            if (Sorter.arr != ElementsList)
                Sorter.arr = ElementsList;
            Sorter.Shuffle();
        }

        // Constructor
        public ViewModel()
        {
            ElementListSize = 100;
            ElementsList = new ObservableCollection<int>(Enumerable.Range(0,ElementListSize));

            // commands implementation
            ShuffleCommand = new RelayCommand(Shuffle);
        }

        #region boiler plate
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
