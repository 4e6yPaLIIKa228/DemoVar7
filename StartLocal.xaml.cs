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
using Demo7.Connect;
using Demo7.Pages;

namespace Demo7
{
    /// <summary>
    /// Логика взаимодействия для StartLocal.xaml
    /// </summary>
    public partial class StartLocal : Window
    {
        public StartLocal()
        {
            InitializeComponent();
            Connect.ConnectDB.conn = new AgentsEntities();
            FraneWind.frmMain = FrmMain;
            FrmMain.Navigate(new Pages.PageInfo());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FraneWind.frmMain.GoBack();
            }
            catch
            {

            }
            
        }
    }
}
