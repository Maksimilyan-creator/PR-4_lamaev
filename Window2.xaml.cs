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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        RestaurantEntities _db;
        public ObservableCollection<Menu> menu { get; set; }
        public Window2()
        {
            InitializeComponent();
            _db = new RestaurantEntities();
            menu = new ObservableCollection<Menu>(_db.Menu);
            List_Visitors1.ItemsSource = menu;
        }

        private void Bt9_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Name_dish = add1.Text;
            menu.Price = Convert.ToInt32(add2.Text);
            menu.Nominal_quantity = Convert.ToInt32(add3.Text);
            menu.Availability = add4.Text;

            _db.Menu.Add(menu);
            _db.SaveChanges();
            MessageBox.Show("Блюдо добавлено в базу");
            Update();
        }
        public void Update()
        {
            _db = new RestaurantEntities();
            menu = new ObservableCollection<Menu>(_db.Menu);
            List_Visitors1.ItemsSource = menu;
            menu = new ObservableCollection<Menu>(_db.Menu);
        }

        private void Bt10_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Name_dish = add1.Text;
            menu.Price = Convert.ToInt32(add2.Text);
            menu.Nominal_quantity = Convert.ToInt32(add3.Text);
            menu.Availability = add4.Text;
            if (MessageBox.Show("Вы действительно хотите изменить ,блюдо?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var removeMenu = List_Visitors1.SelectedItem as Menu;
                _db.Menu.Remove(removeMenu);
                _db.SaveChanges();
                _db.Menu.Add(menu);
                _db.SaveChanges();
                MessageBox.Show("Посетитель был изменен  базе.");
                Update();
            }    
        }

        private void Bt11_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить ,блюдо?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var removeMenu = List_Visitors1.SelectedItem as Menu;
                _db.Menu.Remove(removeMenu);
                _db.SaveChanges();
                MessageBox.Show("Блюдо удалено из базы");
                Update();
            }
        }
    }
}
