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
using Demo7.Pages;

namespace Demo7.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAgents.xaml
    /// </summary>
    public partial class PageAgents : Page
    {
        int no = 1,count=0;

        public PageAgents()
        {
            InitializeComponent();
            Update();
        }
        private void Update()
        {
            List<Agent> list = new List<Agent>();
            List<Agent> nlist = new List<Agent>();

            int k = no;
            list = ConnectDB.conn.Agent.ToList();
            count = nlist.Count;
            // if (count <= 0)
            // {
            try
            {
                nlist = new List<Agent>(list.GetRange(k * 10 - 10, 10));
                agents.ItemsSource = nlist;
            }
            catch
            {
                agents.ItemsSource = list;
            }
            

        }

        private void teBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (teBox.Text == "")
            {
                Update();
            }
            else
            {
                agents.ItemsSource = ConnectDB.conn.Agent.Where(x => x.Title.StartsWith(teBox.Text)).ToList();
                List<Agent> list = new List<Agent>();
                List<Agent> nlist = new List<Agent>();

                int k = no;
                list = ConnectDB.conn.Agent.ToList();
                nlist = new List<Agent>(list.GetRange(k * 10 - 10, 10));
                

            }
        }

        private void Bwd(object sender, MouseButtonEventArgs e)
        {
            if (no == 1) return;
            no--;
            if (agents.ItemsSource is null) return;
            Update();
        }

        private void Fwd(object sender, MouseButtonEventArgs e)
        {
            no++;
            if (no == count) return;
            else
            {
                if (agents.ItemsSource is null) return;
                Update();
            }
        }

        private void BtnEddit_Click(object sender, RoutedEventArgs e)
        {

            FraneWind.frmMain.Navigate(new Pages.PageEdditAgents((sender as Button).DataContext as Agent));
            Update();
        }

        private void BtDell_Click(object sender, RoutedEventArgs e)
        {
            
            var result = MessageBox.Show("Dell agent?", "To4no?", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                int IDAgent = ((Agent)((Control)sender).DataContext).ID;
                var delAge = ConnectDB.conn.Agent.Where(a => a.ID == IDAgent).Single();
                ConnectDB.conn.Agent.Remove(delAge);
                ConnectDB.conn.SaveChanges();
                Update();
            }
            else
            {
                return;
            }
        }

        private void btavtoriz_Click(object sender, RoutedEventArgs e)
        {
            FraneWind.frmMain.Navigate(new Pages.PageAutoriz());
        }

        public void Load()
        {
            if (ConnectDB.Update == 1)
            {
                Update();
            }
        }
    }
}
