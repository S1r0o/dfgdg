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
using System.Windows.Shapes;

namespace Kursach3._0
{
    /// <summary>
    /// Логика взаимодействия для RedactWindow.xaml
    /// </summary>
    public partial class RedactWindow : Window
    {
        public RedactWindow(object id)
        {
            InitializeComponent();
            DataContext = id;
            Comboboxes();           
        }
        private void Comboboxes()
        {
            //Работа с комбобоксами

            //Создние 0 элементов в комбобокс для корректного выбора категории и поставщика
            GTComboBox.Items.Add(new Category() {ID_Category = 0, Title_Category = "--- no ---"});
            GTComboBox.SelectedIndex = 0;

            SPComboBox.Items.Add(new Supplier() { ID_supplier = 0, Title_supplier = "--- no ---" });
            SPComboBox.SelectedIndex = 0;
            //Запрос к базе с цель получения записей категории и поставщика
            var data = from Category in DBEntities.GetContext().Category
                       select Category;

            var data2 = from Supplier in DBEntities.GetContext().Supplier
                      select Supplier;
            //Вывод элементов комбобокса
            data2.ToList().ForEach((Supplier supplier) =>
            {
                SPComboBox.Items.Add(supplier);
            });

            data.ToList().ForEach((Category category) =>
            {
                GTComboBox.Items.Add(category);
            });

            
        }
        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка сохранения редактирования
            
            //Проверка на правильно введённые данные
            if (GTComboBox.SelectedIndex == 0)
            {
                GTComboBox.SelectedIndex = 1;
            }
            else
            {
                DBEntities.GetContext().SaveChanges();
                ((GoodsWindow)this.Owner).updateData();
                this.Close();
            }

            if (SPComboBox.SelectedIndex == 0)
            {
                SPComboBox.SelectedIndex = 1;
            }
            else
            {
                //Сохранение данных и переход в новое окно
                DBEntities.GetContext().SaveChanges();
                ((GoodsWindow)this.Owner).updateData();
                this.Close();
            }
        }
    }
}