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
using System.Windows.Threading;
using Demo7.Connect;
using Demo7.Pages;


namespace Demo7.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageInfo.xaml
    /// </summary>
    public partial class PageInfo : Page
    {
      
        public PageInfo()
        {
            InitializeComponent();
        }
       
        private void BtnMaterial_Click(object sender, RoutedEventArgs e)
        {
            FraneWind.frmMain.Navigate(new Pages.PageAgents());
        }

        private void BtnAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            FraneWind.frmMain.Navigate(new Pages.PageAddAgents());
        }
    }
}
