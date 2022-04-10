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
using Demo7.Class;
using System.Text.RegularExpressions;

namespace Demo7.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEdditAgents.xaml
    /// </summary>
    public partial class PageEdditAgents : Page
    {
        public PageEdditAgents(Agent agent)
        {
            InitializeComponent();

            CmbTypeAgent.SelectedIndex = agent.AgentTypeID - 1;
            CmbTypeAgent.SelectedValuePath = "ID";
            CmbTypeAgent.DisplayMemberPath = "Title";
            CmbTypeAgent.ItemsSource = Connect.ConnectDB.conn.AgentType.ToList();


            Class.AgentObject.ID = agent.ID;
            txtTitle.Text = agent.Title;
            txtEmail.Text = agent.Email;
            txtPhone.Text = agent.Phone;
            txtImg.Text = agent.Logo;
            txtAddress.Text = agent.Address;
            txtDirector.Text = agent.DirectorName;
            txtINN.Text = agent.INN;
            txtKPP.Text = agent.KPP;
        }

        private void BtnEddit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<Agent> agents = ConnectDB.conn.Agent.Where(x => x.ID == Class.AgentObject.ID).AsEnumerable().
                   Select(x =>
                   {
                       bool result = int.TryParse(CmbTypeAgent.SelectedValue.ToString(), out int IDType);
                       x.Title = txtTitle.Text;
                       x.Email = txtEmail.Text;
                       x.Phone = txtPhone.Text;
                       x.Logo = txtImg.Text;
                       x.Address = txtAddress.Text;
                       x.DirectorName = txtDirector.Text;
                       x.INN = txtINN.Text;
                       x.KPP = txtKPP.Text;
                       return x;
                   });
                foreach (Agent agent in agents)
                {
                    ConnectDB.conn.Entry(agent).State = System.Data.Entity.EntityState.Modified;
                }
                ConnectDB.conn.SaveChanges();
                MessageBox.Show("Save");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }

        private void txtINN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
                Regex re = new Regex("[^0-9]+");
                e.Handled = re.IsMatch(e.Text);
        }
    }
}
