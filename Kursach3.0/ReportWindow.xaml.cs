using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace Kursach3._0
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            //Создание заголовков для элемента Chart
            chart1.Titles.Add("Данные о товарах");
            chart1.ChartAreas.Add(new ChartArea("Default"));
            chart1.Series.Add(new Series("Количество_в_наличии")
            {
                ChartType = SeriesChartType.Column
            });
            //Присвоение данных заголовкам и осям
            List<String> info_product = new List<string>();
            List<int> count_extra = new List<int>();
            foreach (Goods goods in DBEntities.GetContext().Goods)
            {
                info_product.Add(goods.Title_Goods);
                count_extra.Add((int)goods.In_Stock);
            }
            chart1.Series["Количество_в_наличии"].Points.DataBindXY(info_product, count_extra);
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word document(*.docx) | *.docx";
            object oMissing = System.Reflection.Missing.Value;
            //Документ
            Word.Application word_app = new Word.Application();
            word_app.Visible = true;
            Word.Document doc = word_app.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //Заголовки
            Word.Paragraph par_zag = doc.Content.Paragraphs.Add(ref oMissing);
            par_zag.Range.Text = "Отчёт по количеству товаров";
            par_zag.Range.Font.Color = Word.WdColor.wdColorBlack;
            par_zag.Range.Font.Bold = 1;
            par_zag.Range.Font.Size = 14f;
            par_zag.Range.Font.Name = "Times New Roman";
            par_zag.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            par_zag.Range.InsertParagraphAfter();
            //Таблица
            Word.Paragraph table_par = doc.Content.Paragraphs.Add(ref oMissing);
            Word.Table table = doc.Content.Tables.Add(table_par.Range, DBEntities.GetContext().Goods.Count() + 1, 5, ref oMissing, ref oMissing);
            table.Range.Font.Size = 11f;
            table.Range.Font.Bold = 0;
            table.Rows[1].Range.Font.Bold = 1;
            table.Cell(1, 1).Range.Text = "Наименование товара";
            table.Cell(1, 2).Range.Text = "Количество";
            table.Cell(1, 3).Range.Text = "Стоимость";
            table.Cell(1, 4).Range.Text = "Категория";
            table.Cell(1, 5).Range.Text = "Поставщик";
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            var join_massive = from goods in DBEntities.GetContext().Goods
                               join category in DBEntities.GetContext().Category on goods.ID_Category equals category.ID_Category
                               join supplier in DBEntities.GetContext().Supplier on goods.ID_supplier equals supplier.ID_supplier
                               select new {
                                   goods.Title_Goods,
                                   goods.In_Stock,
                                   goods.Price,
                                   category.Title_Category,
                                   supplier.Title_supplier
                               };
                               
            //Заполнение таблицы данными из БД
            for (int i = 0; i < DBEntities.GetContext().Goods.Count(); i++)
            {
                for (int j = 1; j <= table.Columns.Count; j++)
                {
                    switch (j)
                    {
                        case 1:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].Title_Goods;
                            break;
                        case 2:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].In_Stock.ToString();
                            break;
                        case 3:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].Price.ToString();
                            break;
                        case 4:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].Title_Category;
                            break;
                        case 5:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].Title_supplier;
                            break;
                    }
                }
            }
            doc.SaveAs2(saveFileDialog.FileName = "Product Report", ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }
    }
}
