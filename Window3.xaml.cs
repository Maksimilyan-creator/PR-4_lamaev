using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace PR_4_lamaev
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        RestaurantEntities _db;
        public ObservableCollection<Menu> menu { get; set; }
        public ObservableCollection<Orders> order { get; set; }
        public ObservableCollection<Stocktaking> stocktakings { get; set; }
        public ObservableCollection<Visitor> visitor { get; set; }
        public Window3()
        {
            InitializeComponent();
            _db = new RestaurantEntities();
            order = new ObservableCollection<Orders>(_db.Orders);
            List_Orders.ItemsSource = order;
            add1.ItemsSource = _db.Visitor.ToList();
            add2.ItemsSource = _db.Menu.ToList();
        }

        private void Bt12_Click(object sender, RoutedEventArgs e)
        {
            Orders order = new Orders();
            //order.Visitor.FirstName = add1.Text;
            //order.Menu.Name_dish = add2.Text;
            order.quantity_dish = Convert.ToInt32(add3.Text);
            order.Date_orders = DateTime.Parse(add4.Text);

            var CurrentName = add1.SelectedItem as Visitor;
            order.Id_visitor = CurrentName.Id;
            var CurrentMenu = add2.SelectedItem as Menu;
            order.Id_menu = CurrentMenu.Id;
            _db.Orders.Add(order);
            _db.SaveChanges();
            MessageBox.Show("Заказ оформлен");
            Update();
        }
        public void Update()
        {
            _db = new RestaurantEntities();
            order = new ObservableCollection<Orders>(_db.Orders);
            List_Orders.ItemsSource = order;
        }

        private void Bt13_Click(object sender, RoutedEventArgs e)
        {
            Orders order = new Orders();
            order.quantity_dish = Convert.ToInt32(add3.Text);
            order.Date_orders = DateTime.Parse(add4.Text);

            var CurrentName = add1.SelectedItem as Visitor;
            order.Id_visitor = CurrentName.Id;
            var CurrentMenu = add2.SelectedItem as Menu;
            order.Id_menu = CurrentMenu.Id;
            if (MessageBox.Show("Вы действительно хотите изменить заказ?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var removeOrder = List_Orders.SelectedItem as Orders;
                _db.Orders.Remove(removeOrder);
                _db.SaveChanges();
                _db.Orders.Add(order);
                _db.SaveChanges();
                MessageBox.Show("Заказ изменен");
                Update();

            }    
        }

        private void Bt14_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить заказ?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var removeOrder = List_Orders.SelectedItem as Orders;
                _db.Orders.Remove(removeOrder);
                _db.SaveChanges();
                MessageBox.Show("Заказ удален из базы");
                Update();
            }
        }
    }
}
