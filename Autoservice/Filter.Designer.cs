namespace Autoservice
{
    partial class Filter
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
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.columnsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resListBox = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AllAddButton = new System.Windows.Forms.Button();
            this.AllRemoveButton = new System.Windows.Forms.Button();
            this.filterGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.applyFilterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filterGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tablesListBox
            // 
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.ItemHeight = 16;
            this.tablesListBox.Items.AddRange(new object[] {
            "Заказ",
            "Клиент",
            "Автомобиль",
            "Запчасть",
            "Работник"});
            this.tablesListBox.Location = new System.Drawing.Point(12, 47);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.Size = new System.Drawing.Size(144, 164);
            this.tablesListBox.TabIndex = 0;
            this.tablesListBox.SelectedIndexChanged += new System.EventHandler(this.tablesListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Таблицы";
            // 
            // columnsListBox
            // 
            this.columnsListBox.FormattingEnabled = true;
            this.columnsListBox.ItemHeight = 16;
            this.columnsListBox.Items.AddRange(new object[] {
            "Заказ",
            "Клиент",
            "Автомобиль",
            "Запчасть",
            "Работник"});
            this.columnsListBox.Location = new System.Drawing.Point(192, 47);
            this.columnsListBox.Name = "columnsListBox";
            this.columnsListBox.Size = new System.Drawing.Size(125, 164);
            this.columnsListBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Столбцы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Стоблцы таблицы результата";
            // 
            // resListBox
            // 
            this.resListBox.FormattingEnabled = true;
            this.resListBox.ItemHeight = 16;
            this.resListBox.Location = new System.Drawing.Point(446, 47);
            this.resListBox.Name = "resListBox";
            this.resListBox.Size = new System.Drawing.Size(203, 164);
            this.resListBox.TabIndex = 4;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(357, 47);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(66, 23);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = ">>";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(357, 76);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(66, 23);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.Text = "<<";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AllAddButton
            // 
            this.AllAddButton.Location = new System.Drawing.Point(357, 108);
            this.AllAddButton.Name = "AllAddButton";
            this.AllAddButton.Size = new System.Drawing.Size(66, 23);
            this.AllAddButton.TabIndex = 8;
            this.AllAddButton.Text = "Все >>";
            this.AllAddButton.UseVisualStyleBackColor = true;
            this.AllAddButton.Click += new System.EventHandler(this.AllAddButton_Click);
            // 
            // AllRemoveButton
            // 
            this.AllRemoveButton.Location = new System.Drawing.Point(357, 137);
            this.AllRemoveButton.Name = "AllRemoveButton";
            this.AllRemoveButton.Size = new System.Drawing.Size(66, 23);
            this.AllRemoveButton.TabIndex = 9;
            this.AllRemoveButton.Text = "<< Все";
            this.AllRemoveButton.UseVisualStyleBackColor = true;
            this.AllRemoveButton.Click += new System.EventHandler(this.AllRemoveButton_Click);
            // 
            // filterGridView
            // 
            this.filterGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.filterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filterGridView.Location = new System.Drawing.Point(12, 267);
            this.filterGridView.Name = "filterGridView";
            this.filterGridView.RowHeadersVisible = false;
            this.filterGridView.RowTemplate.Height = 24;
            this.filterGridView.Size = new System.Drawing.Size(634, 295);
            this.filterGridView.TabIndex = 10;
            this.filterGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.filterGridView_CellValidating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Фильтры";
            // 
            // applyFilterButton
            // 
            this.applyFilterButton.Location = new System.Drawing.Point(15, 579);
            this.applyFilterButton.Name = "applyFilterButton";
            this.applyFilterButton.Size = new System.Drawing.Size(302, 42);
            this.applyFilterButton.TabIndex = 12;
            this.applyFilterButton.Text = "Применить фильтр";
            this.applyFilterButton.UseVisualStyleBackColor = true;
            this.applyFilterButton.Click += new System.EventHandler(this.applyFilterButton_Click);
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 633);
            this.Controls.Add(this.applyFilterButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filterGridView);
            this.Controls.Add(this.AllRemoveButton);
            this.Controls.Add(this.AllAddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.columnsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablesListBox);
            this.Name = "Filter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтр заказов";
            this.Load += new System.EventHandler(this.Filter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.filterGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox columnsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox resListBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AllAddButton;
        private System.Windows.Forms.Button AllRemoveButton;
        private System.Windows.Forms.DataGridView filterGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button applyFilterButton;
    }
}