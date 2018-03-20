using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoservice
{
    public partial class SelectSpareForm : Form
    {
        readonly AutoserviceEntities db = new AutoserviceEntities();

        public int SelectedManufacturerId { get; set; }
        public string SelectedManufacturerName { get; set; }

        public int SelectedProviderId { get; set; }
        public string SelectedProviderName { get; set; }

        public string SelectedVendorcode { get; set; }
        public string SelectedVendorcodeText { get; set; }

        public int SparePrice { get; set; }

        public bool Selected { get; set; }

        private AutoModel selectedAutoModel;

        public SelectSpareForm(AutoModel selectedAutoModel)
        {
            InitializeComponent();

            this.selectedAutoModel = selectedAutoModel;
        }

        private void SelectSpareForm_Load(object sender, EventArgs e)
        {
            manufacturerComboBox.DisplayMember = "Name";
            manufacturerComboBox.ValueMember = "Id";
            manufacturerComboBox.DataSource = (from m in db.Manufacturers select new { m.Id, m.Name }).ToList();

            providerComboBox.DisplayMember = "Name";
            providerComboBox.ValueMember = "Id";
            providerComboBox.DataSource = (from m in db.Providers select new { m.Id, m.Name }).ToList();

            spareTypeComboBox.DisplayMember = "Name";
            spareTypeComboBox.ValueMember = "Id";
            spareTypeComboBox.DataSource = (from m in db.SpareTypes select new { m.Id, m.Name }).ToList();

            vendorCodeComboBox.DisplayMember = "Display";
            vendorCodeComboBox.ValueMember = "Vendorcode";
            UpdateSpareList();
        }

        private void spareTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSpareList();
        }

        private void UpdateSpareList()
        {
            if (spareTypeComboBox.SelectedValue == null || manufacturerComboBox.SelectedValue == null 
                || providerComboBox.SelectedValue == null)
                return;

            vendorCodeComboBox.DataSource = (from spares in selectedAutoModel.Spares join prices in (from p in db.Prices
                                             where (p.SpareSet.SpareTypeId == (int)spareTypeComboBox.SelectedValue)
                                             && (p.Manufacturer_Id == (int)manufacturerComboBox.SelectedValue)
                                             && (p.Provider_Id == (int)providerComboBox.SelectedValue)
                                             select new { Display = p.SpareSet.Vendorcode + " (Цена: "+ p.Value + " руб.)", p.SpareSet.Vendorcode }
                                             ) on spares.Vendorcode equals prices.Vendorcode select prices).ToList();

            var autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange((from p in db.Prices
                where (p.SpareSet.SpareTypeId == (int)spareTypeComboBox.SelectedValue)
                      && (p.Manufacturer_Id == (int)manufacturerComboBox.SelectedValue)
                      && (p.Provider_Id == (int)providerComboBox.SelectedValue)
                select p.SpareSet.Vendorcode + " (Цена: " + p.Value + " руб.)").ToArray());
            vendorCodeComboBox.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void manufacturerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSpareList();
        }

        private void providerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSpareList();
        }

        private void vendorCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SelectedManufacturerId = (int)manufacturerComboBox.SelectedValue;
            SelectedProviderId = (int)providerComboBox.SelectedValue;
            SelectedVendorcode = (string)vendorCodeComboBox.SelectedValue;

            SelectedManufacturerName = manufacturerComboBox.Text;
            SelectedProviderName = providerComboBox.Text;
            SelectedVendorcodeText = (string)vendorCodeComboBox.Text;

            Regex priceRegex= new Regex("Цена: (?<price>[0-9]+) руб");
            SparePrice = int.Parse(priceRegex.Match(SelectedVendorcodeText).Groups["price"].Captures[0].Value);

            Selected = true;

            Close();
        }
    }
}
