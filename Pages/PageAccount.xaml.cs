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
using Demo7.Connect;

namespace Demo7.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAccount.xaml
    /// </summary>
    public partial class PageAccount : Page
    {
        public PageAccount()
        {
            InitializeComponent();
            Load();

        }
        public void Load()
        {
            List<Agent> list = new List<Agent>();
            Agent foundUser = list.Find(x => x.Title == "123");
            profel.ItemsSource = ConnectDB.conn.Agent.Where(x => x.Title.StartsWith("123")).ToList();

           // profel.ItemsSource = foundUser;
        }
    }
}
