namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CreateMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddRow = new System.Windows.Forms.ToolStripMenuItem();
			this.AddColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.DeleteRow = new System.Windows.Forms.ToolStripMenuItem();
			this.DeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ShowExpression = new System.Windows.Forms.ToolStripMenuItem();
			this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.допомогаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.таблицаToolStripMenuItem,
            this.допомогаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Margin = new System.Windows.Forms.Padding(2);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(1081, 28);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMenuButton,
            this.OpenMenuButton,
            this.SaveMenuButton,
            this.сохранитьКакToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// CreateMenuButton
			// 
			this.CreateMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateMenuButton.Image")));
			this.CreateMenuButton.Name = "CreateMenuButton";
			this.CreateMenuButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.CreateMenuButton.Size = new System.Drawing.Size(273, 26);
			this.CreateMenuButton.Text = "Створити";
			this.CreateMenuButton.Click += new System.EventHandler(this.CreateMenuButton_Click);
			// 
			// OpenMenuButton
			// 
			this.OpenMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenMenuButton.Image")));
			this.OpenMenuButton.Name = "OpenMenuButton";
			this.OpenMenuButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.OpenMenuButton.Size = new System.Drawing.Size(273, 26);
			this.OpenMenuButton.Text = "Відкрити";
			this.OpenMenuButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// SaveMenuButton
			// 
			this.SaveMenuButton.Enabled = false;
			this.SaveMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveMenuButton.Image")));
			this.SaveMenuButton.Name = "SaveMenuButton";
			this.SaveMenuButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.SaveMenuButton.Size = new System.Drawing.Size(273, 26);
			this.SaveMenuButton.Text = "Зберегти";
			this.SaveMenuButton.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// сохранитьКакToolStripMenuItem
			// 
			this.сохранитьКакToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьКакToolStripMenuItem.Image")));
			this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
			this.сохранитьКакToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
			this.сохранитьКакToolStripMenuItem.Text = "Зберегти як...";
			this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
			// 
			// таблицаToolStripMenuItem
			// 
			this.таблицаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRow,
            this.AddColumn,
            this.toolStripSeparator2,
            this.DeleteRow,
            this.DeleteColumn,
            this.toolStripSeparator3,
            this.ShowExpression,
            this.обновитьToolStripMenuItem});
			this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
			this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
			this.таблицаToolStripMenuItem.Text = "Таблиця";
			// 
			// AddRow
			// 
			this.AddRow.Name = "AddRow";
			this.AddRow.Size = new System.Drawing.Size(273, 26);
			this.AddRow.Text = "Додати строку";
			this.AddRow.Click += new System.EventHandler(this.AddRowToolStripMenuItem_Click);
			// 
			// AddColumn
			// 
			this.AddColumn.Name = "AddColumn";
			this.AddColumn.Size = new System.Drawing.Size(273, 26);
			this.AddColumn.Text = "Додати стовпчик";
			this.AddColumn.Click += new System.EventHandler(this.AddColumn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(270, 6);
			// 
			// DeleteRow
			// 
			this.DeleteRow.Name = "DeleteRow";
			this.DeleteRow.Size = new System.Drawing.Size(273, 26);
			this.DeleteRow.Text = "Видалити строку";
			this.DeleteRow.Click += new System.EventHandler(this.DeleteRow_Click);
			// 
			// DeleteColumn
			// 
			this.DeleteColumn.Name = "DeleteColumn";
			this.DeleteColumn.Size = new System.Drawing.Size(273, 26);
			this.DeleteColumn.Text = "Видалити стовпчик";
			this.DeleteColumn.Click += new System.EventHandler(this.DeleteColumn_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(270, 6);
			// 
			// ShowExpression
			// 
			this.ShowExpression.Name = "ShowExpression";
			this.ShowExpression.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.ShowExpression.Size = new System.Drawing.Size(273, 26);
			this.ShowExpression.Text = "Показати формули";
			this.ShowExpression.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
			// 
			// обновитьToolStripMenuItem
			// 
			this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
			this.обновитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
			this.обновитьToolStripMenuItem.Text = "Обновити";
			this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView1);
			this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1081, 584);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(1081, 612);
			this.toolStripContainer1.TabIndex = 3;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Cross;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridView1.Size = new System.Drawing.Size(1081, 584);
			this.dataGridView1.StandardTab = true;
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView1_CellBeginEdit);
			this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
			// 
			// допомогаToolStripMenuItem
			// 
			this.допомогаToolStripMenuItem.Name = "допомогаToolStripMenuItem";
			this.допомогаToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
			this.допомогаToolStripMenuItem.Text = "Опис дій";
			this.допомогаToolStripMenuItem.Click += new System.EventHandler(this.допомогаToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1081, 612);
			this.Controls.Add(this.toolStripContainer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.Text = "lab2_@Duilovskyi_Igor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuButton;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuButton;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStripMenuItem таблицаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AddRow;
		private System.Windows.Forms.ToolStripMenuItem AddColumn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem DeleteColumn;
		private System.Windows.Forms.ToolStripMenuItem DeleteRow;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ShowExpression;
		private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CreateMenuButton;
		private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem допомогаToolStripMenuItem;
	}
}

