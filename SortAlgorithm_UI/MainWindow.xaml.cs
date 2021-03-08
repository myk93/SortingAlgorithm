using System.Windows;

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
            var s = ((ViewModel)DataContext).Sorter;
            if (s.arr != ((ViewModel)DataContext).ElementsList)
                s.arr = ((ViewModel)DataContext).ElementsList;
            s.DoSort(this.Dispatcher);
        }
    }
}
