using Sorting_algorithm;
using System;
using System.Collections.Generic;
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

namespace SortAlgorithm_UI
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl
    {
        public static readonly DependencyProperty SortProperty = DependencyProperty.Register(
            "SortAll", typeof(BaseSort), typeof(ChartView), new PropertyMetadata(default(BaseSort)));

        public BaseSort Sort
        {
            get { return (BaseSort) GetValue(SortProperty); }
            set { 
                SetValue(SortProperty, value);
                MessageBox.Show(value.ToString());
            }
        }
        public ChartView()
        {
            InitializeComponent();
        }
    }
}
