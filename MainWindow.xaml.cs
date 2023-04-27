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
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace PR_4_lamaev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestaurantEntities _db;
        public ObservableCollection<Menu> menu { get; set; }
        public ObservableCollection<Orders> order { get; set; }
        public ObservableCollection<Stocktaking> stocktakings { get; set; }
        public ObservableCollection<Visitor> visitor { get; set; }
        public static Window4 AboutWindows4;
        public static Window1 AboutWindows1;
        public static Window2 AboutWindows2;
        public static Window3 AboutWindows3;
        public MainWindow()
        {
            InitializeComponent();
            _db = new RestaurantEntities();
            visitor = new ObservableCollection<Visitor>(_db.Visitor);
            List_Visitors.ItemsSource = visitor;
            menu = new ObservableCollection<Menu>(_db.Menu);
            List_Menu.ItemsSource = menu;
            order = new ObservableCollection<Orders>(_db.Orders);
            List_Orders.ItemsSource = order;

    }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            if (AboutWindows4 == null)
            {
                AboutWindows4 = new Window4 ();
                AboutWindows4.Show ();
            }
            else AboutWindows4.Activate();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            if (AboutWindows1 == null)
            {
                AboutWindows1 = new Window1();
                AboutWindows1.Show();
            }
            else AboutWindows1.Activate();
        }

        private void btt1_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            _db = new RestaurantEntities();
            visitor = new ObservableCollection<Visitor>(_db.Visitor);
            List_Visitors.ItemsSource = visitor;
            menu = new ObservableCollection<Menu>(_db.Menu);
            List_Menu.ItemsSource = menu;
            order = new ObservableCollection<Orders>(_db.Orders);
            List_Orders.ItemsSource = order;


        }

        private void btt2_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btt3_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            if (AboutWindows2 == null)
            {
                AboutWindows2 = new Window2();
                AboutWindows2.Show();
            }
            else AboutWindows2.Activate();
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            if (AboutWindows3 == null)
            {
                AboutWindows3 = new Window3();
                AboutWindows3.Show();
            }
            else AboutWindows3.Activate();
        }
    }
}
