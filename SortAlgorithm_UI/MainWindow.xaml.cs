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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("please implement me using command");
            var s =((ViewModel)DataContext).Sorter;
            if (s.arr != ((ViewModel) DataContext).ElementsList)
                s.arr = ((ViewModel) DataContext).ElementsList;
            s.DoSort(this.Dispatcher);
        }
    }
}
