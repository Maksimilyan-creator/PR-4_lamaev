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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        RestaurantEntities _db;
        public ObservableCollection<Menu> menu { get; set; }
        public ObservableCollection<Orders> order { get; set; }
        public ObservableCollection<Stocktaking> stocktakings { get; set; }
        public ObservableCollection<Visitor> visitor { get; set; }
        public Window1()
        {
            InitializeComponent();
            _db = new RestaurantEntities();
            visitor = new ObservableCollection<Visitor>(_db.Visitor);
            List_Visitors1.ItemsSource = visitor;
        }

        private void Bt6_Click(object sender, RoutedEventArgs e)
        {
            Visitor visitor = new Visitor();
            visitor.LastName = add1.Text;
            visitor.FirstName = add2.Text;
            visitor.MiddleName = add3.Text;
            visitor.DOB = DateTime.Parse(add4.Text);

            _db.Visitor.Add(visitor);
            _db.SaveChanges();
            MessageBox.Show("Посетитель был добавлен в базу.");
            Update();
        }
        public void Update()
        {
            _db = new RestaurantEntities();
            visitor = new ObservableCollection<Visitor>(_db.Visitor);
            List_Visitors1.ItemsSource = visitor;
            
        }

        private void Bt8_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить посетителя?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var removeVisitor = List_Visitors1.SelectedItem as Visitor;
                _db.Visitor.Remove(removeVisitor);
                _db.SaveChanges();
                MessageBox.Show("Посетитель удален из базы");
                Update();
            }
        }

        private void Bt7_Click(object sender, RoutedEventArgs e)
        {
            Visitor visitor = new Visitor();
            visitor.LastName = add1.Text;
            visitor.FirstName = add2.Text;
            visitor.MiddleName = add3.Text;
            visitor.DOB = DateTime.Parse(add4.Text);
            //if (visitor == null & List_Visitors1.SelectedItem == null) return;
            
            //try
            //{
                if (MessageBox.Show("Вы действительно хотите изменить посетителя?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var removeVisitor = List_Visitors1.SelectedItem as Visitor;
                    _db.Visitor.Remove(removeVisitor);
                    _db.SaveChanges();
                    _db.Visitor.Add(visitor);
                    _db.SaveChanges();
                    MessageBox.Show("Посетитель был изменен  базе.");
                    Update();

                }
            //}
            //catch
            //{
            //    MessageBox.Show("Сначала введите информацию о новом посетителе и выберете изменяемого посетителя");
            //}
            
        }
    }
}
