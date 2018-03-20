using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Autoservice
{
    public partial class MainForm : Form
    {
        AutoserviceEntities db = new AutoserviceEntities();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadOrdersData();
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            var form = new NewOrderForm();
            form.ShowDialog();

            ReloadOrdersData();
        }

        private void ReloadOrdersData()
        {
            orderListView.DataSource = (from o in db.Orders
                select new
                {
                    Id_заказа = o.Id,
                    Статус = o.Status,
                    Итоговая_цена = o.TotalPrice,
                    Цена_работы = o.TotalPrice - o.SparePrice,
                    Запчасть = o.SpareSet.Vendorcode + " ("+ o.SpareSet.SpareType.Name + ")",
                    Цена_запчасти = o.SparePrice,
                    Производитель = o.ManufacturerSet.Name,
                    Поставщик = o.ProviderSet.Name,
                    Марка = o.AutoModelSet.AutoMarkSet.Name,
                    Модель = o.AutoModelSet.Name,
                    Клиент = o.ClientSet.Name + " " + o.ClientSet.Tel
                }).ToList();
        }

        private void orderListView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int selectedOrderId = (int)orderListView[0, e.RowIndex].Value;
            var form = new NewOrderForm(selectedOrderId);
            form.ShowDialog();

            ReloadOrdersData();
            form = null;
        }

        private void выгрузитьЗаказыВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;

            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.Item[1];

            for (int i = 0; i < orderListView.Columns.Count; i++)
            {
                workSheet.Cells[1, i + 1] = orderListView.Columns[i].HeaderCell.Value.ToString();
            }
 
            
            
            for (int i = 0; i < orderListView.Rows.Count; i++)
            {
                for (int j = 0; j < orderListView.Rows[i].Cells.Count; j++)
                {
                    workSheet.Cells[i + 2, j + 1] = orderListView.Rows[i].Cells[j].Value.ToString();
                }
            }


            excelApp.Visible = true;
            excelApp.UserControl = true;
        }

        private void загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Manufacturer_Id, Provider_Id, Spare_Vendorcode, Value
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;

            

            var dialog = new OpenFileDialog
            {
                Filter = @"Excel|*.xlsx",
                InitialDirectory = "",
                RestoreDirectory = true,
                FileName = "prices.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                excelApp.Workbooks.Open(dialog.FileName);
                Excel.Worksheet currentSheet = (Excel.Worksheet)excelApp.Workbooks[1].Worksheets[1];

                if (currentSheet.Cells[1, 1].Value2.ToString() != "Manufacturer_Id" 
                    || currentSheet.Cells[1, 2].Value2.ToString() != "Provider_Id"
                    || currentSheet.Cells[1, 3].Value2.ToString() != "Spare_Vendorcode"
                    || currentSheet.Cells[1, 4].Value2.ToString() != "Value"
                    )
                {
                    MessageBox.Show(@"Неправильный формат входного файла", @"Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                
                var insert = new List<Price>();
                for (int i = 2; ; i++)
                {
                    if (currentSheet.Cells[i, 1].Value2 == null)
                        break;

                    var price = new Price();
                    price.Manufacturer_Id = (int)(currentSheet.Cells[i, 1].Value2);
                    price.Provider_Id = (int)(currentSheet.Cells[i, 2].Value2);
                    price.Spare_Vendorcode = currentSheet.Cells[i, 3].Value2;
                    price.Value = (int)(currentSheet.Cells[i, 4].Value2);

                    insert.Add(price);
                }

                db.Prices.AddRange(insert);
                db.SaveChanges();

                excelApp.Quit();

                MessageBox.Show(@"Цены успешно импортированы", @"Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void маркиАвтомобилейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CatalogEditor("Каталог автомарок", new AutoMarksCatalogEditor());
            form.ShowDialog();
        }

        private void моделиАвтомобилейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CatalogEditor("Каталог автомоделей", new AutoModelCatalogEditor());
            form.ShowDialog();
        }

        private void работникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CatalogEditor("Список работников", new WorkersCatalogEditor());
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CatalogEditor("Список клиентов", new ClientsCatalogEditor());
            form.ShowDialog();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            var form = new Filter();
            form.ShowDialog();
        }
    }
}
