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
    public partial class NewClientForm : Form
    {
        AutoserviceEntities db = new AutoserviceEntities();

        public int ClientId { get; set; }

        public NewClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            if (name == "")
            {
                MessageBox.Show(@"Заполните поле Имя", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tel = telTextBox.Text.Trim();
            if (tel == "")
            {
                MessageBox.Show(@"Заполните поле Телефон", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = emailTextBox.Text.Trim() == "" ? null : emailTextBox.Text.Trim();

            var client = new Client(){Email = email, Name = name, Tel = tel};

            db.Clients.Add(client);
            db.SaveChanges();

            ClientId = client.Id;

            Close();
        }
    }
}
