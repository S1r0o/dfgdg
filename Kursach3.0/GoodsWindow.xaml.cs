using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Kursach3._0
{
    /// <summary>
    /// Логика взаимодействия для GoodsWindow.xaml
    /// </summary>
    public partial class GoodsWindow : Window
    {
        //Объявление перемемнной с модификатором public для окна MainWindow, чтобы впоследствии к ней обращаться с целью присвоения свойства "Owner" для перехода между окнами 
        public MainWindow window;
        //Объявление перемемнной goods для работы с элементом Листбокс(Почему IEnumerable? потому что это как лист или ICollection, но с ними ничего не работает)
        IEnumerable<Goods> goods;

        public GoodsWindow(Auth auth, MainWindow window)
        {
            InitializeComponent();
            //Обращение к базе с целью возвращения названия профиля
            UserNameLabel.Content = auth.Profile_Name;
            //Выбор источника данных для формы
            DataContext = DBEntities.GetContext().Goods.ToList();
            //Вызов метода обновления элемента Листбокс и всех элементов внутри
            updateData();
        }
        //Метод для обновления элемента Листбокс и всех элементов внутри
        public void updateData()
        {
            //Фильтрация

            //Присвоение значения переменной goods
            goods = DBEntities.GetContext().Goods.ToList();
            //Условие "Если в элемент чекбокс поставлена галочка, то условие выполняется"
            if (PriceCheckBox.IsChecked == true)
            {
                //Объявление переменных с типом данных "int(целочисленный)" для последующего использования совместно с элементом текстбокс для реализации фильтрации по цене
                int priceone = 0, pricetwo = 0;
                ///Присвоение значения свойству "Text" элемента "PriceBox1" переменной priceone внутри проверки на введённые данные
                if (!int.TryParse(PriceBox1.Text, out priceone))
                    return;
                //Присвоение значения свойству "Text" элемента "PriceBox2" переменной pricetwo внутри проверки на введённые данные
                if (!int.TryParse(PriceBox2.Text, out pricetwo))
                    return;
                //Проверка на неправильно введённые данные(значение pricetwo не может быть больше priceone)
                if (priceone > pricetwo)
                    return;
                //Возвращение записей с заданными параметрами priceone и pricetwo (цена "С" и цена "По")
                goods = goods.Where(p => p.Price >= priceone && p.Price <= pricetwo);
            }

            //Поиск

            //Возвращение записей из бд название которых совпадает с названием, записанным в Текстбокс "SearchBox"
            goods = goods.Where(p => p.Title_Goods.Contains(SearchBox.Text)).ToList();
            //Присвоение источника данных элементу Листбокс
            listBox.ItemsSource = goods;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка редактирования

            //Поиск id у выбранной записи в элементе листбокс и передача его в окно редактирования
            int id = (int)TypeDescriptor.GetProperties(listBox.SelectedItem)[2].GetValue(listBox.SelectedItem);
            Goods goods = DBEntities.GetContext().Goods.Where(p => p.ID_Goods == id).First();
            //Переход в окно редактирования
            RedactWindow redactWindow = new RedactWindow(goods);
            redactWindow.Owner = this;
            redactWindow.Show();
        }

        private void AddButtonGoods_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка добавления

            //Переход в окно добавления
            AddWindow addWindow = new AddWindow();
            addWindow.Owner = this;
            addWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка удаления

            //Создание всплывающего окна с предупреждением пользователя об удалении записи
            MessageBoxResult messegeBoxResult = MessageBox.Show("Вы действительно хотите удалить товар?", "Удаление записи", MessageBoxButton.YesNo);
            //Если пользователь согласился с условиями, то выполняется код ниже
            if (messegeBoxResult == MessageBoxResult.Yes)
            {
                //Поиск id у выбранной записи в элементе листбокс
                int id = (int)TypeDescriptor.GetProperties(listBox.SelectedItem)[2].GetValue(listBox.SelectedItem);
                Goods goods = DBEntities.GetContext().Goods.Where(p => p.ID_Goods == id).First(); 
                //Удаление элемента с выбранным id
                DBEntities.GetContext().Goods.Remove(goods);
                //Сохранение изменений
                DBEntities.GetContext().SaveChanges();
                //Обновление элемента листбокс
                updateData();
                //Кнопка удаления становится неактивной
                DeleteButton.IsEnabled = false;
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //При выборе записи в элементе листбокс кнопка удаления становится активной(по умолчанию не активна)
            DeleteButton.IsEnabled = true; 
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Обновление элемента листбокс после ввода данных в строку поиска
            updateData();
        }

        private void PriceCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PriceBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Обновление элемента листбокс после ввода данных в строку цены "С"
            updateData();
        }

        private void PriceBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Обновление элемента листбокс после ввода данных в строку цены "По"
            updateData();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка перехода в окно формирования отчёта
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Owner = this;
            reportWindow.Show();
        }
    }
}
