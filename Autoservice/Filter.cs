using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoservice
{
    public partial class Filter : Form
    {
        AutoserviceEntities db = new AutoserviceEntities();

        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            tablesListBox.ValueMember = "Table";
            tablesListBox.DisplayMember = "Text";
            tablesListBox.DataSource = new List<TableListItem>
            {
                new TableListItem { Table = db.Orders, Text = "Заказ" },
                new TableListItem { Table = db.Clients, Text = "Клиент" },
                new TableListItem { Table = db.AutoModels, Text = "Автомобиль" },
                new TableListItem { Table = db.SpareTypes, Text = "Запчасть" },
                new TableListItem { Table = db.Workers, Text = "Работник" },
            };
        }

        class TableListItem
        {
            public string Text { get; set; }
            public DbSet Table { get; set; }
        }

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTableListItem = tablesListBox.SelectedValue as TableListItem;
            var columns = typeof(Order).GetProperties().Select(p => p.Name).ToList();
            columnsListBox.DataSource = columns;
        }
    }
}
