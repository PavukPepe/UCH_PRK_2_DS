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

namespace PRACT_LAB_2_DS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void posts_table_but_Click(object sender, RoutedEventArgs e)
        {
            page_frame.Content = new Post_page();
            posts_table_but.IsEnabled = false;
            employeers_table_but.IsEnabled = true;
        }

        private void employeers_table_but_Click(object sender, RoutedEventArgs e)
        {
            page_frame.Content = new Employeer_page();
            posts_table_but.IsEnabled = true;
            employeers_table_but.IsEnabled = false;
        }
    }
}
