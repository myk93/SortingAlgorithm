using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sorting_algorithm;

namespace SortAlgorithm_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<int> lst { get; set; }
        public Sorting_algorithm.BaseSort BogoSort{ get; set; }
        public MainWindow()
        {
            InitializeComponent();
            lst = new ObservableCollection<int>( Enumerable.Range(0,5));
            BogoSort = new BogoSort(lst);
            
            myLST.ItemsSource = lst;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BogoSort.DoSort(this.Dispatcher);
        }
    }
}
