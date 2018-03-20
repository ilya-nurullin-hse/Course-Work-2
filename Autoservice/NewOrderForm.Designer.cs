namespace Autoservice
{
    partial class NewOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clientsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.markComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.newClientLink = new System.Windows.Forms.LinkLabel();
            this.saveButton = new System.Windows.Forms.Button();
            this.spareTextBox = new System.Windows.Forms.TextBox();
            this.changeSpareLink = new System.Windows.Forms.LinkLabel();
            this.updateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.workPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.workerComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.deleteOrderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientsComboBox
            // 
            this.clientsComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Один",
            "Два",
            "Тркк"});
            this.clientsComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.clientsComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.clientsComboBox.FormattingEnabled = true;
            this.clientsComboBox.Location = new System.Drawing.Point(153, 13);
            this.clientsComboBox.Name = "clientsComboBox";
            this.clientsComboBox.Size = new System.Drawing.Size(557, 24);
            this.clientsComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Клиент";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Запчасть";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Марка автомобиля";
            // 
            // markComboBox
            // 
            this.markComboBox.FormattingEnabled = true;
            this.markComboBox.Location = new System.Drawing.Point(153, 56);
            this.markComboBox.Name = "markComboBox";
            this.markComboBox.Size = new System.Drawing.Size(557, 24);
            this.markComboBox.TabIndex = 8;
            this.markComboBox.SelectedIndexChanged += new System.EventHandler(this.markComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Модель автомобиля";
            // 
            // modelComboBox
            // 
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(153, 99);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(557, 24);
            this.modelComboBox.TabIndex = 10;
            // 
            // newClientLink
            // 
            this.newClientLink.AutoSize = true;
            this.newClientLink.Location = new System.Drawing.Point(94, 16);
            this.newClientLink.Name = "newClientLink";
            this.newClientLink.Size = new System.Drawing.Size(51, 17);
            this.newClientLink.TabIndex = 12;
            this.newClientLink.TabStop = true;
            this.newClientLink.Text = "Новый";
            this.newClientLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newClientLink_LinkClicked);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(153, 380);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(259, 48);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Сохранить заказ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // spareTextBox
            // 
            this.spareTextBox.Location = new System.Drawing.Point(153, 279);
            this.spareTextBox.Multiline = true;
            this.spareTextBox.Name = "spareTextBox";
            this.spareTextBox.ReadOnly = true;
            this.spareTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spareTextBox.Size = new System.Drawing.Size(557, 57);
            this.spareTextBox.TabIndex = 14;
            this.spareTextBox.Text = "Для выбора запчасти нажмите \"Изменить\" под надписью \"Запчасть\"";
            // 
            // changeSpareLink
            // 
            this.changeSpareLink.AutoSize = true;
            this.changeSpareLink.Location = new System.Drawing.Point(73, 296);
            this.changeSpareLink.Name = "changeSpareLink";
            this.changeSpareLink.Size = new System.Drawing.Size(72, 17);
            this.changeSpareLink.TabIndex = 15;
            this.changeSpareLink.TabStop = true;
            this.changeSpareLink.Text = "Изменить";
            this.changeSpareLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changeSpareLink_LinkClicked);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(153, 380);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(259, 48);
            this.updateButton.TabIndex = 16;
            this.updateButton.Text = "Обновить заказ";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Статус заказа";
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Ожидается исполнение",
            "Исполнен",
            "Оплачен"});
            this.statusComboBox.Location = new System.Drawing.Point(153, 189);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(557, 24);
            this.statusComboBox.TabIndex = 17;
            this.statusComboBox.SelectedIndexChanged += new System.EventHandler(this.statusComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Цена ремонта";
            // 
            // workPrice
            // 
            this.workPrice.Location = new System.Drawing.Point(151, 236);
            this.workPrice.Name = "workPrice";
            this.workPrice.Size = new System.Drawing.Size(559, 22);
            this.workPrice.TabIndex = 20;
            this.workPrice.TextChanged += new System.EventHandler(this.workPrice_TextChanged);
            this.workPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Итого";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Location = new System.Drawing.Point(150, 348);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(44, 17);
            this.totalPriceLabel.TabIndex = 22;
            this.totalPriceLabel.Text = "- руб.";
            // 
            // workerComboBox
            // 
            this.workerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workerComboBox.FormattingEnabled = true;
            this.workerComboBox.Location = new System.Drawing.Point(153, 145);
            this.workerComboBox.Name = "workerComboBox";
            this.workerComboBox.Size = new System.Drawing.Size(557, 24);
            this.workerComboBox.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Рабоник";
            // 
            // deleteOrderButton
            // 
            this.deleteOrderButton.Location = new System.Drawing.Point(451, 380);
            this.deleteOrderButton.Name = "deleteOrderButton";
            this.deleteOrderButton.Size = new System.Drawing.Size(259, 48);
            this.deleteOrderButton.TabIndex = 23;
            this.deleteOrderButton.Text = "Удалить заказ";
            this.deleteOrderButton.UseVisualStyleBackColor = true;
            this.deleteOrderButton.Visible = false;
            this.deleteOrderButton.Click += new System.EventHandler(this.deleteOrderButton_Click);
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 447);
            this.Controls.Add(this.deleteOrderButton);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.workPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.changeSpareLink);
            this.Controls.Add(this.spareTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newClientLink);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.workerComboBox);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.markComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientsComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание нового заказа";
            this.Load += new System.EventHandler(this.NewOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox clientsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox markComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.LinkLabel newClientLink;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox spareTextBox;
        private System.Windows.Forms.LinkLabel changeSpareLink;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox workPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.ComboBox workerComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button deleteOrderButton;
    }
}