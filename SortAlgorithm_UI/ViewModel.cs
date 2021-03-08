﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Sorting_algorithm;

namespace SortAlgorithm_UI
{
    class ViewModel : BaseViewModel
    {
        // properties
        private ObservableCollection<int> _elementsList;
        public ObservableCollection<int> ElementsList {
            get { return _elementsList; }
            set { _elementsList = value; OnPropertyChanged(); }

        }

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
            Sorter = new BubbleSort(ElementsList);

            // commands implementation
            ShuffleCommand = new RelayCommand(Shuffle);
        }
        
    }
}
