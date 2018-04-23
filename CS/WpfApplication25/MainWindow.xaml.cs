using System;
using System.Collections.Generic;
using System.Data;
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
using DevExpress.Xpf.Grid;

namespace WpfApplication25
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
        private void MyScrollBarCustomRowAnnotationEventHandler(object sender, DevExpress.Xpf.Grid.ScrollBarCustomRowAnnotationEventArgs e)
        {
            TestData data = e.Row as TestData;
            if (data == null) return;
            int number = data.Number;
            if (number > 10 && number < 15)
                ShowCustomScrollAnnotation(e, Brushes.LightCoral);
            if (number > 2 && number < 4)
                ShowCustomScrollAnnotation(e, Brushes.Green);

        }
        private void ShowCustomScrollAnnotation(DevExpress.Xpf.Grid.ScrollBarCustomRowAnnotationEventArgs e, SolidColorBrush brush)
        {
            e.ScrollBarAnnotationInfo = new DevExpress.Xpf.Grid.ScrollBarAnnotationInfo() {
                Alignment = DevExpress.Xpf.Grid.ScrollBarAnnotationAlignment.Right,
                Brush = brush,
                MinHeight = 3,
                Width = 10
            };
        }

        private void MyLoadedEventHandler(object sender, RoutedEventArgs e)
        {
            TableView view = sender as TableView;
            view.SearchString = "Element2";
            view.SelectCells(15, view.Grid.Columns[0], 25, view.Grid.Columns[1]);
        }
    }
}
