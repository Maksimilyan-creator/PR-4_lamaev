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
    }
}
