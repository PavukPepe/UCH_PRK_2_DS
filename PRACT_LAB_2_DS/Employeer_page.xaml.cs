using PRACT_LAB_2_DS.VOD_DSTableAdapters;
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

namespace PRACT_LAB_2_DS
{
    /// <summary>
    /// Логика взаимодействия для Employeer_page.xaml
    /// </summary>
    public partial class Employeer_page : Page
    {
        EmployeersTableAdapter employeers = new EmployeersTableAdapter();
        PostsTableAdapter posts = new PostsTableAdapter();
        public Employeer_page()
        {
            InitializeComponent();
            Reload();
            emlp_post.ItemsSource = posts.GetData();
            emlp_post.DisplayMemberPath = "post_name";
        }

        private void add_but_Click(object sender, RoutedEventArgs e)
        {
            InterEN();
            save_but.IsEnabled = true;

        }

        private void save_but_Click(object sender, RoutedEventArgs e)
        {
            if (empl_name.Text != "" && empl_suname.Text != "" && emlp_midlename.Text != "")
            {
                employeers.Insert(empl_name.Text, empl_suname.Text, emlp_midlename.Text, (int)(emlp_post.SelectedItem as DataRowView).Row[0]);
                Reload();
                InterDIS();
                save_but.IsEnabled = false;
            }
        }

        private void del_but_Click(object sender, RoutedEventArgs e)
        {
            employeers.DeleteQuery((int)(table_grid.SelectedItem as DataRowView).Row[0]);    
            Reload();
            InterDIS();
        }

        private void alter_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null && empl_name.Text != "" && empl_suname.Text != "" && emlp_midlename.Text != "")
            {
                employeers.UpdateQuery(empl_name.Text, empl_suname.Text, emlp_midlename.Text, (int)(emlp_post.SelectedItem as DataRowView).Row[0], (int)(table_grid.SelectedItem as DataRowView)[0]);
                Reload();
            }
            InterDIS();
        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InterEN();
            if (table_grid.SelectedItem != null)
            {
                foreach(var i in posts.GetData())
                {
                    if ((int)(table_grid.SelectedItem as DataRowView).Row[4] == i.post_id)
                        emlp_post.SelectedIndex = i.post_id - 1;
                }
                empl_name.Text = (string)(table_grid.SelectedItem as DataRowView).Row[1];
                empl_suname.Text = (string)(table_grid.SelectedItem as DataRowView).Row[2];
                emlp_midlename.Text = (string)(table_grid.SelectedItem as DataRowView).Row[3];
                emlp_post.SelectedItem = table_grid.SelectedItem as DataRowView;
            }
        }


        void Reload()
        {
            table_grid.ItemsSource = employeers.GetData();
        }

        void InterEN()
        {
            empl_name.Visibility = Visibility.Visible;
            empl_suname.Visibility = Visibility.Visible;
            emlp_midlename.Visibility = Visibility.Visible;
            emlp_post.Visibility = Visibility.Visible;
            nt.Visibility = Visibility.Visible;
            st.Visibility = Visibility.Visible;
            mt.Visibility = Visibility.Visible;
            pt.Visibility = Visibility.Visible;
        }

        void InterDIS()
        {
            empl_name.Text = "";
            empl_suname.Text = "";
            emlp_midlename.Text = "";
            empl_name.Visibility = Visibility.Hidden;
            empl_suname.Visibility = Visibility.Hidden;
            emlp_midlename.Visibility = Visibility.Hidden;
            emlp_post.Visibility = Visibility.Hidden;
            nt.Visibility = Visibility.Hidden;
            st.Visibility = Visibility.Hidden;
            mt.Visibility = Visibility.Hidden;
            pt.Visibility = Visibility.Hidden;
        }
    }
}
