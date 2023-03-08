using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DataContext
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
        SqlConnection sqlCon = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Sign_Up_Details; Integrated Security = True;");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DataContext.Sign_Up_DetailsDataSet sign_Up_DetailsDataSet = ((DataContext.Sign_Up_DetailsDataSet)(this.FindResource("sign_Up_DetailsDataSet")));
            // Load data into the table Sign_up_table. You can modify this code as needed.
            DataContext.Sign_Up_DetailsDataSetTableAdapters.Sign_up_tableTableAdapter sign_Up_DetailsDataSetSign_up_tableTableAdapter = new DataContext.Sign_Up_DetailsDataSetTableAdapters.Sign_up_tableTableAdapter();
            sign_Up_DetailsDataSetSign_up_tableTableAdapter.Fill(sign_Up_DetailsDataSet.Sign_up_table);
            System.Windows.Data.CollectionViewSource sign_up_tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sign_up_tableViewSource")));
            //sign_up_tableViewSource.View.MoveCurrentToFirst();
        }

     

        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string query = $"Select * from Sign_up_table where ID = {iDComboBox.Text}";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                SecondWindow sw = new SecondWindow();


                if (iDComboBox.SelectedIndex == iDComboBox.Items.Count-1)
                {
                    while (sdr.Read())
                    {

                        sw.txtblock_1.Text = sdr["Username"].ToString();
                        sw.txtblock_2.Text = sdr["Password"].ToString();

                    }

                }
              
                sw.Show();


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlCon.Close();
            }


        }
    }
}
