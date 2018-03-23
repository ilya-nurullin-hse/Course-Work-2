namespace Autoservice
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выгрузитьЗаказыВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маркиАвтомобилейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моделиАвтомобилейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.filterButton = new System.Windows.Forms.Button();
            this.addOrderButton = new System.Windows.Forms.Button();
            this.orderListView = new System.Windows.Forms.DataGridView();
            this.clearFilter = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderListView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выгрузитьЗаказыВExcelToolStripMenuItem,
            this.загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1351, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выгрузитьЗаказыВExcelToolStripMenuItem
            // 
            this.выгрузитьЗаказыВExcelToolStripMenuItem.Name = "выгрузитьЗаказыВExcelToolStripMenuItem";
            this.выгрузитьЗаказыВExcelToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.выгрузитьЗаказыВExcelToolStripMenuItem.Text = "Открыть заказы в Excel";
            this.выгрузитьЗаказыВExcelToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьЗаказыВExcelToolStripMenuItem_Click);
            // 
            // загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem
            // 
            this.загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem.Name = "загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem";
            this.загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem.Size = new System.Drawing.Size(279, 24);
            this.загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem.Text = "Загрузить цены на запчасти из  Excel";
            this.загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem.Click += new System.EventHandler(this.загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.маркиАвтомобилейToolStripMenuItem,
            this.моделиАвтомобилейToolStripMenuItem,
            this.работникиToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // маркиАвтомобилейToolStripMenuItem
            // 
            this.маркиАвтомобилейToolStripMenuItem.Name = "маркиАвтомобилейToolStripMenuItem";
            this.маркиАвтомобилейToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.маркиАвтомобилейToolStripMenuItem.Text = "Марки автомобилей";
            this.маркиАвтомобилейToolStripMenuItem.Click += new System.EventHandler(this.маркиАвтомобилейToolStripMenuItem_Click);
            // 
            // моделиАвтомобилейToolStripMenuItem
            // 
            this.моделиАвтомобилейToolStripMenuItem.Name = "моделиАвтомобилейToolStripMenuItem";
            this.моделиАвтомобилейToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.моделиАвтомобилейToolStripMenuItem.Text = "Модели автомобилей";
            this.моделиАвтомобилейToolStripMenuItem.Click += new System.EventHandler(this.моделиАвтомобилейToolStripMenuItem_Click);
            // 
            // работникиToolStripMenuItem
            // 
            this.работникиToolStripMenuItem.Name = "работникиToolStripMenuItem";
            this.работникиToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.работникиToolStripMenuItem.Text = "Работники";
            this.работникиToolStripMenuItem.Click += new System.EventHandler(this.работникиToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.clearFilter);
            this.splitContainer1.Panel1.Controls.Add(this.filterButton);
            this.splitContainer1.Panel1.Controls.Add(this.addOrderButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.orderListView);
            this.splitContainer1.Size = new System.Drawing.Size(1351, 644);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 2;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(192, 3);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(193, 43);
            this.filterButton.TabIndex = 1;
            this.filterButton.Text = "Отфильтровать заказы";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // addOrderButton
            // 
            this.addOrderButton.Location = new System.Drawing.Point(3, 3);
            this.addOrderButton.Name = "addOrderButton";
            this.addOrderButton.Size = new System.Drawing.Size(159, 43);
            this.addOrderButton.TabIndex = 0;
            this.addOrderButton.Text = "Добавить заказ";
            this.addOrderButton.UseVisualStyleBackColor = true;
            this.addOrderButton.Click += new System.EventHandler(this.addOrderButton_Click);
            // 
            // orderListView
            // 
            this.orderListView.AllowUserToAddRows = false;
            this.orderListView.AllowUserToDeleteRows = false;
            this.orderListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderListView.Location = new System.Drawing.Point(0, 0);
            this.orderListView.MultiSelect = false;
            this.orderListView.Name = "orderListView";
            this.orderListView.ReadOnly = true;
            this.orderListView.RowHeadersVisible = false;
            this.orderListView.RowTemplate.Height = 24;
            this.orderListView.Size = new System.Drawing.Size(1351, 587);
            this.orderListView.TabIndex = 0;
            this.orderListView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderListView_CellDoubleClick);
            // 
            // clearFilter
            // 
            this.clearFilter.Location = new System.Drawing.Point(416, 3);
            this.clearFilter.Name = "clearFilter";
            this.clearFilter.Size = new System.Drawing.Size(349, 43);
            this.clearFilter.TabIndex = 2;
            this.clearFilter.Text = "Очистить фильтр / Обновить таблицу заказов";
            this.clearFilter.UseVisualStyleBackColor = true;
            this.clearFilter.Click += new System.EventHandler(this.clearFilter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 672);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Все заказы";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView orderListView;
        private System.Windows.Forms.Button addOrderButton;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьЗаказыВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьЦеныНаЗапчастиИзExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маркиАвтомобилейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моделиАвтомобилейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button clearFilter;
    }
}