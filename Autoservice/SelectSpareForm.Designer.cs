namespace Autoservice
{
    partial class SelectSpareForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.spareTypeComboBox = new System.Windows.Forms.ComboBox();
            this.vendorCodeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.providerComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип запчасти";
            // 
            // spareTypeComboBox
            // 
            this.spareTypeComboBox.FormattingEnabled = true;
            this.spareTypeComboBox.Location = new System.Drawing.Point(192, 15);
            this.spareTypeComboBox.Name = "spareTypeComboBox";
            this.spareTypeComboBox.Size = new System.Drawing.Size(360, 24);
            this.spareTypeComboBox.TabIndex = 1;
            this.spareTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.spareTypeComboBox_SelectedIndexChanged);
            // 
            // vendorCodeComboBox
            // 
            this.vendorCodeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.vendorCodeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.vendorCodeComboBox.FormattingEnabled = true;
            this.vendorCodeComboBox.Location = new System.Drawing.Point(192, 141);
            this.vendorCodeComboBox.Name = "vendorCodeComboBox";
            this.vendorCodeComboBox.Size = new System.Drawing.Size(360, 24);
            this.vendorCodeComboBox.TabIndex = 4;
            this.vendorCodeComboBox.SelectedIndexChanged += new System.EventHandler(this.vendorCodeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Артикул";
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(192, 184);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(195, 52);
            this.selectButton.TabIndex = 5;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Поставщик запчасти";
            // 
            // providerComboBox
            // 
            this.providerComboBox.FormattingEnabled = true;
            this.providerComboBox.Location = new System.Drawing.Point(192, 101);
            this.providerComboBox.Name = "providerComboBox";
            this.providerComboBox.Size = new System.Drawing.Size(360, 24);
            this.providerComboBox.TabIndex = 3;
            this.providerComboBox.SelectedIndexChanged += new System.EventHandler(this.providerComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Производитель запчасти";
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Location = new System.Drawing.Point(192, 58);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(360, 24);
            this.manufacturerComboBox.TabIndex = 2;
            this.manufacturerComboBox.SelectedIndexChanged += new System.EventHandler(this.manufacturerComboBox_SelectedIndexChanged);
            // 
            // SelectSpareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 254);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.providerComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.manufacturerComboBox);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.vendorCodeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spareTypeComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SelectSpareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор запчасти";
            this.Load += new System.EventHandler(this.SelectSpareForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox spareTypeComboBox;
        private System.Windows.Forms.ComboBox vendorCodeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox providerComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
    }
}