using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoservice
{
    public partial class NewOrderForm : Form
    {
        AutoserviceEntities db = new AutoserviceEntities();

        private int manufacturerId;
        private int providerId;
        private string vendorcode;
        private int clientId;
        private int modelId;
        private int markId;
        private int orderId;
        private string status;
        private int totalPrice = 0;
        private int sparePrice = -1;
        private int workerId;

        public NewOrderForm()
        {
            InitializeComponent();
            Text = @"Создание нового заказа";
            saveButton.Visible = true;
            updateButton.Visible = false;
            deleteOrderButton.Visible = false;

            statusComboBox.SelectedIndex = 0;
        }

        public NewOrderForm(int selectedOrderId)
        {
            Order order = (from o in db.Orders where o.Id == selectedOrderId select o).First();

            InitializeComponent();
            Text = @"Обновление заказа";
            saveButton.Visible = false;
            updateButton.Visible = true;
            deleteOrderButton.Visible = true;

            orderId = order.Id;
            manufacturerId = order.ManufacturerId;
            providerId = order.ProviderId;
            clientId = order.ClientId;
            modelId = order.AutoModelId;
            markId = order.AutoModelSet.AutoMarkId;
            sparePrice = order.SparePrice;
            totalPrice = order.TotalPrice;
            vendorcode = order.SpareVendorcode;
            workerId = order.WorkerId;

            workPrice.Text = (totalPrice - sparePrice).ToString();

            statusComboBox.SelectedItem = order.Status;

            spareTextBox.Text = $"Производитель: {order.ManufacturerSet.Name}\r\nПоставщик: {order.ProviderSet.Name}\r\nАртикул: {order.SpareVendorcode} (Цена: {order.SparePrice})";
        }

        private void NewOrderForm_Load(object sender, EventArgs e)
        {
            clientsComboBox.DisplayMember = "Show";
            clientsComboBox.ValueMember= "Id";

            markComboBox.DisplayMember = "Name";
            markComboBox.ValueMember = "Id";
            markComboBox.DataSource = (from m in db.AutoMarks select new {m.Id, m.Name}).ToList();

            modelComboBox.DisplayMember = "Name";
            modelComboBox.ValueMember = "Id";
            modelComboBox.DataSource = (from m in db.AutoModels
                where m.AutoMarkId == (int) markComboBox.SelectedValue
                select new {m.Id, m.Name}).ToList();

            workerComboBox.DisplayMember = "Name";
            workerComboBox.ValueMember = "Id";
            workerComboBox.DataSource = (from m in db.Workers select new { m.Id, m.Name }).ToList();

            if (workerId != 0)
                workerComboBox.SelectedValue = workerId;

            UpdateClientsList();

            if (modelId != 0)
            {
                modelComboBox.SelectedValue = modelId;
                markComboBox.SelectedValue = markId;
                clientsComboBox.SelectedValue = clientId;
            }
        }

        private void newClientLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new NewClientForm();
            form.ShowDialog();
            clientId = form.ClientId;
            UpdateClientsList();
            clientsComboBox.SelectedValue = clientId;
        }

        private void UpdateClientsList()
        {
            clientsComboBox.DataSource = (from c in db.Clients select new { Show = c.Name + " (Тел: " + c.Tel + ")", c.Id }).ToList();

            var autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange((from c in db.Clients select c.Name + " (Тел: " + c.Tel + ")").ToArray());
            clientsComboBox.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (clientsComboBox.SelectedValue == null)
            {
                MessageBox.Show(@"Выберите клиента");
                return;
            }
            if (totalPrice == 0)
            {
                MessageBox.Show(@"Укажите цену работы. Цена работы должна быть больше нуля");
                return;
            }
            var order = new Order();
            order.SpareVendorcode = vendorcode;
            order.AutoModelId = (int)modelComboBox.SelectedValue;
            order.ProviderId = providerId;
            order.ManufacturerId = manufacturerId;
            order.ClientId = (int)clientsComboBox.SelectedValue;
            order.Status = status;
            order.SparePrice = sparePrice;
            order.CreatedAt = DateTime.Now;
            order.TotalPrice = totalPrice;
            order.WorkerId = (int) workerComboBox.SelectedValue;

            db.Orders.Add(order);
            db.SaveChanges();

            Close();
            MessageBox.Show(@"Заказ успешно создан", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void markComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelComboBox.DataSource = (from m in db.AutoModels
                where m.AutoMarkId == (int)markComboBox.SelectedValue
                select new { m.Id, m.Name }).ToList();
        }

        private void changeSpareLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowSelectSpareWindow();
        }

        private void ShowSelectSpareWindow()
        {
            var form = new SelectSpareForm(db.AutoModels.Find((int)modelComboBox.SelectedValue));
            form.ShowDialog();
            if (form.Selected)
            {
                manufacturerId = form.SelectedManufacturerId;
                providerId = form.SelectedProviderId;
                vendorcode = form.SelectedVendorcode;
                sparePrice = form.SparePrice;
                updateTotalPrice();

                spareTextBox.Text = $"Производитель: {form.SelectedManufacturerName}\r\nПоставщик: {form.SelectedProviderName}\r\nАртикул: {form.SelectedVendorcodeText}";
            }
        }
        
        private void updateButton_Click(object sender, EventArgs e)
        {
            var order = db.Orders.Find(orderId);
            order.SpareVendorcode = vendorcode;
            order.AutoModelId = (int)modelComboBox.SelectedValue;
            order.ProviderId = providerId;
            order.ManufacturerId = manufacturerId;
            order.ClientId = (int)clientsComboBox.SelectedValue;
            order.Status = status;
            order.SparePrice = sparePrice;
            order.CreatedAt = DateTime.Now;
            order.TotalPrice = totalPrice;
            order.WorkerId = (int)workerComboBox.SelectedValue;

            updateTotalPrice();
            
            db.SaveChanges();

            Close();
            MessageBox.Show(@"Заказ успешно обновлен", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = (string) statusComboBox.SelectedItem;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void updateTotalPrice()
        {
            if (sparePrice == -1)
                return;

            string workPriceText = workPrice.Text;
            if (workPriceText.Length > 0)
            {
                var workPrice = int.Parse(workPriceText);
                totalPrice = sparePrice + workPrice;
                totalPriceLabel.Text = totalPrice + @" руб.";
            }
        }

        private void workPrice_TextChanged(object sender, EventArgs e)
        {
            updateTotalPrice();
        }

        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Вы действительно хотите удалить текущий заказ?", @"Удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.Orders.Remove(db.Orders.Find(orderId));

                db.SaveChanges();
                MessageBox.Show(@"Заказ успешно удален", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
