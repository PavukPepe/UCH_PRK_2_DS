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
    /// Логика взаимодействия для Post_page.xaml
    /// </summary>
    public partial class Post_page : Page
    {
        PostsTableAdapter posts = new PostsTableAdapter();
        EmployeersTableAdapter employeers = new EmployeersTableAdapter();
        public Post_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = posts.GetData();
        }

        private void add_but_Click(object sender, RoutedEventArgs e)
        {
            InterEN();
            save_but.IsEnabled = true;
        }

        private void del_but_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)(table_grid.SelectedItem as DataRowView).Row[0];
            foreach (var item in employeers.GetData())
                if (item.id_post == id)
                    return;
            posts.DeleteQuery(id);
            Reload();
            InterDIS();
        }

        private void alter_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null && post_name.Text != "" && post_salary.Text != "")
            {
                posts.UpdateQuery(post_name.Text, (float)Convert.ToDouble(post_salary.Text), (int)(table_grid.SelectedItem as DataRowView)[0]);
                Reload();
            }
            InterDIS();
        }

        private void save_but_Click(object sender, RoutedEventArgs e)
        {
            if (post_name.Text != "" && post_salary.Text != "")
            {
                posts.Insert(post_name.Text, (float)Convert.ToDouble(post_salary.Text));
                Reload();
                InterDIS();
                save_but.IsEnabled = false;
            }
        }
        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InterEN();
            if (table_grid.SelectedItem != null)
            {
                post_name.Text = (string)(table_grid.SelectedItem as DataRowView).Row[1];
                post_salary.Text = (table_grid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        void Reload()
        {
            table_grid.ItemsSource = posts.GetData();
        }

        void InterEN()
        {
            post_name.Visibility = Visibility.Visible;
            post_salary.Visibility = Visibility.Visible;
            nt.Visibility = Visibility.Visible;
            st.Visibility = Visibility.Visible;
        }

        void InterDIS()
        {
            post_name.Text = "";
            post_salary.Text = "";
            post_name.Visibility = Visibility.Hidden;
            post_salary.Visibility = Visibility.Hidden;
            nt.Visibility = Visibility.Hidden;
            st.Visibility = Visibility.Hidden;
        }

    }
}
