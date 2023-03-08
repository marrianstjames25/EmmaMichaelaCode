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
using System.Windows.Shapes;

namespace DataContext
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DataContext.Sign_Up_DetailsDataSet sign_Up_DetailsDataSet = ((DataContext.Sign_Up_DetailsDataSet)(this.FindResource("sign_Up_DetailsDataSet")));
            // Load data into the table Sign_up_table. You can modify this code as needed.
            DataContext.Sign_Up_DetailsDataSetTableAdapters.Sign_up_tableTableAdapter sign_Up_DetailsDataSetSign_up_tableTableAdapter = new DataContext.Sign_Up_DetailsDataSetTableAdapters.Sign_up_tableTableAdapter();
            sign_Up_DetailsDataSetSign_up_tableTableAdapter.Fill(sign_Up_DetailsDataSet.Sign_up_table);
            System.Windows.Data.CollectionViewSource sign_up_tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sign_up_tableViewSource")));
            sign_up_tableViewSource.View.MoveCurrentToFirst();
        }
    }
}
