using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Sorting_algorithm;
using sortingAlgorithm;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SortAlgorithm_UI
{
    class ViewModel : BaseViewModel
    {
        // properties
        private ObservableCollection<int> _elementsList;
        public ObservableCollection<int> ElementsList
        {
            get { return _elementsList; }
            set
            {
                _elementsList = value;
                if (Sorters != null)
                    foreach (var sorter_vm in Sorters)
                    {
                        sorter_vm.ElementListSize = ElementListSize;
                    }
                OnPropertyChanged();
            }

        }

        public ObservableCollection<ChartView_VM> Sorters { get; set; }

        public int ElementListSize
        {
            get => ElementsList.Count;
            set
            {
                ElementsList = new ObservableCollection<int>(Enumerable.Range(0, value));
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
        public ICommand ShuffleAllCommand { get; set; }

        public void ShuffleAll(object param)
        {
            foreach (var sorter_vm in Sorters)
            {
                sorter_vm.Sorter.Shuffle();
            }
        }

        public ICommand SortAllCommand { get; set; }

        public void SortAll(object param)
        {
            var dispatcher = Dispatcher.CurrentDispatcher;
            foreach (var sorter_vm in Sorters)
            {
                Task.Run(() => sorter_vm.Sorter.DoSort(dispatcher, 10));
            }
        }

        // Constructor
        public ViewModel()
        {
            ElementListSize = 100;
            ElementsList = new ObservableCollection<int>(Enumerable.Range(0, ElementListSize));
            Sorter = new BubbleSort(ElementsList);
            
            // Get all types of sorter
            var baseSortType = typeof(BaseSort);

            var allSorterTypes = Assembly.GetAssembly(baseSortType).GetTypes()
               .Where(t => !t.IsAbstract && !t.IsInterface && baseSortType.IsAssignableFrom(t));

            var instancesOfSorters = from t in allSorterTypes
                                     select Activator.CreateInstance(t) as BaseSort;

            var allSorter = new ObservableCollection<BaseSort>(instancesOfSorters);

            // Create a Chart_View_VM for each sorter
            var vms = from sorter in allSorter
                      select new ChartView_VM(sorter);

            Sorters = new ObservableCollection<ChartView_VM>(vms);

            // commands implementation
            ShuffleAllCommand = new RelayCommand(ShuffleAll);
            SortAllCommand = new RelayCommand(SortAll);
        }

    }
}
