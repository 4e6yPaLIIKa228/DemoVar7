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
using Demo7.Class;
using Demo7.Connect;
using Demo7.Pages;

namespace Demo7.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAutoriz.xaml
    /// </summary>
    public partial class PageAutoriz : Page
    {
        public PageAutoriz()
        {
            InitializeComponent();
        }

        private void txtKPP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                //char books = e.KeyChar

                //bool texta = Convert.ToBoolean("wasd");
                //string a = Convert.ToString(texta);
                //e.Handled = texta;
            }
            catch
            {

            }
        }

        private void BtnEddit_Click(object sender, RoutedEventArgs e)
        {
            List<Agent> agents = new List<Agent>();
            int number2 = ConnectDB.conn.Agent.Count(x => x.Title == txtTitle.Text && x.Email == txtEmail.Text);
            if (number2 == 1)
            {
                MessageBox.Show("Ok");
                 Agent foundUser = agents.Find(x => x.Title == txtTitle.Text && x.Email == txtEmail.Text);
                //int number2 = ConnectDB.conn.Agent.
                 //   int a;
                 //   a = Class.AgentObject.ID;
                  // MessageBox.Show(Convert.ToString(a));
                FraneWind.frmMain.Navigate(new Pages.PageAccount());

                //Agent config = agents.FirstOrDefault(p => p.Title == txtTitle.Text);
                //MessageBox.Show(Convert.ToString(  config));



                //int number3 = ConnectDB.conn.Agent.F
                //ConnectDB.conn.Agent.SelectMany(h => h.Title == txtTitle.Text).Select(a => a)
                // List<Agent> IDagnet = ConnectDB.conn.Agent.Select
                //Agent result = agents.Find(x => x.ID == txtTitle.Text && txtEmail.Text);
                //  Agent found = agents.Find(x => x.Email == "123");


                // выводим элемент на экран
                // MessageBox.Show("Цена:{0}", Convert.ToString(found.ID));
                //MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show("No");
            }

        }
    }
}
 

