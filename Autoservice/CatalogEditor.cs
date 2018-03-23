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
    public partial class CatalogEditor: Form
    {
        private readonly ICatalogEditor _editor;

        public CatalogEditor(string title, ICatalogEditor editor)
        {
            InitializeComponent();
            Text = title;

            _editor = editor;
        }

        private void CatalogEditor_Load(object sender, EventArgs e)
        {
            _editor.ShowTable(ref catalogDataGridView);
            Width = catalogDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 36;

            CenterToParent();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Для добавления измените последнюю пустую строку таблицы");
        }

        private void catalogDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (catalogDataGridView.CurrentCell.ColumnIndex == 0)
            {
                MessageBox.Show(@"Нельзя изменять Id", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catalogDataGridView.CurrentCell.ReadOnly = false;
            catalogDataGridView.BeginEdit(true);
        }

        private void catalogDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((int) catalogDataGridView.CurrentRow.Cells[0].Value == 0)
            {
                if (! _editor.CanISave(catalogDataGridView.CurrentRow.DataBoundItem))
                    return;
            }
            var res = _editor.Edit(catalogDataGridView.CurrentRow.DataBoundItem);
            updateTable();
            if (res == EditResult.Edited)
                MessageBox.Show(@"Успешно изменено");
            else if(res == EditResult.Added)
                MessageBox.Show(@"Успешно добавлено");
        }



        private void catalogDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(@"Неверный формат входной строки", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Для изменения кликните дважды по нужной ячейке");
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRow = catalogDataGridView.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show(@"Для удаления строки выберите любую её ячейку и нажмите Удалить");
                return;
            }

            _editor.Remove(selectedRow.DataBoundItem);
            MessageBox.Show(@"Успешно удалено");
            updateTable();
        }

        private void updateTable()
        {
            _editor.ShowTable(ref catalogDataGridView);
        }
    }

    public interface ICatalogEditor
    {
        void ShowTable(ref DataGridView dataGridView);
        EditResult Edit(object newRow);
        void Remove(object newRow);
        bool CanISave(object newRow);
    }

    public enum EditResult
    {
        Edited, Added
    }

    public class AutoMarksCatalogEditor : ICatalogEditor
    {
        AutoserviceEntities db = new AutoserviceEntities();

        class AutoMarkRow
        {
            public int Id { get; set; }
            public string Название { get; set; }
        }

        public void ShowTable(ref DataGridView dataGridView)
        {
            BindingList<AutoMarkRow> list = new BindingList<AutoMarkRow>((from m in db.AutoMarks select new AutoMarkRow { Id = m.Id, Название = m.Name }).ToList());
            dataGridView.DataSource = list;
        }

        public EditResult Edit(object newRow)
        {
            var value = newRow as AutoMarkRow;
            EditResult res;
            if (value.Id > 0)
            {
                var dbRow = db.AutoMarks.Find(value.Id);
                dbRow.Name = value.Название;
                res = EditResult.Edited;
            }
            else
            {
                var rowToAdd = new AutoMark();
                rowToAdd.Name = value.Название;
                db.AutoMarks.Add(rowToAdd);
                res = EditResult.Added;
            }
            db.SaveChanges();
            return res;
        }

        public void Remove(object newRow)
        {
            var value = newRow as AutoMarkRow;
            if (value.Id == 0)
                return;
            db.AutoMarks.Remove(db.AutoMarks.Find(value.Id));
            db.SaveChanges();
        }

        public bool CanISave(object newRow)
        {
            return true;
        }
    }

    public class AutoModelCatalogEditor : ICatalogEditor
    {
        AutoserviceEntities db = new AutoserviceEntities();

        class AutoModelRow
        {
            public int Id { get; set; }
            public int Id_Марки { get; set; }
            public string Название { get; set; }
        }

        public void ShowTable(ref DataGridView dataGridView)
        {
            BindingList<AutoModelRow> list = new BindingList<AutoModelRow>((from m in db.AutoModels
                select new AutoModelRow {Id = m.Id, Id_Марки = m.AutoMarkId, Название = m.Name }).ToList());
            dataGridView.DataSource = list;
           
        }

        public EditResult Edit(object newRow)
        {
            var value = newRow as AutoModelRow;
            EditResult res;
            if (value.Id > 0)
            {
                var dbRow = db.AutoModels.Find(value.Id);
                dbRow.Name = value.Название;
                dbRow.AutoMarkId = value.Id_Марки;
                res = EditResult.Edited;
            }
            else
            {
                var rowToAdd = new AutoModel
                {
                    Name = value.Название,
                    AutoMarkId = value.Id_Марки
                };
                db.AutoModels.Add(rowToAdd);
                res = EditResult.Added;
            }
            db.SaveChanges();
            return res;
        }

        public void Remove(object newRow)
        {
            var value = newRow as AutoModelRow;
            if (value.Id == 0)
                return;
            db.AutoModels.Remove(db.AutoModels.Find(value.Id));
            db.SaveChanges();
        }

        public bool CanISave(object newRow)
        {
            var value = newRow as AutoModelRow;
            return value.Id_Марки > 0 && value.Название != null;
        }
    }

    public class WorkersCatalogEditor : ICatalogEditor
    {
        AutoserviceEntities db = new AutoserviceEntities();

        class WorkerRow
        {
            public int Id { get; set; }
            public string Имя { get; set; }
        }

        public void ShowTable(ref DataGridView dataGridView)
        {
            BindingList<WorkerRow> list = new BindingList<WorkerRow>((from worker in db.Workers
                select new WorkerRow { Id = worker.Id, Имя = worker.Name }).ToList());
            dataGridView.DataSource = list;

        }

        public EditResult Edit(object newRow)
        {
            var value = newRow as WorkerRow;
            EditResult res;
            if (value.Id > 0)
            {
                var dbRow = db.Workers.Find(value.Id);
                dbRow.Name = value.Имя;
                res = EditResult.Edited;
            }
            else
            {
                var rowToAdd = new Worker
                {
                    Name = value.Имя,
                };
                db.Workers.Add(rowToAdd);
                res = EditResult.Added;
            }
            db.SaveChanges();
            return res;
        }

        public void Remove(object newRow)
        {
            var value = newRow as WorkerRow;
            if (value.Id == 0)
                return;
            db.Workers.Remove(db.Workers.Find(value.Id));
            db.SaveChanges();
        }

        public bool CanISave(object newRow)
        {
            return true;
        }
    }

    public class ClientsCatalogEditor : ICatalogEditor
    {
        AutoserviceEntities db = new AutoserviceEntities();

        class ClientRow
        {
            public int Id { get; set; }
            public string Имя { get; set; }
            public string Телефон { get; set; }
            public string Email { get; set; }
        }

        public void ShowTable(ref DataGridView dataGridView)
        {
            BindingList<ClientRow> list = new BindingList<ClientRow>((from client in db.Clients
                select new ClientRow { Id = client.Id, Имя = client.Name, Телефон =  client.Tel, Email = client.Email }).ToList());
            dataGridView.DataSource = list;

        }

        public EditResult Edit(object newRow)
        {
            var value = newRow as ClientRow;
            EditResult res;
            if (value.Id > 0)
            {
                var dbRow = db.Clients.Find(value.Id);
                dbRow.Name = value.Имя;
                dbRow.Tel = value.Телефон;
                dbRow.Email = value.Email;
                res = EditResult.Edited;
            }
            else
            {
                var rowToAdd = new Client()
                {
                    Name = value.Имя,
                    Tel = value.Телефон,
                    Email = value.Email,
                };
                db.Clients.Add(rowToAdd);
                res = EditResult.Added;
            }
            db.SaveChanges();
            return res;
        }

        public void Remove(object newRow)
        {
            var value = newRow as ClientRow;
            if (value.Id == 0)
                return;
            db.Clients.Remove(db.Clients.Find(value.Id));
            db.SaveChanges();
        }

        public bool CanISave(object newRow)
        {
            var value = newRow as ClientRow;
            return value.Имя != null && value.Телефон != null;
        }
    }
}
