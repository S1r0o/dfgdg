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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            Comboboxes();
        }
        private void Comboboxes()
        {
            //Работа с комбобоксами

            //Создние 0 элементов в комбобокс для корректного выбора категории и поставщика
            GTComboBox.Items.Add(new Category() { ID_Category = 0, Title_Category = "--- no ---" });
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
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка добавления

            //Проверка на заполнения всех полей данными
            StringBuilder errors = new StringBuilder();
            if (NameBox.Text == "")
                errors.AppendLine("Укажите название товара");
            if (ArticlulBox.Text == "")
                errors.AppendLine("Укажите артикул товара");
            if (MinCostTextBox.Text == "")
                errors.AppendLine("Укажите себестоимость");
            if (PriceBox.Text == "")
                errors.AppendLine("Укажите цену товара");
            if (InStockTextBox.Text == "")
                errors.AppendLine("Укажите количество товара");
            if (GTComboBox.SelectedIndex == 0)
                errors.AppendLine("Укажите категорию");
            if (SPComboBox.SelectedIndex == 0)
                errors.AppendLine("Укажите поставщика");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Присвоение введённых данных к записи в бд
            DBEntities.GetContext().Goods.Add(new Goods()
            {
                Title_Goods = NameBox.Text,
                Vendore_code_goods = Convert.ToInt32(ArticlulBox.Text),
                Prime_cost_goods = Convert.ToInt32(MinCostTextBox.Text),
                Price = Convert.ToInt32(PriceBox.Text),
                In_Stock = Convert.ToInt32(InStockTextBox.Text),
                Decommisioned = 0,
                Sold = 0,
                ID_Category = GTComboBox.SelectedIndex,
                ID_supplier = SPComboBox.SelectedIndex
            });
            //Сохранение изменений и переход в окно вывода данных
            DBEntities.GetContext().SaveChanges();
            ((GoodsWindow)this.Owner).updateData();
            MessageBox.Show("Новый товар добавлен", " ", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
