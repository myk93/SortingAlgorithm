using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Sorting_algorithm;

namespace SortAlgorithm_UI
{
    public class ChartView_VM : BaseViewModel
    {
        private ObservableCollection<int> _elementsList;
        public ObservableCollection<int> ElementsList
        {
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

        public ICommand SortCommand { get; set; }

        public void Sort(object param)
        {
            if (Sorter.arr != ElementsList)
                Sorter.arr = ElementsList;
            Sorter.DoSort(Dispatcher.CurrentDispatcher);
        }

        public ChartView_VM()
        {
            ElementListSize = 100;
            ElementsList = new ObservableCollection<int>(Enumerable.Range(0, ElementListSize));
            Sorter = new BubbleSort(ElementsList);

            // commands implementation
            ShuffleCommand = new RelayCommand(Shuffle);
            SortCommand = new RelayCommand(Sort);
        }

        public ChartView_VM(ObservableCollection<int> collection, BaseSort sorter)
        {
            ElementsList = collection;
            Sorter = sorter;
        }
    }
}
