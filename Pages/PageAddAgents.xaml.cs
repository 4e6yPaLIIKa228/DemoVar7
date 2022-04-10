using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PageAddAgents.xaml
    /// </summary>
    public partial class PageAddAgents : Page
    {
        public PageAddAgents()
        {
            InitializeComponent();

            CmbTypeAgent.SelectedValuePath = "ID";
            CmbTypeAgent.DisplayMemberPath = "Title";
            CmbTypeAgent.ItemsSource = Connect.ConnectDB.conn.AgentType.ToList();

        }

        private void BtnEddit_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitle.Text == "" || CmbTypeAgent.SelectedItem == null || txtEmail.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || txtDirector.Text == "" || txtINN.Text.Length != 12 || txtKPP.Text.Length != 9)
            {
                MessageBox.Show("Error");

            }
            else
            {
                try
                {
                    Agent agent = new Agent()
                    {
                        Title = txtTitle.Text,
                        AgentTypeID = (int)CmbTypeAgent.SelectedValue,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Address = txtAddress.Text,
                        DirectorName = txtDirector.Text,
                        Logo = txtImg.Text,
                        INN = txtINN.Text,
                        KPP = txtKPP.Text,
                    };
                    if (txtTitle.Text == "" || CmbTypeAgent.SelectedItem == null || txtEmail.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || txtDirector.Text == "" || txtINN.Text.Length != 12 || txtKPP.Text.Length != 9)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        ConnectDB.conn.Agent.Add(agent);
                        ConnectDB.conn.SaveChanges();
                        MessageBox.Show("Ok");
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message.ToString());
                }
            }
        
        }

        private void txtINN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9]+");
            e.Handled = re.IsMatch(e.Text);
        }

        private void txtKPP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9]+");
            e.Handled = re.IsMatch(e.Text);
        }
    }
}
