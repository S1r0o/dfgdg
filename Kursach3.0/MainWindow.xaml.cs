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

namespace Kursach3._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Источник данных для логотипа
            Logo_auth.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("../../Resources/Logo-main.ico")));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Авторизация с использованием логина и пароля
            if (!String.IsNullOrEmpty(LoginBox.Text))
            {
                if (!String.IsNullOrEmpty(PasswordBox.Password))
                {
                    IQueryable<Auth> авторизация_list = DBEntities.GetContext().Auth.Where(p => p.Login == LoginBox.Text && p.Password == PasswordBox.Password);
                    if (авторизация_list.Count() == 1)
                    {
                        //Всплвающее сообщение при успешной авторизации
                        MessageBox.Show("Добро пожаловать," + авторизация_list.First().Profile_Name, "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);
                        GoodsWindow window = new GoodsWindow(авторизация_list.First(), this);
                        //Переход в окно с выводом данных
                        window.Owner = this;
                        window.Show();
                        this.Hide();
                    }
                }
                //Всплвающее сообщение при провальной авторизации
                else MessageBox.Show("Пароль неверный!");
                {
                    this.LoginBox.Text = "";
                    this.PasswordBox.Password = "";
                }
            }
        }
    }
}
